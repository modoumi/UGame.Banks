using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Logging;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using Xxyy.Banks.DAL;
using UGame.Banks.BFpay.Service;
using System.Web;
using Xxyy.Common;
using System.Globalization;
using Microsoft.IdentityModel.Tokens;
using UGame.Banks.BFpay.Common;
using UGame.Banks.BFpay.IpoDto;

namespace UGame.Banks.BFpay.Controllers
{
    [ApiController]
    [Route("api/bank/bfpay/callback")]
    [IgnoreActionFilter]
    [RequestIpFilter("callback.bfpay")]
    public class CallbackController : ControllerBase
    {
        private readonly Sb_bank_orderMO _orderMo = new();
         
//           {
//	"body": {
//		"amount": "9900",
//		"biz": "ca001",
//		"chargeTime": "20240531024039",
//		"mchtId": "2001027000142831",
//		"orderId": "665961a98b2280e185c905c3",
//		"payType": "bq",
//		"phone": "",
//		"seq": "00eb1af0ce934c8493d435ee90e50eef",
//		"status": "SUCCESS",
//		"tradeId": "1796415297645121536"
//	},
//	"head": {
//		"respCode": "0000",
//		"respMsg": "Request success"
//	},
//	"sign": "7a48b599a03ebe66d3ac3344eca3e73f"
//}
 
        /// <summary>
        /// 代收回调 60/120/180/240/300
        /// </summary>
        /// <param name="resp"></param>
        /// <returns></returns>
        [HttpPost("paynotify")]
        public async Task<string> PayInNotify([FromBody]PayNotifyIpo ipo)
        {
            //1.获取order
            var orderEo = await _orderMo.GetByPKAsync(ipo.body.OrderId);
            if (null == orderEo)
                return "SUCCESS";
            
           //2.构建context
            var callbackContext = BankCallbackContext.Create(ipo,orderEo);
            //3.调用callback处理逻辑
            var _svc = CallbackSvcUtil.Create(orderEo.BankID,orderEo.CountryID);
            if (!string.IsNullOrEmpty(ipo.body.ChargeTime))
            {
                callbackContext.OrderEo.BankTime = DateTime.ParseExact(ipo.body.ChargeTime,"yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToUtcTime(orderEo.OperatorID);
            }
            var ret = await _svc.PayCallback(callbackContext);
            return ret==0? "SUCCESS":"";
        }

//        {
//	"batchOrderNo": "665ea4791934896c4a184f0e",
//	"detail": [
//		{
//			"amount": "1300",
//			"desc": "success",
//			"detailId": "17978613491705487361",
//			"finishTime": "20240604022715",
//			"seq": "1",
//			"status": "SUCCESS"

//        }
//	],
//	"status": "DONE",
//	"totalAmount": "1300",
//	"totalNum": "1",
//	"tradeId": "1797861349170548736"
//}
//{"body":"bLy5COlwnMLaPvb9ntmHqYYUp1H9n1sAw68zRC5xLiTJ2xU%2BtjCalrnzN750KN%2Fy1VXhZpU%2Bk5DWtoDvYityCcMudpqJc9tsqA7nFFVxxm7s5uM2BzM0Ti9hws5zcEz04Kqymie%2Bie3PcA6MgKg8tGEaOYphdWWGJbxWjbmJ00fB11Ev5PZzM9DAy%2BMbGwE0hiZlk67axp9rj0oOBQjy7HBzPdadREnlM2Epy9fayaCtT%2FV8IX%2Fmmq9tTxQAaOK0R2W2Xa8FnfXXJVsVQi3XtXyGEUpsrqsna6hqKb%2Fb9w5%2FhA9Fg1y9P2UJZC9PHUzIEFPNoVZj4oh9KqHLARJzx0CU%2FuRDTVia%2BNsQ%2Bqhc86JJeALOUzcjndNI2fz2vbyUQzFiO9tmLn97%2BQfEHn3y3nL0xtgfUy1L1b6Lm3kc0IndbdMSbadJwYRETkrC9NJzQWdRpBF0om7n5tfaaqC2aKrbvgtYxHsLiviqe6ojlX%2FHB1Jtdn%2FB%2BIf59BNy%2BFUt","head":{"respCode":"0000","respMsg":"Request success"}}

    /// <summary>
    /// 代付回调 60/120/180/240/300
    /// </summary>
    /// <param name="resp"></param>
    /// <returns></returns>
    [HttpPost("cashnotify")]
        public async Task<string> CashNotify([FromBody] CashNotifyIpo ipo)
        {
            var _bank = DbBankCacheUtil.GetBank("bfpay_bra");

            var _bankConfig = SerializerUtil.DeserializeJsonNet<BfpayConfig>(_bank.BankConfig);

            string data = RSAUtils.decrypt(HttpUtility.UrlDecode(ipo.body.ToString()), _bankConfig.PrivateKey);//jo["body"].ToString()

            var body = JsonConvert.DeserializeObject<CashNotifyIpo.Body>(data);
            if (!(body.Detail[0].Status == "SUCCESS" || body.Detail[0].Status == "FAIL"))

            {
                return "";
            }
            //1.获取order
            var orderEo = await _orderMo.GetByPKAsync(body.BatchOrderNo);
            if (null == orderEo)
                return "SUCCESS";

            //2.构建context
            var callbackContext = BankCallbackContext.Create(body, orderEo);
            //3.调用callback处理逻辑
            var _svc = CallbackSvcUtil.Create(orderEo.BankID, orderEo.CountryID);

            if (!string.IsNullOrEmpty(body.Detail[0].FinishTime))
            {
                callbackContext.OrderEo.BankTime = DateTime.ParseExact(body.Detail[0].FinishTime, "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToUtcTime(orderEo.OperatorID);
            }

            var ret = await _svc.CashCallback(callbackContext);
            return ret == 0 ? "SUCCESS" : "";
        }
    }
}
