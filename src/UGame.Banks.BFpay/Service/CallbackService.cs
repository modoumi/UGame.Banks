using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Reflection;
using UGame.Banks.BFpay.Common;
using UGame.Banks.BFpay.IpoDto;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.MQMsg;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Common;

namespace UGame.Banks.BFpay.Service
{
    public abstract class CallbackService:PayCallbackServiceBase2
    {

        public override bool CheckPaySuccess(BankCallbackContext context) => ((PayNotifyIpo)context.Ipo).body.Status == "SUCCESS";

        public override bool CheckCashSuccess(BankCallbackContext context) => ((CashNotifyIpo.Body)context.Ipo).Detail[0].Status == "SUCCESS";

        public override async Task CheckSign(BankCallbackContext context)
        {
            var bankEo = DbBankCacheUtil.GetBank(context.OrderEo.BankID);
            var BfpayConfig = SerializerUtil.DeserializeJsonNet<BfpayConfig>(bankEo.BankConfig);
            if (BfpayConfig.IsTesting)
                return;
            var businessKey = context.OrderEo.OrderType == (int)OrderTypeEnum.Charge ? BfpayConfig.PayKey : BfpayConfig.CashKey;
         
            var signPropertyName = context.OrderEo.OrderType switch {
                (int)OrderTypeEnum.Charge=>nameof(PayNotifyIpo.sign),
                (int)OrderTypeEnum.Draw=>"",
                _=>throw new Exception($"未知的ordertype:{context.OrderEo.OrderType}!")
            };
            if (!string.IsNullOrEmpty(signPropertyName))
            {
                var ownSignStr = SignHelper.GetSign(((PayNotifyIpo)context.Ipo).body, businessKey);

                var ipoSignStr = ReflectionUtil.GetPropertyValue<string>(context.Ipo, signPropertyName);
                if (ipoSignStr != ownSignStr)
                {
                    LogUtil.GetContextLogger()
                       .AddMessage($"bfpay订单orderid:{context.OrderEo.OrderID}通知签名不匹配！req.sign:{ipoSignStr},ownsign:{ownSignStr}")
                       .AddField("bfpay.ipo", SerializerUtil.SerializeJsonNet(context.Ipo))
                       .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
                    throw new Exception($"orderid:{context.OrderEo.OrderID},ipo.sign:{ipoSignStr},ownsign:{ownSignStr}计算签名不匹配！");
                }
            }
          
        }

        public override async Task CheckIpo(BankCallbackContext context)
        {
            var (ipoAmount, platformOrderId) = context.Ipo switch
            {
                PayNotifyIpo payNotifyIpo=>(Convert.ToInt64(payNotifyIpo.body.Amount), payNotifyIpo.body.TradeId),
                CashNotifyIpo.Body cashNotifyIpo =>(Convert.ToInt64(cashNotifyIpo.TotalAmount), cashNotifyIpo.TradeId),
                _=>throw new Exception($"未知的Ipo参数！ipo:{SerializerUtil.SerializeJsonNet(context.Ipo)}")
            };
            var money = ipoAmount / (decimal)this.MULTIPLE;
            if (context.OrderEo.OrderMoney != money)
                throw new Exception($"支付金额amount:{ipoAmount}与订单金额ordermoney:{context.OrderEo.OrderMoney}不一致！orderid:{context.OrderEo.OrderID}");
            if (context.OrderEo.BankOrderId != platformOrderId)
                throw new Exception($"合作方订单号不一致！BankOrderId:{context.OrderEo.BankOrderId},平台订单号:{platformOrderId}");
        }

        /// <summary>
        /// bfpay支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public virtual async Task<int> PayCallback(BankCallbackContext context)
        {
            var result = await Execute(context);
            return result?0:1;
        }

        /// <summary>
        /// bfpay提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public virtual async Task<int> CashCallback(BankCallbackContext context)
        {
            var result = await Execute(context);
            return result?0:1;
        }
    }
}
