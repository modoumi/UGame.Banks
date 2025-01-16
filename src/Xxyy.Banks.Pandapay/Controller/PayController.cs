﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using Xxyy.Banks.Pandapay.PaySvc;

namespace Xxyy.Banks.Pandapay.Controller
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [IgnoreActionFilter]
    [Route("api/bank/pandapay")]
    //[ApiAccessFilter("default")]
    public class PayController : ControllerBase
    {
        private PandaPayService _paySvc = new();

        /// <summary>
        /// panda支付
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [HttpPost]
        [Route("pay")]
        public async Task<PandapayDto> Pay(PandapayIpo ipo)
        {
            LogUtil.Info($"pandapay.pay:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _paySvc.Pay(ipo);
        }

        /// <summary>
        /// panda提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [Route("cash")]
        [HttpPost]
        public async Task<PandaCashDto> Cash(PandaCashIpo ipo)
        {
            LogUtil.Info($"pandapay.cash:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _paySvc.Cash(ipo);
        }

        /// <summary>
        /// panda支持的银行列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [Route("banklist")]
        [HttpPost]
        public async Task<GetBankListDto> BankList(BankListIpo ipo)
        {
            LogUtil.Info($"pandapay.BankList:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _paySvc.GetBankList(ipo);
        }

        /// <summary>
        /// panda查询个人信息（）
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [Route("querydictkey")]
        [HttpPost]
        public async Task<QueryDictKeyDto> QueryDictKey(QueryDictKeyIpo ipo)
        {
            LogUtil.Info($"pandapay.QueryDictKey:1,ipo:{SerializerUtil.SerializeJsonNet(ipo)}");

            return await _paySvc.QueryDictKey(ipo);
        }
    }
}
