using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using TinyFx.Net;
using TinyFx.AspNet;
using TinyFx.Text;
using UGame.Banks.Client.Caching;
using UGame.Banks.Client.BLL;
using System.Security.Cryptography;
using TinyFx.Security;
using UGame.Banks.Client.BLL.Tejeepay;

namespace UGame.Banks.Client.BLL.Letspay
{
    public class LetspayClient: BaseClient
    {
        public LetspayClient(string clientName = "xxyy.banks"):base(clientName)
        {
                
        }

        /// <summary>
        /// letsPay充值
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<LetsCommonPayDto>> LetsPay(XxyyLetsCommonPayIpo xxyyIpo)
        {
            var ipo = new LetsCommonPayIpo
            {
                BankId = "letspay",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId=xxyyIpo.CountryId,
                email = xxyyIpo.email,
                Meta = xxyyIpo.Meta,
                name = xxyyIpo.name,
                phone = xxyyIpo.phone,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp,
                ActivityIds= xxyyIpo.ActivityIds,
                IsAddBalance=xxyyIpo.IsAddBalance,
                BankCode=xxyyIpo.BankCode
            };
            SetIpoData(ipo);
            var rsp = await PostJson<LetsCommonPayIpo, LetsCommonPayDto>(ipo, "api/bank/letspay/pay");
            return rsp;
        }

        /// <summary>
        /// letspay提现
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<BaseDto>> LetsCash(XxyyLetsProxyPayIpo xxyyIpo)
        {
            var ipo = new LetsProxyPayIpo
            {
                BankId = "letspay",
                Amount = xxyyIpo.Amount,
                CashRate=xxyyIpo.CashRate,
                AppId = xxyyIpo.AppId,
                AppOrderId =xxyyIpo.AppOrderId,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId=xxyyIpo.CountryId,
                UserIp = xxyyIpo.UserIp,
                UserId=xxyyIpo.UserId,
                accountName = xxyyIpo.accountName,
                accountNo = xxyyIpo.accountNo,
                bankCode = xxyyIpo.bankCode,
                cashAuditId = xxyyIpo.cashAuditId,
                cpf = xxyyIpo.cpf,
                email = xxyyIpo.email,
                Meta=xxyyIpo.Meta,
                phone = xxyyIpo.phone,
                ReceiveBonus= 0,
                ReqComment=xxyyIpo.ReqComment,
                RequestUUID=null,
                taxId=xxyyIpo.taxId
            };
            SetIpoData(ipo);
            var rsp = await PostJson<LetsProxyPayIpo, BaseDto>(ipo,"api/bank/letspay/cash");
            return rsp;
        }

        /// <summary>
        /// letsPay充值(mex)
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<LetsCommonPayDto>> LetsPayMex(XxyyLetsCommonPayIpo xxyyIpo)
        {
            var ipo = new LetsCommonPayIpo
            {
                BankId = "letspay_mex",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId = "MEX",
                email = string.IsNullOrWhiteSpace(xxyyIpo.email)? "test@lucro777.com" : xxyyIpo.email,
                Meta = xxyyIpo.Meta,
                name = xxyyIpo.name,
                phone = string.IsNullOrWhiteSpace(xxyyIpo.phone)? "9784561230" : xxyyIpo.phone,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp,
                ActivityIds = xxyyIpo.ActivityIds,
                IsAddBalance = xxyyIpo.IsAddBalance,
                BankCode= "CLABE"
            };
            SetIpoData(ipo);
            var rsp = await PostJson<LetsCommonPayIpo, LetsCommonPayDto>(ipo, "api/bank/letspay/pay");
            return rsp;
        }

        /// <summary>
        /// letspay提现(MEX)
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<BaseDto>> LetsCashMex(XxyyLetsProxyPayIpo xxyyIpo)
        {
            var ipo = new LetsProxyPayIpo
            {
                BankId = "letspay_mex",
                Amount = xxyyIpo.Amount,
                CashRate = xxyyIpo.CashRate,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.AppOrderId,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId = "MEX",
                UserIp = xxyyIpo.UserIp,
                UserId = xxyyIpo.UserId,
                accountName = xxyyIpo.accountName,
                accountNo = xxyyIpo.accountNo,
                bankCode = xxyyIpo.bankCode,
                cashAuditId = xxyyIpo.cashAuditId,
                cpf = xxyyIpo.cpf,
                email = xxyyIpo.email,
                Meta = xxyyIpo.Meta,
                phone = xxyyIpo.phone,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                mode="bank"
            };
            SetIpoData(ipo);
            var rsp = await PostJson<LetsProxyPayIpo, BaseDto>(ipo, "api/bank/letspay/cash");
            return rsp;
        }


        public async Task<ApiResult<List<BankCodeModel>>> BankList(XxyyGetBankListIpo xxyyIpo)
        {
            var ipo = new GetBankListIpo
            {
                UserId = xxyyIpo.UserId,
                AppId = xxyyIpo.AppId,
                BankId = "letspay_mex",
                CountryId = xxyyIpo.CountryId
            };
            var rsp = await PostJson<GetBankListIpo, List<BankCodeModel>>(ipo, "api/bank/banklist");
            return rsp;
        }
    }
}
