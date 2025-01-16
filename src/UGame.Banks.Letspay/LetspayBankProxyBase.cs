using Grpc.Core;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Net;
using UGame.Banks.Letspay.Common;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Letspay.Req;
using UGame.Banks.Letspay.Resp;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.MQMsg;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Banks.Letspay
{
    public abstract class LetspayBankProxyBase
    {
        protected HttpClientEx _client;
        protected LetsPayConfig _letspayConfig;
        protected Sb_bankEO _bank;
        protected const int MULTIPLE = 100;
        protected BankErrorDCache _bankErrorDCache = new();
        protected const string BASEBANKID = "letspay";
        protected static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
        protected const string ISPRODUCTION = "IsProduction";
        protected string _bankId;
        public LetspayBankProxyBase(string bankId)
        {
            _bankId= bankId;
            _bank = DbBankCacheUtil.GetBank(bankId);
            _letspayConfig = _bank.BankConfig.ToSafeDeserialize<LetsPayConfig>();
            _client = _clientDict.GetOrAdd("banks.letspay", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _letspayConfig.host,
                    Name = k
                });
            });
        }

        protected abstract (string bankCode,string product) GetPayInRequestParam(LetsCommonPayIpo ipo);

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<LetsCommonPayDto> CommonPay(LetsCommonPayIpo ipo, LetsCommonPayDto dto)
        {
            var amount = Math.Truncate(100 * ipo.Amount.AToM(ipo.CurrencyId)) / 100;
            var payInRequestParam = GetPayInRequestParam(ipo);
            var request1 = new PayInRequest()
            {
                amount = amount.ToString(),
                bankcode = payInRequestParam.bankCode,
                goods = new Goods()
                {
                    email = ipo.email,
                    name = ipo.name,
                    phone = ipo.phone
                }.ToString(),
                mchId = _letspayConfig.mchId,
                orderNo = ipo.OrderId,
                product = payInRequestParam.product,
                notifyUrl = _letspayConfig.payNotify,
                returnUrl = _letspayConfig.payNotify,
            };
            dto.TransMoney = amount;
            dto.OrderMoney = amount;
            request1.sign = SignHelper.GetSign(request1, _letspayConfig.key);
            var resp = await this.PostForm<PayInRequest, PayInResponse, object>(_client, "apipay", request1);
            if (!resp.Success || resp.SuccessResult?.retCode == "FAIL")
            {
                await _bankErrorDCache.IncrError(BASEBANKID);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = _bankId,
                    Channel = 0,
                    Money = amount,
                    CurrencyId = ipo.CurrencyId,
                    ErrorMsg = resp.SuccessResult?.retCode,
                    OrderType = OrderTypeEnum.Charge,
                    Paytype = PayTypeEnum.Letspay,
                    UserId = ipo.UserId,
                    OrderId = ipo.OrderId,
                    RecDate = DateTime.UtcNow,
                    Remark = resp.SuccessResult
                });
                LogUtil.Error("代收信息出错!resultstring:" + resp.ResultString);
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, resp.ResultString ?? "代收信息出错！");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BASEBANKID, 0);
            }
            dto.code = resp.SuccessResult.code;
            dto.payUrl = resp.SuccessResult.payUrl;
            dto.Meta = resp.SuccessResult;
            dto.OperatorSuccess = true;
            dto.OrderId = resp.SuccessResult.orderNo;
            dto.BankOrderId = resp.SuccessResult.platOrder;
            return dto;
        }

        /// <summary>
        /// 计算代付手续费
        /// </summary>
        /// <param name="payMoney"></param>
        /// <returns></returns>
        public abstract decimal CalcCashFee(decimal payMoney);

        protected abstract string GetRemarkInfo(LetsProxyPayIpo ipo);
        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<LetsProxyPayDto> ProxyPay(LetsProxyPayIpo ipo, LetsProxyPayDto dto)
        {
            // var cashMoney = Math.Truncate(100 * (ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId)) / 100;
            var cashMoney = (ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId);
            if (ipo.UserFeeAmount == 0)
            {
                cashMoney=cashMoney - CalcCashFee(cashMoney);
            }
            cashMoney = Math.Truncate(cashMoney * 100) / 100;
            //dto.Fee = CalcCashFee(cashMoney);
            //cashMoney = Math.Truncate((cashMoney - dto.Fee)*100)/100;
            var request3 = new PayOutRequest()
            {
                type = "api",
                amount = cashMoney.ToString(),
                accountName = ipo.accountName,
                mchId = _letspayConfig.mchId,
                accountNo = ipo.accountNo,
                bankCode = ipo.bankCode,
                mchTransNo = ipo.OrderId,
                remarkInfo = GetRemarkInfo(ipo),
                notifyUrl = _letspayConfig.cashNotify,
            };
            dto.TransMoney = cashMoney;
            dto.OrderMoney = cashMoney;
            request3.sign = SignHelper.GetSign(request3, _letspayConfig.key);
            var resp = await PostForm<PayOutRequest, PayOutResponse, object>(_client, "apitrans", request3);
            if (!resp.Success || resp.SuccessResult?.retCode == "FAIL" || resp.SuccessResult?.status == "3")
            {
                await _bankErrorDCache.IncrError(BASEBANKID);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = _bankId,
                    Channel = 0,
                    Money = cashMoney,
                    CurrencyId = ipo.CurrencyId,
                    ErrorMsg = resp.SuccessResult?.retCode,
                    OrderType = OrderTypeEnum.Draw,
                    Paytype = PayTypeEnum.Letspay,
                    UserId = ipo.UserId,
                    OrderId = ipo.OrderId,
                    RecDate = DateTime.UtcNow,
                    Remark = resp.SuccessResult
                });
                LogUtil.Error("代付信息出错!resultstring:{0}", SerializerUtil.SerializeJsonNet(resp));
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, resp.ResultString ?? $"代付出错");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BASEBANKID, 0);
            }

            var userDCache =await GlobalUserDCache.Create(ipo.UserId);
            var lastCashDate = await userDCache.GetLastCashDateAsync();
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                dto.IsFirstCashOfDay = true;
                await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
            }

            dto.Message = resp.SuccessResult.retMsg;
            dto.Meta = resp.SuccessResult;
            dto.OrderId = resp.SuccessResult.mchTransNo;
            dto.BankOrderId = resp.SuccessResult.platOrder;
            dto.OperatorSuccess = true;
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
            var rsp = await PostForm<QueryPayOrderRequest, QueryPayOrderResponse, object>(client, "qpayorder", request);

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

            var resp = await PostForm<QueryTransOrderRequest, QueryTransOrderResponse, object>(client, "qtransorder", request);
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
        private async Task<HttpResponseResult<TSuccess, TError>> PostForm<TRequest, TSuccess, TError>(HttpClientEx client, string url, TRequest request)
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
