using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Web;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Configuration;
using TinyFx.Logging;
using TinyFx.Security;
using TinyFx.Text;
using UGame.Banks.Service;
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Ipo;
using UGame.Banks.Tejeepay.Resp;
using UGame.Banks.Tejeepay.Service;
using Xxyy.Banks.DAL;
using UGame.Banks.Tejeepay.Req;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Banks.Tejeepay.Controllers
{
    //[ApiController]
    [Route("api/bank/tejeepay")]
    //[ApiAccessFilter("default")]
    [AllowAnonymous]
    public class Pay2Controller : TinyFxControllerBase
    {
        private PayService _paySvc = new();
        private QueryService _querySvc= new();
        

        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        [HttpPost("pay2")]
        public async Task<TejeeCommonPayDto> CommpnPay(TejeeCommonPayIpo ipo)
        {
            LogUtil.Info($"请求CommpnPay接口 , req:{SerializerUtil.SerializeJsonNet(ipo)}");
            if (ConfigUtil.Environment.IsDebug || ConfigUtil.Environment.IsStaging)
            {
                var ret= await _paySvc.CommpnPay(ipo);
                if (ret.Status != PartnerCodes.RS_OK || string.IsNullOrWhiteSpace(ret.payUrl))
                {
                    return ret;
                }
                CallbackService callbackSvc = new();
                MexCallbackService mexcallbackSvc = new("tejeepay_mex");
                string publicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCIZse+6wVqXPtzou+CYWznruFt8wBoURPB+eOlRdkTasx9TgtygkUIU855Bo9h2VUmESqhkSWBeBA10AR1IMN3NSaW3OE+hdLC4d/HnhFt92oNrL+lNHmdLYvmhECnMX7Ib1hOFCOJuZOECKNPL7tJ+YN9RCJWqIPfkBilB3DEqQIDAQAB";
                var merchantId = "2000713000197336";
                var amount = ((long)ret.TransMoney).ToString();
                var ipo3 = new CommonPayAsyncResponse()
                {
                    Balance = 0,
                    body = new CommonPayAsynBody()
                    {
                        amount = amount,
                        mchtId = merchantId,
                        biz = "",
                        orderId =ret.OrderId, //jo3["orderId"].ToString(),
                        seq = Guid.NewGuid().ToString(),
                        payType = "bq101",
                        tradeId = ret.tradeId, //jo3["tradeId"].ToString(),
                        chargeTime = "",
                        status = "SUCCESS"
                    },
                    fee = 0,
                    head = new CommonPayAsynHead()
                    {
                        respCode = "0000",
                        respMsg = "请求成功"
                    }
                };
                if(string.IsNullOrWhiteSpace(ipo.CountryId))
                {
                    var userDCache = await GlobalUserDCache.Create(ipo.UserId);
                    var countryId = await userDCache.GetCountryIdAsync();
                    ipo.CountryId = countryId;
                }
                if(ipo.CountryId=="MEX")
                {
                    await mexcallbackSvc.PayCallback(ipo3);
                }
                else
                {
                    await callbackSvc.PayCallback(ipo3);
                }
                return new TejeeCommonPayDto { 
                 OrderId=ret.OrderId,
                 UserId=ipo.UserId,
                 CurrencyId=ipo.CurrencyId,
                 Status=PartnerCodes.RS_OK,
                 Amount=ipo.Amount,
                 BankOrderId=ret.tradeId,
                 tradeId=ret.tradeId,
                 mchtId=ret.mchtId,
                 payUrl=ret.payUrl,
                 RequestUUID=ipo.RequestUUID,
                 Message= ret.Message
                };
            }
            else
            {
                return await _paySvc.CommpnPay(ipo);
            }
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        [HttpPost("cash2")]
        public async Task<TejeeProxyPayDto> ProxyPay(TejeeProxyPayIpo ipo)
        {
            LogUtil.Info($"请求ProxyPay接口 , req:{SerializerUtil.SerializeJsonNet(ipo)}");
            if (ConfigUtil.Environment.IsDebug||ConfigUtil.Environment.IsStaging)
            {
                var ret = await _paySvc.ProxyPay(ipo);
                if (ret.Status == "RS_OK"||ret.Status== "SUCCESS")
                {
                    await Task.Factory.StartNew(async (Object param) => {
                        var ret = param as TejeeProxyPayDto;
                        await Task.Delay(TimeSpan.FromSeconds(2));
                        CallbackService callbackSvc = new();
                        MexCallbackService mexcallbackSvc = new("tejeepay_mex");
                        string publicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCIZse+6wVqXPtzou+CYWznruFt8wBoURPB+eOlRdkTasx9TgtygkUIU855Bo9h2VUmESqhkSWBeBA10AR1IMN3NSaW3OE+hdLC4d/HnhFt92oNrL+lNHmdLYvmhECnMX7Ib1hOFCOJuZOECKNPL7tJ+YN9RCJWqIPfkBilB3DEqQIDAQAB";
                        var amount = ((long)ret.TransMoney).ToString();
                        var body = new ProxyPayAsynBody
                        {
                            batchOrderNo = ret.batchOrderNo,
                            desc = "",
                            detail = new List<ProxyPayRespDetail> { new ProxyPayRespDetail{
                            detailId=ObjectId.NewId(),
                            amount=amount,
                            status="SUCCESS",
                            desc="",
                            seq="1"}},
                            status = "AUDIT_SUCCESS",
                            totalAmount = amount,
                            totalNum = "1",
                            tradeId = ret.tradeId
                        };
                        var resp = new ProxyPayAsyncResponse
                        {
                            Balance = 0,
                            fee = 0,
                            head = new ProxyPayAsynRespHead
                            {
                                respCode = "0000",
                                respMsg = "成功"
                            },
                            body = HttpUtility.UrlEncode(RSAUtils.encrypt(SerializerUtil.SerializeJsonNet(body), publicKey))
                        };
                        if (string.IsNullOrWhiteSpace(ipo.CountryId))
                        {
                            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
                            var countryId = await userDCache.GetCountryIdAsync();
                            ipo.CountryId = countryId;
                        }
                        if (ipo.CountryId == "MEX")
                        {
                            await mexcallbackSvc.CashCallback(resp);
                        }
                        else
                        {
                            await callbackSvc.CashCallback(resp);
                        }
                    },ret,TaskCreationOptions.LongRunning);
                }
                
                return new TejeeProxyPayDto
                {
                    Amount = ipo.Amount,
                    Balance = 0,
                    BankOrderId = ret.BankOrderId,
                    batchOrderNo = ret.batchOrderNo,
                    CurrencyId = ipo.CurrencyId,
                    mchtId = ret.mchtId,
                    Message = ret.Message,
                    Status = ret.Status,
                    tradeId = ret.tradeId,
                    OrderId=ipo.OrderId
                };
            }
            else
            {
                return await _paySvc.ProxyPay(ipo);
            }

        }

        ///// <summary>
        ///// 代收查询
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("payquery2")]
        //public async Task<TejeePayQueryDto> PayQuery(TejeePayQueryIpo ipo)
        //{

        //    return await _querySvc.PayQuery(ipo);
        //}

        ///// <summary>
        ///// 代付查询
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("proxyquery2")]
        //public async Task<TejeeProxyQueryDto> ProxyQuery(TejeeProxyQueryIpo ipo)
        //{

        //    return await _querySvc.ProxyQuery(ipo);
        //}

        /// <summary>
        /// 余额查询
        /// </summary>
        /// <returns></returns>
        [HttpPost("balancequery2")]
        public async Task<TejeeBalanceQueryDto> BalanceQuery(TejeeBalanceQueryIpo ipo)
        {

            return await _querySvc.BalanceQuery(ipo);
        }

        /// <summary>
        /// 获取tejeepay支持的指定国家的银行列表
        /// </summary>
        /// <returns></returns>
        [HttpPost("banklist")]
        public Task<List<Sb_bankcodePO>> BankList(TejeeBankListIpo ipo)
        {
            return Task.FromResult(_querySvc.GetBankList(ipo));
        }
    }
}