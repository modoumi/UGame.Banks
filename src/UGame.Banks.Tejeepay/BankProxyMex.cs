using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
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
using UGame.Banks.Service.Common;
using UGame.Banks.Service.MQMsg;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Tejeepay.Common;
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Model;
using UGame.Banks.Tejeepay.Req;
using UGame.Banks.Tejeepay.Resp;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;


namespace UGame.Banks.Tejeepay
{
    //public abstract class TejeeBankProxy
    //{
    //    private HttpClientEx _client;
    //    private const string CLIENT_NAME = "banks.tejeepay_mex";
    //    private TejeepayConfig _tejeepayConfig;
    //    private BankConfig _bankConfig;
    //    private Sb_bankEO _bank;
    //    private const int MULTIPLE = 100;
    //    private BankErrorDCache _bankErroCountDCache = new();
    //    private static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
    //    private const string BASEBANKID = "tejeepay";
    //    private const string ISPRODUCTION = "IsProduction";
    //    public TejeeBankProxy(string bankId)
    //    {
    //        _bank = DbBankCacheUtil.GetBank(bankId);
    //        _bankConfig = _bank.BankConfig.ToSafeDeserialize<BankConfig>();
    //        _client = _clientDict.GetOrAdd(CLIENT_NAME, k =>
    //        {
    //            var baseUrl = (ConfigUtil.IsDebugEnvironment || (ConfigUtil.IsStagingEnvironment && !ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION, false))) ? "https://pre.pay.haodamall.com" : _bankConfig.BaseAddress;
    //            return HttpClientExFactory.CreateClientEx(new HttpClientConfig
    //            {
    //                BaseAddress = baseUrl,
    //                Name = CLIENT_NAME
    //            });
    //        });
    //        var tmpHost = _bankConfig.Host;
    //        if (ConfigUtil.IsDebugEnvironment)
    //        {
    //            tmpHost = "http://123.125.255.133:8989/banks/";
    //        }
    //        if (ConfigUtil.IsStagingEnvironment && !ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION, false))
    //        {
    //            tmpHost = "https://api.ingame777.com/banks/";
    //        }
    //        if (ConfigUtil.IsDebugEnvironment || (ConfigUtil.IsStagingEnvironment && !ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION, false)))
    //        {
    //            _bankConfig.MerchantId = "2000713000197336";
    //            _bankConfig.MerchantKey = "5cde8dfe0c894429bb6b86ec05f8406f";
    //            _bankConfig.PublicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCToLb5QpQKyeT2c/94qo6Q8QA2CxESLxk9MGW6if5xRuZ4vSXXJ0gdOSrv6FbNS9m85z0+JP/C4QmSwSi3i/+wERA4Q2H3ZVxJHynqw/P3OwWFdg++8A5VjRoo6O3KceZekPQiK09Y6uwX22VZJD8BO6V55XE1GrNmATEO84IjYwIDAQAB";
    //            _bankConfig.PrivateKey = "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAIhmx77rBWpc+3Oi74JhbOeu4W3zAGhRE8H546VF2RNqzH1OC3KCRQhTznkGj2HZVSYRKqGRJYF4EDXQBHUgw3c1Jpbc4T6F0sLh38eeEW33ag2sv6U0eZ0ti+aEQKcxfshvWE4UI4m5k4QIo08vu0n5g31EIlaog9+QGKUHcMSpAgMBAAECgYAJavdNslJ8ZpEiCdT5rppjYMrF2apkiXyQvx09sxXq5kvaNwJJVL9JdOfjqVVLD0N2zmagIzJwvwZ3gLZeE/YK8jzIit0eg7N50UURlit9SPOyHfUOVgTePlQDlmL4CXMfRKfEEvw4j5X+f9Z1+yy5Li0l/u+crNnKgnlGJKQRUQJBAL23petSBJiJClOijsUQYE3UWQ7C5J6RJPoT8qG6rrtruNcP39gMXD1B9++qDGaycYoGl084A4H5mW+zaY0Kfk0CQQC4Dozwj25huBGP1GXBIBZLGze4V15BNFI6eCCOXY1l/48DbuqoBKWauWnSp1njaj8uPSEECv2G6raU84oCKqXNAkBDwA20l7mkb2wMqgSqQ0rhAHA9YUQbjGHUHMONFgnITJPZ2YVqth9KkQBlyihblGYPkIMAe1RlWil9RmjvQUwRAkEAnnU4daqmV07HH9K2P8xGJScrk3L0XKKU4G2naam1IEkicMw/DaPihxB1wLv/MUC5YC+UiwyDNHJB+n6pJDBfSQJAdUSgVr55C6viC3Nti5nLeOBN25345UUMgVqbhIQyINgLfgUmGh9dvFrAr/HtHlpqD7y24xVpJHRqVWYKuvUMlQ==";
    //        }
    //        _tejeepayConfig = new TejeepayConfig
    //        {
    //            merchantId = _bankConfig.MerchantId,
    //            merchantKey = _bankConfig.MerchantKey,
    //            publicKey = _bankConfig.PublicKey,
    //            privateKey = _bankConfig.PrivateKey,
    //            host = tmpHost,
    //            payNotify = tmpHost + _bankConfig.PayNotify,
    //            payCallback = tmpHost + _bankConfig.PayCallback,
    //            cashNotify = tmpHost + _bankConfig.CashNotify,
    //        };
    //    }
    //}
    public class BankProxyMex
    {
        private HttpClientEx _client;
        private const string CLIENT_NAME = "banks.tejeepay_mex";
        private TejeepayConfig _tejeepayConfig;
        private BankConfig _bankConfig;
        private Sb_bankEO _bank;
        private const int MULTIPLE = 100;
        private BankErrorDCache _bankErroCountDCache = new();
        private static ConcurrentDictionary<string, HttpClientEx> _clientDict = new();
        private const string BASEBANKID = "tejeepay";
        private const string ISPRODUCTION = "IsProduction";
        private const decimal PERFEE = 3M;
        public BankProxyMex(string bankId)
        {
            _bank = DbBankCacheUtil.GetBank(bankId);
            _bankConfig = _bank.BankConfig.ToSafeDeserialize<BankConfig>();
            _client = _clientDict.GetOrAdd(CLIENT_NAME, k =>
            {
                var baseUrl = (ConfigUtil.Environment.IsDebug||(ConfigUtil.Environment.IsStaging&&!ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION,false))) ? "https://pre.pay.haodamall.com" : _bankConfig.BaseAddress;
                return HttpClientExFactory.CreateClientEx(new HttpClientConfig
                {
                    BaseAddress = baseUrl,
                    Name = CLIENT_NAME
                });
            });
            var tmpHost = _bankConfig.Host;
            if (ConfigUtil.Environment.IsDebug)
            {
                tmpHost = "http://111.206.173.171:8989/banks/";
            }
            if(ConfigUtil.Environment.IsStaging&&!ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION,false))
            {
                tmpHost = "https://api.ingame777.com/banks/";
            }
            if(ConfigUtil.Environment.IsDebug||(ConfigUtil.Environment.IsStaging&&!ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION,false)))
            {
                _bankConfig.MerchantId = "2000713000197336";
                _bankConfig.MerchantKey = "5cde8dfe0c894429bb6b86ec05f8406f";
                _bankConfig.PublicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCToLb5QpQKyeT2c/94qo6Q8QA2CxESLxk9MGW6if5xRuZ4vSXXJ0gdOSrv6FbNS9m85z0+JP/C4QmSwSi3i/+wERA4Q2H3ZVxJHynqw/P3OwWFdg++8A5VjRoo6O3KceZekPQiK09Y6uwX22VZJD8BO6V55XE1GrNmATEO84IjYwIDAQAB";
                _bankConfig.PrivateKey = "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAJjt6V2FnQsTwjp7Zg3AN3t9cGW45v9dQepyf9khGzh39nfHRxWL0aQswCymI8xH0+Tw1FC71AM5Jl1qi0btWH154fMNWmxmGTc87ByfCsertK/ehDw0OyVWjb8gEEitlBX9BvW1ROqrBFUteI0wp/kmGLE1QRyqj58lt7cvggNJAgMBAAECgYEAirkdvJkseNTmllhDneukKKAEKjINUM4OshZFRPgUEig36jVZlQDtHYj+lkHrLS5m10Fixw1q57WayJiSWLeKUXkPmGy9CI+VxtLJuXedw/Tiz5Ptfmb6Dl5q6axEW1tDaCdiIeKI6UNIL7Iwp3r2lnwOjl3DeO0Rsdi/l7eaGgECQQDI90r/h5UY8WT9CokNeTuj1X0ReX2nnhjaMatFiaBtKYhLf0cLwJC0cXbsToKdgMcTJEmiOYJIHAV0soXztJ1BAkEAws8DRn3Kw2pkwMfsWSxjJimrBvbqx9kGMlj8PNHI97GlsnwY78YS3eWtPnIMAZGCfnwlwb6CwQoFYRumyb18CQJAVxJmKT6qR+tXERe+d9r+DycRkD+uRLCIHgmFJpTRsFpdVjCoLJxbVgMPPqVpjCpelpmTWblHDE0vw/cReJzZwQJBAKViRe+UX41jR8H6eIaEDnCZs16oRU4Ayyf3L70ahLj0Ei3i+PCmgeHsWRXIkLTMKbLkBtHiwPLNZR+57/EZcrECQEGZiSrP3pd+/ErN7jwI9tRuFf2Nh6umqCjV8zl6BAo/HBXtdHfYsNreaQop89gI/4NBV8GJpMYWADNrO18Tt8s=";
            }
            _tejeepayConfig = new TejeepayConfig
            {
                merchantId = _bankConfig.MerchantId,
                merchantKey = _bankConfig.MerchantKey,
                publicKey = _bankConfig.PublicKey,
                privateKey = _bankConfig.PrivateKey,
                host = tmpHost,
                payNotify = tmpHost + _bankConfig.PayNotify,
                payCallback = tmpHost + _bankConfig.PayCallback,
                cashNotify = tmpHost + _bankConfig.CashNotify,
            };
           
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
                    name = ipo.Name ?? string.Empty,
                    email = ipo.Email ?? string.Empty,
                    phone = ipo.Phone ?? string.Empty,
                }
            };
            dto.TransMoney = amount;
            dto.OrderMoney = Math.Truncate(100 * payMoney) / 100;
            request.sign = SighHelper.GetSign(request.body, _tejeepayConfig.merchantKey);
            var resp = await PostJson<CommonPayResponse, CommonPayResponse>(url, request);
            if (!resp.Success || resp.SuccessResult.head.respCode != "0000")
            {
                await _bankErroCountDCache.IncrError(BASEBANKID);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = _bank.BankID,
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
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, resp.SuccessResult?.head.respMsg ?? "代收信息出错！");
            }
            else
            {
                await _bankErroCountDCache.SetAsync(BASEBANKID, 0);
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
            var payMoney = (ipo.Amount-ipo.UserFeeAmount).AToM(ipo.CurrencyId);
            if(ipo.UserFeeAmount==0)
            {
                payMoney=payMoney- Math.Truncate(100 * Math.Max(payMoney * _bank.CashFee, PERFEE)) / 100;
            }
            //dto.Fee = Math.Truncate(100 * Math.Max(payMoney * _bank.CashFee, PERFEE)) / 100;
            //payMoney -= dto.Fee;
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
                                        mobile=ipo.mobile??string.Empty,
                                        email=ipo.email??string.Empty,
                                        bankName=ipo.bankName??string.Empty
                                    }
                            }
                }
            };
            string json = JsonConvert.SerializeObject(request.body);
            LogUtil.Info($"请求tejeepay接口url:{url},Header-MerchantId:{_tejeepayConfig.merchantId}，OrderId:{ipo.OrderId}");
            string sign = RSAUtils.encrypt(json, _tejeepayConfig.publicKey);
            request.body = HttpUtility.UrlEncode(sign);
            dto.TransMoney = amount;
            dto.OrderMoney = Math.Truncate(100 * (amount/(decimal)MULTIPLE)) / 100;
            ProxyPayRespBody obj = null;
            if (ConfigUtil.Environment.IsDebug|| (ConfigUtil.Environment.IsStaging && !ConfigUtil.AppSettings.GetOrDefault(ISPRODUCTION,false)))
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
                    await _bankErroCountDCache.IncrError(BASEBANKID);
                    await MQUtil.PublishAsync(new BankErrorMsg
                    {
                        BankId = _bank.BankID,
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
                    throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, resp.SuccessResult?.head.respMsg ?? "代付信息出错！");
                }
                else
                {
                    await _bankErroCountDCache.SetAsync(BASEBANKID, 0);
                }

                var userDCache = new GlobalUserDCache(ipo.UserId);
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
            //dto.TransMoney = amount;
            return dto;
        }

        public decimal CalcCashFee(decimal payMoney)
        {
           //var payMoney = ipo.Amount.AToM(ipo.CurrencyId);
           return Math.Truncate(100 * Math.Max(payMoney * _bank.CashFee, PERFEE)) / 100;
        }

        /// <summary>
        /// 代收查询
        /// </summary>
        /// <returns></returns>
        public async Task<QueryPayResponse> PayQuery(TejeePayQueryIpo ipo)
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
            if (!resp.Success || resp.SuccessResult?.head == null)
            {
                LogUtil.Error("查询代收信息出错!resultstring:" + resp.ResultString);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "查询代收信息出错！");
            }

            //dto.Meta = resp.SuccessResult.body;
            //dto.OperatorSuccess = true;
            return resp.SuccessResult;
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
            //Console.WriteLine(resp);
            if (!resp.Success || resp.SuccessResult.head.respCode != "0000")
            {
                LogUtil.Error("查询代付信息出错!resultstring:" + resp.ResultString);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.SuccessResult?.head.respMsg ?? "查询代付信息出错！");
            }
            string body = RSAUtils.decrypt(HttpUtility.UrlDecode(resp.SuccessResult.body?.ToString()), _tejeepayConfig.privateKey);//jo["body"].ToString()
            var obj = JsonConvert.DeserializeObject<ProxyQueryRespBody>(body);
            //dto.Meta = obj;
            //dto.OperatorSuccess = true;
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

            LogUtil.Info($"请求tejeepay接口url:{url},Header-MerchantId:{_tejeepayConfig.merchantId}，req:{json}");


            var rsp = await _client.CreateAgent()
               .AddUrl(url)
               .BuildJsonContent(json)
               .PostAsync<TSuccess, TError>();

            //var data = await new Http_Client().postJson(_client.BaseAddress + url, json);
            //var rsp = new HttpResponseResult<TSuccess, TError>()
            //{
            //    ResultString = data,
            //    Success = true,
            //    SuccessResult = JsonConvert.DeserializeObject<TSuccess>(data)
            //};
            LogUtil.Info($"请求tejeepay接口url:{url}，success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");

            return rsp;
        }


    }
}
