using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using UGame.Banks.Service.Services.Query;
using TinyFx.AspNet;
using UGame.Banks.Hubtel.CallbackSvc;
using UGame.Banks.Hubtel;
using TinyFx.Data.SqlSugar;
using UGame.Banks.Service;
using Xxyy.Banks.DAL;

namespace UGame.Banks.JOB.Controllers
{
    /// <summary>
    /// 验证订单接口
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [IgnoreActionFilter]
    public class BankOrdersController: ControllerBase
    {
        /// <summary>
        /// 验证订单
        /// </summary>
        /// <returns></returns>
        [HttpPost,AllowAnonymous]
        public async Task VerifyOrders(UGame.Banks.Service.Services.SyncOrders.VerifyOrderIpo ipo)
        {
            var utcNow = ipo.VerifyTime = DateTime.UtcNow;
            var ipoJson = SerializerUtil.SerializeJsonNet(ipo);
            try
            {
                LogUtil.Info("0.BankOrdersController.VerifyOrders,收到同步银行订单请求ipo:{0},开始验证订单！utcNow:{1}", ipoJson,utcNow);
                await new BankService().VerifyOrders(ipo);
                LogUtil.Info("1.BankOrdersController.VerifyOrders,收到同步银行订单请求ipo:{0}，验证订单完成！utcNow:{1}", ipoJson,utcNow);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "2.验证订单异常！BankOrdersController.VerifyOrders！ipo:{0},utcNow:{1}", ipoJson,utcNow);
            }
        }

        [HttpGet,AllowAnonymous]
        public async Task<IActionResult> SyncHubtelAccount()
        {
            var proxy = new UGame.Banks.Hubtel.BankProxy();
            var balanceRet = await proxy.QueryPosSalesAccount();
            if (balanceRet?.Data.Amount >= 1m)
            {
                var transferRet=await proxy.BalanceTransfer(balanceRet.Data.Amount);
                return Ok(transferRet);
            }
            return Ok("无操作");
        }

        [HttpGet,AllowAnonymous]
        public async Task<IActionResult> QueryHubtelAccount()
        {
            var proxy = new UGame.Banks.Hubtel.BankProxy();
            var ret=await proxy.QueryPrepaidAccount();
            return Ok(ret);
        }

        [HttpGet, AllowAnonymous]
        public async Task<IActionResult> QueryHubtelOrder(string orderId)
        {
            var repo = DbUtil.GetRepository<Sb_bank_orderPO>();
            var orderPo = await repo.GetFirstAsync(x => x.OrderID == orderId);
            if (null == orderPo)
                return NotFound();
            var proxy = new UGame.Banks.Hubtel.BankProxy();
            if (orderPo.OrderType == (int)OrderTypeEnum.Charge)
            {
                var payRet =await proxy.ReceiveMoneyStatusCheck(orderId);
                return Ok(payRet);
            }
            var cashRet =await proxy.SendMoneyStatusCheck(orderId);
            return Ok(cashRet);
        }
    }
}
