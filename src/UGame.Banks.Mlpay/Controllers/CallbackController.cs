using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using UGame.Banks.Mlpay.Common;
using UGame.Banks.Mlpay.IpoDto;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using Xxyy.Banks.DAL;
using UGame.Banks.Mlpay.Service;

namespace UGame.Banks.Mlpay.Controllers
{
    [ApiController]
    [Route("api/bank/mlpay/callback")]
    [IgnoreActionFilter]
    [RequestIpFilter("callback.mlpay")]
    public class CallbackController : ControllerBase
    {
        private readonly Sb_bank_orderMO _orderMo = new();
        /// <summary>
        /// 代收回调 60/120/180/240/300
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>
        [HttpGet("paynotify")]
        public async Task<int> PayInNotify([FromQuery]PayNotifyIpo ipo)
        {
            //1.获取order
            var orderEo = await _orderMo.GetByPKAsync(ipo.partnerOrderNo);
            if (null == orderEo)
                return 1;
            
           //2.构建context
            var callbackContext = BankCallbackContext.Create(ipo,orderEo);
            //3.调用callback处理逻辑
            var _svc = CallbackSvcUtil.Create(orderEo.BankID,orderEo.CountryID);
            var ret = await _svc.PayCallback(callbackContext);
            return ret;
        }

        /// <summary>
        /// 代付回调 60/120/180/240/300
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>
        [HttpGet("cashnotify")]
        public async Task<int> CashNotify([FromQuery]CashNotifyIpo ipo)
        {
            //1.获取order
            var orderEo = await _orderMo.GetByPKAsync(ipo.partnerWithdrawNo);
            if (null == orderEo)
                return 1;
            
            //2.构建context
            var callbackContext = BankCallbackContext.Create(ipo, orderEo);
            //3.调用callback处理逻辑
            var _svc = CallbackSvcUtil.Create(orderEo.BankID, orderEo.CountryID);
            var ret = await _svc.CashCallback(callbackContext);
            return ret;
        }
    }
}
