using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using TinyFx.Net;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.DAL;

using TinyFx.Security;
using Xxyy.Common;
using Org.BouncyCastle.Ocsp;
using Xxyy.Common.Caching;
using TinyFx.Configuration;
using Xxyy.Banks.Pandapay.PaySvc;
using Nacos.V2.Naming.Core;
using Xxyy.Banks.BLL.Services.Cash;
using Xxyy.Banks.BLL;

namespace Xxyy.Banks.Pandapay
{
    public class BankProxy
    {
        #region Base
        private HttpClientEx _client;
        private const string CLIENT_NAME = "banks.pandapay";
        private const string APPID = "AppId";
        private const string APIKEY = "ApiKey";
        private const string COMPANYNO = "CompanyNo";
        private PandapayConfig _pandapayConfig;
        private const int MULTIPLE = 100;
        private const decimal CASHFEE = 0.02m;
        private BankErrorDCache _bankErrorDCache = new();
        private const string BANKID = "pandapay";

        /// <summary>
        /// 
        /// </summary>
        public BankProxy()
        {
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            _pandapayConfig = new PandapayConfig
            {
                AppId = _client.GetSettingValue<string>(APPID),
                ApiKey = _client.GetSettingValue<string>(APIKEY),
                CompanyNo = _client.GetSettingValue<string>(COMPANYNO)
            };
        }
        #endregion

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task Pay(PandapayIpo ipo, PandapayDto dto)
        {
            var payReq = new PayInReq
            {
                reference = _pandapayConfig.CompanyNo + ipo.OwnOrderId,
                amount = Math.Round(ipo.Amount.AToM(ipo.CurrencyId) * MULTIPLE,0,MidpointRounding.ToZero),
                name = ipo.AccName,// ipo.UserId,
                taxId = ipo.TaxId,
                payInType = "BRCODE"
            };
            ipo.OwnOrderId = payReq.reference;
            var ret = await this.Pay(payReq,dto);
            dto.BankOrderId = ret.data.transactionId;
            dto.BarCode = ret.data.barCode;
            dto.OperatorSuccess = !string.IsNullOrWhiteSpace(ret.data.barCode);
            if (!dto.OperatorSuccess)
            {
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, "支付过程出错");
            }
        }


        /// <summary>
        /// 还款
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<PandaPayRspBase<PayInRsp>> Pay(PayInReq req, PandapayDto dto)
        {
            string requestUrl = "/api/pay/v2/createPayIn";
            dto.TransMark = requestUrl;
            var rsp = await PostJson<PandaPayRspBase<PayInRsp>, PandaPayRspBase<PayInRsp>>(requestUrl, req);
            if (!rsp.Success || rsp.SuccessResult?.data == null || rsp.SuccessResult.data.barCodeStatus != "SUCCESS")
            {
                await _bankErrorDCache.IncrError(BANKID);
                LogUtil.Error("创建收款码出错!resultstring:" + rsp.ResultString);
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, rsp.SuccessResult?.message ?? "创建收款码出错");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID,0);
            }
            return rsp.SuccessResult;
        }

     

        /// <summary>
        /// 出款
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task Cash(PandaCashIpo ipo, PandaCashDto dto)
        {
            var req = new CashReq()
            {
                reference = _pandapayConfig.CompanyNo + ipo.OwnOrderId,
                amount =0, //Math.Round(ipo.Amount.AToM(ipo.Order.CurrencyID) * MULTIPLE,0,MidpointRounding.ToZero),
                name = ipo.AccName, //ipo.Order.UserID,
                taxId = ipo.TaxId,
                bankName = ipo.BankName,
                bankCode = ipo.BankCode,
                branchCode = ipo.BranchCode,
                bankAccountNumber = ipo.AccNumber,
                accountType = ipo.AccountType
            };
            //每天首提免手续费
            var userDCache = new GlobalUserDCache(ipo.UserId);
            var lastCashDate =await userDCache.GetLastCashDateAsync();
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                dto.IsFirstCashOfDay = true;
                await userDCache.SetLastCashDateAsync(DateTime.UtcNow);
            }
            var pandaMoney = ipo.Amount.AToM(ipo.Order.CurrencyID);
            if (!dto.IsFirstCashOfDay)
            {
                if (ConfigUtil.IsDebugEnvironment)
                {
                    var feeMoney = ipo.Amount.AToM(ipo.Order.CurrencyID) switch
                    {
                        < 10000 => 3.01m,
                        >= 10000 and < 20000 => 2.49m,
                        _ => 0.06m
                    };
                    req.amount = Math.Round((pandaMoney - feeMoney) * MULTIPLE, 0, MidpointRounding.ToZero);
                }
                else
                {
                    req.amount = Math.Round((pandaMoney - (pandaMoney * 0.02M + 1)) * MULTIPLE, 0, MidpointRounding.ToZero);
                }
            }
            else
            {
                req.amount =(int)(pandaMoney * MULTIPLE);
            }
            dto.TransMoney = req.amount;
            dto.OrderMoney =Math.Truncate(100*req.amount/ MULTIPLE) /100;
            var ret = await this.Cash(req,dto);
            dto.OperatorSuccess = ret.message == "Success"&&ret.data!=null;
            dto.BankOrderId = ret.data?.transactionId;
            if (!dto.OperatorSuccess)
            {
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, $"支付过程出错!ret:{SerializerUtil.SerializeJsonNet(ret)}");
            }
        }

        /// <summary>
        /// 出款
        /// </summary>
        /// <param name="req"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<PandaPayRspBase<CashRsp>> Cash(CashReq req, PandaCashDto dto)
        {
            string requestUrl = "/api/pay/v2/createPay";
            dto.TransMark = requestUrl;
            var rsp = await PostJson<PandaPayRspBase<CashRsp>, PandaPayRspBase<CashRsp>>(requestUrl, req);
            if (!rsp.Success || rsp.SuccessResult?.message != "Success" || rsp.SuccessResult?.data == null||rsp.SuccessResult.data.status== "FAIL")
            {
                await _bankErrorDCache.IncrError(BANKID);
                LogUtil.Error($"bankproxy.cash,panda发起收款失败!param:{SerializerUtil.SerializeJsonNet(new { req,dto})},resultstring:{rsp.ResultString}");
                throw new CustomException(PartnerCodes.RS_PAY_VALIDATION_ERROR, rsp.SuccessResult?.message ?? "panda发起收款失败");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID, 0);
            }
            return rsp.SuccessResult;
        }

        /// <summary>
        /// querykey
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<PandaPayRspBase<QueryDictKeyRsp>> QueryDictKey(QueryDictKeyIpo ipo)
        {
            var queryDictKeyReq = new QueryDictKeyReq
            {
                 key=ipo.QueryKey
            };
            var rsp = await PostJson<PandaPayRspBase<QueryDictKeyRsp>, PandaPayRspBase<QueryDictKeyRsp>>("/api/pay/v2/queryDictKey", queryDictKeyReq);
            if (!rsp.Success || rsp.SuccessResult?.data == null)
            {
                await _bankErrorDCache.IncrError(BANKID);
                LogUtil.Debug($"bankproxy.QueryDictKey,根据pixkey查询个人银行信息出错!param:{SerializerUtil.SerializeJsonNet(new { ipo})}，resultstring:{rsp.ResultString}" );
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, rsp.SuccessResult?.message ?? "根据pixkey查询个人银行信息出错！");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID, 0);
            }
            return rsp.SuccessResult;
        }

        /// <summary>
        /// queryBankList
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<PandaPayRspBase<IEnumerable<QueryBankListRsp>>> QueryBankList()
        {
            var rsp = await GetJson<PandaPayRspBase<IEnumerable<QueryBankListRsp>>, PandaPayRspBase<IEnumerable<QueryBankListRsp>>>("/api/pay/v2/queryBankList", null);
            if (!rsp.Success || rsp.SuccessResult?.data == null)
            {
                await _bankErrorDCache.IncrError(BANKID);
                LogUtil.Error("查询pandapay银行列表出错!resultstring:" + rsp.ResultString);
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, rsp.SuccessResult?.message ?? "查询pandapay银行列表出错！");
            }
            else
            {
                await _bankErrorDCache.SetAsync(BANKID, 0);
            }
            return rsp.SuccessResult;
        }




        private async Task<HttpResponseResult<TSuccess, TError>> PostJson<TSuccess, TError>(string url, object req)
        {
            var json = SerializerUtil.SerializeJson(req);
            //var contentmd5 = SecurityUtil.MD5Hash(json, CipherEncode.Bit32Lower);
            //var sign = SecurityUtil.MD5Hash(contentmd5 + _pandapayConfig.ApiKey, CipherEncode.Bit32Lower);
            var sign = GetSign(json);
            LogUtil.Info($"请求pandapay接口url:{url},Header-AppId:{_pandapayConfig.AppId},Authorization:{sign}，req:{json}");

            var rsp = await _client.CreateAgent()
                .AddUrl(url)
                .AddRequestHeader("AppId", _pandapayConfig.AppId)
                .AddRequestHeader("Authorization", sign)
                .BuildJsonContent(json)
                .PostAsync<TSuccess, TError>();
            LogUtil.Info($"请求pandapay接口url:{url}，req:{json},success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");

            return rsp;
        }

        private async Task<HttpResponseResult<TSuccess, TError>> GetJson<TSuccess, TError>(string url, object req)
        {
            //var json = SerializerUtil.SerializeJson(req);
            //var contentmd5 = SecurityUtil.MD5Hash(json, CipherEncode.Bit32Lower);
            //var sign = SecurityUtil.MD5Hash(contentmd5 + _pandapayConfig.ApiKey, CipherEncode.Bit32Lower);
            //var sign = GetSign(json);
            LogUtil.Info($"请求pandapay接口url:{url},Header-AppId:{_pandapayConfig.AppId}");

            var rsp = await _client.CreateAgent()
                .AddUrl(url)
                .AddRequestHeader("AppId", _pandapayConfig.AppId)
               // .AddRequestHeader("Authorization", sign)
                //.BuildJsonContent(json)
                .GetAsync<TSuccess, TError>();
            LogUtil.Info($"请求pandapay接口url:{url}，success:{rsp?.Success}，返回值resultstring：{rsp?.ResultString}");

            return rsp;
        }

        private string GetSign(string json)
        {
            var contentmd5 = SecurityUtil.MD5Hash(json, CipherEncode.Bit32Lower);
            var sign = SecurityUtil.MD5Hash(contentmd5 + _pandapayConfig.ApiKey, CipherEncode.Bit32Lower);
            return sign;
        }
    }
}
