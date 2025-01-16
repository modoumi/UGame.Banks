using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TinyFx.AspNet;
using TinyFx.Configuration;
using TinyFx.Extensions.RabbitMQ;
using UGame.Banks.Service;
using UGame.Banks.Service.MQMsg;
using UGame.Banks.Service.Services.Consumers;
using UGame.Banks.Service.Services.Query;
using UGame.Banks.Service.Services.SyncOrders;
using UGame.Banks.Hubtel;

//using Xxyy.Banks.Pandapay;
using Xxyy.MQ.Bank;

namespace UGame.Banks.WebAPI.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet, RequestIpFilter("callback.pandapay")]
        public string[] demo()
        {
            return new string[] { "11", Environment.MachineName, AspNetUtil.GetRemoteIpString(), this.HttpContext.Connection.RemoteIpAddress.ToString() };
        }

        //[HttpGet]
        //public async Task<IActionResult> testpoint()
        //{
        //    var sub = new UserFirstPayMQSub();
        //    var msg = new UserFirstPayMsg
        //    {
        //        CurrencyId = "BRL",
        //        UserFee = 0,
        //        OwnFee = 0.07m,
        //        PayAmount = 100000,
        //        OperatorId = "own_lobby_bra8",
        //        PayTime = DateTime.UtcNow,
        //        PayType = 5,
        //        UserId = "65310e682917eeab16c30d9c",
        //        //AppId = "lobby",
        //        OrderID = "65310f4d56117743ef2d69d8",
        //        UserKind = 1,
        //        //ReceiveBonus = 2,
        //        Meta = "{\"appsflyerid\":\"123\"}",
        //        CountryId = "BRA"
        //    };
        //    await sub.SendAppsflyerPayPointRequest(msg,CancellationToken.None);
        //    return Ok();
        //}

        [HttpGet]
        public async Task<string[]> demo2()
        {
            //var svc= new BankService();
            //await svc.VerifyOrders(ipo);
            //return null;

            ////await MQUtil.PublishAsync(new PayPointMsg
            ////{
            ////    Currency = "BRL",
            ////    Fee = 0,
            ////    FromId = "lucro30xpurchase",
            ////    FromMode = 2,
            ////    Gaid = "058D87A2-6293-4736-B3AB-C0C4CD4B8CF1",
            ////    Money = 31.125M,
            ////    OperatorId = "own_lobby_bra",
            ////    PayTime = DateTime.UtcNow,
            ////    PayType = 5,
            ////    PointName = "",
            ////    Transactionid = "058D87A2-6293-4736-B3AB-C0C4CD4B8CF1",
            ////    UserId = "61a6a718-c427-47ca-954f-cd689efc5015"
            ////});
            //await MQUtil.PublishAsync(new BankErrorMsg
            //{
            //    BankId = "tejeepay",
            //    Channel = 0,
            //    ErrorMsg = "",
            //    Money = 1.5m,
            //    OrderId = "111111",
            //    OrderType = BLL.OrderTypeEnum.Charge,
            //    Paytype = BLL.PayTypeEnum.Tejeepay,
            //    RecDate = DateTime.UtcNow,
            //    Remark = "",
            //    UserId = "aaaaa"
            //});
            //return null;

            //await MQUtil.PublishAsync(new UserFirstPayMsg
            //{
            //    CurrencyId = "BRL",
            //    UserFee = 0,
            //    OwnFee = 0.15m,
            //    PayAmount = 100000,
            //    OperatorId = "own_lobby_bra",
            //    PayTime = DateTime.UtcNow,
            //    PayType = 5,
            //    UserId = "2915780c-5ca0-4b2d-966c-c8adb9945d3f",
            //    //AppId = "lobby",
            //    OrderID = "28131bd8-79d5-431a-adfa-8308238bba48",
            //    UserKind = 1,
            //    //ReceiveBonus = 2,
            //    Meta = "{\"appsflyerid\":\"123\"}",
            //    CountryId = "BRA"
            //});
            //var pandaconfig = ConfigUtil.AppConfigs.Get<PandapayConfig>("pandapay");
            //var pandaconfig = ConfigUtil.GetCustomConfig<PandapayConfig>("pandapay");

            var test = ConfigUtil.AppConfigs.GetOrDefault<HubtelConfig>("hubtel",new HubtelConfig { Channels=""}).Channels.Split(",", StringSplitOptions.RemoveEmptyEntries);

            var disableFaceBookPoint = ConfigUtil.AppSettings.GetOrDefault("PayPoint.DisableFaceBookPoint", true);
            return new string[] { "11", Environment.MachineName, AspNetUtil.GetRemoteIpString(), this.HttpContext.Connection.RemoteIpAddress.ToString(), $"disableFaceBookPoint:{disableFaceBookPoint}" };
        }
    }
}
