//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Primitives;
//using Microsoft.Net.Http.Headers;
//using Org.BouncyCastle.Asn1.Ocsp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx;
//using TinyFx.AspNet;
//using TinyFx.Data;
//using TinyFx.Security;
//using Xxyy.Banks.BLL;
//using Xxyy.Banks.BLL.Caching;
//using Xxyy.Banks.BLL.Common;
//using Xxyy.Banks.BLL.Services.Pay;
//using Xxyy.Banks.DAL;
//using Xxyy.Banks.Inx.Core;
//using Xxyy.Common;
//using Xxyy.DAL;

//namespace Xxyy.Banks.Inx.Controller
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [Route("api/bank/inx/callback")]
//    [IgnoreActionFilter]
//    [ApiController]
//    public class CallbackController : ControllerBase
//    {        
//        private InxPayService _paySvc = new();
//        /// <summary>
//        /// 
//        /// </summary>
//        public CallbackController()
//        {
          
//        }

        

//        /// <summary>
//        /// inx银行对应的visa支付回调
//        /// </summary>
//        /// <returns></returns>
//        [HttpPost]
//        [Route("visa")]
//        public async Task<bool> Visa([FromForm]VisaPayCallbackIpo ipo)
//        {
//            return await _paySvc.VisaCallback(ipo);
//        }

//    }
//}
