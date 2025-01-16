using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Cash;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.MQ.Bank;

namespace Xxyy.Banks.Pandapay.CallbackSvc
{
    /// <summary>
    /// 
    /// </summary>
    public class CallbackService : PayCallbackServiceBase<CallbackIpoCommonBase, PandaCallbackDto>
    {
        private HttpRequest _request;
        private const string BANKID = "pandapay";
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_panda_user_barcodeMO _userBarcodeMO = new();
        private readonly Sb_order_trans_logMO _orderTranslogMo = new();
        //private string COMPANYNO = "P010";
        private const int MULTIPLE = 100;
        //private const decimal CASHFEE = 0.02m;
        private Sb_bankEO _bank;
        private decimal payoutFee = 0;
        private decimal payinFee = 0;
        /// <summary>
        /// 
        /// </summary>
        public CallbackService()
        {
            _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext?.Request;
            _bank = DbBankCacheUtil.GetBank(BANKID);
            payinFee = _bank.PayFee;
            payoutFee = _bank.CashFee;
        }



        /// <summary>
        /// panda支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<PandaCallbackDto> PayCallback(PayCallbackIpo ipo)
        {
            var ret =new PandaCallbackDto { status="success",msg=""};
            try
            {
                //-1.添加银行通讯日志
                await AddBankTransLog(ipo, ipo.transactionId, BANKID, _request.Path.Value, null, 0, null, null);
                LogUtil.Info($"pandapay.paycallback.2,param:{SerializerUtil.SerializeJsonNet(new { ipo,ret})}");
                //根据createCodeReference获取创建barcode时的传递的我方订单号ownorderId
                var userBarcodes = await _userBarcodeMO.GetByOwnOrderIdAsync(ipo.createCodeReference,1);
                if (null == userBarcodes|| userBarcodes.Count!=1)
                    throw new ArgumentException($"没有找到匹配的brcode！createCodeReference：{ipo.createCodeReference}");
                var userBarcode = userBarcodes.First();
                LogUtil.Info($"pandapay.paycallback.3,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret, userBarcodes })}");

                var userDcache = new GlobalUserDCache(userBarcode.UserID);
                if (!await userDcache.KeyExistsAsync())
                {
                    var s_userEo = await DbSink.BuildUserMo(userBarcode.UserID).GetByPKAsync(userBarcode.UserID);
                    if (null == s_userEo) throw new Exception($"用户不存在！UserID:{userBarcode.UserID}");
                    await userDcache.SetBaseValues(s_userEo);
                }
                LogUtil.Info($"pandapay.paycallback.4,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret, userBarcodes })}");
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    //0.是否处理过
                    var isOrderHandled = await CheckOrderHandled(ipo.transactionId, tm);
                    if (isOrderHandled)
                    {   //已处理直接返回
                        tm.Rollback();
                        return ret;
                    }
                    string orderId = ObjectId.NewId();
                    string currencyId =await userDcache.GetCurrencyIdAsync();
                    string operatorId =await userDcache.GetOperatorIdAsync();
                    int userKind = (int)await userDcache.GetUserKindAsync();
                    string countryId =await userDcache.GetCountryIdAsync();
                    var frommode = await userDcache.GetFromModeAsync();
                    var fromid=await userDcache.GetFromIdAsync();
                    var registDate = await userDcache.GetRegistDateAsync();

                    if (!decimal.TryParse(ipo.amount, out var pandaMoney))
                        throw new ArgumentException($"参数错误，amount:{ipo.amount}");
                    var ownMoney = (pandaMoney/ MULTIPLE).MToA(currencyId);
                    var ownFee = ipo.fee / MULTIPLE;
                    var bankUtcTime = string.IsNullOrWhiteSpace(ipo.repayTime) ? DateTime.UtcNow : ipo.repayTime.Trim().ToDateTime("yyyy-MM-dd HH:mm:ss").ToUtcTime(operatorId);
                    if (ipo.status != "SUCCESS")
                    {
                        //添加失败订单
                        await AddBankOrder(ipo,userBarcode.UserID,orderId, 3, ownMoney, currencyId, operatorId, userKind,ipo.transactionId, ownFee, 0,-pandaMoney/MULTIPLE, userBarcode.AppID,frommode,fromid,bankUtcTime, pandaMoney, registDate, tm);
                        //更新银行通讯日志
                        await UpdateBankTransaLog(ipo, 2, null, tm);
                        tm.Commit();
                    }
                    else
                    {
                        var userEo = await DbSink.BuildUserMo(userBarcode.UserID).GetByPKAsync(userBarcode.UserID, tm);
                        if (null == userEo)
                            throw new Exception($"用户不存在！userId:{userBarcode.UserID}");
                        //1.更新用户账户
                        var (endBalance,endBonus) = await BankUtil.UpdateUserCash(userBarcode.UserID, ownMoney, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;
                        //2.更新订单
                        await AddBankOrder(ipo,userBarcode.UserID, orderId, 2, ownMoney, currencyId, operatorId, userKind,ipo.transactionId, ownFee, 0,-pandaMoney/MULTIPLE, userBarcode.AppID,frommode,fromid,bankUtcTime, pandaMoney, registDate, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        tm.Commit();
                        //更新统计信息
                        await SendPayMsg(userEo.Cash,ipo,userBarcode.UserID, userKind, countryId, currencyId, operatorId,ownMoney);
                        //var gaid =await userDcache.GetGAIDAsync();
                        //var frommode =await userDcache.GetFromModeAsync();
                        //var fromid =await userDcache.GetFromIdAsync();
                        //await SendBranchPoint("PURCHASE", userBarcode.UserID, "BRL", gaid, orderId, operatorId, frommode, fromid, ipo);
                    }
                    LogUtil.Info($"pandapay.paycallback.5,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret, userBarcodes })}");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret.status = "fail";
                    await UpdateBankTransaLog(ipo, 2, ex, null);
                }
            }
            catch (Exception ex)
            {
                ret.status = "fail";
                LogUtil.Error(ex, "panda支付回调处理异常");
            }
            return ret;
        }



        /// <summary>
        /// 计算此次提款手续费
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<decimal> CalcCashFee(BLL.Services.Cash.CalcCashFeeIpo ipo)
        {
            //每天首提免手续费
            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            var lastCashDate = await userDCache.GetLastCashDateAsync();
            var isFirstCashOfDay = lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd");
            decimal fee = 0;
            if (!isFirstCashOfDay)
            {
                var pandaMoney = ipo.Amount.AToM(ipo.Order.CurrencyID);
                if (ConfigUtil.IsDebugEnvironment)
                {
                    var feeMoney = ipo.Amount.AToM(ipo.Order.CurrencyID) switch
                    {
                        < 10000 => 3.01m,
                        >= 10000 and < 20000 => 2.49m,
                        _ => 0.06m
                    };
                    fee = feeMoney;
                }
                else
                {
                    fee = (pandaMoney * payoutFee + 1);
                }
            }
            else
            {
                fee = 0;
            }
            return fee;
        }

        /// <summary>
        /// 发送branch打点
        /// </summary>
        /// <param name="pointname"></param>
        /// <param name="userId"></param>
        /// <param name="currency"></param>
        /// <param name="gaid"></param>
        /// <param name="transactionid"></param>
        /// <param name="operatorId"></param>
        /// <param name="frommode"></param>
        /// <param name="fromid"></param>
        /// <param name="ipo"></param>
        /// <returns></returns>
        private async Task SendBranchPoint(string pointname,string userId, string currency, string gaid, string transactionid, string operatorId, int frommode, string fromid, PayCallbackIpo ipo)
        {
            //if (string.IsNullOrWhiteSpace(gaid)) return;

            try
            {
                decimal.TryParse(ipo.amount,out var pandaMoney);
                await MQUtil.PublishAsync(new PayPointMsg
                {
                    PointName = pointname,
                    Currency = currency,
                    Gaid = gaid,
                    Money = pandaMoney,
                    Fee = ipo.fee,
                    Transactionid = transactionid,
                    UserId = userId,
                    OperatorId = operatorId,
                    PayType = (int)PayTypeEnum.Spei,
                    PayTime = DateTime.UtcNow,
                    FromId = fromid,
                    FromMode = frommode
                });
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送pandapay打点消息异常");
            }
        }

        

        /// <summary>
        /// 检查是否处理过
        /// </summary>
        /// <param name="bankOrderId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected async Task<bool> CheckOrderHandled(string bankOrderId, TransactionManager tm)
        {
            //var orderEo = ipo.Order =
            var orderEos = await _bankOrderMo.GetAsync("BankId=@BankId and BankOrderId=@BankOrderId", tm, BANKID, bankOrderId);
            return !(orderEos == null || orderEos.Count() == 0);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="userId"></param>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        /// <param name="ownMoney"></param>
        /// <param name="currencyId"></param>
        /// <param name="operatorId"></param>
        /// <param name="userKind"></param>
        /// <param name="bankOrderId"></param>
        /// <param name="ownFee"></param>
        /// <param name="userFee"></param>
        /// <param name="userMoney"></param>
        /// <param name="appId"></param>
        /// <param name="frommode"></param>
        /// <param name="fromid"></param>
        /// <param name="bankUtcTime"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task AddBankOrder(PayCallbackIpo ipo,string userId, string orderId, int status, long ownMoney, string currencyId, string operatorId, int userKind,string bankOrderId,decimal ownFee,decimal userFee,decimal userMoney, string appId,int frommode,string fromid,DateTime bankUtcTime,decimal transMoney,DateTime? registDate,TransactionManager tm)
        {
           // var appId = "lobby";
            var app = DbCacheUtil.GetApp(appId);
           // var provider = DbCacheUtil.GetProvider(app.ProviderID);
            var bankOrderEo = new Sb_bank_orderEO
            {
                OrderID = orderId,
                ProviderID = app.ProviderID,
                AppID = appId,
                OperatorID = operatorId,
                UserID = userId,
                FromMode=frommode,
                FromId=fromid,
                UserKind = userKind,
                RegistDate=registDate,
                OrderType = (int)OrderTypeEnum.Charge,
                BankID = BANKID,
                PaytypeID = (int)PayTypeEnum.Pandapay,
                PaytypeChannel = 0,
                CurrencyID = currencyId,
                PlanAmount = ownMoney,
                RecDate = DateTime.UtcNow,
                AppRequestUUID = ObjectId.NewId(),
                AppOrderId = ObjectId.NewId(),
                AppReqComment = "",
                AppRequestTime = DateTime.UtcNow,
                Meta = "{}",
                Status = status,
                OwnOrderId = orderId,
                TransMoney=transMoney,
                OrderMoney= Math.Truncate(100 * (transMoney/100)) / 100,
                BankResponseTime = DateTime.UtcNow,
                BankOrderId = bankOrderId,
                BankCallbackTime = DateTime.UtcNow,
                BankTime= bankUtcTime,
                Amount = ownMoney,
                OwnFee = ownFee,
                UserFee = userFee,
                UserMoney = userMoney,
                EndBalance = ipo.Balance,
                EndBonus=ipo.Bonus
            };
            ipo.Order = bankOrderEo;
            await _bankOrderMo.AddAsync(bankOrderEo, tm);
        }

        #region 提现

        /// <summary>
        /// panda提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<PandaCallbackDto> CashCallback(CashCallbackIpo ipo)
        {
            var ret = new PandaCallbackDto() { 
             status="success"
            };
            
            try
            {
                var pandapayConfig = ConfigUtil.AppConfigs.GetOrDefault<PandapayConfig>("pandapay");
                //var pandapayConfig = ConfigUtil.GetCustomConfig<PandapayConfig>("pandapay");
                if (string.IsNullOrWhiteSpace(pandapayConfig?.CompanyNo))
                    throw new Exception($"配置错误，customconfig.companyno:{pandapayConfig?.CompanyNo}");
                 //var companyNo= pandapayConfig?.CompanyNo;

                if (string.IsNullOrWhiteSpace(ipo.reference) || !ipo.reference.StartsWith(pandapayConfig.CompanyNo))
                    throw new ArgumentException($"参数异常！reference:{ipo.reference}");

                var orderId = ipo.reference.Replace(pandapayConfig.CompanyNo, "");
                await AddBankTransLog(ipo, orderId, BANKID, _request.Path.Value, null, 0, null, null);
                ////获取银行信息
                //var bank = DbBankCacheUtil.GetBank(BANKID);
                //// sign
                //if (!VerifyResponseDataByPublicKey(ipo.PlatSign, bank.TrdPublicKey, () => SignHelper.GetSign(ipo)))
                //    throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE);
                var orderPayCache = new OrderPayDCache(orderId);
                LogUtil.Info($"pandapay.cashcallback.2,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret, pandapayConfig.CompanyNo })}");
               
                //代付订单状态status:  SUCCESS, FAIL
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    var isOrderHandled = await CheckOrderHandled(ipo, orderId, tm);
                    if (isOrderHandled)
                    {
                        tm.Rollback();
                        return ret;
                    }
                    if (!decimal.TryParse(ipo.amount, out var pandaMoney))
                        throw new ArgumentException($"参数异常！amount:{ipo.amount}");

                    if (pandaMoney.MToA(ipo.Order.CurrencyID) != ipo.Order.TransMoney.MToA(ipo.Order.CurrencyID))
                        throw new Exception($"代付金额amount:{pandaMoney}与订单金额transmoney:{ipo.Order.TransMoney}不一致！orderid:{ipo.Order.OrderID}");

                    var ownMoney = (pandaMoney/MULTIPLE).MToA(ipo.Order.CurrencyID);
                    //if (ownMoney != Math.Abs(ipo.Order.PlanAmount))
                    //{
                    //    LogUtil.Error($"panda_cash提现金额与订单金额不一致！order_amount:{ipo.Order.PlanAmount},panda_money:{(pandaMoney/100).MToA(ipo.Order.CurrencyID)}");
                    //    throw new Exception($"提现金额与订单金额不一致！");
                    //}
                    LogUtil.Info($"pandapay.cashcallback.3,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");
                    var bankUtcTime = string.IsNullOrWhiteSpace(ipo.payTime) ? DateTime.UtcNow : ipo.payTime.Trim().ToDateTime("yyyy-MM-dd HH:mm:ss").ToUtcTime(ipo.Order.OperatorID);
                    if (ipo.status != "SUCCESS")//失败
                    {
                        //账户余额还原
                        var (endBalance,endBonus)= await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;
                        //更新订单状态:失败
                        await UpdateBankOrder(ipo, orderId,ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Draw, bankUtcTime, tm);
                        //记录银行日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);

                        await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Fail);
                        tm.Commit();
                    }
                    else if (ipo.status == "SUCCESS")
                    {
                        //2.更新订单
                        var ownFee = 0M;
                        var userFee = 0M;
                        //用户实际到账金额
                        var userMoney = pandaMoney / MULTIPLE;
                        if (ipo.Order.IsFirstCashOfDay)
                        {
                            ownFee = ipo.fee/MULTIPLE;
                        }
                        else
                        {
                            userFee = ipo.fee/MULTIPLE;
                        }
                        await UpdateBankOrder(ipo,orderId,ownFee, userFee, userMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Draw, bankUtcTime, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        //4.redis
                        await BankUtil.SetOrderCacheAsync(orderPayCache, -ownMoney, ipo.Order, (int)BankOrderStatusEnum.Success);
                        tm.Commit();
                        

                        //发送提现消息
                        await SendCashMsg(ipo.Order, userFee, ownFee, ownMoney);
                    }
                    else
                    {
                        throw new Exception($"状态异常：没有该状态的逻辑status:{ipo.status}");
                    }
                    LogUtil.Info($"pandapay.cashcallback.4,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                }
                catch (OrderStatusException ex)
                {
                    tm.Rollback();
                    ret.status = "fail";
                    LogUtil.Error(ex,$"pandapay.cashcallback.5,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                    //LogUtil.Warning(ex, $"panda提现回调处理订单状态异常!ipo:{SerializerUtil.SerializeJsonNet(new { ipo,ret})}");
                }
                catch (DuplicateUpdateOrderException ex)
                {
                    tm.Rollback();
                    ret.status = "fail";
                    LogUtil.Error(ex, $"pandapay.cashcallback.6,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                    //LogUtil.Warning(ex, $"panda提现回调处理订单更新异常！ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret.status = "fail";
                    //更新订单状态
                    await UpdateBankOrder(ipo,orderId,ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Exception, OrderTypeEnum.Draw,null,null);
                    //银行日志
                    await UpdateBankTransaLog(ipo, 3, ex, null);
                    await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Exception);
                    LogUtil.Error(ex, $"pandapay.cashcallback.7,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                }
            }
            catch (Exception ex)
            {
                ret.status = "fail";
                LogUtil.Error(ex, $"pandapay.cashcallback.8,param:{SerializerUtil.SerializeJsonNet(new { ipo, ret })}");

                //LogUtil.Error(ex, $"panda提现回调处理异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            }
            return ret;
        }
        #endregion

        #region 发送消息
        /// <summary>
        /// 更新充值统计信息
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="userId"></param>
        /// <param name="userKind"></param>
        /// <param name="countryId"></param>
        /// <param name="currencyId"></param>
        /// <param name="operatorId"></param>
        /// <param name="ownMoney"></param>
        /// <returns></returns>
        private async Task SendPayMsg(long payBeforeAmount, PayCallbackIpo ipo, string userId, int userKind, string countryId, string currencyId, string operatorId, long ownMoney)
        {
            try
            {
                #region 注释

                //var orderLogs = await _orderTranslogMo.GetTopAsync("OrderID=@OrderID and BankID=@BankID and TransType=@TransType and Status=@Status", 1, ipo.Order.OrderID, BANKID, 0, 1);
                //var orderTranslog = orderLogs?.FirstOrDefault();
                ////if (null == orderTranslog)
                ////    return;
                //var receiveBonus = orderTranslog?.ReceiveBonus ?? 0;

                //await MQUtil.PublishAsync(new UserPayMsg
                //{
                //    UserId = userId,
                //    UserKind = userKind,
                //    PayTime = DateTime.UtcNow,
                //    CountryId = countryId,
                //    PayType = (int)PayTypeEnum.Pandapay,
                //    OperatorId = operatorId,
                //    OwnFee = ipo.fee,
                //    PayAmount = ownMoney,
                //    CurrencyId = currencyId,
                //    UserFee = 0,
                //    OrderID = ipo.Order.OrderID,
                //    ReceiveBonus = receiveBonus==1?1:2
                //});


                ////是否是首充消息
                //var userDCache = await GlobalUserDCache.Create(userId);
                //if (await userDCache.GetHasPayAsync())
                //    return;
                ////
                //await userDCache.SetHasPayAsync();
                //await DbSink.BuildUserMo(userId).PutHasPayByPKAsync(userId, true);

                ////首充
                //var firstPayMsg = new UserFirstPayMsg
                //{
                //    OwnFee = ipo.fee,
                //    UserFee = 0,
                //    PayType = (int)PayTypeEnum.Tejeepay,
                //    CountryId = countryId,
                //    CurrencyId = currencyId,
                //    PayAmount = ownMoney,
                //    PayTime = DateTime.UtcNow,
                //    UserId = userId,
                //    UserKind = userKind,
                //    OperatorId = operatorId
                //};

                //await MQUtil.PublishAsync(firstPayMsg);
                #endregion
                var userPayMsgDo = new UserPayMsgDo
                {
                    OrderId = ipo.Order.OrderID,
                    BankId = BANKID,
                    UserId = userId,
                    AppId=ipo.Order.AppID,
                    UserKind = userKind,
                    CountryId = countryId,
                    CurrencyId = currencyId,
                    OperatorId = operatorId,
                    Fee = ipo.fee,
                    EventSourceUrl = "https://www.lucro777.com/",
                    OwnMoney = ownMoney,
                    PayTypeEnum = PayTypeEnum.Pandapay,
                    PayBeforeAmount=payBeforeAmount
                };
                await SendUserPayMsg(userPayMsgDo);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送panda充值消息异常");
            }
        }

        /// <summary>
        /// 发送提现消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="countryId"></param>
        /// <param name="userFee"></param>
        /// <param name="ownFee"></param>
        /// <param name="ownMoney"></param>
        /// <returns></returns>
        private async Task SendCashMsg(Sb_bank_orderEO orderEo, decimal userFee, decimal ownFee, long ownMoney)
        {
            try
            {
                var oper = DbCacheUtil.GetOperator(orderEo.OperatorID);
                //await MQUtil.PublishAsync(new UserCashMsg
                //{
                //    UserId = orderEo.UserID,
                //    UserKind = orderEo.UserKind,
                //    CashAmount = ownMoney,
                //    CountryId = oper.CountryID,
                //    CurrencyId = orderEo.CurrencyID,
                //    CashTime = DateTime.UtcNow,
                //    OperatorId = orderEo.OperatorID,
                //    OwnFee = ownFee,
                //    UserFee = userFee,
                //    FirstCashOfDay = orderEo.IsFirstCashOfDay
                //});
                var userCashMsgDo = new UserCashMsgDo {
                    UserId=orderEo.UserID,
                    UserKind=orderEo.UserKind,
                    CashAmount=ownMoney,
                    CountryId=oper.CountryID,
                    AppId= orderEo.AppID,
                    CurrencyId=orderEo.CurrencyID,
                    IsFirstCashOfDay=orderEo.IsFirstCashOfDay,
                    OperatorId=orderEo.OperatorID,
                    OwnFee=ownFee,
                    UserFee=userFee,
                    PayType=(int)PayTypeEnum.Pandapay,
                    Meta=orderEo.Meta,
                    OrderID=orderEo.OrderID
                };
                await SendUserCashMsg(userCashMsgDo);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送用户panda提现消息异常！");
            }
        }
        #endregion
    }
}
