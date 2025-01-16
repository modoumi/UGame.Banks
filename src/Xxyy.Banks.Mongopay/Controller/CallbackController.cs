using Microsoft.AspNetCore.Mvc;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using Xxyy.Banks.Mongopay.CallbackSvc;
using Xxyy.Banks.Mongopay.Models.Dto;

namespace Xxyy.Banks.Mongopay.Controller
{

    /// <summary>
    /// 
    /// </summary>
    [Route("api/bank/mongopay/callback")]
    [ApiController]
    [IgnoreActionFilter]
    public class CallbackController : ControllerBase
    {
        private CallbackService _paySvc = new();

        private Service.CallbackService _callbackSvc = new();

        /// <summary>
        /// spei充值异步通知回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pay")]
        public async Task<string> SpeiPay([FromForm] SpeiPayNotifyIpo ipo)
        {
            LogUtil.Info($"speipaycallback-ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _paySvc.SpeiPayCallback(ipo);
        }

        /// <summary>
        /// mogonPay一次性付款码回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pay3")]
        public async Task<string> SpeiPay3([FromForm] PayNotifyIpo ipo)
        {
            LogUtil.Info($"speipaycallback-ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _callbackSvc.SpeiPayCallback(ipo);
        }

        /// <summary>
        /// spei提现异步通知回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cash")]
        public async Task<string> SpeiCash([FromForm] SpeiCashNotifyIpo ipo)
        {
            LogUtil.Info($"speicashcallback-ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _paySvc.SpeiCashCallback(ipo);
        }
    }
}
