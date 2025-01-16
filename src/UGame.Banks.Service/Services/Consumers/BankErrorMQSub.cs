using EasyNetQ;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.BIZ.RabbitMQ;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx.Security;
using UGame.Banks.Service.MQMsg;
using Xxyy.MQ.Bank;

namespace UGame.Banks.Service.Services.Consumers
{
    public class BankErrorMQSub : MQBizSubConsumer<BankErrorMsg>
    {
        private HttpClientEx _dingClient;
        public BankErrorMQSub()
        {
            _dingClient = HttpClientExFactory.CreateClientExFromConfig("dingtalk");
            AddHandler(SendDingtalk);
        }

        public override MQSubscribeMode SubscribeMode =>  MQSubscribeMode.OneQueue;

        protected override void Configuration(ISubscriptionConfiguration config)
        {
        }

        protected override Task OnMessage(BankErrorMsg message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task SendDingtalk(BankErrorMsg message, CancellationToken cancellationToken)
        {
            try
            {
                var timestamp = DateTime.UtcNow.ToTimestamp(true,true);
                var secret = _dingClient.GetSettingValue<string>("secret");
                var accessToken = _dingClient.GetSettingValue<string>("accessToken");
                var stringToSign = timestamp + "\n" + secret;
                var sign = SecurityUtil.HMACSHA256Hash(secret, stringToSign);

                var orderTypeMsg = message.OrderType == OrderTypeEnum.Charge ? "充值" : "提现";
                var dingtalkMsg = $"北京时间：{message.RecDate.AddHours(8)},用户userId：{message.UserId}通过{message.BankId}{orderTypeMsg}失败!orderId:{message.OrderId},金额：{message.Money},货币：{message.CurrencyId}";

                var jsoncontent = SerializerUtil.SerializeJsonNet(new { msgtype = "text", text = new { content =dingtalkMsg } });

                await _dingClient.CreateAgent()
              .AddUrl($"robot/send?access_token={accessToken}&timestamp={timestamp}&sign={sign}")
              .BuildJsonContent(jsoncontent)
              .PostStringAsync();
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex,"发送钉钉异常！msg:{0}",SerializerUtil.SerializeJsonNet(message));
            }
        }
    }
}
