//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx.AspNet;
//using Xxyy.Banks.BLL.Services.Pay;

//namespace Xxyy.Banks.Inx.Controller
//{
//    /// <summary>
//    /// 充值
//    /// </summary>
//    [ApiController]
//    [IgnoreActionFilter]
//    [Route("api/bank/inx/pay")]
//    public class PayController : ControllerBase
//    {
//        private InxPayService _paySvc = new();


//        /// <summary>
//        /// visa支付
//        /// </summary>
//        /// <param name="ipo"></param>
//        /// <returns></returns>
//        [HttpPost]
//        [Route("visa")]
//        public async Task<VisaDto> Visa(VisaIpo ipo)
//        {
//            return await _paySvc.VisaPay(ipo);
//        }
//    }
//}
