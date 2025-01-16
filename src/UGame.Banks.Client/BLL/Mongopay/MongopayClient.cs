using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Mongopay
{
    public class MongopayClient : BaseClient
    {
        public MongopayClient(string clientName = "xxyy.banks") : base(clientName)
        {

        }

        /// <summary>
        /// spei充值
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<MongopayDto>> SpeiPay(XxyyMongopayIpo xxyyIpo)
        {
            var ipo = new BaseIpo
            {
                BankId = "mongopay",
                Amount = xxyyIpo.Amount,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = xxyyIpo.ReceiveBonus,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp
            };
            SetIpoData(ipo);
            var rsp = await PostJson<BaseIpo, MongopayDto>(ipo, "api/bank/mongopay/pay/spei2");
            return rsp;
        }


        /// <summary>
        /// spei提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<BaseDto>> SpeiCash(XxyyMongoCashIpo xxyyIpo)
        {
            var ipo = new MongoCashIpo
            {
                BankId = "mongopay",
                Amount = xxyyIpo.Amount,
                BankCode = xxyyIpo.BankCode,
                AccName = xxyyIpo.AccName,
                AccNumber = xxyyIpo.AccNumber,
                AppId = xxyyIpo.AppId,
                AppOrderId = xxyyIpo.CashAuditId,
                CashAuditId = xxyyIpo.CashAuditId,
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = xxyyIpo.Meta,
                ReceiveBonus = 0,
                ReqComment = xxyyIpo.ReqComment,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = xxyyIpo.UserIp
            };
            SetIpoData(ipo);
            var rsp = await PostJson<MongoCashIpo, BaseDto>(ipo, "api/bank/mongopay/cash/spei2");
            return rsp;
        }

        /// <summary>
        ///  获取mongopay支持的银行代码和名称列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<ApiResult<MongoBankListDto>> BankNameList(XxyyMongoBankListIpo xxyyIpo)
        {
            var ipo = new BaseIpo
            {
                BankId = "mongopay",
                Amount = 0,
                AppId = xxyyIpo.AppId,
                AppOrderId = null,
                CurrencyId = xxyyIpo.CurrencyId,
                Meta = null,
                ReceiveBonus = 0,
                ReqComment = null,
                RequestUUID = null,
                UserId = xxyyIpo.UserId,
                UserIp = null
            };
            SetIpoData(ipo);
            var rsp = await PostJson<BaseIpo, MongoBankListDto>(ipo, "api/bank/mongopay/query/banknamelist2");
            return rsp;
        }
    }
}
