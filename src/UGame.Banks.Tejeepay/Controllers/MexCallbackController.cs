using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TinyFx.Logging;
using TinyFx;
using TinyFx.AspNet;
using UGame.Banks.Tejeepay.Resp;
using UGame.Banks.Tejeepay.Service;

namespace UGame.Banks.Tejeepay.Controllers
{
    [ApiController]
    [Route("api/bank/tejeepaymex/callback")]
    [IgnoreActionFilter]
    [RequestIpFilter("callback.tejeepay")]
    public class MexCallbackController : ControllerBase
    {
        private MexCallbackService _paySvc = new("tejeepay_mex");
        private readonly ILogger<CallbackController> _logger;

        public MexCallbackController(ILogger<CallbackController> logger)
        {
            _logger = logger;
        }

        [HttpPost("payNotify")]
        public async Task<string> PayInNotify([FromBody] CommonPayAsyncResponse resp)
        {
            var json = JsonConvert.SerializeObject(resp);
            LogUtil.Info($"tejeePayInNotify֧���ص�ipo��{json}");
            var ret = await _paySvc.PayCallback(resp);
            return ret.status;
        }

        [HttpPost("cashNotify")]
        public async Task<string> CashNotify([FromBody] ProxyPayAsyncResponse resp)
        {
            LogUtil.Info($"tejeePayOutNotify���ֻص�ipo��{resp}");
            var ret = await   _paySvc.CashCallback(resp);
            return ret.status;
        }
    }
}