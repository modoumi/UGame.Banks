using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using UGame.Banks.Client.BLL.Tejeepay;

namespace UGame.Banks.Client.BLL.Pandapay
{
    public class PandapayClient : BaseClient
    {
        public PandapayClient(string clientName = "xxyy.banks") : base(clientName)
        {

        }


        /// <summary>
        /// pandaPay充值
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<PandapayDto>> PandaPay(XxyyPandapayIpo xxyyIpo)
        {
            var ipo = new PandapayIpo
            {
                AccName = xxyyIpo.AccName,
                TaxId = xxyyIpo.TaxId,
                Amount = xxyyIpo.Amount,
                UserIp = xxyyIpo.UserIp,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                BankId = "pandapay",
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId
            };
            SetIpoData(ipo);
            var rsp = await PostJson<PandapayIpo, PandapayDto>(ipo, "api/bank/pandapay/pay2");
            return rsp;
        }

        /// <summary>
        /// pandapay提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<BaseDto>> PandaCash(XxyyPandaCashIpo xxyyIpo)
        {
            var ipo = new PandaCashIpo
            {
                AccName = xxyyIpo.AccName,
                TaxId = xxyyIpo.TaxId,
                AccNumber = xxyyIpo.AccNumber,
                AccountType = xxyyIpo.AccountType,
                BankCode = xxyyIpo.BankCode,
                BankName = xxyyIpo.BankName,
                BranchCode = xxyyIpo.BranchCode,
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.CashAuditId,
                BankId = "pandapay",
                CashAuditId = xxyyIpo.CashAuditId,
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = xxyyIpo.Meta,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp
            };
            SetIpoData(ipo);
            var rsp = await PostJson<PandaCashIpo, BaseDto>(ipo, "api/bank/pandapay/cash2");
            return rsp;
        }

        /// <summary>
        ///  获取pandapay支持的银行代码和名称列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<PandaBankListDto>> GetPandaBankList(XxyyPandaBankListIpo xxyyIpo)
        {
            var ipo = new BaseIpo
            {
                Amount = 0,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                BankId = "pandapay",
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = xxyyIpo.Meta,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId
            };
            SetIpoData(ipo);
            var rsp = await PostJson<BaseIpo, PandaBankListDto>(ipo, "api/bank/pandapay/banklist2");
            return rsp;
        }
        public async Task<ApiResult<QueryDictKeyDto>> QueryDictKey(XxyyQueryDictKeyIpo XxyyIpo)
        {
            var ipo = new QueryDictKeyIpo
            {
                Amount = 0,
                UserIp = null,
                AppId = XxyyIpo.AppId,
                AppOrderId = null,
                BankId = "pandapay",
                CurrencyId = XxyyIpo.CurrencyId,
                Meta = XxyyIpo.Meta,
                QueryKey = XxyyIpo.QueryKey,
                ReceiveBonus = 0,
                ReqComment = null,
                RequestUUID = null,
                UserId = XxyyIpo.UserId
            };
            SetIpoData(ipo);
            var rsp = await PostJson<QueryDictKeyIpo, QueryDictKeyDto>(ipo, "api/bank/pandapay/querydictkey2");
            return rsp;
        }

    }
}
