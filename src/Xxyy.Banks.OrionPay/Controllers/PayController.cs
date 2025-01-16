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
using TinyFx.Logging;
using Xxyy.Banks.Orionpay.Dto;
using Xxyy.Banks.Orionpay.Ipo;
using Xxyy.Banks.Orionpay.Req;
using Xxyy.Banks.Orionpay.Resp;
using Xxyy.Banks.Orionpay.Service;

namespace Xxyy.Banks.Orionpay.Controllers
{
    //[ApiController]
    [Route("api/bank/Orionpay")]
    [AllowAnonymous]
    //[ApiAccessFilter("default")]
    //[IgnoreActionFilter]

    public class PayController : TinyFxControllerBase
    {
        //private readonly ILogger<PayController> _logger;
        //EntityContext _entityContext;
        //IConfiguration _config;
        //IHttp_Client _http_Client;
        //static string currencyType = "BRL";
        //static string host = System.Configuration.ConfigurationManager.AppSettings["Orionpay:host"]?.ToString();
        //static string merchantId = System.Configuration.ConfigurationManager.AppSettings["Orionpay:merchantId"]?.ToString();
        //static string merchantKey = System.Configuration.ConfigurationManager.AppSettings["Orionpay:merchantKey"]?.ToString();
        //static string orderId1 = Guid.NewGuid().ToString("N").Substring(new Random().Next(18), 15);
        //static string orderId2 = Guid.NewGuid().ToString("N").Substring(new Random().Next(18), 15);
        //static string publicKey = System.Configuration.ConfigurationManager.AppSettings["Orionpay:publicKey"]?.ToString();
        //static string privateKey = System.Configuration.ConfigurationManager.AppSettings["Orionpay:privateKey"]?.ToString();

        //public PayController(EntityContext  entityContext , ILogger<PayController> logger, IConfiguration  config, IHttp_Client http_Client)
        //{
        //    _logger = logger;
        //    _entityContext = entityContext;
        //    _config = config;
        //    _http_Client = http_Client;
        //    host = _config["Orionpay:host"]?.ToString();
        //    merchantId = _config["Orionpay:merchantId"]?.ToString();
        //    merchantKey = _config["Orionpay:merchantKey"]?.ToString();
        //    publicKey = _config["Orionpay:publicKey"]?.ToString();
        //    privateKey = _config["Orionpay:privateKey"]?.ToString();
        //}


        private PayService _paySvc = new();
        //private QueryService _querySvc = new();



        /// <summary>
        /// PayIn
        /// </summary>
        /// <returns></returns>
        [HttpPost("pay")]
        public async Task<OrionCommonPayDto> CommpnPay(OrionCommonPayIpo ipo)
        {
            LogUtil.Info($"请求CommpnPay接口, req:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _paySvc.CommpnPay(ipo);
        }

        /// <summary>
        /// PayOut
        /// </summary>
        /// <returns></returns>
        [HttpPost("cash")]
        public async Task<OrionProxyPayDto> ProxyPay(OrionProxyPayIpo ipo)
        {
            LogUtil.Info($"请求ProxyPay接口, req:{SerializerUtil.SerializeJsonNet(ipo)}");
            return await _paySvc.ProxyPay(ipo);
        }


        /// <summary>
        /// GetQRCode
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        [HttpPost("code")]
        public async Task<QRCodeDto> GetQRCode(QRCodeIpo ipo)
        {
            return await _paySvc.GetQRCode(ipo);
        }
    

   

 
    }
}