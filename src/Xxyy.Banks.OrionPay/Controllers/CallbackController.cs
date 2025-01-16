using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TinyFx.Logging;
using TinyFx;
using TinyFx.AspNet;
using Xxyy.Banks.Orionpay.Resp;
using Xxyy.Banks.Orionpay.Service;
using Xxyy.Banks.BLL;

namespace Xxyy.Banks.Orionpay.Controllers
{
    [ApiController]
    [Route("api/bank/Orionpay/callback")]
    [IgnoreActionFilter]
    [ApiAccessFilter("callback.orionpay")]
    public class CallbackController : ControllerBase
    {
        private CallbackService _paySvc = new();
        private readonly ILogger<CallbackController> _logger;

        public CallbackController(ILogger<CallbackController> logger)
        {
            _logger = logger;
        }

        [HttpPost("payNotify")]
        public async Task<string> PayNotify(OrionPayAsyncResponse resp)
        {
            var json = JsonConvert.SerializeObject(resp);
            LogUtil.Info($"OrionpayNotify支付回调ipo：{json}");
            if (resp.transactionMode == "DEPOSIT")
            {
                var ret = await _paySvc.PayCallback(resp);
                return ret.status;
            }
            else
            {
                var ret = await _paySvc.CashCallback(resp);
                return ret.status;
            }
        }
        //[HttpPost("PayCallback")]
        //public string PayInCallback([FromBody] dynamic resp)
        //{
        //    LogUtil.Info($"tejee_payinCallback支付回调ipo：{resp.ToString()}");
        //    var obj = JsonConvert.DeserializeObject(resp.ToString());
        //    return "SUCCESS";
        //}
        //[HttpPost("cashNotify")]
        //public async Task<string> CashNotify([FromBody] ProxyPayAsyncResponse resp)
        //{
        //    LogUtil.Info($"OrionpayOutNotify提现回调ipo：{resp}");
        //    var ret = await   _paySvc.CashCallback(resp);
        //    return ret.status;
        //}
    }
}