using TinyFx;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Security;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.DAL;
using Xxyy.Banks.Mongopay.Models.Dto;
using Xxyy.Banks.Mongopay.Models.Request;
using Xxyy.Banks.Mongopay.Models.Response;
using Xxyy.Common;

namespace Xxyy.Banks.Mongopay.Proxy
{
    /// <summary>
    /// 
    /// </summary>
    public class BankProxy
    {
        private HttpClientEx _client;
        private Sb_bankEO _bank;

        private const string CLIENT_NAME = "banks.mongopay";
        private const string MERCHANTCODE = "MerchantCode";
        private const string PAYCALLBACKURL = "PayCallbackUrl";
        private const string Method = "store";//bank_account,store,oxxo_cash


        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        public BankProxy(string bankId)
        {
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            _bank = DbBankCacheUtil.GetBank(bankId);
        }

        /// <summary>
        /// MongoPay
        /// </summary>
        /// <returns></returns>
        public async Task<PayDto> Pay(PayIpo ipo, PayDto dto)
        {
            var url = "/gateway/pay";
            var merchantCode = _client.GetSettingValue<string>(MERCHANTCODE);
            var payCallbackUrl = _client.GetSettingValue<string>(PAYCALLBACKURL);
            var payReq = new PayRequest
            {
                MerchantCode = merchantCode,
                Method = Method,
                OrderNum = ipo.OrderId,
                PayMoney = (ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId),
                CustName = ipo.UserId,
                Email = "test@email.com",
                ProductDetail = "test pay",
                NotifyUrl = payCallbackUrl,
                DateTime = DateTime.UtcNow.ToString("yyyyMMddHHmmss")
            };
            //请求数据签名
            payReq.Sign = SignDataByPrivateKey(SignHelper.GetSign(payReq), _bank.OwnPrivateKey);

            var ret = await PostJson<PayRespons, PayRespons>(url, payReq);

            if (ret != null && ret.SuccessResult.PlatRespCode != "SUCCESS")
            {
                LogUtil.Warning($"mongopay充值失败！orderid:{ipo.OrderId},返回结果ret为:{SerializerUtil.SerializeJsonNet(ret)}");
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, ret.SuccessResult.PlatRespMessage);
            }
            //验证返回的数据签名
            if (!VerifyResponseDataByPublicKey(ret, ret.SuccessResult.PlatSign, _bank.TrdPublicKey))
            {
                throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE, "验证签名错误");
            }

            dto.BankOrderId = ret.SuccessResult.PlatOrderNum;
            dto.TransMoney = ipo.Amount;
            dto.OrderId = ipo.OrderId;
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
            var json = SerializerUtil.SerializeJson(req);
            LogUtil.Info($"请求mongopay接口url:{url}，req:{json}");
            var rsp = await _client.CreateAgent()
               .AddUrl(url)
               .BuildJsonContent(json)
               .PostAsync<TSuccess, TError>();

            LogUtil.Info($"请求mongopay接口url:{url}，req:{json},success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");

            return rsp;
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="source"></param>
        /// <param name="privateKey"></param>
        /// <returns></returns>
        private static string SignDataByPrivateKey(string source, string privateKey)
        {
            return SecurityUtil.RSAEncryptUsePrivateKey(source, privateKey, RSAKeyMode.PrivateKey);
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="sign"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        private static bool VerifyResponseDataByPublicKey<T>(T source, string sign, string publicKey)
        {
            var decryptdata = SecurityUtil.RSADecryptUsePublicKey(sign, publicKey);
            var sourceToVerify = SignHelper.GetSign(source);
            return sourceToVerify == decryptdata;
        }
    }
}
