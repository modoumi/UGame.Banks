using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Security;
using TinyFx;
using TinyFx.Text;
using UGame.Banks.Client.Caching;

namespace UGame.Banks.Client.BLL
{
    public class BaseClient
    {
        public HttpClientEx Client;
        private const string HEADER_NAME = "X-ING-Signature";

        public BaseClient(string clientName = "xxyy.banks")
        {
            Client = HttpClientExFactory.CreateClientExFromConfig(clientName);
        }

        internal async Task<ApiResult<TDto>> PostJson<TIpo, TDto>(TIpo ipo, string url)
            where TIpo : BaseIpo, new()
        {
            var json = SerializerUtil.SerializeJsonNet(ipo);
            var privateKey = GetOwnPrivateKey(ipo.AppId);
            var sign = SignData(json, privateKey);

            LogUtil.Info($"XxyyBankClient:1.请求url-${url},json-{json},sign:{sign}");
            var rsp = await Client.CreateAgent()
                .AddUrl(url)
                .AddRequestHeader(HEADER_NAME, sign)
                .BuildJsonContent(json)
                .PostAsync<ApiResult<TDto>, object>();
            LogUtil.Info($"XxyyBankClient:2.请求url-${url},json-{json},sign:{sign},resultstring:{SerializerUtil.SerializeJsonNet(rsp)}");
            if (!rsp.Success)
            {
                var msg = $"ipo:{json},rsp:{SerializerUtil.SerializeJsonNet(rsp)}";
                LogUtil.Error(rsp.Exception, msg);
                throw new CustomException(ResponseCodes.RS_TRANSFER_FAILED, "Bank Request Failed!!!");
            }
            return rsp.SuccessResult;
        }
        internal async Task<ApiResult<TDto>> PostTextJson<TIpo, TDto>(TIpo ipo, string url)
           where TIpo : BaseIpo, new()
        {
            var json = SerializerUtil.SerializeJson(ipo);
            var privateKey = GetOwnPrivateKey(ipo.AppId);
            var sign = SignData(json, privateKey);

            LogUtil.Info($"XxyyBankClient:1.请求url-${url},json-{json},sign:{sign}");
            var rsp = await Client.CreateAgent()
                .AddUrl(url)
                .AddRequestHeader(HEADER_NAME, sign)
                .BuildJsonContent(json)
                .PostAsync<ApiResult<TDto>, object>();
            LogUtil.Info($"XxyyBankClient:2.请求url-${url},json-{json},sign:{sign},resultstring:{SerializerUtil.SerializeJsonNet(rsp)}");
            if (!rsp.Success)
            {
                var msg = $"ipo:{json},rsp:{SerializerUtil.SerializeJsonNet(rsp)}";
                LogUtil.Error(rsp.Exception, msg);
                throw new CustomException(ResponseCodes.RS_TRANSFER_FAILED, "Bank Request Failed!!!");
            }
            return rsp.SuccessResult;
        }

        private string SignData(string source, string privateKey)
        {
            return SecurityUtil.RSASignData(source, privateKey
                , RSAKeyMode.RSAPrivateKey
                , HashAlgorithmName.SHA256
                , CipherEncode.Base64
                , Encoding.UTF8);
        }

        #region Utils

        internal void SetIpoData<T>(T ipo) where T : BaseIpo
        {
            if (string.IsNullOrWhiteSpace(ipo.AppOrderId))
                ipo.AppOrderId = ObjectId.NewId();
            if (string.IsNullOrEmpty(ipo.RequestUUID))
                ipo.RequestUUID = ObjectId.NewId();
        }


        private string GetOwnPrivateKey(string appId)
        {
            // appId
            var app = DbCacheUtil.GetApp(appId, false);
            if (app == null)
                throw new CustomException(ResponseCodes.RS_INVALID_APP, $"未知App。 appId:{appId}");
            // provider
            var provider = DbCacheUtil.GetProvider(app.ProviderID, false);
            if (provider == null)
                throw new CustomException(ResponseCodes.RS_WRONG_SYNTAX, $"未知Provider。 providerId:{app.ProviderID}");
            if (provider.Status == 0)
                throw new CustomException(ResponseCodes.RS_INVALID_PROVIDER, $"提供商被禁用。 providerId:{provider.ProviderID}");
            return provider.OwnPrivateKey;
        }
        #endregion

        /// <summary>
        /// 获取order
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<GetOrderDto>> GetOrder(XxyyGetOrderIpo xxyyIpo)
        {
            var ipo = new GetOrderIpo
            {
                Amount = 0,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                OrderId = xxyyIpo.OrderId,
                BankId = "",
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = xxyyIpo.Meta,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp
            };
            SetIpoData(ipo);
            var rsp = await PostJson<GetOrderIpo, GetOrderDto>(ipo, "api/bank/order2");
            return rsp;
        }

        /// <summary>
        /// 计算手续费
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        public async Task<ApiResult<CalcCashFeeDto>> CashFee(XxyyCalcCashFeeIpo xxyyIpo)
        {
            var ipo = new CalcCashFeeIpo
            {
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                BankId = xxyyIpo.BankId,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId= xxyyIpo.CountryId,
                Meta = xxyyIpo.Meta,
                RequestUUID = null,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                UserId = xxyyIpo.UserId,
                UserIp = null,
                CashRate=xxyyIpo.CashRate,
                AdditionalParameters= xxyyIpo.AdditionalParameters
            };
            SetIpoData(ipo);
            var rsp = await PostTextJson<CalcCashFeeIpo, CalcCashFeeDto>(ipo, "api/bank/cashfee2");
            return rsp;
        }
    }
}
