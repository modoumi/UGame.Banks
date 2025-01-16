using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Configuration;
using TinyFx.Logging;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Letspay.Resp;
using UGame.Banks.Letspay.Service;
using UGame.Banks.Service;
using Xxyy.Banks.DAL;

namespace UGame.Banks.Letspay.Controllers
{
    //[ApiController]
    [Route("api/bank/letspay")]
    [AllowAnonymous]
    //[ApiAccessFilter("default")]
    //[IgnoreActionFilter]
    public class PayController : TinyFxControllerBase
    {
        //private PayService _paySvc = new();
        private QueryService _querySvc = new();

        /// <summary>
        /// PayIn
        /// </summary>
        /// <returns></returns>
        [HttpPost("pay")]
        public async Task<LetsCommonPayDto> CommpnPay(LetsCommonPayIpo ipo)
        {
            LogUtil.Info($"请求CommpnPay接口, req:{SerializerUtil.SerializeJsonNet(ipo)}");
            if (ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)
            {
                if (ipo.CountryId != "MEX")
                {
                    var braRet = await new PayService().CommpnPay(ipo);
                    if (braRet.Status == PartnerCodes.RS_OK && !string.IsNullOrWhiteSpace(braRet.code))
                    {
                        var braCallbackSvc = new CallbackService();
                        var payNotifyIpo = new PayInAsyncResponse
                        {
                            mchId = "704891365954",
                            orderNo = braRet.OrderId,
                            amount = braRet.TransMoney.ToString(),
                            product = "baxipix",
                            paySuccTime = DateTime.UtcNow.ToTimestamp(true, true).ToString(),
                            status = "2",
                            sign = ""
                        };
                        await braCallbackSvc.PayCallback(payNotifyIpo);
                    }
                    return braRet;
                }
                var mexRet = await new PayServiceCommon().CommpnPay(ipo);
                if (mexRet.Status == PartnerCodes.RS_OK && !string.IsNullOrWhiteSpace(mexRet.payUrl))
                {
                    var mexCallbackSvc = new MexCallbackService();
                    var payNotifyIpo = new PayInAsyncResponse
                    {
                        mchId = "704943232745",
                        orderNo = mexRet.OrderId,
                        amount = mexRet.OrderMoney.ToString(),
                        product = "mexbank",
                        paySuccTime = DateTime.UtcNow.ToTimestamp(true, true).ToString(),
                        status = "2",
                        sign = ""
                    };
                    await mexCallbackSvc.PayCallback(payNotifyIpo);
                }
                return mexRet;
            }
            else
            {
                if (ipo.CountryId != "MEX")
                {
                    return await new PayService().CommpnPay(ipo);
                }
                return await new PayServiceCommon().CommpnPay(ipo);
            }
        }

        /// <summary>
        /// PayOut
        /// </summary>
        /// <returns></returns>
        [HttpPost("cash")]
        public async Task<LetsProxyPayDto> ProxyPay(LetsProxyPayIpo ipo)
        {
            LogUtil.Info($"请求ProxyPay接口, req:{SerializerUtil.SerializeJsonNet(ipo)}");
            if (ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)
            {
                if (ipo.CountryId != "MEX")
                {
                    var braRet= await new PayService().ProxyPay(ipo);
                    if (braRet.Status == PartnerCodes.RS_OK)
                    {
                        await Task.Factory.StartNew(async (object obj) => {
                            try
                            {
                                var braRet = obj as LetsProxyPayDto;
                                await Task.Delay(TimeSpan.FromSeconds(2));
                                var callbackSvc = new CallbackService();
                                var cashNotifyIpo = new PayOutAsyncResponse
                                {
                                    mchId = "704891365954",
                                    mchTransNo = braRet.OrderId,
                                    amount = braRet.OrderMoney.ToString(),
                                    status = "2",
                                    transSuccTime = DateTime.UtcNow.ToTimestamp(true,true).ToString(),
                                    msg = "ok"
                                };
                                await callbackSvc.CashCallback(cashNotifyIpo);
                            }
                            catch
                            {

                            }    
                        },braRet,TaskCreationOptions.LongRunning);
                        
                    }
                    return braRet;
                }
                var mexRet= await new PayServiceCommon().ProxyPay(ipo);
                if (mexRet.Status == PartnerCodes.RS_OK)
                {
                    await Task.Factory.StartNew(async (Object obj) => {
                        var mexRet = obj as LetsProxyPayDto;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        var mexCallbackSvc = new MexCallbackService();
                        var mexCashNotifyIpo = new PayOutAsyncResponse
                        {
                            mchId = "704943232745",
                            mchTransNo = mexRet.OrderId,
                            amount = mexRet.OrderMoney.ToString(),
                            status = "2",
                            transSuccTime = DateTime.UtcNow.ToTimestamp(true,true).ToString(),
                            msg = "ok"
                        };
                        await mexCallbackSvc.CashCallback(mexCashNotifyIpo);
                    },mexRet,TaskCreationOptions.LongRunning);
                }
                return mexRet;
            }
            else
            {
                if (ipo.CountryId != "MEX")
                {
                    return await new PayService().ProxyPay(ipo);
                }
                return await new PayServiceCommon().ProxyPay(ipo);
            }
        }

        

        ///// <summary>
        ///// querypayorder
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("querypayorder")]
        //public async Task<QueryPayOrderResponse> QueryPayOrder(QueryPayOrderIpo ipo)
        //{
        //    LogUtil.Info($"请求QueryPayOrder接口, req:{SerializerUtil.SerializeJsonNet(ipo)}");
        //    return await _querySvc.QueryPayOrder(ipo);
        //}

        ///// <summary>
        ///// querytransorder
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("querytransorder")]
        //public async Task<QueryTransOrderResponse> QueryTransOrder(QueryTransOrderIpo ipo)
        //{
        //    LogUtil.Info($"请求QueryTransOrder接口, req:{SerializerUtil.SerializeJsonNet(ipo)}");
        //    return await _querySvc.QueryTransOrder(ipo);
        //}
    }
}
