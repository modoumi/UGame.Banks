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
using UGame.Banks.Mlpay.Common;
using UGame.Banks.Mlpay.IpoDto;
using UGame.Banks.Mlpay.Service;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using Xxyy.Banks.DAL;

namespace UGame.Banks.Mlpay.Controllers
{
    [Route("api/bank/mlpay")]
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
        public async Task<MlpayPayDto> Pay(MlpayPayIpo ipo)
        {
            var ret= await _paySvc.CommpnPay(ipo);
            //测试、仿真环境并且是配置的测试商户则自动回调
            var bankEo = DbBankCacheUtil.GetBank(ipo.BankId);
            var isTesting = JObject.Parse(bankEo.BankConfig).SelectToken("IsTesting")?.Value<bool>()??false;
            if ((ConfigUtil.Environment.IsDebug ||ConfigUtil.Environment.IsStaging)&&ret.Status==PartnerCodes.RS_OK&&!string.IsNullOrWhiteSpace(ret.payUrl)&& isTesting)
            {
                //1.获取order
                var orderEo = await new Sb_bank_orderMO().GetByPKAsync(ret.OrderId);
                //2.构建context
                var payNotifyIpo=new PayNotifyIpo()
                {
                    status=1,
                    applicationId=182,
                    payWay=2,
                    partnerOrderNo=ret.OrderId,
                    orderNo=ret.BankOrderId,
                    amount=(int)ret.TransMoney
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
        public async Task<MlpayCashDto> Cash(MlpayCashIpo ipo)
        {
            var ret= await _paySvc.ProxyPay(ipo);
            var bankEo = DbBankCacheUtil.GetBank(ipo.BankId);
            var isTesting = JObject.Parse(bankEo.BankConfig).SelectToken("IsTesting")?.Value<bool>() ?? false;
            if ((ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)&&ret.Status==PartnerCodes.RS_OK&& isTesting)
            {
                await Task.Factory.StartNew(async (object obj) => {
                    var ret = obj as MlpayCashDto;
                    await Task.Delay(TimeSpan.FromSeconds(2));
                    //1.获取order
                    var orderEo = await new Sb_bank_orderMO().GetByPKAsync(ret.OrderId);
                    //2.构建context
                    var cashNotifyIpo = new CashNotifyIpo()
                    {
                        status = 1,
                        partnerWithdrawNo = ret.OrderId,
                        withdrawNo = ret.BankOrderId,
                        channelWithdrawNo = ret.BankOrderId,
                        amount = (int)ret.TransMoney
                    };
                    var callbackContext = BankCallbackContext.Create(cashNotifyIpo, orderEo);
                    //3.调用callback处理逻辑
                    var _svc = CallbackSvcUtil.Create(orderEo.BankID, orderEo.CountryID);
                    await _svc.CashCallback(callbackContext);
                },ret, TaskCreationOptions.LongRunning);
            }
            return ret;
        }
    }
}
