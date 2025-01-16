using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx.Configuration;
using UGame.Banks.BFpay.Common;
using UGame.Banks.BFpay.IpoDto;
using UGame.Banks.BFpay.Service;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using Xxyy.Banks.DAL;
using Xxyy.Common;

namespace UGame.Banks.BFpay.Controllers
{
    [Route("api/bank/bfpay")]
    [AllowAnonymous]
    //[ApiAccessFilter("default")]
    public class PayController : TinyFxControllerBase
    {
        private PayService _paySvc = new();
        /// <summary>
        /// PayIn
        /// </summary>
        /// <returns></returns>
        [HttpPost("pay")]
        public async Task<BfpayPayDto> Pay(BfpayPayIpo ipo)
        {
            var ret= await _paySvc.CommpnPay(ipo);
            //测试、仿真环境并且是配置的测试商户则自动回调
            var bankEo = DbBankCacheUtil.GetBank(ipo.BankId);
            var isTesting = JObject.Parse(bankEo.BankConfig).SelectToken("IsTesting")?.Value<bool>()??false;
            if ((ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging) && ret.Status == PartnerCodes.RS_OK && !string.IsNullOrWhiteSpace(ret.payUrl) && isTesting)
            {
                //1.获取order
                var orderEo = await new Sb_bank_orderMO().GetByPKAsync(ret.OrderId);
                //2.构建context
                var payNotifyIpo = new PayNotifyIpo()
                {
                    body = new PayNotifyIpo.Body()
                    {
                        OrderId = ret.OrderId,
                        Status = "SUCCESS",
                        Biz = "ca001",
                        ChargeTime = "",
                        Amount = ret.TransMoney.ToString(),
                        TradeId = ret.BankOrderId
                    },
                    head = new PayNotifyIpo.Head()
                    {
                        RespCode = "0000"
                    }
                };
                var callbackContext = BankCallbackContext.Create(payNotifyIpo, orderEo);
                //3.调用callback处理逻辑
                var _svc = CallbackSvcUtil.Create(orderEo.BankID, orderEo.CountryID);
                await _svc.PayCallback(callbackContext);
            }
            return ret;
        }

        /// <summary>
        /// PayOut
        /// </summary>
        /// <returns></returns>
        [HttpPost("cash")]
        public async Task<BfpayCashDto> Cash(BfpayCashIpo ipo)
        {
            var ret= await _paySvc.ProxyPay(ipo);
            var bankEo = DbBankCacheUtil.GetBank(ipo.BankId);
            var isTesting = JObject.Parse(bankEo.BankConfig).SelectToken("IsTesting")?.Value<bool>() ?? false;
            if ((ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging) && ret.Status == PartnerCodes.RS_OK && isTesting)
            {
                await Task.Factory.StartNew(async (object obj) =>
                {
                    var ret = obj as BfpayCashDto;
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    //1.获取order
                    var orderEo = await new Sb_bank_orderMO().GetByPKAsync(ret.OrderId);
                    //2.构建context
                    CashNotifyIpo.Body body = new CashNotifyIpo.Body()
                    {
                        TradeId = ret.BankOrderId,
                        Status = "SUCCESS",
                        BatchOrderNo = ret.OrderId,
                        Desc = "",
                        TotalAmount = ((int)ret.TransMoney).ToString(),
                        TotalNum = 1,
                        Detail = new CashNotifyIpo.Detail[] {new CashNotifyIpo.Detail() {   Amount = ((int)ret.TransMoney).ToString(),
                            Desc = "",
                            DetailId = ret.OrderId,
                            FinishTime = DateTime.UtcNow.ToLocalTimeByCountryId(orderEo.CountryID).ToString("yyyyMMddHHmmss"),
                            Seq = "1",
                            Status = "SUCCESS"} },
                    };
                    var callbackContext = BankCallbackContext.Create(body, orderEo);
                    //3.调用callback处理逻辑
                    var _svc = CallbackSvcUtil.Create(orderEo.BankID, orderEo.CountryID);
                    await _svc.CashCallback(callbackContext);
                }, ret, TaskCreationOptions.LongRunning);
            }
            return ret;
        }
    }
}
