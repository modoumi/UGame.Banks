using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using UGame.Banks.Hubtel.PaySvc;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Hubtel.Controller
{
    /// <summary>
    /// 充值
    /// </summary>
    //[ApiController]
    //[IgnoreActionFilter]
    [Route("api/bank/hubtel"),AllowAnonymous]
    public class PayController : TinyFxControllerBase
    {
        private PayService _paySvc = new();


        /// <summary>
        /// hubtel支付（充值）
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("pay")]
        public async Task<PayDto> Pay(PayIpo ipo)
        {
            return await _paySvc.Pay(ipo);
        }

        /// <summary>
        /// hubtel提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [Route("cash")]
        [HttpPost]
        public async Task<CashDto> Cash(CashIpo ipo)
        {
            return await _paySvc.Cash(ipo);
        }

        /// <summary>
        /// 获取hubtel下的可用channels列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("channels")]
        public async Task<ChannelsDto> GetChannels(ChannelsIpo ipo)
        {
            return await _paySvc.GetChannels(ipo);
        }
    }
}
