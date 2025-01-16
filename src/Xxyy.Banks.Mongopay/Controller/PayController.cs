using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.Mongopay.PaySvc;
using Xxyy.Banks.Mongopay.QuerySvc;

namespace Xxyy.Banks.Mongopay.Controller
{
    /// <summary>
    /// spei充值
    /// </summary>
    [ApiController]
    [IgnoreActionFilter]
    //[ApiAccessFilter("default")]
    [Route("api/bank/mongopay")]
    public class PayController : ControllerBase
    {
        private MongoPayService _paySvc = new();
        private QueryService _querySvc = new();

        /// <summary>
        /// spei支付
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("pay/spei")]
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
        [Route("cash/spei")]
        [HttpPost]
        public async Task<CashSpeiDto> Cash(CashSpeiIpo ipo)
        {
            LogUtil.Info($"mongopay.cash:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _paySvc.Cash(ipo);
        }

        /// <summary>
        /// 获取指定渠道（如：mongopay）下的银行代码和名称列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("query/banknamelist")]
        public async Task<GetBankNameListDto> GetBankNameList(BankNameListIpo ipo)
        {
            LogUtil.Info($"mongopay.banknamelist:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _querySvc.GetBankNameList(ipo);
        }
    }
}
