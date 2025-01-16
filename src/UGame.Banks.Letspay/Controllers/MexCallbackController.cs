using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx.Logging;
using UGame.Banks.Letspay.Resp;
using UGame.Banks.Letspay.Service;
using UGame.Banks.Service;

namespace UGame.Banks.Letspay.Controllers
{
    [ApiController]
    [Route("api/bank/letspay/mexcallback")]
    [IgnoreActionFilter]
    [RequestIpFilter("callback.letspay")]
    public class MexCallbackController : ControllerBase
    {
        private MexCallbackService _paySvc = new();
        private readonly ILogger<CallbackController> _logger;

        public MexCallbackController(ILogger<CallbackController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 代收回调 60/120/180/240/300
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>

        [HttpPost("payNotify")]
        public async Task<string> PayInNotify([FromForm] PayInAsyncResponse resp)
        {
            var json = JsonConvert.SerializeObject(resp);
            LogUtil.Info($"letsPayInNotify支付回调ipo：{json}");
            var ret = await _paySvc.PayCallback(resp);
            return ret.status;
        }

        /// <summary>
        /// 代付回调 60/120/180/240/300
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>
        [HttpPost("cashNotify")]
        public async Task<string> CashNotify([FromForm] PayOutAsyncResponse resp)
        {
            LogUtil.Info($"letsPayOutNotify提现回调ipo：{resp}");
            var ret = await _paySvc.CashCallback(resp);
            return ret.status;
        }
    }
}
