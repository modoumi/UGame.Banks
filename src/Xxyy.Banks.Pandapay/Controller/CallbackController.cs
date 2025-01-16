using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using Xxyy.Banks.Pandapay.CallbackSvc;

namespace Xxyy.Banks.Pandapay.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/bank/pandapay/callback")]
    [ApiController]
    [IgnoreActionFilter]
    [ApiAccessFilter("callback.pandapay")]
    public class CallbackController : ControllerBase
    {
        private CallbackService _paySvc = new();

        /// <summary>
        /// pandapay支付回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> Pay(PayCallbackIpo ipo)
        {
            if (ipo.type != "BRCODE")
                return BadRequest(new { status="fail", msg=$"错误的type类型:type={ipo.type}" });
            LogUtil.Info($"panda_paycallback支付回调ipo：{SerializerUtil.SerializeJsonNet(ipo)}");
            var result = await _paySvc.PayCallback(ipo);
            return Ok(result);
        }

        /// <summary>
        /// panda提现异步通知回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cash")]
        public async Task<IActionResult> Cash(CashCallbackIpo ipo)
        {
            LogUtil.Info($"panda_cashcallback提现回调ipo：{SerializerUtil.SerializeJsonNet(ipo)}");
            var result= await _paySvc.CashCallback(ipo);
            return Ok(result);
        }
    }
}
