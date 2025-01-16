using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using Xxyy.Banks.Mongopay.Models.Dto;
using Xxyy.Banks.Mongopay.PaySvc;
using Xxyy.Banks.Mongopay.QuerySvc;

namespace Xxyy.Banks.Mongopay.Controller
{
    /// <summary>
    /// spei充值
    /// </summary>
    [Route("api/bank/mongopay")]
    //[ApiAccessFilter("default")]
    [AllowAnonymous]
    public class Pay2Controller : TinyFxControllerBase
    {
        private MongoPayService _paySvc = new();
        private QueryService _querySvc = new();
        private readonly Service.MongoPayService _payService = new();

        /// <summary>
        /// spei支付
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("pay/spei2")]
        public async Task<SpeiDto> Pay(SpeiIpo ipo)
        {
            LogUtil.Info($"mongopay.pay:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _paySvc.Pay(ipo);
        }

        /// <summary>
        /// spei提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [Route("cash/spei2")]
        [HttpPost]
        public async Task<CashSpeiDto> Cash(CashSpeiIpo ipo)
        {
            LogUtil.Info($"mongopay.cash:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _paySvc.Cash(ipo);
        }

        /// <summary>
        /// 一次性付款码
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pay/spei3")]
        public async Task<PayDto> Pay(PayIpo ipo)
        {
            LogUtil.Info($"mongopay.pay:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _payService.Pay(ipo);
        }

        /// <summary>
        /// 获取指定渠道（如：mongopay）下的银行代码和名称列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("query/banknamelist2")]
        public async Task<GetBankNameListDto> GetBankNameList(BankNameListIpo ipo)
        {
            LogUtil.Info($"mongopay.banknamelist:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _querySvc.GetBankNameList(ipo);
        }
    }
}
