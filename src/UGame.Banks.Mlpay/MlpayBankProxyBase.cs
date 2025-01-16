using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using MySqlX.XDevAPI;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Net;
using UGame.Banks.Mlpay.Common;
using UGame.Banks.Mlpay.IpoDto;
using UGame.Banks.Mlpay.Proxy;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.MQMsg;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;
using static UGame.Banks.Mlpay.Proxy.PayReq;

namespace UGame.Banks.Mlpay
{
    public abstract class MlpayBankProxyBase
    {
        protected HttpClientEx _client;
        protected MlpayConfig _bankConfig;
        protected Sb_bankEO _bank;
        //protected const int MULTIPLE = 100;
        protected abstract int MULTIPLE { get; set; }
        protected BankErrorDCache _bankErrorDCache = new();
        protected const string BASEBANKID = "mlpay";
        protected static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
        protected string _bankId;
        public MlpayBankProxyBase(string bankId)
        {
            _bankId = bankId;
            _bank = DbBankCacheUtil.GetBank(bankId);
            _bankConfig = SerializerUtil.DeserializeJsonNet<MlpayConfig>(_bank.BankConfig);
            _client = _clientDict.GetOrAdd("banks.mlpay", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _bankConfig.BaseAddress,
                    Name = k
                });
            });
        }

        protected abstract (string bankCode, string identityNo) GetPayInRequestParam(MlpayPayIpo ipo);



        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<MlpayPayDto> CommonPay(MlpayPayIpo ipo, MlpayPayDto dto)
        {
            var amount = (int)(MULTIPLE * ipo.Amount.AToM(ipo.CurrencyId));//分
            var payInRequestParam = GetPayInRequestParam(ipo);
            var payRequest = new PayReq()
            {
                partnerId = _bankConfig.PartnerId,
                applicationId = _bankConfig.ApplicationId,
                payWay = _bankConfig.PayWay,
                partnerOrderNo = ipo.OrderId,
                amount = amount,
                currency = ipo.CurrencyId,
                name = ipo.Name,
                gameId = ipo.UserId,
                clientIp = ipo.UserIp,
                notifyUrl = _bankConfig.PayNotify,
                subject = ipo.OrderId,
                body = ipo.OrderId,
                version = _bankConfig.Version,
                identityNo = payInRequestParam.identityNo,
                bankCode = payInRequestParam.bankCode,
                sign = "",
                extra = new PayReq.ExtraModel
                {
                    userEmail = ipo.Email,
                    userName = ipo.Name,
                    userPhone = ipo.Phone
                }.ToString()
            };
            dto.TransMoney = amount;//分
            dto.OrderMoney = Math.Truncate(dto.TransMoney / MULTIPLE * 100) / 100;//元,保留2位小数
            payRequest.sign = SignHelper.GetSign(payRequest, _bankConfig.PayKey);
            //urlencode
            payRequest.notifyUrl = HttpUtility.UrlEncode(payRequest.notifyUrl);
            payRequest.subject = HttpUtility.UrlEncode(payRequest.subject);
            payRequest.body = HttpUtility.UrlEncode(payRequest.body);
            payRequest.extra = HttpUtility.UrlEncode(payRequest.extra);
            var resp = await this.PostForm<PayReq, PayRsp, object>(_client, "/pay/order/v2", payRequest);
            if (resp.SuccessResult?.Code!=MlpayResponseCodes.Rs_Success || string.IsNullOrWhiteSpace(resp.SuccessResult?.Data?.PayUrl))
            {
                await _bankErrorDCache.IncrError(BASEBANKID);
                string msg = "调用mlpay代收出错！";
                var reqJson = SerializerUtil.SerializeJsonNet(ipo);
                var rspJson = SerializerUtil.SerializeJsonNet(resp);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = _bankId,
                    Channel = 0,
                    Money = dto.OrderMoney,
                    CurrencyId = ipo.CurrencyId,
                    ErrorMsg = $"{msg}req:{reqJson},rsp:{rspJson}",
                    OrderType = OrderTypeEnum.Charge,
                    Paytype = PayTypeEnum.Mlpay,
                    UserId = ipo.UserId,
                    OrderId = ipo.OrderId,
                    RecDate = DateTime.UtcNow,
                    Remark = resp.SuccessResult
                });
                LogUtil.GetContextLogger()
                    .AddField("client.bankid", _bankId)
                    .AddField("client.basebankid", BASEBANKID)
                    .AddField("client.req", reqJson)
                    .AddField("client.rsp", rspJson)
                    .SetLevel(resp.Success ? Microsoft.Extensions.Logging.LogLevel.Warning : Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage(msg);
                if (ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)
                {
                    msg += $"req:{reqJson},rsp:{rspJson}";
                }
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, msg);
            }
            else
            {
                await _bankErrorDCache.SetAsync(BASEBANKID, 0);
            }
            dto.code = null;
            dto.payUrl = resp.SuccessResult.Data.PayUrl;
            dto.Meta = resp.SuccessResult;
            dto.OperatorSuccess = true;
            //dto.OrderId = resp.SuccessResult.orderNo;
            dto.BankOrderId = resp.SuccessResult.Data.OrderNo;
            return dto;
        }


        /// <summary>
        /// 计算代付手续费
        /// </summary>
        /// <param name="payMoney"></param>
        /// <returns></returns>
        protected abstract decimal CalcCashFee(decimal payMoney);

        protected virtual int GetReceiptMode(MlpayCashIpo ipo)
        {
            return 0;
        }
        protected virtual string GetAccountExtra1(MlpayCashIpo ipo)
        {
            return null;
        }
        protected virtual string GetAccountExtra2(MlpayCashIpo ipo)
        {
            return null;
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<MlpayCashDto> ProxyPay(MlpayCashIpo ipo, MlpayCashDto dto)
        {
            var cashMoney = (ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId);
            dto.Fee = CalcCashFee(cashMoney);
            var transAmount = (int)((cashMoney - dto.Fee) * MULTIPLE);
            var cashRequest = new CashReq()
            {
                partnerId = _bankConfig.PartnerId,
                partnerWithdrawNo = ipo.OrderId,
                amount = transAmount,
                currency = ipo.CurrencyId,
                gameId = ipo.UserId,
                notifyUrl = _bankConfig.CashNotify,
                receiptMode = GetReceiptMode(ipo),
                accountNumber = ipo.AccountNo,
                accountName = ipo.AccountName,
                accountPhone = ipo.Phone,
                accountEmail = ipo.Email,
                accountExtra1 = GetAccountExtra1(ipo),
                accountExtra2 = GetAccountExtra2(ipo),
                identityNo = ipo.TaxId,
                version = _bankConfig.Version,
                sign = ""
            };
            dto.TransMoney = transAmount;
            dto.OrderMoney = Math.Truncate(dto.TransMoney / MULTIPLE * 100) / 100;//元，保留2位小数
            cashRequest.sign = SignHelper.GetSign(cashRequest, _bankConfig.CashKey);
            var resp = await PostForm<CashReq, CashRsp, object>(_client, "/pay/withdraw", cashRequest);
            if (!resp.Success ||resp.SuccessResult?.Code!=MlpayResponseCodes.Rs_Success)
            {
                await _bankErrorDCache.IncrError(BASEBANKID);
                string msg = "调用mlpay代付出错！";
                var reqJson = SerializerUtil.SerializeJsonNet(ipo);
                var rspJson = SerializerUtil.SerializeJsonNet(resp);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = _bankId,
                    Channel = 0,
                    Money = cashMoney,
                    CurrencyId = ipo.CurrencyId,
                    ErrorMsg = $"{msg}req:{reqJson},rsp:{rspJson}",
                    OrderType = OrderTypeEnum.Draw,
                    Paytype = PayTypeEnum.Mlpay,
                    UserId = ipo.UserId,
                    OrderId = ipo.OrderId,
                    RecDate = DateTime.UtcNow,
                    Remark = resp.SuccessResult
                });
                LogUtil.GetContextLogger()
                    .AddField("client.bankid", _bankId)
                    .AddField("client.basebankid", BASEBANKID)
                    .AddField("client.req", reqJson)
                    .AddField("client.rsp", rspJson)
                    .SetLevel(resp.Success ? Microsoft.Extensions.Logging.LogLevel.Warning : Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage(msg);
                if (ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)
                {
                    msg += $"req:{reqJson},rsp:{rspJson}";
                }
                //LogUtil.Error("代付信息出错!resultstring:{0}", SerializerUtil.SerializeJsonNet(resp));
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR,msg);
            }
            else
            {
                await _bankErrorDCache.SetAsync(BASEBANKID, 0);
            }

            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            var lastCashDate = await userDCache.GetLastCashDateAsync();
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                dto.IsFirstCashOfDay = true;
                await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
            }

            //dto.Message = resp.SuccessResult.retMsg;
            dto.Meta = resp.SuccessResult;
            dto.BankOrderId = resp.SuccessResult.Data;
            dto.OperatorSuccess = true;
            return dto;
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
            var queryString =string.Join("&", SignHelper.GetPropValues(request));
            var rsp = await client.CreateAgent()
           .AddUrl(url+"?"+ queryString)
           //.AddParameter(request)
           .GetAsync<TSuccess, TError>();
            //.BuildFormUrlEncodedContent()
            //.PostAsync<TSuccess, TError>();
            return rsp;
        }
    }
}
