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
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Resp;
using UGame.Banks.Tejeepay.Service;
using UGame.Banks.Tejeepay.Req;
using Xxyy.Common;

namespace UGame.Banks.Tejeepay.Controllers
{
    [ApiController]
    [Route("api/bank/tejeepay")]
    //[ApiAccessFilter("default")]
    [IgnoreActionFilter]
    public class PayController : ControllerBase
    {
        //private readonly ILogger<PayController> _logger;
        //EntityContext _entityContext;
        //IConfiguration _config;
        //IHttp_Client _http_Client;
        //static string currencyType = "BRL";
        //static string host = System.Configuration.ConfigurationManager.AppSettings["tejeePay:host"]?.ToString();
        //static string merchantId = System.Configuration.ConfigurationManager.AppSettings["tejeePay:merchantId"]?.ToString();
        //static string merchantKey = System.Configuration.ConfigurationManager.AppSettings["tejeePay:merchantKey"]?.ToString();
        //static string orderId1 = Guid.NewGuid().ToString("N").Substring(new Random().Next(18), 15);
        //static string orderId2 = Guid.NewGuid().ToString("N").Substring(new Random().Next(18), 15);
        //static string publicKey = System.Configuration.ConfigurationManager.AppSettings["tejeePay:publicKey"]?.ToString();
        //static string privateKey = System.Configuration.ConfigurationManager.AppSettings["tejeePay:privateKey"]?.ToString();

        //public PayController(EntityContext  entityContext , ILogger<PayController> logger, IConfiguration  config, IHttp_Client http_Client)
        //{
        //    _logger = logger;
        //    _entityContext = entityContext;
        //    _config = config;
        //    _http_Client = http_Client;
        //    host = _config["tejeePay:host"]?.ToString();
        //    merchantId = _config["tejeePay:merchantId"]?.ToString();
        //    merchantKey = _config["tejeePay:merchantKey"]?.ToString();
        //    publicKey = _config["tejeePay:publicKey"]?.ToString();
        //    privateKey = _config["tejeePay:privateKey"]?.ToString();
        //}


        private PayService _paySvc = new();
        private QueryService _querySvc = new();


        /// <summary>
        /// 代收
        /// </summary>
        /// <returns></returns>
        [HttpPost("pay")]
        public async Task<TejeeCommonPayDto> CommpnPay(TejeeCommonPayIpo ipo)
        {
            LogUtil.Info($"请求CommpnPay接口 , req:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _paySvc.CommpnPay(ipo);
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <returns></returns>
        [HttpPost("cash")]
        public async Task<TejeeProxyPayDto> ProxyPay(TejeeProxyPayIpo ipo)
        {
            LogUtil.Info($"请求ProxyPay接口 , req:{SerializerUtil.SerializeJsonNet(ipo)}");
            if (ConfigUtil.Environment.IsDebug)
            {
                var ret = await _paySvc.ProxyPay(ipo);
                CallbackService callbackSvc = new();
                string publicKey = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCIZse+6wVqXPtzou+CYWznruFt8wBoURPB+eOlRdkTasx9TgtygkUIU855Bo9h2VUmESqhkSWBeBA10AR1IMN3NSaW3OE+hdLC4d/HnhFt92oNrL+lNHmdLYvmhECnMX7Ib1hOFCOJuZOECKNPL7tJ+YN9RCJWqIPfkBilB3DEqQIDAQAB";
                var body = new ProxyPayAsynBody
                {
                    batchOrderNo = ret.batchOrderNo,
                    desc = "",
                    detail = new List<ProxyPayRespDetail> { new ProxyPayRespDetail{
                            detailId=ObjectId.NewId(),
                            amount=(ipo.Amount.AToM(ipo.CurrencyId)*100).ToString(),
                            status="SUCCESS",
                            desc="",
                            seq="1"}},
                    status = "AUDIT_SUCCESS",
                    totalAmount = (ipo.Amount.AToM(ipo.CurrencyId) * 100).ToString(),
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
                    body =HttpUtility.UrlEncode(RSAUtils.encrypt(SerializerUtil.SerializeJsonNet(body),publicKey))
                };

                await callbackSvc.CashCallback(resp);
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
                    tradeId = ret.tradeId
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
        //[HttpPost("payquery")]
        //public async Task<TejeePayQueryDto> PayQuery(TejeePayQueryIpo ipo)
        //{

        //    return await _querySvc.PayQuery(ipo);
        //}

        ///// <summary>
        ///// 代付查询
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("proxyquery")]
        //public async Task<TejeeProxyQueryDto> ProxyQuery(TejeeProxyQueryIpo ipo)
        //{

        //    return await _querySvc.ProxyQuery(ipo);
        //}

        ///// <summary>
        ///// 余额查询
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost("balancequery")]
        //public async Task<TejeeBalanceQueryDto> BalanceQuery(TejeeBalanceQueryIpo ipo)
        //{

        //    return await _querySvc.BalanceQuery(ipo);
        //}







    }
}