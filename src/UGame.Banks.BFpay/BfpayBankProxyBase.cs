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
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.MQMsg;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;
using TinyFx.Extensions.AutoMapper;
using Newtonsoft.Json;
using NetTaste;
using Org.BouncyCastle.Ocsp;
using UGame.Banks.BFpay.Common;
using UGame.Banks.BFpay.IpoDto;
using UGame.Banks.BFpay.Proxy;

namespace UGame.Banks.BFpay
{
    public abstract class BfpayBankProxyBase
    {
        protected HttpClientEx _client;
        protected BfpayConfig _bankConfig;
        protected Sb_bankEO _bank;
        //protected const int MULTIPLE = 100;
        protected abstract int MULTIPLE { get; set; }
        protected BankErrorDCache _bankErrorDCache = new();
        protected const string BASEBANKID = "bfpay";
        protected static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
        protected string _bankId;
        public BfpayBankProxyBase(string bankId)
        {
            _bankId = bankId;
            _bank = DbBankCacheUtil.GetBank(bankId);
            _bankConfig = SerializerUtil.DeserializeJsonNet<BfpayConfig>(_bank.BankConfig);
            _client = _clientDict.GetOrAdd("banks.bfpay", k =>
            {
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = _bankConfig.BaseAddress,
                    Name = k
                });
            });
        }

        protected abstract (string bankCode, string identityNo) GetPayInRequestParam(BfpayPayIpo ipo);



        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<BfpayPayDto> CommonPay(BfpayPayIpo ipo, BfpayPayDto dto)
        {
            var amount = (int)(MULTIPLE * ipo.Amount.AToM(ipo.CurrencyId));//分
            var payInRequestParam = GetPayInRequestParam(ipo);
            var createDate = DateTime.UtcNow.ToLocalTimeByCountryId(ipo.CountryId);

            BfPayReq payRequest = new BfPayReq()
            {
                body = new BfPayReq.Body()
                {
                    Amount = amount.ToString(),
                    CallBackUrl = "",
                    CurrencyType = ipo.CurrencyId,
                    Desc = ipo.AppId,
                    Email = ipo.Email,
                    ExpireTime = createDate.AddHours(3).ToString("yyyyMMddHHmmss"),
                    Goods = ipo.UserId,
                    Ip = ipo.UserIp,
                    Name = ipo.Name,
                    NotifyUrl = _bankConfig.PayNotify,
                    OrderId = ipo.OrderId,
                    Operator = "",
                    OrderTime = createDate.ToString("yyyyMMddHHmmss"),
                    Param = "",
                    //Phone = ipo.Phone,
                    //UserId = ipo.UserId,
                },
                head = new BfPayReq.Head() {MchtId= _bankConfig.PartnerId }
            };



            dto.TransMoney = amount;//分
            dto.OrderMoney = Math.Truncate(dto.TransMoney / MULTIPLE * 100) / 100;//元,保留2位小数
            payRequest.sign = SignHelper.GetSign(payRequest.body, _bankConfig.PayKey);
            //urlencode
            //payRequest.notifyUrl = HttpUtility.UrlEncode(payRequest.notifyUrl);
            //payRequest.subject = HttpUtility.UrlEncode(payRequest.subject);
            //payRequest.body = HttpUtility.UrlEncode(payRequest.body);
            //payRequest.extra = HttpUtility.UrlEncode(payRequest.extra);
            var resp = await this.PostForm<BfPayReq, BfPayRsp, object>(_client, "/gateway/api/commPay", payRequest);
            if (resp.SuccessResult?.head.RespCode!=BfpayResponseCodes.Rs_Success)
            {
                await _bankErrorDCache.IncrError(BASEBANKID);
                string msg = "调用bfpay代收出错！";
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
                    Paytype = PayTypeEnum.Bfpay,
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
            dto.payUrl = resp.SuccessResult.body.PayUrl;
            dto.Meta = resp.SuccessResult;
            dto.OperatorSuccess = true;
            //dto.OrderId = resp.SuccessResult.orderNo;
            dto.BankOrderId = resp.SuccessResult.body.TradeId;
            return dto;
        }


        /// <summary>
        /// 计算代付手续费
        /// </summary>
        /// <param name="payMoney"></param>
        /// <returns></returns>
        protected abstract decimal CalcCashFee(decimal payMoney);

        protected virtual int GetReceiptMode(BfpayCashIpo ipo)
        {
            return 0;
        }
        protected virtual string GetAccountExtra1(BfpayCashIpo ipo)
        {
            return null;
        }
        protected virtual string GetAccountExtra2(BfpayCashIpo ipo)
        {
            return null;
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<BfpayCashDto> ProxyPay(BfpayCashIpo ipo, BfpayCashDto dto)
        {
            var cashMoney = (ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId);
            dto.Fee = CalcCashFee(cashMoney);
            var transAmount = (int)((cashMoney - dto.Fee) * MULTIPLE);
            var cashRequest = new CashReq()
            {
                head = new CashReq.Head() { MchtId = _bankConfig.PartnerId,Biz= "df104" },
            };

            var body = new CashReq.Body();
            body.BatchOrderNo = ipo.OrderId;
            body.TotalNum = 1;
            body.TotalAmount = transAmount.ToString();
            body.NotifyUrl = _bankConfig.CashNotify;
            body.CurrencyType = ipo.CurrencyId;
            
            body.Detail = new CashReq.Detail[] { new CashReq.Detail(){
                Seq="1",
                Amount=transAmount.ToString(),
                AccType="0",
                                                        BankCardName=ipo.bankCardName,
                                        BankCardNo=ipo.bankCardNo,
                                        CertId=ipo.certId,
                                        CertType=ipo.certType+"",
            }
            };

            dto.TransMoney = transAmount;
            dto.OrderMoney = Math.Truncate(dto.TransMoney / MULTIPLE * 100) / 100;//元，保留2位小数

            string json = JsonConvert.SerializeObject(body);

            string sign = RSAUtils.encrypt(json, _bankConfig.PublicKey);
            cashRequest.body = HttpUtility.UrlEncode(sign);

            var resp = await PostForm<CashReq, CashRsp, object>(_client, "/df/gateway/proxyrequest", cashRequest);
            if (!resp.Success || resp.SuccessResult?.head.respCode != "0000")
            {
                await _bankErrorDCache.IncrError(BASEBANKID);
                string msg = "调用bfpay代付出错！";
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
                    Paytype = PayTypeEnum.Bfpay,
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
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, msg);
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
            ProxyPayRespBody obj = null;
            obj = JsonConvert.DeserializeObject<ProxyPayRespBody>(RSAUtils.decrypt(HttpUtility.UrlDecode(resp.SuccessResult.body?.ToString()), _bankConfig.PrivateKey));


            //dto.Message = resp.SuccessResult.retMsg;
            dto.Meta = obj;
            dto.BankOrderId = obj.tradeId;
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
            // var queryString =string.Join("&", SignHelper.GetPropValues(request));
            // var rsp = await client.CreateAgent()
            //.AddUrl(url+"?"+ queryString)
            ////.AddParameter(request)
            //.PostAsync<TSuccess, TError>();
            // //.BuildFormUrlEncodedContent()
            // //.PostAsync<TSuccess, TError>();

            var opts = SerializerUtil.GetJsonOptions();
            opts.WriteIndented = false;
            var json = SerializerUtil.SerializeJson(request, opts);

            var rsp = await _client.CreateAgent()
   .AddUrl(url)
   .BuildJsonContent(json)
   .PostAsync<TSuccess, TError>();

            return rsp;
        }
    }
}
