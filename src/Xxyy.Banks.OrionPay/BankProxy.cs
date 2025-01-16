using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Hosting;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using RabbitMQ.Client;
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
using TinyFx.Logging;
using TinyFx.Net;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.DAL;
using Xxyy.Banks.Orionpay.Common;
using Xxyy.Banks.Orionpay.Dto;
using Xxyy.Banks.Orionpay.Model;
using Xxyy.Banks.Orionpay.Req;
using Xxyy.Banks.Orionpay.Resp;
using Xxyy.Common;
using Xxyy.Common.Caching;


namespace Xxyy.Banks.Orionpay
{
    public class BankProxy
    {
        private HttpClientEx _client;
        private const string CLIENT_NAME = "banks.orionpay";
        private const string API_BASE_URL = "API_BASE_URL";
        private const string AUTH_BASE_URL = "AUTH_BASE_URL";
        private const string account_id = "account_id";
        private const string client_id = "client_id";
        private const string client_secret = "client_secret";
        private const string marketplace_id = "marketplace_id";
        private const string payCallback = "callback";
        private const string username = "username";
        private const string password = "password";
        private OrionPayConfig _orionpayConfig;
        private Sb_bankEO _bank;
        private const int MULTIPLE = 100;
        private Http_Client http_Client = null;
        private BankErrorDCache _bankErrorDCache = new();
        private const string BANKID = "orionpay";
        public BankProxy(string bankId)
        {
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            _orionpayConfig = new OrionPayConfig
            {
                account_id = _client.GetSettingValue<string>(account_id),

                API_BASE_URL = _client.GetSettingValue<string>(API_BASE_URL),

                AUTH_BASE_URL = _client.GetSettingValue<string>(AUTH_BASE_URL),

                marketplace_id = _client.GetSettingValue<string>(marketplace_id),

                client_id = _client.GetSettingValue<string>(client_id),

                client_secret = _client.GetSettingValue<string>(client_secret),

                payCallback = _client.GetSettingValue<string>(payCallback),

                username = _client.GetSettingValue<string>(username),

                password = _client.GetSettingValue<string>(password),

            };
            _bank = DbBankCacheUtil.GetBank(bankId);
            http_Client = new Http_Client();

            RegistService();
        }


        public void RegistService()
        {
            try
            {
                var token = GetToken(0).GetAwaiter().GetResult();
                if (token == null)
                {
                    LogUtil.Error("获取token0出错！");
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "获取token0出错！");
                }
                var data = SubcriptWebHook(token.access_token).GetAwaiter().GetResult();
                if (!data.Item2)
                {
                    LogUtil.Error($"{data.Item1}");
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "注册回调出错！");
                }
                var resToken = JObject.Parse(data.Item1);
                LogUtil.Info($"subscription_id:{resToken["id"].ToString()}");
            }
            catch (Exception ex)
            {
                LogUtil.Error("Orionpay:RegistService:注册回调出错!resultString:" + ex.Message);
            }
        }
     

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        public async Task<OrionCommonPayDto> CommonPay(OrionCommonPayIpo ipo, OrionCommonPayDto dto)
        {
            var token = await GetToken(1);
            if (token == null)
            {
                LogUtil.Error("获取token1出错！");
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "获取token1出错！");
            }
            string payinURL = _orionpayConfig.API_BASE_URL + $"/accounts/{_orionpayConfig.account_id}/deposit";
            var payMoney = ipo.Amount.AToM(ipo.CurrencyId);
            var amount = (long)(payMoney * MULTIPLE);

            var header2 = new Dictionary<string, object>() { { "Bearer", token.access_token } };

            var request1 = new PayInRequest()
            {
                type = "PIX",
                amount = amount,
                currency = ipo.CurrencyId,
                customer = new Customer()
                {
                    identify = new Identify()
                    {
                        type = ipo.type,
                        number = ipo.number
                    },
                    address = new Address()
                    {
                        zipCode = ipo.zipCode
                    },
                    phone = ipo.phone,
                    email = ipo.email,
                    name = ipo.name 
                }
            };
            dto.TransMoney = request1.amount;
            dto.OrderMoney = Math.Truncate(100 * payMoney / MULTIPLE) / 100;
            var resp = await http_Client.postJson<PayInRequest,PayInResponse>(payinURL, request1, header2);
            Console.WriteLine(resp);
            if (!resp.success)
            {
                await _bankErrorDCache.IncrError(BANKID);
                LogUtil.Error("代收信息出错!resultstring:" + resp.message);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.message ?? "代收信息出错！");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID, 0);
            }
            dto.AuthorizationCode = resp.data.authorizationCode;
            dto.Status = resp.data.status;
            dto.CurrencyId = resp.data.currency;
            dto.Amount = resp.data.amount;
            dto.Meta = resp.data;
            dto.OrderId = ipo.OrderId;
            dto.BankOrderId = resp.data.id;
            dto.OperatorSuccess = true;
            return dto;
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        public async Task<OrionProxyPayDto> ProxyPay(OrionProxyPayIpo ipo, OrionProxyPayDto dto)
        {
            var token = await GetToken(1);
            if (token == null)
            {
                LogUtil.Error("获取token2出错！");
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "获取token2出错！");
            }
            string payoutURL = _orionpayConfig.API_BASE_URL + $"/accounts/{_orionpayConfig.account_id}/withdraw";

            var amount = (long)(ipo.Amount.AToM(ipo.CurrencyId) * MULTIPLE);
          
            var request3 = new PayOutRequest()
            {
                type = "PIX",
                amount = amount,
                dictKey = ipo.certValue, 
                dictType = ipo.certType,
                currency = ipo.CurrencyId, 
                customer = new Customer()
                {
                    identify = new Identify()
                    {
                        type = ipo.identifyType,
                        number = ipo.identifyValue
                    },
                    address = new Address()
                    {
                        zipCode = ipo.zipCode
                    },
                    email = ipo.email,
                    name =  ipo.name,
                    phone =  ipo.phone
                }
            };
            var resp = http_Client.postJson<PayOutRequest,PayOutResponse>(payoutURL, request3, new Dictionary<string, object>() { { "Bearer", token.access_token } }).GetAwaiter().GetResult();
            //Console.WriteLine(resp);
            if (!resp.success)
            {
                await _bankErrorDCache.IncrError(BANKID);
                LogUtil.Error("代付信息出错!resultstring:" + resp.message);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, resp.message ?? "代付信息出错！");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID,0);
            }
            var userDCache = new GlobalUserDCache(ipo.UserId);
            var lastCashDate = await userDCache.GetLastCashDateAsync();
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                dto.IsFirstCashOfDay = true;
                await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
            }

            dto.authorizationCode = resp.data.authorizationCode;
            dto.Status = resp.data.status;
            dto.tradeId = resp.data.id;
            dto.Meta = resp.data;
            dto.OrderId = ipo.OrderId;
            dto.BankOrderId = resp.data.id;
            dto.OperatorSuccess = true;
            return dto;
        }

        private async Task<OrionToken> GetToken(int flag)
        {
            var dict = new Dictionary<string, string>();
            string tokenURL = _orionpayConfig.AUTH_BASE_URL + "/auth/realms/digital-banking/protocol/openid-connect/token";
            dict.Add("token", tokenURL);
            dict.Add("client_id", _orionpayConfig.client_id);
            dict.Add("client_secret", _orionpayConfig.client_secret);
            if (flag == 1)
            {
                dict.Add("username", _orionpayConfig.username);
                dict.Add("password", _orionpayConfig.password);
                dict.Add("grant_type", "password");
            }
            else
            {
                dict.Add("grant_type", "client_credentials");
            }

            var res = await http_Client.postForm(tokenURL, dict);

            if (res.Item2)
            {
                return JsonConvert.DeserializeObject<OrionToken>(res.Item1);
            }
            else
            {
                return null;
            }
        }
        private async Task<(string,bool)> SubcriptWebHook(string token)
        {
            string registHookUrl = _orionpayConfig.API_BASE_URL + $"/marketplaces/{_orionpayConfig.marketplace_id}/subscriptions";
            var data = await http_Client.postJson(registHookUrl, $"{{\"url\":\"{_orionpayConfig.payCallback}\"}}", new Dictionary<string, object>() { { "Bearer", token } });
            return data;
        }

        ///// <summary>
        ///// post请求
        ///// </summary>
        ///// <typeparam name="TSuccess"></typeparam>
        ///// <typeparam name="TError"></typeparam>
        ///// <param name="url"></param>
        ///// <param name="req"></param>
        ///// <returns></returns>
        //private async Task<HttpResponseResult<TSuccess, TError>> PostJson<TSuccess, TError>(string url, object req)
        //{
        //    var opts = SerializerUtil.GetJsonOptions();
        //    opts.WriteIndented = false;
        //    var json = SerializerUtil.SerializeJson(req, opts);

        //    LogUtil.Info($"请求Orionpay接口url:{url},Header-MerchantId:{_OrionpayConfig.merchantId}，req:{json}");


        //    //var rsp = await _client.CreateAgent()
        //    //   .AddUrl(url)
        //    //   .BuildJsonContent(json)
        //    //   .PostAsync<TSuccess, TError>();

        //    var data = await new Http_Client().postJson(_client.BaseAddress + url, json);
        //    var rsp = new HttpResponseResult<TSuccess, TError>()
        //    {
        //        ResultString = data,
        //        Success = true,
        //        SuccessResult = JsonConvert.DeserializeObject<TSuccess>(data)
        //    };
        //    LogUtil.Info($"请求Orionpay接口url:{url}，success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");

        //    return rsp;
        //}


    }
}
