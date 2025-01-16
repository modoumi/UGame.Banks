using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx;
using UGame.Banks.Service.Caching;
using Xxyy.Common;
using MySqlX.XDevAPI;
using Xxyy.Common.Caching;
using Microsoft.AspNetCore.Authorization.Policy;
using System.Security.Policy;
using UGame.Banks.Service;
using TinyFx.Extensions.RabbitMQ;
using UGame.Banks.Service.MQMsg;
using Xxyy.Banks.DAL;
using System.Collections.Concurrent;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using UGame.Banks.Letspay.Common;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Letspay.Req;
using UGame.Banks.Letspay.Resp;

namespace UGame.Banks.Letspay
{
    public class BankProxy
    {
        private HttpClientEx _client;
        private const string CLIENT_NAME = "banks.letspay";
        private const string host = "host";
        private const string key = "key";
        private const string mchId = "mchId";
        private const string payCallback = "payNotify";
        private const string cashCallback = "cashNotify";
        private const string queryHost = "queryHost";
        private LetsPayConfig _letspayConfig;
        private Sb_bankEO _bank;
        private const int MULTIPLE = 100;
        private BankErrorDCache _bankErrorDCache = new();
        private const string BANKID = "letspay";
        private static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
       
        public BankProxy():this(BANKID)
        {

        }
        public BankProxy(string bankId)
        {
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            _letspayConfig = new LetsPayConfig
            {
                host = _client.GetSettingValue<string>(host),
                key = _client.GetSettingValue<string>(key),
                mchId = _client.GetSettingValue<string>(mchId),
                payNotify = _client.GetSettingValue<string>(payCallback),
                cashNotify = _client.GetSettingValue<string>(cashCallback),
                queryHost=_client.GetSettingValue<string>(queryHost)
            };
            _bank = DbBankCacheUtil.GetBank(bankId);
        }





        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<LetsCommonPayDto> CommonPay(LetsCommonPayIpo ipo, LetsCommonPayDto dto)
        {
            //string payInURL = _letspayConfig.host + $"/apipay";
            //var amount = (long)(ipo.Amount.AToM(ipo.CurrencyId));
            var amount = Math.Truncate(100 * ipo.Amount.AToM(ipo.CurrencyId)) / 100;
            var request1 = new PayInRequest()
            {
                amount =amount.ToString(), //amount.ToString() + ".00",
                bankcode = "all",
                goods = new Goods()
                {
                    email = ipo.email,
                    name = ipo.name,
                    phone = ipo.phone
                }.ToString(),
                mchId = _letspayConfig.mchId,
                orderNo = ipo.OrderId,
                product = "baxipix",
                notifyUrl = _letspayConfig.payNotify,
                returnUrl = _letspayConfig.payNotify,
            };
            dto.TransMoney = amount;
            dto.OrderMoney = amount;
            request1.sign = SignHelper.GetSign(request1, _letspayConfig.key);

            //var client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            var resp = await this.PostForm<PayInRequest, PayInResponse,object>(_client, "apipay",request1);
            if (!resp.Success || resp.SuccessResult?.retCode == "FAIL")
            {
                await _bankErrorDCache.IncrError(BANKID);
                await MQUtil.PublishAsync(new BankErrorMsg { 
                 BankId=BANKID,
                 Channel=0,
                 Money=amount,
                 CurrencyId=ipo.CurrencyId,
                 ErrorMsg=resp.SuccessResult?.retCode,
                 OrderType=OrderTypeEnum.Charge,
                 Paytype=PayTypeEnum.Letspay,
                 UserId=ipo.UserId,
                 OrderId=ipo.OrderId,
                 RecDate=DateTime.UtcNow,
                 Remark=resp.SuccessResult
                });
                LogUtil.Error("代收信息出错!resultstring:" + resp.ResultString);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.ResultString ?? "代收信息出错！");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID,0);
            }
            dto.code = resp.SuccessResult.code;
            dto.Meta = resp.SuccessResult;
            dto.OperatorSuccess = true;
            dto.OrderId = resp.SuccessResult.orderNo;
            dto.BankOrderId = resp.SuccessResult.platOrder;
            return dto;
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<LetsProxyPayDto> ProxyPay(LetsProxyPayIpo ipo, LetsProxyPayDto dto)
        {
            var amount = Math.Truncate(100 * (ipo.Amount-ipo.UserFeeAmount).AToM(ipo.CurrencyId)) / 100;
            var request3 = new PayOutRequest()
            {
                type = "api",
                amount = amount.ToString(),
                accountName = ipo.accountName,
                mchId = _letspayConfig.mchId,
                accountNo = ipo.accountNo,
                bankCode = ipo.bankCode,
                mchTransNo = ipo.OrderId,
                remarkInfo = new RemarkInfo()
                {
                    email = ipo.email,
                    phone = ipo.phone,
                    mode = "pix",
                    cpf = (!string.IsNullOrWhiteSpace(ipo.taxId))?ipo.taxId: ipo.cpf
                }.ToString(),
                notifyUrl = _letspayConfig.cashNotify,
            };
            dto.TransMoney = amount;
            dto.OrderMoney = amount;
            request3.sign = SignHelper.GetSign(request3, _letspayConfig.key);
            //var client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            var resp = await PostForm<PayOutRequest, PayOutResponse, object>(_client, "apitrans", request3);
            //var resp = await http_Client.postForm<PayOutRequest, PayOutResponse>(payoutURL, request3);
            //Console.WriteLine(resp);
            if (!resp.Success || resp.SuccessResult?.retCode == "FAIL"||resp.SuccessResult?.status=="3")
            {
                await _bankErrorDCache.IncrError(BANKID);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = BANKID,
                    Channel = 0,
                    Money = amount,
                    CurrencyId=ipo.CurrencyId,
                    ErrorMsg = resp.SuccessResult?.retCode,
                    OrderType = OrderTypeEnum.Draw,
                    Paytype = PayTypeEnum.Letspay,
                    UserId = ipo.UserId,
                    OrderId = ipo.OrderId,
                    RecDate = DateTime.UtcNow,
                    Remark = resp.SuccessResult
                });
                LogUtil.Error("代付信息出错!resultstring:{0}",SerializerUtil.SerializeJsonNet(resp));
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.ResultString ?? $"代付出错");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID,0);
            }

            var userDCache =await GlobalUserDCache.Create(ipo.UserId);
            var lastCashDate = await userDCache.GetLastCashDateAsync();
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                dto.IsFirstCashOfDay = true;
                await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
            }

            //dto.Status = resp.data.status;
            dto.Message = resp.SuccessResult.retMsg;
            dto.Meta = resp.SuccessResult;
            dto.OrderId = resp.SuccessResult.mchTransNo;
            dto.BankOrderId = resp.SuccessResult.platOrder;
            dto.OperatorSuccess = true;
            //dto.TransMoney = amount;
            return dto;
        }


        public async Task<QueryPayOrderResponse> QueryPayOrder(QueryPayOrderIpo ipo)
        {
            var request = new QueryPayOrderRequest()
            {
                mchId = _letspayConfig.mchId,
                orderNo = ipo.OrderId
            };
            request.sign = SignHelper.GetSign(request, _letspayConfig.key);

            var httpClientConfig = new HttpClientConfig
            {
                BaseAddress = _letspayConfig.queryHost
            };

            var client = _clientDict.GetOrAdd("banks.letspay.query", (k) => 
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _letspayConfig.queryHost
                });
            });
            var rsp = await PostForm<QueryPayOrderRequest,QueryPayOrderResponse, object>(client, "qpayorder",request);

            if (!rsp.Success || rsp.SuccessResult?.retCode == "FAIL" || rsp.SuccessResult?.status == 5)
            {
                LogUtil.Info("代收订单查询失败!resultstring:{0}", SerializerUtil.SerializeJsonNet(rsp));
            }
            return rsp.SuccessResult;
        }

        public async Task<QueryTransOrderResponse> QueryTransOrder(QueryTransOrderIpo ipo)
        {
            var request = new QueryTransOrderRequest()
            {
                mchId = _letspayConfig.mchId,
                mchTransNo = ipo.OrderId
            };
            request.sign = SignHelper.GetSign(request, _letspayConfig.key);


            var client = _clientDict.GetOrAdd("banks.letspay.query", (k) =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _letspayConfig.queryHost
                });
            });

            var resp = await PostForm<QueryTransOrderRequest, QueryTransOrderResponse,object>(client,"qtransorder", request);
            return resp.SuccessResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TRequest">请求参数对象</typeparam>
        /// <typeparam name="TSuccess"></typeparam>
        /// <typeparam name="TError"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<HttpResponseResult<TSuccess, TError>> PostForm<TRequest,TSuccess, TError>(HttpClientEx client,string url,TRequest request)
        {
            var rsp = await client.CreateAgent()
           .AddUrl(url)
           .AddParameter(request)
           .BuildFormUrlEncodedContent()
           .PostAsync<TSuccess, TError>();
            return rsp;
        }

    }
}