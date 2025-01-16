using TinyFx.Logging;
using TinyFx;
using Xxyy.Common;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using UGame.Banks.Repository;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Xxyy.Common.Caching;
using Xxyy.MQ.Bank;
using TinyFx.AspNet;
using TinyFx.Configuration;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.MQMsg;

namespace UGame.Banks.Service.Services.Pay
{
    public abstract class PayCallbackServiceBase2
    {
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_order_trans_logMO _orderTransLogMo = new();
        /// <summary>
        /// 货币倍数(元-->分)
        /// </summary>
        protected virtual int MULTIPLE { get; set; } = 100;

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual Task CheckSign(BankCallbackContext context)
        {
            return Task.CompletedTask;
        }

        
        public virtual Task CheckIpo(BankCallbackContext context)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 计算代收手续费
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract decimal GetPayFee(BankCallbackContext context);

        /// <summary>
        /// 检查代付手续费
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual decimal GetCashFee(BankCallbackContext context)
        {
            return 0;
        }
        /// <summary>
        /// 检查代收是否成功
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract bool CheckPaySuccess(BankCallbackContext context);

        /// <summary>
        /// 检查代付是否成功
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public abstract bool CheckCashSuccess(BankCallbackContext context);

        /// <summary>
        /// 代收
        /// </summary>
        /// <param name="context"></param>
        /// <param name="orderPayCache"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task ExecutePay(BankCallbackContext context, OrderPayDCache orderPayCache, TransactionManager tm)
        {
            if (CheckPaySuccess(context))
            {
                var userEo = await DbSink.BuildUserMo(context.OrderEo.UserID).GetByPKAsync(context.OrderEo.UserID, tm);
                if (null == userEo)
                    throw new Exception($"用户不存在！userId:{context.OrderEo.UserID}");
                //var ownMoney = context.OrderEo.OrderMoney.MToA(context.OrderEo.CurrencyID);
                if (context.OrderEo.IsAddBalance)
                {
                    //1.更新用户账户
                    var (endBalance, endBonus) = await BankUtil.UpdateUserCash(context.OrderEo.UserID, context.OrderEo.Amount, tm);
                    context.OrderEo.EndBalance = endBalance;
                    context.OrderEo.EndBonus  = endBonus;
                }
                else
                {
                    //充值不操作账户余额
                    //1.更新用户账户
                    context.OrderEo.EndBalance = userEo.Cash;
                    context.OrderEo.EndBonus = userEo.Bonus;
                }
                //2.更新订单
                await UpdateBankOrder(context, BankOrderStatusEnum.Success, tm);
                //3.添加银行通讯日志
                await UpdateBankTransaLog(context, 1, null, tm);
                //4.更新redis
                await BankUtil.SetOrderCacheAsync(orderPayCache, context.OrderEo.Amount, context.OrderEo, (int)BankOrderStatusEnum.Success);
                
                tm.Commit();
                //更新统计信息
                await SendUserPayMsg(context.OrderEo, userEo.Cash);
            }
            else
            {
                //添加失败订单
                await UpdateBankOrder(context, BankOrderStatusEnum.Fail, tm);
                //更新银行通讯日志
                await UpdateBankTransaLog(context, 1, null, tm);
                await BankUtil.SetOrderCacheAsync(orderPayCache, context.OrderEo.Amount, context.OrderEo, (int)BankOrderStatusEnum.Fail);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = context.OrderEo.BankID,
                    Channel = context.OrderEo.PaytypeChannel,
                    Money = context.OrderEo.OrderMoney,
                    CurrencyId = context.OrderEo.CurrencyID,
                    ErrorMsg = $"orderid:{context.OrderEo.OrderID},userid:{context.OrderEo.UserID}充值对方通知失败！",
                    OrderType = OrderTypeEnum.Charge,
                    Paytype = context.OrderEo.PaytypeID.ToEnum<PayTypeEnum>(),
                    UserId = context.OrderEo.UserID,
                    OrderId =context.OrderEo.OrderID,
                    RecDate = context.OrderEo.RecDate,
                    Remark = context.Ipo
                });
                tm.Commit();
            }
        }

        /// <summary>
        /// 代付
        /// </summary>
        /// <param name="context"></param>
        /// <param name="orderPayCache"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        private async Task ExecuteCash(BankCallbackContext context, OrderPayDCache orderPayCache, TransactionManager tm)
        {
            if (CheckCashSuccess(context)) //成功
            {
                //2.更新订单
                //用户实际到账金额
                //context.OrderEo.UserFee = GetCashFee(context);
                await UpdateBankOrder(context, BankOrderStatusEnum.Success, tm);
                //3.添加银行通讯日志
                await UpdateBankTransaLog(context, 1, null, tm);
                //4.redis
                var ownMoney = context.OrderEo.OrderMoney.MToA(context.OrderEo.CurrencyID);
                await BankUtil.SetOrderCacheAsync(orderPayCache, -ownMoney,context.OrderEo, (int)BankOrderStatusEnum.Success);
                tm.Commit();
                //发送提现消息
                await SendUserCashMsg(context.OrderEo, true);
            }
            else
            {
                ////账户余额还原
                //var (endBalance, endBonus) = await BankUtil.UpdateUserCash(context.OrderEo.UserID, -context.OrderEo.Amount, tm);
                var userEo = await DbSink.BuildUserMo(context.OrderEo.UserID).GetByPKAsync(context.OrderEo.UserID, tm);
                if (null == userEo)
                    throw new Exception($"提现回调失败!用户不存在!userid:{context.OrderEo.UserID},orderid:{context.OrderEo.OrderID}");
                context.OrderEo.EndBalance = userEo.Cash;
                context.OrderEo.EndBonus = userEo.Bonus;
                //更新订单状态:失败
                await UpdateBankOrder(context, BankOrderStatusEnum.Fail, tm);
                //记录银行日志
                await UpdateBankTransaLog(context, 1, null, tm);
                await BankUtil.SetOrderCacheAsync(orderPayCache, context.OrderEo.Amount, context.OrderEo, (int)BankOrderStatusEnum.Fail);
                await MQUtil.PublishAsync(new BankErrorMsg
                {
                    BankId = context.OrderEo.BankID,
                    Channel = context.OrderEo.PaytypeChannel,
                    Money = context.OrderEo.OrderMoney,
                    CurrencyId = context.OrderEo.CurrencyID,
                    ErrorMsg = $"orderid:{context.OrderEo.OrderID},userid:{context.OrderEo.UserID}提现对方通知失败！",
                    OrderType = OrderTypeEnum.Draw,
                    Paytype = context.OrderEo.PaytypeID.ToEnum<PayTypeEnum>(),
                    UserId = context.OrderEo.UserID,
                    OrderId = context.OrderEo.OrderID,
                    RecDate = context.OrderEo.RecDate,
                    Remark = context.OrderEo
                });
                tm.Commit();
                //发送提现消息
                await SendUserCashMsg(context.OrderEo, false);
            }
        }

        public async Task<bool> Execute(BankCallbackContext context)
        {
            var ret = false;
            try
            {
                //0.添加银行通讯日志
                await AddBankTransLog(context, null, 0, null, null);
                //1.checksign
                await CheckSign(context);
                //2.是否已处理过
                if (context.OrderEo.Status > 1)
                {
                    ret = true;
                    LogUtil.GetContextLogger()
                        .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning)
                        .AddField("bank.orderid",context.OrderEo.OrderID)
                        .AddField("bank.context", SerializerUtil.SerializeJsonNet(context))
                        .AddField("bank.return", ret)
                        .AddMessage($"订单orderid:{context.OrderEo.OrderID}已处理无需重复处理!")
                        .Save();
                    return ret;
                }
                //3.checkipo
                await CheckIpo(context);
                //4.计算手续费
                if(context.OrderEo.OrderType==(int)OrderTypeEnum.Charge)
                {
                    context.OrderEo.OwnFee = GetPayFee(context);
                }else if(context.OrderEo.OrderType==(int)OrderTypeEnum.Draw)
                {
                    if (context.OrderEo.UserFeeAmount > 0)
                        context.OrderEo.OwnFee = GetCashFee(context);
                    else
                        context.OrderEo.UserFee = GetCashFee(context);

                }
                var orderPayCache = new OrderPayDCache(context.OrderEo.OrderID);
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    var utcNow = DateTime.UtcNow;
                    context.OrderEo.BankCallbackTime = utcNow;



                    if (context.OrderEo.BankTime == null || context.OrderEo.BankTime.Value == DateTime.MinValue)
                        context.OrderEo.BankTime = utcNow;

                


                    context.OrderEo.SettlStatus = (int)SettlStatusEnum.Consistent;
                    if (context.OrderEo.OrderType == (int)OrderTypeEnum.Charge)
                    {
                       await ExecutePay(context,orderPayCache,tm);
                    }
                    else if (context.OrderEo.OrderType == ( int)OrderTypeEnum.Draw)
                    {
                        await ExecuteCash(context,orderPayCache,tm);
                    }
                    ret = true;
                }
                catch (DuplicateUpdateOrderException ex)
                {
                    tm.Rollback();
                    ret = false;
                    LogUtil.GetContextLogger()
                        .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning)
                        .AddField("bank.orderid", context.OrderEo.OrderID)
                        .AddField("bank.context", SerializerUtil.SerializeJsonNet(context))
                        .AddException(ex)
                        .AddField("bank.return", ret)
                        .AddMessage($"订单orderid:{context.OrderEo.OrderID}回调处理并发更新订单状态失败!");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret = false;
                    //更新订单状态
                    await UpdateBankOrder(context, BankOrderStatusEnum.Exception, null);
                    //银行日志
                    await UpdateBankTransaLog(context, 3, ex, null);
                    await BankUtil.SetOrderCacheAsync(orderPayCache, context.OrderEo.Amount, context.OrderEo, (int)BankOrderStatusEnum.Exception);
                    LogUtil.GetContextLogger()
                   .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                   .AddMessage("订单回调处理异常！")
                   .AddException(ex)
                   .AddField("bank.orderid", context.OrderEo.OrderID)
                   .AddField("bank.context", SerializerUtil.SerializeJsonNet(context))
                   .AddField("bank.return", SerializerUtil.SerializeJsonNet(ret));
                }
            }
            catch (Exception ex)
            {
                ret = false;
                LogUtil.Error(ex, $"订单orderid:{context.OrderEo.OrderID}回调处理异常!");
            }
            return ret;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="status"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task UpdateBankOrder(BankCallbackContext context, BankOrderStatusEnum status, TransactionManager tm)
        {
            string sql = "Meta=@Meta,Status=@Status,OwnFee=@OwnFee,UserFee=@UserFee,UserMoney=@UserMoney,BankOrderId=@BankOrderId,EndBalance=@EndBalance,EndBonus=@EndBonus,BankCallbackTime=@BankCallbackTime,BankTime=@BankTime,SettlStatus=@SettlStatus";
            var param = new List<object> {
                   context.OrderEo.Meta,(int)status,context.OrderEo.OwnFee,context.OrderEo.UserFee,context.OrderEo.UserMoney, context.OrderEo.BankOrderId,context.OrderEo.EndBalance,context.OrderEo.EndBonus,context.OrderEo.BankCallbackTime,context.OrderEo.BankTime, context.OrderEo.SettlStatus,context.OrderEo.OrderID, context.OrderEo.Status
                };
            var rows = await _bankOrderMo.PutAsync(sql, "OrderID=@OrderID and Status=@OldStatus", tm, param.ToArray());
            if (rows <= 0)
                throw new DuplicateUpdateOrderException($"updatebankorder更新订单失败!orderid:{context.OrderEo.OrderID},oldstatus:{context.OrderEo.Status},newstatus:{(int)status}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="transmark"></param>
        /// <param name="dto"></param>
        /// <param name="status"></param>
        /// <param name="ex"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        private async Task AddBankTransLog(BankCallbackContext context, object dto, int status, Exception ex, TransactionManager tm)
        {
            var utcNow = DateTime.UtcNow;
            var bankTransLogEo = new Sb_order_trans_logEO
            {
                TransLogID = ObjectId.NewId(),
                OrderID = context.OrderEo.OrderID,
                BankID = context.OrderEo.BankID,
                TransType = 1,
                TransMark = HttpContextEx.Request?.Path.Value,
                RequestBody = SerializerUtil.SerializeJsonNet(context.Ipo),
                RequestTime = utcNow,
                Status = status,
                ResponseTime = utcNow,
                ResponseBody = SerializerUtil.SerializeJsonNet(dto),
                Exception = SerializerUtil.SerializeJsonNet(ex)
            };
            context.SetTranslog(bankTransLogEo);
            await _orderTransLogMo.AddAsync(bankTransLogEo, tm);
        }

        /// <summary>
        /// 更新银行订单通讯日志
        /// </summary>
        /// <param name="context"></param>
        /// <param name="status"></param>
        /// <param name="ex"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        protected async Task UpdateBankTransaLog(BankCallbackContext context, int status, Exception ex, TransactionManager tm)
        {
            var eo = context.OrderTranslogEo;
            if (context.OrderEo != null && eo.OrderID != context.OrderEo.OrderID)
                eo.OrderID = context.OrderEo.OrderID;
            eo.Status = status;
            eo.ResponseTime = DateTime.UtcNow;
            eo.ResponseBody = SerializerUtil.SerializeJsonNet(ex==null);
            eo.Exception = SerializerUtil.SerializeJsonNet(ex);
            await _orderTransLogMo.PutAsync(eo, tm);
        }

        /// <summary>
        /// 发送用户充值消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="payBeforeAmount"></param>
        /// <returns></returns>
        public async Task SendUserPayMsg(Sb_bank_orderEO orderEo, long payBeforeAmount)
        {
            try
            {
                bool isFirst = false;
                //是否是首充消息
                var userDCache = await GlobalUserDCache.Create(orderEo.UserID);
                if (null != userDCache && !await userDCache.GetHasPayAsync())
                {
                    await userDCache.SetHasPayAsync();
                    await DbSink.BuildUserMo(orderEo.UserID).PutHasPayByPKAsync(orderEo.UserID, true);
                    isFirst = true;
                }

                var orderLogs = await _orderTransLogMo.GetTopAsync("OrderID=@OrderID and BankID=@BankID and TransType=@TransType and Status=@Status", 1, orderEo.OrderID, orderEo.BankID, 0, 1);
                var orderTranslog = orderLogs?.FirstOrDefault();

                var receiveBonus = orderTranslog?.ReceiveBonus ?? 0;

                var activityIds = orderEo.ActivityIds?.Split('|', StringSplitOptions.RemoveEmptyEntries).ToList();
                await MQUtil.PublishAsync(new UserPayMsg
                {
                    UserId = orderEo.UserID,
                    AppId = orderEo.AppID,
                    UserKind = orderEo.UserKind,
                    PayTime = DateTime.UtcNow,
                    CountryId = orderEo.CountryID,
                    PayType = orderEo.PaytypeID,
                    OperatorId = orderEo.OperatorID,
                    OwnFee = orderEo.OwnFee,
                    PayAmount = orderEo.Amount,
                    CurrencyId = orderEo.CurrencyID,
                    UserFee = 0,
                    OrderID = orderEo.OrderID,
                    ReceiveBonus = receiveBonus == 1 ? 1 : 2,
                    IsFirst = isFirst,
                    PayBeforeAmount = payBeforeAmount,
                    ActivityIds = activityIds,
                    IsAddBalance = orderEo.IsAddBalance,
                    EndBalance=orderEo.EndBalance,
                    EndBonus=orderEo.EndBonus
                });

                if (!isFirst)
                {
                    return;
                }
                //首充消息
                var firstPayMsg = new UserFirstPayMsg
                {
                    OwnFee = orderEo.OwnFee,
                    UserFee = 0,
                    PayType = orderEo.PaytypeID,
                    CountryId = orderEo.CountryID,
                    CurrencyId = orderEo.CurrencyID,
                    PayAmount = orderEo.Amount,
                    PayTime = DateTime.UtcNow,
                    UserId = orderEo.UserID,
                    UserKind = orderEo.UserKind,
                    OperatorId = orderEo.OperatorID,
                    OrderID = orderEo.OrderID,
                    EventSourceUrl = "",
                    ActivityIds = activityIds,
                    IsAddBalance = orderEo.IsAddBalance,
                    AppId = orderEo.AppID,
                    BankId = orderEo.BankID
                };

                await MQUtil.PublishAsync(firstPayMsg);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"orderid:{orderEo.OrderID}发送用户充值消息异常！");
            }
        }

        /// <summary>
        /// 发送用户提现消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected async Task SendUserCashMsg(Sb_bank_orderEO orderEo,bool status)
        {
            try
            {
                bool isFirst = false;
                var userDCache = await GlobalUserDCache.Create(orderEo.UserID);
                if (!await userDCache.GetHasCashAsync())
                {
                    await userDCache.SetHasCashAsync();
                    await DbSink.BuildUserMo(orderEo.UserID).PutHasCashByPKAsync(orderEo.UserID, true);
                    isFirst = true;
                }

                DateTime cashTime = DateTime.UtcNow;
                var cashAmount = Math.Abs(orderEo.Amount);
                await MQUtil.PublishAsync(new UserCashMsg
                {
                    UserId = orderEo.UserID,
                    UserKind = orderEo.UserKind,
                    CashAmount = cashAmount,
                    CountryId = orderEo.CountryID,
                    CurrencyId = orderEo.CurrencyID,
                    CashTime = cashTime,
                    PayType = orderEo.PaytypeID,
                    Meta = orderEo.Meta,
                    OperatorId = orderEo.OperatorID,
                    OwnFee = orderEo.OwnFee,
                    UserFee = orderEo.UserFee,
                    FirstCashOfDay = orderEo.IsFirstCashOfDay,
                    IsFirst = isFirst,
                    OrderID= orderEo.OrderID,
                    AppOrderId= orderEo.AppOrderId,
                    AppId=orderEo.AppID,
                    PaytypeChannel= orderEo.PaytypeChannel,
                    Status=status?0:1
                });

                if (!isFirst)
                    return;
                
                //首提
                var firstCashMsg = new UserFirstCashMsg
                {
                    OwnFee = orderEo.OwnFee,
                    UserFee = orderEo.UserFee,
                    PayType = orderEo.PaytypeID,
                    CashTime = cashTime,
                    CashAmount = cashAmount,
                    CurrencyId = orderEo.CurrencyID,
                    Meta = orderEo.Meta,
                    UserId = orderEo.UserID,
                    UserKind = orderEo.UserKind,
                    OperatorId = orderEo.OperatorID,
                    Status = status ? 0 : 1,
                    PaytypeChannel = orderEo.PaytypeChannel,
                    AppOrderId = orderEo.AppOrderId,
                    OrderID = orderEo.OrderID,
                    CountryId = orderEo.CountryID
                };
                await MQUtil.PublishAsync(firstCashMsg);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"orderid:{orderEo.OrderID}发送用户提现消息异常！");
            }
        }
    }
}
