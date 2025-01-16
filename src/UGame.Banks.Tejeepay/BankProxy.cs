using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Text;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.MQMsg;
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Model;
using UGame.Banks.Tejeepay.Req;
using UGame.Banks.Tejeepay.Resp;
using Xxyy.Banks.DAL;
using UGame.Banks.Tejeepay.Common;
using Xxyy.Common;
using Xxyy.Common.Caching;


namespace UGame.Banks.Tejeepay
{
    public class BankProxy
    {
        private HttpClientEx _client;
        private const string CLIENT_NAME = "banks.tejeepay";
        private const string merchantId = "merchantId";
        private const string merchantKey = "merchantKey";
        private const string publicKey = "publicKey";
        private const string privateKey = "privateKey";
        private const string host = "host";
        private const string payNotify = "payNotify";
        private const string payCallback = "payCallback";
        private const string cashNotify = "cashNotify";
        private const string currencyType = "BRL";
        private TejeepayConfig _tejeepayConfig;
        private Sb_bankEO _bank;
        private const int MULTIPLE = 100;
        private BankErrorDCache _bankErroCountDCache = new();
        private const string BANKID = "tejeepay";
        public BankProxy() : this(BANKID)
        {

        }
        public BankProxy(string bankId)
        {
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            var tmpHost = _client.GetSettingValue<string>(host);
            _tejeepayConfig = new TejeepayConfig
            {
                merchantId = _client.GetSettingValue<string>(merchantId),
                merchantKey = _client.GetSettingValue<string>(merchantKey),
                publicKey = _client.GetSettingValue<string>(publicKey),
                privateKey = _client.GetSettingValue<string>(privateKey),
                host = tmpHost,
                payNotify = tmpHost + _client.GetSettingValue<string>(payNotify),
                payCallback = tmpHost + _client.GetSettingValue<string>(payCallback),
                cashNotify = tmpHost + _client.GetSettingValue<string>(cashNotify),
            };
            _bank = DbBankCacheUtil.GetBank(bankId);
        }

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<TejeeCommonPayDto> CommonPay(TejeeCommonPayIpo ipo, TejeeCommonPayDto dto)
        {
            string url = "/gateway/api/commPay";
            var payMoney = ipo.Amount.AToM(ipo.CurrencyId);
            var amount = (long)(payMoney * MULTIPLE);
            //var amount = ipo.Amount;//分
            var request = new CommonPayRequest()
            {
                head = new CommonPayHeader()
                {
                    mchtId = _tejeepayConfig.merchantId,
                    biz = System.Enum.GetName(typeof(BizInEnum), ipo.BizEnum), // "bq102",
                    version = 20
                },
                body = new CommonPayBody()
                {
                    amount = amount,
                    callBackUrl = _tejeepayConfig.payCallback, // "http://agqyvw.natappfree.cc/home/callback3",
                    notifyUrl = _tejeepayConfig.payNotify, // "http://agqyvw.natappfree.cc/home/notify3",
                    currencyType = ipo.CurrencyId,
                    desc = ipo.OrderId + " desc ", //orderId1
                    goods = ipo.OrderId + " goods ",//orderId1
                    ip = ipo.ClientIp, //"127.0.0.1",
                    orderId = ipo.OrderId, //"YWS190722070956320",
                    orderTime = DateTime.UtcNow.ToString("yyyyMMddHHmmss"),//"20190722130005",
                    //name = ipo.Name ?? string.Empty,
                    //email = ipo.Email ?? string.Empty,
                    //phone = ipo.Phone ?? string.Empty,
                }
            };
            dto.TransMoney = amount;
            dto.OrderMoney = Math.Truncate(100 * payMoney) / 100;
            request.sign = SighHelper.GetSign(request.body, _tejeepayConfig.merchantKey);
            var resp = await PostJson<CommonPayResponse, CommonPayResponse>(url, request);
            //Console.WriteLine(resp);
            if (!resp.Success || resp.SuccessResult.head.respCode != "0000")
            {
                await _bankErroCountDCache.IncrError(BANKID);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = BANKID,
                    Channel = 0,
                    Money = dto.OrderMoney,
                    CurrencyId = ipo.CurrencyId,
                    ErrorMsg = resp.SuccessResult?.head?.respMsg,
                    OrderType = OrderTypeEnum.Charge,
                    Paytype = PayTypeEnum.Tejeepay,
                    UserId = ipo.UserId,
                    OrderId = ipo.OrderId,
                    RecDate = DateTime.UtcNow,
                    Remark = resp.SuccessResult
                });
                LogUtil.Error("代收信息出错!resultstring:" + resp.ResultString);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "代收信息出错！");
            }
            else
            {
                await _bankErroCountDCache.SetAsync(BANKID, 0);
            }
            dto.mchtId = resp.SuccessResult.body.mchtId;
            dto.payUrl = resp.SuccessResult.body.payUrl;
            dto.tradeId = resp.SuccessResult.body.tradeId;
            dto.Meta = resp.SuccessResult.body;
            dto.OrderId = ipo.OrderId;
            dto.BankOrderId = resp.SuccessResult.body.tradeId;
            dto.OperatorSuccess = true;
            dto.TransMoney = amount;
            return dto;
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<TejeeProxyPayDto> ProxyPay(TejeeProxyPayIpo ipo, TejeeProxyPayDto dto)
        {
            string url = "/df/gateway/proxyrequest";
            //var payMoney = ipo.Amount.AToM(ipo.CurrencyId);
            var payMoney = (ipo.Amount-ipo.UserFeeAmount).AToM(ipo.CurrencyId);
            var amount = (long)(payMoney * MULTIPLE);
            var request = new ProxyPayRequest()
            {
                head = new ProxyPayHeader()
                {
                    mchtId = _tejeepayConfig.merchantId,
                    biz = System.Enum.GetName(typeof(BizOutEnum), ipo.BizEnum),
                    version = 20
                },
                body = new ProxyPayBody()
                {
                    appId = _tejeepayConfig.merchantId,
                    batchOrderNo = ipo.OrderId,
                    currencyType = ipo.CurrencyId,
                    notifyUrl = _tejeepayConfig.cashNotify,
                    detail = new List<ProxyPayDetail>() {
                                        new  ProxyPayDetail(){
                                        accType=0,
                                        amount=amount,
                                        bankCardName=ipo.bankCardName,
                                        bankCardNo=ipo.bankCardNo,
                                        certId=ipo.certId,
                                        certType=ipo.certType,
                                        seq= "0",
                                        bankCardType=ipo.bankCardType,
                                        bankCode=ipo.bankCode,
                                        creditCvv=ipo.creditCvv??string.Empty,
                                        creditValid=ipo.creditValid??string.Empty,
                                        //mobile=ipo.mobile??string.Empty,
                                        //email=ipo.email??string.Empty,
                                        //bankName=ipo.bankName??string.Empty
                                    }
                            }
                }
            };
            string json = JsonConvert.SerializeObject(request.body);
            LogUtil.Info($"请求tejeepay接口url:{url},Header-MerchantId:{_tejeepayConfig.merchantId}，OrderId:{ipo.OrderId}");
            string sign = RSAUtils.encrypt(json, _tejeepayConfig.publicKey);
            request.body = HttpUtility.UrlEncode(sign);
            dto.TransMoney = amount;
            dto.OrderMoney = Math.Truncate(100 * payMoney) / 100;
            ProxyPayRespBody obj = null;
            if (ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)
            {
                obj = new ProxyPayRespBody
                {
                    status = "SUCCESS",
                    batchOrderNo = ipo.OrderId,
                    desc = "",
                    mchtId = "2000713000197336",
                    tradeId = ObjectId.NewId()
                };
            }
            else
            {
                var resp = await PostJson<ProxyPayResponse, ProxyPayResponse>(url, request);
                // Console.WriteLine(resp);
                if (!resp.Success || resp.SuccessResult.head.respCode != "0000")
                {
                    await _bankErroCountDCache.IncrError(BANKID);
                    await MQUtil.PublishAsync(new BankErrorMsg
                    {
                        BankId = BANKID,
                        Channel = 0,
                        Money = dto.OrderMoney,
                        CurrencyId = ipo.CurrencyId,
                        ErrorMsg = resp.SuccessResult?.head?.respMsg,
                        OrderType = OrderTypeEnum.Draw,
                        Paytype = PayTypeEnum.Tejeepay,
                        UserId = ipo.UserId,
                        OrderId = ipo.OrderId,
                        RecDate = DateTime.UtcNow,
                        Remark = resp.SuccessResult
                    });
                    LogUtil.Error($"代付信息出错! OrderId:{ipo.OrderId}，resultstring:" + resp.ResultString);
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "代付信息出错！");
                }
                else
                {
                    await _bankErroCountDCache.SetAsync(BANKID, 0);
                }

                var userDCache = await GlobalUserDCache.Create(ipo.UserId);
                var lastCashDate = await userDCache.GetLastCashDateAsync();
                if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
                {
                    dto.IsFirstCashOfDay = true;
                    await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
                }

                string body = RSAUtils.decrypt(HttpUtility.UrlDecode(resp.SuccessResult.body?.ToString()), _tejeepayConfig.privateKey);
                obj = JsonConvert.DeserializeObject<ProxyPayRespBody>(body);
            }


            dto.Status = obj.status;
            dto.tradeId = obj.tradeId;
            dto.batchOrderNo = obj.batchOrderNo;
            dto.mchtId = obj.mchtId;

            dto.Meta = obj;
            dto.OrderId = ipo.OrderId;
            dto.BankOrderId = obj?.tradeId;
            dto.OperatorSuccess = true;
            dto.TransMoney = amount;
            return dto;
        }

        /// <summary>
        /// 代收查询
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseResult<QueryPayResponse, QueryPayResponse>> PayQuery(TejeePayQueryIpo ipo)
        {
            string url = "/gateway/api/queryPay";
            var request = new QueryPayRequest()
            {
                head = new QueryPayHeader()
                {
                    mchtId = _tejeepayConfig.merchantId,
                    biz = System.Enum.GetName(typeof(BizInEnum), ipo.BizEnum),
                    version = 20
                },
                body = new QueryPayBody()
                {
                    currencyType = ipo.CurrencyId,
                    orderId = ipo.OrderId,
                    orderTime = ipo.OrderEo.RecDate.ToLocalTime(ipo.OrderEo.OperatorID).ToString("yyyyMMddHHmmss")
                }
            };
            string sign = SighHelper.GetSign(request.body, _tejeepayConfig.merchantKey);
            request.sign = sign;
            var resp = await PostJson<QueryPayResponse, QueryPayResponse>(url, request);
            //Console.WriteLine(resp);
            //if (!resp.Success || resp.SuccessResult?.head.respCode!="0000")
            //{
            //    LogUtil.Error("查询代收信息出错!resultstring:" + resp.ResultString);
            //    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "查询代收信息出错！");
            //}

            //dto.Meta = resp.SuccessResult.body;
            //dto.OperatorSuccess = true;
            //return resp.SuccessResult;
            return resp;
        }

        /// <summary>
        /// 代付查询
        /// </summary>
        /// <param name="tradeId"></param>
        /// <returns></returns>
        public async Task<ProxyQueryRespBody> ProxyQuery(TejeeProxyQueryIpo ipo)
        {
            string url = "/df/gateway/proxyquery";
            var request = new ProxyQueryRequest()
            {
                head = new ProxyQueryHeader()
                {
                    biz = System.Enum.GetName(typeof(BizOutEnum), ipo.BizEnum),
                    mchtId = _tejeepayConfig.merchantId,
                    version = 20
                },
                body = new ProxyQueryBody()
                {
                    batchOrderNo = ipo.OrderId,
                    currencyType = ipo.CurrencyId,
                    orderTime = ipo.OrderEo.RecDate.ToLocalTime(ipo.OrderEo.OperatorID).ToString("yyyyMMddHHmmss")
                    //tradeId = ipo.TradeId
                }
            };
            string data = JsonConvert.SerializeObject(request.body);
            string sign = RSAUtils.encrypt(data, _tejeepayConfig.publicKey);
            request.body = HttpUtility.UrlEncode(sign);
            var resp = await PostJson<ProxyQueryResponse, ProxyQueryResponse>(url, request);
            
            if (!resp.Success || resp.SuccessResult.head.respCode != "0000"||string.IsNullOrWhiteSpace(resp.SuccessResult.body?.ToString()))
            {
                LogUtil.GetContextLogger()
                           .AddField("banks.orderid", ipo.OrderId)
                           .AddField("banks.userid", ipo.OrderEo.UserID)
                           .AddField("banks.bankid", ipo.OrderEo.BankID)
                           .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning)
                           .AddField("banks.tejeepay.cashqueryrsp", resp.ResultString)
                           .AddMessage($"查询代付信息出错!").Save();
                return default;
                //LogUtil.Error("查询代付信息出错!resultstring:" + resp.ResultString);
                //throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "查询代付信息出错！");
            }
            string body = RSAUtils.decrypt(HttpUtility.UrlDecode(resp.SuccessResult.body?.ToString()), _tejeepayConfig.privateKey);//jo["body"].ToString()
            var obj = JsonConvert.DeserializeObject<ProxyQueryRespBody>(body);
            return obj;
        }

        /// <summary>
        /// 余额查询
        /// </summary>
        /// <returns></returns>
        public async Task<TejeeBalanceQueryDto> BalanceQuery(TejeeBalanceQueryIpo ipo, TejeeBalanceQueryDto dto)
        {
            string url = "/df/gateway/proxybalance";
            var request = new ProxyBalanceRequest()
            {
                head = new ProxyBalanceHeader()
                {
                    biz = System.Enum.GetName(typeof(BizOutEnum), ipo.BizEnum),
                    mchtId = _tejeepayConfig.merchantId,
                    version = 20
                },
                body = new ProxyBalanceBody()
                {
                    currencyType = ipo.CurrencyId,
                    mchtId = _tejeepayConfig.merchantId
                }
            };
            string data = JsonConvert.SerializeObject(request.body);
            string sign = RSAUtils.encrypt(data, _tejeepayConfig.publicKey);
            request.body = HttpUtility.UrlEncode(sign);
            var resp = await PostJson<ProxyBalanceResponse, ProxyBalanceResponse>(url, request);
            if (!resp.Success || resp.SuccessResult.head.respCode != "0000")
            {
                LogUtil.Error("查询余额信息出错!resultstring:" + resp.ResultString);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "查询余额信息出错！");
            }
            string body = RSAUtils.decrypt(HttpUtility.UrlDecode(resp.SuccessResult.body?.ToString()), _tejeepayConfig.privateKey);//jo["body"].ToString()
            var obj = JsonConvert.DeserializeObject<ProxyBalanceRespBody>(body);
            dto.Meta = obj;
            dto.OperatorSuccess = true;
            return dto;
        }

        /// <summary>
        /// post请求
        /// </summary>
        /// <typeparam name="TSuccess"></typeparam>
        /// <typeparam name="TError"></typeparam>
        /// <param name="url"></param>
        /// <param name="req"></param>
        /// <returns></returns>
        private async Task<HttpResponseResult<TSuccess, TError>> PostJson<TSuccess, TError>(string url, object req)
        {
            var opts = SerializerUtil.GetJsonOptions();
            opts.WriteIndented = false;
            var json = SerializerUtil.SerializeJson(req, opts);

            //LogUtil.Info($"请求tejeepay接口url:{url},Header-MerchantId:{_tejeepayConfig.merchantId}，req:{json}");

            var logger = LogUtil.GetContextLogger()
               .AddField("banks.tejeepay.req", json)
               .SetLevel(Microsoft.Extensions.Logging.LogLevel.Information)
               .AddMessage($"开始请求tejeepay接口url:{url}");

            var rsp = await _client.CreateAgent()
               .AddUrl(url)
               .BuildJsonContent(json)
               .PostAsync<TSuccess, TError>();
            
            logger.AddField("banks.tejeepay.rsp",rsp?.ResultString);
            if (!(rsp?.Success ?? false) || string.IsNullOrWhiteSpace(rsp.ResultString))
            {
                logger.SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                .AddMessage($"请求tejeepay接口url:{url}出错!");
                //logger.SetLevel(Microsoft.Extensions.Logging.LogLevel.Error).AddMessage("调用tejeepay接口出错！");
            }
            //else
            //{
            //    LogUtil.GetContextLogger()
            //  .AddField("banks.tejeepay.req", json)
            //   .AddField("banks.tejeepay.rsp", rsp?.ResultString)
            //  .AddMessage($"请求tejeepay接口url:{url}正常返回！")
            //   .Save();
            //}
            logger.Save();
            //var data = await new Http_Client().postJson(_client.BaseAddress + url, json);
            //var rsp = new HttpResponseResult<TSuccess, TError>()
            //{
            //    ResultString = data,
            //    Success = true,
            //    SuccessResult = JsonConvert.DeserializeObject<TSuccess>(data)
            //};
            //LogUtil.Info($"请求tejeepay接口url:{url}，success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");

            return rsp;
        }


    }
}
