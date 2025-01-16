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
using UGame.Banks.Mlpay.Common;
using UGame.Banks.Mlpay.IpoDto;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.MQMsg;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Common;

namespace UGame.Banks.Mlpay.Service
{
    public abstract class CallbackService:PayCallbackServiceBase2
    {

        public override bool CheckPaySuccess(BankCallbackContext context) => ((PayNotifyIpo)context.Ipo).status == 1;

        public override bool CheckCashSuccess(BankCallbackContext context) => ((CashNotifyIpo)context.Ipo).status == 1;

        public override async Task CheckSign(BankCallbackContext context)
        {
            var bankEo = DbBankCacheUtil.GetBank(context.OrderEo.BankID);
            var mlpayConfig = SerializerUtil.DeserializeJsonNet<MlpayConfig>(bankEo.BankConfig);
            if (mlpayConfig.IsTesting)
                return;
            var businessKey = context.OrderEo.OrderType == (int)OrderTypeEnum.Charge ? mlpayConfig.PayKey : mlpayConfig.CashKey;
            var ownSignStr = SignHelper.GetSign(context.Ipo, businessKey);
            var signPropertyName = context.OrderEo.OrderType switch {
                (int)OrderTypeEnum.Charge=>nameof(PayNotifyIpo.sign),
                (int)OrderTypeEnum.Draw=>nameof(CashNotifyIpo.sign),
                _=>throw new Exception($"未知的ordertype:{context.OrderEo.OrderType}!")
            };
            var ipoSignStr = ReflectionUtil.GetPropertyValue<string>(context.Ipo, signPropertyName);
            if (ipoSignStr != ownSignStr)
            {
                LogUtil.GetContextLogger()
                   .AddMessage($"mlpay订单orderid:{context.OrderEo.OrderID}通知签名不匹配！req.sign:{ipoSignStr},ownsign:{ownSignStr}")
                   .AddField("mlpay.ipo", SerializerUtil.SerializeJsonNet(context.Ipo))
                   .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning);
                throw new Exception($"orderid:{context.OrderEo.OrderID},ipo.sign:{ipoSignStr},ownsign:{ownSignStr}计算签名不匹配！");
            }
        }

        public override async Task CheckIpo(BankCallbackContext context)
        {
            var (ipoAmount, platformOrderId) = context.Ipo switch
            {
                PayNotifyIpo payNotifyIpo=>(payNotifyIpo.amount, payNotifyIpo.orderNo),
                CashNotifyIpo cashNotifyIpo=>(cashNotifyIpo.amount, cashNotifyIpo.withdrawNo),
                _=>throw new Exception($"未知的Ipo参数！ipo:{SerializerUtil.SerializeJsonNet(context.Ipo)}")
            };
            var money = ipoAmount / (decimal)this.MULTIPLE;
            if (context.OrderEo.OrderMoney != money)
                throw new Exception($"支付金额amount:{ipoAmount}与订单金额ordermoney:{context.OrderEo.OrderMoney}不一致！orderid:{context.OrderEo.OrderID}");
            if (context.OrderEo.BankOrderId != platformOrderId)
                throw new Exception($"合作方订单号不一致！BankOrderId:{context.OrderEo.BankOrderId},平台订单号:{platformOrderId}");
        }

        /// <summary>
        /// mlpay支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public virtual async Task<int> PayCallback(BankCallbackContext context)
        {
            var result = await Execute(context);
            return result?0:1;
        }

        /// <summary>
        /// mlpay提现回调
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
