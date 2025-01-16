using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using UGame.Banks.Service.Common;
using UGame.Banks.Service;
using UGame.Banks.Service.Services.Pay;
using TinyFx.Data;
using UGame.Banks.Hubtel;
using Microsoft.AspNetCore.Http;
using UGame.Banks.Service.Caching;
using Xxyy.Banks.DAL;
using TinyFx.Logging;
using Xxyy.DAL;
using Xxyy.Common;
using TinyFx.AspNet;
using TinyFx.Configuration;
using Newtonsoft.Json.Linq;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services;
using Serilog.Enrichers;
using StackExchange.Redis;
using UGame.Banks.Hubtel.CallbackSvc;


namespace UGame.Banks.Hubtel.PaySvc
{
    public class PayService : BankServiceBase,ICashFeeService
    {
        //private HttpRequest _request;
        //private static readonly Sb_bank_orderMO _bankOrderMo = new();
        //private readonly S_userMO _userMo = new();
        //private static readonly Sb_order_trans_logMO _orderTransLog = new();
        private const string BANKID = "hubtel";
        //private const int AMOUNT = 100000;

        ///// <summary>
        ///// 
        ///// </summary>
        //public PayService()
        //{
        //    _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext!.Request;
        //}



        /// <summary>
        /// hubtel支付
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<PayDto> Pay(PayIpo ipo)
        {
            if (string.IsNullOrWhiteSpace(ipo.Mobile))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"支付时Mobile不能为空");

            if (string.IsNullOrWhiteSpace(ipo.Channel))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"支付时Channel不能为空");
            if (ipo.Amount <= 0)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于0");
            if (string.IsNullOrWhiteSpace(ipo.BankId))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值时BankId不能为空");

            var ret = BankUtil.CreateDto<PayDto>(ipo);

            try
            {
                var proxy = new BankProxy(BANKID);
                var func = async (TransactionManager tm) =>
                {
                    ////生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    //var proxy = new BankProxy(BANKID);
                    await proxy.Pay(ipo, ret);
                };
                //1.执行下单和支付流程
                await Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Hubtel,null, (int)ipo.Channel.Replace("-", "").ToEnum<HubtelChannelEnum>(), func);
                //测试环境自动回调
                if (proxy._hubtelConfig.IsTesting&&ret.OperatorSuccess)
                {
                    var orderEo = await _bankOrderMo.GetByPKAsync(ipo.OrderId);
                    var payCallbackIpo = new PayCallbackIpo {
                        Message = "success",
                        ResponseCode="0000",
                        Data=new PayCallbackIpo.ReceiveMoneyCallbackResponseData { 
                           Amount=orderEo.OrderMoney,
                           Charges= ipo.PayFee,
                           AmountAfterCharges=orderEo.OrderMoney-ipo.PayFee,
                           Description= "The MTN Mobile Money payment has been approved and processed successfully.",
                           ClientReference=ipo.OrderId,
                           TransactionId=ret.BankOrderId,
                           ExternalTransactionId="",
                           AmountCharged= orderEo.OrderMoney,
                           OrderId=ret.BankOrderId
                        }
                    };
                    var callbackContext = BankCallbackContext.Create(payCallbackIpo, orderEo);
                    await new CallbackService().PayCallback(callbackContext);
                }
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : "支付出错";
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage("通过hubtel代收异常！")
                    .AddException(ex)
                    .AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
                    .AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));
            }
            return ret;
        }


        protected override void SetSbBankOrderEo(Sb_bank_orderEO order, PayIpoBase ipo)
        {
            var mlpayIpo = (CashIpo)ipo;
            order.AccName = mlpayIpo.Mobile;
            order.AccNumber = mlpayIpo.Mobile;
            order.BankCode = mlpayIpo.Mobile;
        }

        /// <summary>
        /// hubtel提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<CashDto> Cash(CashIpo ipo)
        {
            if (string.IsNullOrWhiteSpace(ipo.Mobile))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现时Mobile不能为空");
            if (string.IsNullOrWhiteSpace(ipo.Channel))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现时Channel不能为空");
            if (ipo.Amount <= 0)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现金额Amount必须大于0");
            if (string.IsNullOrWhiteSpace(ipo.BankId))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"提现时BankId不能为空");

            var ret = BankUtil.CreateDto<CashDto>(ipo);
            try
            {
                var proxy = new BankProxy(BANKID);
                var func = async (TransactionManager tm) =>
                {
                    //生成我方传给对方的交易流水号
                    ipo.OwnOrderId = ipo.OrderId;
                    //var proxy = new BankProxy(BANKID);
                    await proxy.Cash(ipo, ret);
                };
                //1.执行下单和支付流程
                await Execute(ipo, ret, OrderTypeEnum.Draw, PayTypeEnum.Hubtel, null, (int)ipo.Channel.Replace("-", "").ToEnum<HubtelChannelEnum>(), func, System.Data.IsolationLevel.RepeatableRead);
                //测试环境自动回调
                if (proxy._hubtelConfig.IsTesting&&ret.OperatorSuccess)
                {
                    var orderEo = await _bankOrderMo.GetByPKAsync(ipo.OrderId);
                    var cashCallbackIpo = new CashCallbackIpo { 
                      Message="",
                      ResponseCode="0000",
                      Data=new CashCallbackIpo.SendMoneyCallbackResponseData { 
                       TransactionId=orderEo.BankOrderId,
                       ExternalTransactionId="",
                       OrderId=null,
                       Description= "The MTN Mobile Money payment has been approved and processed successfully.",
                       ClientReference=ipo.OrderId,
                       Amount=orderEo.OrderMoney,
                       AmountDebitted=0,
                       Charges=ipo.CashFee
                      }
                    };
                    var callbackContext = BankCallbackContext.Create(cashCallbackIpo, orderEo);
                    await new CallbackService().CashCallback(callbackContext);
                }
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = exc != null ? exc.Message : "代付出错";
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage("通过hubtel代收异常！")
                    .AddException(ex)
                    .AddField("bank.ipo", SerializerUtil.SerializeJsonNet(ipo))
                    .AddField("bank.dto", SerializerUtil.SerializeJsonNet(ret));
            }
            return ret;
        }

        /// <summary>
        /// 获取hubtel可用的channels
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<ChannelsDto> GetChannels(ChannelsIpo ipo)
        {
            var ret = new ChannelsDto()
            {
                Status = PartnerCodes.RS_OK
            };
            try
            {
                await BankUtil.CheckAndSetIpo(ipo);
                ret.Channels = JObject.Parse(DbBankCacheUtil.GetBank(BANKID).BankConfig).SelectToken("Channels").Value<string>().Split(",",StringSplitOptions.RemoveEmptyEntries); //ConfigUtil.AppConfigs.GetOrDefault<HubtelConfig>("hubtel",new HubtelConfig { Channels= "mtn-gh,vodafone-gh,tigo-gh" }).Channels.Split(",", StringSplitOptions.RemoveEmptyEntries);
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
            }
            return ret;
        }

        public decimal Fee(CalcCashFeeIpo ipo)
        {
            if (ipo.UserFeeAmount == 0)
            {
                var money = ipo.Amount.AToM(ipo.CurrencyId);
                // var hubtelChannel = ipo.AdditionalParameters?.GetValueOrDefault("hubtelChannel","").ToString();
                //ipo.AdditionalParameters.TryGet<string>("hubtelChannel",out string hubtelChannel);
                if(string.IsNullOrWhiteSpace(ipo.AdditionalParameters))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, "hubtel通道不能为空！");
                var hubtelChannelObj = JObject.Parse(ipo.AdditionalParameters);
                var hubtelChannel = hubtelChannelObj.SelectToken("hubtelChannel")?.Value<string>();
                if (string.IsNullOrWhiteSpace(hubtelChannel))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX,"hubtel通道不能为空！");

                var ret = new BankProxy(BANKID).CalcCashFee(money, hubtelChannel);
                return ret;
            }
            return ipo.UserFeeAmount.AToM(ipo.CurrencyId);
        }
    }
}
