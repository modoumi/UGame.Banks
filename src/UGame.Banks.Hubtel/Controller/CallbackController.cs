using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.Logging;
using TinyFx.Security;
using UGame.Banks.Hubtel.CallbackSvc;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using UGame.Banks.Hubtel.PaySvc;
using Xxyy.Common;
using Xxyy.DAL;

namespace UGame.Banks.Hubtel.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/bank/hubtel/callback")]
    [IgnoreActionFilter]
    [ApiController]
    [RequestIpFilter("callback.hubtel")]
    public class CallbackController : ControllerBase
    {
        private readonly Sb_bank_orderMO _orderMo = new();
        private CallbackService _paySvc = new();
        /// <summary>
        /// 
        /// </summary>
        public CallbackController()
        {

        }



        /// <summary>
        /// hubtel支付回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("pay")]
        public async Task<string> Pay(PayCallbackIpo ipo)
        {
            LogUtil.Info($"hubtel_paycallback支付回调ipo：{SerializerUtil.SerializeJson(ipo)}");
            var orderEo = await _orderMo.GetByPKAsync(ipo?.Data.ClientReference);
            if (orderEo == null)
            {
                LogUtil.GetContextLogger().SetLevel( Microsoft.Extensions.Logging.LogLevel.Error).AddMessage($"hubtel充值回调参数异常，未找到订单！{nameof(ipo.Data.ClientReference)}:{ipo?.Data.ClientReference}");
                return "FAIL";
            }
            var callbackContext = BankCallbackContext.Create(ipo, orderEo);
            var ret= await _paySvc.PayCallback(callbackContext);
            return ret ? "SUCCESS" : "FAIL";
        }

        /// <summary>
        /// hubtel提现异步通知回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("cash")]
        public async Task<string> Cash(CashCallbackIpo ipo)
        {
            LogUtil.Info($"hubtel_paycallback提现回调ipo：{SerializerUtil.SerializeJson(ipo)}");
            var orderEo = await _orderMo.GetByPKAsync(ipo?.Data.ClientReference);
            if (orderEo == null)
            {
                LogUtil.GetContextLogger().SetLevel(Microsoft.Extensions.Logging.LogLevel.Error).AddMessage($"hubtel提现回调参数异常，未找到订单！{nameof(ipo.Data.ClientReference)}:{ipo?.Data.ClientReference}");
                return "FAIL";
            }
            //return await _paySvc.CashCallback(ipo);
            var callbackContext = BankCallbackContext.Create(ipo, orderEo);
            var ret = await _paySvc.CashCallback(callbackContext);
            return ret ? "SUCCESS" : "FAIL";
        }

        /// <summary>
        /// hubtel账户内部转账回调
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("transfer")]
        public async Task<IActionResult> transfer(HubtelCallbackIpoBase<BalanceTransferCallbackIpo> ipo)
        {
             await _paySvc.TransferOrder(ipo);
            return Ok();
        }
    }
}
