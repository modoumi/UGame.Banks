using Amazon.S3.Model.Internal.MarshallTransformations;
using Lobby.Flow;
using Microsoft.AspNetCore.Mvc;
using TinyFx.Configuration;
using TinyFx.Extensions.RabbitMQ;
using UGame.Banks.Client.BLL.Hubtel;
using UGame.Banks.Client.BLL.Tejeepay;
using Xxyy.MQ.Lobby;
using Xxyy.MQ.Xxyy;

namespace test.Controllers
{
    public class TestMessage : IMQMessage
    {
        public int Id { get; set; }
        public string Name { get; set; }
       //public object MQMeta { get; set; }
        public MQMessageMeta MQMeta { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
                await MQUtil.FuturePublishAsync(new AutoAuditMsg
                {
                    Amount = -2000000,
                    Bonus = 0,
                    AppId = "lobby",
                    ChangeTime = DateTime.UtcNow,
                    Coin = 0,
                    CountryId = "BRA",
                    CurrencyId = "BRL",
                    CurrencyType = Xxyy.Common.CurrencyType.Cash,
                    DomainId = "",
                    EndBalance = 195525840,
                    EndBonus = 0,
                    EndCoin = 0,
                    FlowMultip = 0,
                    FromId = "own_lobby_bra13",
                    FromMode = 0,
                    OperatorId = "own_lobby_bra13",
                    Reason = "24Сʱ���Զ�����",
                    SourceId = "6687cb64ff6f800c29d450d6",
                    SourceTable = "sc_cash_audit",
                    SourceType = 1,
                    UserId = "6687c9dba220dec1e50252da",
                    UserKind = Xxyy.Common.UserKind.User
                }, ConfigUtil.Environment.IsProduction ? TimeSpan.FromHours(24) : TimeSpan.FromSeconds(5));
            
            //for (var i = 0; i < 100; i++)
            //{
            //    await MQUtil.FuturePublishAsync(new AutoAuditMsg
            //    {
            //        Amount = 200000,
            //        Bonus = 0,
            //        AppId = "lobby",
            //        ChangeTime = DateTime.UtcNow,
            //        Coin = 0,
            //        CountryId = "BRA",
            //        CurrencyId = "BRL",
            //        CurrencyType = Xxyy.Common.CurrencyType.Cash,
            //        DomainId = "",
            //        EndBalance = 110894992,
            //        EndBonus = 0,
            //        EndCoin = 0,
            //        FlowMultip = 0,
            //        FromId = "own_lobby_bra13",
            //        FromMode = 0,
            //        OperatorId = "own_lobby_bra13",
            //        Reason = "24Сʱ���Զ�����",
            //        SourceId = "1111",
            //        SourceTable = "sc_cash_audit",
            //        SourceType = 1,
            //        UserId = "66879e1ca220dec1e502518b",
            //        UserKind = Xxyy.Common.UserKind.User
            //    }, ConfigUtil.Environment.IsProduction ? TimeSpan.FromHours(24) : TimeSpan.FromSeconds(10));
            //}
            //var flowsvc = FlowServiceFactory.CreateFlowService("66879e1ca220dec1e502518b", "lobby","own_lobby_bra13");
            //var cashret =await flowsvc.RequestCash(new Lobby.Flow.IpoDto.FlowCashIpo { 
            // AppId="lobby",
            // Amount=20,
            // CountryId="BRA",
            // CurrencyId="BRL",
            // UserId= "66879e1ca220dec1e502518b",
            // OperatorId="own_lobby_bra13",
            // UserBankId= "6687a323c87abfec0d8876b7"
            //});

            //var flowsvc = FlowServiceFactory.CreateFlowService("66852c4aa220dec1e5024f15","lobby","own_lobby_bra");
            //await flowsvc.CashAudit(new Lobby.Flow.IpoDto.FlowCashAuditIpo { 
            //  BonusMultip=100,
            //   CashAuditId= "668657ed2d6bcd013181346a",
            //    Status=0
            //});

            var client = new HubtelClient();
            //var feeRet = await client.CashFee(new UGame.Banks.Client.BLL.XxyyCalcCashFeeIpo
            //{
            //    Amount = 1000000,
            //    AppId = "lobby",
            //    BankId = "hubtel",
            //    CountryId = "GHA",
            //    CurrencyId = "GHS",
            //    UserId = "661601875a28ee8602116b77",
            //    AdditionalParameters=new Dictionary<string, string> {
            //        ["HubtelChannel"]= "mtn-gh"
            //    }
            //});


            //var payret = await client.Pay(new XxyyHubtelPayIpo
            //{
            //    Mobile = "233552378058",
            //    Channel = "mtn-gh",
            //    Amount = 20000,
            //    AppId = "lobby",
            //    CurrencyId = "GHS",
            //    ReceiveBonus = 2,
            //    ReqComment = "",
            //    UserId = "661601875a28ee8602116b77",
            //    UserIp = "127.0.0.1",
            //    CountryId = "GHA",
            //    ActivityIds = null,
            //    IsAddBalance = true
            //});


            //var cashret = await client.Cash(new XxyyHubtelCashIpo
            //{
            //    Mobile = "2330552378058",
            //    Channel = "mtn-gh",
            //    AppOrderId = "",
            //    CountryId = "GHA",
            //    UserIp = "127.0.0.1",
            //    UserId = "661601875a28ee8602116b77",
            //    ReqComment = "",
            //    Amount = 200,
            //    AppId = "lobby",
            //    CashAuditId = "",
            //    CurrencyId = "GHS",
            //});
            return Ok();
            //return Ok(cashret);
        }
    }
}
