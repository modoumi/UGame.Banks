using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Hubtel
{
    public class HubtelClient:BaseClient
    {
        public HubtelClient(string clientName = "xxyy.banks") : base(clientName)
        {

        }

        /// <summary>
        /// 充值
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<BaseDto>> Pay(XxyyHubtelPayIpo xxyyIpo)
        {
            var ipo = new HubtelPayIpo
            {
                Channel=xxyyIpo.Channel,
                Mobile=xxyyIpo.Mobile,
                BankId = "hubtel",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId = xxyyIpo.CountryId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp,
                ActivityIds = xxyyIpo.ActivityIds,
                IsAddBalance = xxyyIpo.IsAddBalance
            };
            if (string.IsNullOrWhiteSpace(ipo.UserIp))
                ipo.UserIp = AspNetUtil.GetRemoteIpString();
            SetIpoData(ipo);
            var rsp = await PostJson<HubtelPayIpo, BaseDto>(ipo, "api/bank/hubtel/pay");
            return rsp;
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="xxyyIpo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<BaseDto>> Cash(XxyyHubtelCashIpo xxyyIpo)
        {
            var ipo = new HubtelCashIpo
            {
                BankId = "hubtel",
                Channel=xxyyIpo.Channel,
                Mobile=xxyyIpo.Mobile,
                Amount = xxyyIpo.Amount,
                CashRate = xxyyIpo.CashRate,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.AppOrderId,
                CurrencyId = xxyyIpo.CurrencyId,
                CountryId = xxyyIpo.CountryId,
                UserIp = xxyyIpo.UserIp,
                UserId = xxyyIpo.UserId,
                CashAuditId = xxyyIpo.CashAuditId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null
            };
            if (string.IsNullOrWhiteSpace(ipo.UserIp))
                ipo.UserIp = AspNetUtil.GetRemoteIpString();
            SetIpoData(ipo);
            var rsp = await PostJson<HubtelCashIpo, BaseDto>(ipo, "api/bank/hubtel/cash");
            return rsp;

        }
    }
}
