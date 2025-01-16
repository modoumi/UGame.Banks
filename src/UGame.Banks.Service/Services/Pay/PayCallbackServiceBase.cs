using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx.Security;
using TinyFx;
using UGame.Banks.Service.Caching;
using Xxyy.Common;
using TinyFx.Data;
using Org.BouncyCastle.Asn1.Ocsp;
using Newtonsoft.Json;
using TinyFx.Extensions.RabbitMQ;
using Xxyy.Common.Caching;
using Xxyy.MQ.Bank;
using Pipelines.Sockets.Unofficial.Buffers;
using StackExchange.Redis;
using EasyNetQ;
using TinyFx.Text;
using UGame.Banks.Service.Common;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Services.Pay
{

    /// <summary>
    /// 支付回调基类
    /// </summary>
    public class PayCallbackServiceBase<TIpo, TDto>
        where TIpo : CallbackIpoCommonBase
    {
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_order_trans_logMO _orderTransLogMo = new();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="orderId"></param>
        /// <param name="bankId"></param>
        /// <param name="transmark"></param>
        /// <param name="dto"></param>
        /// <param name="status"></param>
        /// <param name="ex"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        protected async Task AddBankTransLog(TIpo ipo, string orderId, string bankId, string transmark, TDto dto, int status, Exception ex, TransactionManager tm)
        {
            var bankTransLogEo = new Sb_order_trans_logEO
            {
                TransLogID = ObjectId.NewId(),
                OrderID = orderId,
                BankID = bankId,
                TransType = 1,
                TransMark = transmark,
                RequestBody = SerializerUtil.SerializeJsonNet(ipo),
                RequestTime = DateTime.UtcNow,
                Status = status,
                ResponseTime = DateTime.UtcNow,
                ResponseBody = SerializerUtil.SerializeJsonNet(dto),
                Exception = SerializerUtil.SerializeJsonNet(ex)
            };
            ipo.BankTransLog = bankTransLogEo;
            await _orderTransLogMo.AddAsync(bankTransLogEo, tm);
        }

        /// <summary>
        /// 更新银行订单通讯日志
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="status"></param>
        /// <param name="ex"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        protected async Task UpdateBankTransaLog(TIpo ipo, int status, Exception ex, TransactionManager tm)
        {
            var eo = ipo.BankTransLog;
            if (ipo.Order != null && eo.OrderID != ipo.Order.OrderID)
                eo.OrderID = ipo.Order.OrderID;
            eo.Status = status;
            eo.ResponseTime = DateTime.UtcNow;
            eo.ResponseBody = SerializerUtil.SerializeJsonNet(ipo);
            eo.Exception = SerializerUtil.SerializeJsonNet(ex);
            await _orderTransLogMo.PutAsync(eo, tm);
        }

        /// <summary>
        /// 检查是否处理过
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="orderId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected async Task<bool> CheckOrderHandled(TIpo ipo, string orderId, TransactionManager tm)
        {
            var orderEo = ipo.Order = await _bankOrderMo.GetByPKAsync(orderId, tm, true);
            if (orderEo == null)
                throw new Exception($"订单不存在,orderId：{orderId}");
            var orderStatusArr = new int[] { (int)BankOrderStatusEnum.Processing, (int)BankOrderStatusEnum.Success };
            if (!orderStatusArr.Contains(orderEo.Status))
            {
                throw new OrderStatusException($"订单状态异常.status={orderEo.Status}");
            }
            return orderEo.Status == (int)BankOrderStatusEnum.Success;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="bankOrderId"></param>
        /// <param name="ownFee"></param>
        /// <param name="userFee"></param>
        /// <param name="userMoney"></param>
        /// <param name="status"></param>
        /// <param name="orderType"></param>
        /// <param name="bankTime"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        protected async Task UpdateBankOrder(TIpo ipo, string bankOrderId, decimal ownFee, decimal userFee, decimal userMoney, BankOrderStatusEnum status, OrderTypeEnum orderType,DateTime? bankTime, TransactionManager tm)
        {
            var callbankTime = DateTime.UtcNow;
            var bankSuccessTime = (bankTime != null && bankTime.Value != DateTime.MinValue) ? bankTime.Value : callbankTime;
            string sql = "Meta=@Meta,Status=@Status,OwnFee=@OwnFee,UserFee=@UserFee,UserMoney=@UserMoney,BankOrderId=@BankOrderId,EndBalance=@EndBalance,EndBonus=@EndBonus,BankCallbackTime=@BankCallbackTime,BankTime=@BankTime,SettlStatus=@SettlStatus";
            var param = new List<object> {
                   ipo.Order.Meta,(int)status,ownFee,userFee,userMoney, bankOrderId,ipo.Order.EndBalance,ipo.Order.EndBonus,callbankTime,bankSuccessTime, ipo.Order.SettlStatus,ipo.Order.OrderID, ipo.Order.Status
                };
            var rows = await _bankOrderMo.PutAsync(sql, "OrderID=@OrderID and Status=@OldStatus", tm, param.ToArray());
            if (rows <= 0)
                throw new DuplicateUpdateOrderException($"更新订单状态失败，oldstatus:{ipo.Order.Status},newstatus:{(int)status}");
        }

        /// <summary>
        /// 发送用户充值消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="countryId"></param>
        /// <param name="payBeforeAmount"></param>
        /// <returns></returns>
        public async Task SendUserPayMsg(Sb_bank_orderEO orderEo,string countryId,long payBeforeAmount)
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
                CountryId = countryId,
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
                EndBalance= orderEo.EndBalance,
                EndBonus= orderEo.EndBonus
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
                CountryId = countryId,
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
                AppId=orderEo.AppID,
                BankId=orderEo.BankID
            };

            await MQUtil.PublishAsync(firstPayMsg);
        }

        ///// <summary>
        ///// 发送用户提现消息
        ///// </summary>
        ///// <returns></returns>
        //protected async Task SendUserCashMsg(UserCashMsgDo userCashMsgDo)
        //{
        //    try
        //    {
        //        bool isFirst = false;
        //        var userDCache = await GlobalUserDCache.Create(userCashMsgDo.UserId);
        //        if (!await userDCache.GetHasCashAsync())
        //        {
        //            await userDCache.SetHasCashAsync();
        //            await DbSink.BuildUserMo(userCashMsgDo.UserId).PutHasCashByPKAsync(userCashMsgDo.UserId, true);
        //            isFirst = true;
        //        }

        //        DateTime cashTime = DateTime.UtcNow;
        //        await MQUtil.PublishAsync(new UserCashMsg
        //        {
        //            UserId = userCashMsgDo.UserId,
        //            UserKind = userCashMsgDo.UserKind,
        //            CashAmount = userCashMsgDo.CashAmount,
        //            CountryId = userCashMsgDo.CountryId,
        //            CurrencyId = userCashMsgDo.CurrencyId,
        //            CashTime = cashTime,
        //            PayType = userCashMsgDo.PayType,
        //            Meta = userCashMsgDo.Meta,
        //            OperatorId = userCashMsgDo.OperatorId,
        //            OwnFee = userCashMsgDo.OwnFee,
        //            UserFee = userCashMsgDo.UserFee,
        //            FirstCashOfDay = userCashMsgDo.IsFirstCashOfDay,
        //            IsFirst=isFirst,
        //            Status=userCashMsgDo.Status
        //        });

        //        //var userDCache = new GlobalUserDCache(userCashMsgDo.UserId);
        //        //if (await userDCache.GetHasCashAsync())
        //        if(!isFirst)
        //            return;
        //        //
        //        //await userDCache.SetHasCashAsync();
        //        //await DbSink.BuildUserMo(userCashMsgDo.UserId).PutHasCashByPKAsync(userCashMsgDo.UserId, true);

        //        //首提
        //        var firstCashMsg = new UserFirstCashMsg
        //        {
        //            OwnFee = userCashMsgDo.OwnFee,
        //            UserFee = userCashMsgDo.UserFee,
        //            PayType = userCashMsgDo.PayType,
        //            CashTime = cashTime,
        //            CashAmount = userCashMsgDo.CashAmount,
        //            CurrencyId = userCashMsgDo.CurrencyId,
        //            Meta = userCashMsgDo.Meta,
        //            UserId = userCashMsgDo.UserId,
        //            UserKind = userCashMsgDo.UserKind,
        //            OperatorId = userCashMsgDo.OperatorId,
        //            Status=userCashMsgDo.Status
        //        };
        //        await MQUtil.PublishAsync(firstCashMsg);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex, $"发送用户提现消息异常！");
        //    }
        //}

        /// <summary>
        /// 发送用户提现消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        protected async Task SendUserCashMsg2(Sb_bank_orderEO orderEo, bool status)
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
                await MQUtil.PublishAsync(new UserCashMsg
                {
                    OrderID= orderEo.OrderID,
                    UserId = orderEo.UserID,
                    AppId=orderEo.AppID,
                    UserKind = orderEo.UserKind,
                    CashAmount = Math.Abs(orderEo.Amount),
                    CountryId = orderEo.CountryID,
                    CurrencyId = orderEo.CurrencyID,
                    CashTime = cashTime,
                    PayType = orderEo.PaytypeID,
                    PaytypeChannel= orderEo.PaytypeChannel,
                    Meta = orderEo.Meta,
                    OperatorId = orderEo.OperatorID,
                    OwnFee = orderEo.OwnFee,
                    UserFee = orderEo.UserFee,
                    FirstCashOfDay = orderEo.IsFirstCashOfDay,
                    IsFirst = isFirst,
                    Status = status?0:1,
                    AppOrderId= orderEo.AppOrderId
                });

                //var userDCache = new GlobalUserDCache(userCashMsgDo.UserId);
                //if (await userDCache.GetHasCashAsync())
                if (!isFirst)
                    return;
                //
                //await userDCache.SetHasCashAsync();
                //await DbSink.BuildUserMo(userCashMsgDo.UserId).PutHasCashByPKAsync(userCashMsgDo.UserId, true);

                //首提
                var firstCashMsg = new UserFirstCashMsg
                {
                    OwnFee = orderEo.OwnFee,
                    UserFee = orderEo.UserFee,
                    PayType = orderEo.PaytypeID,
                    PaytypeChannel = orderEo.PaytypeChannel,
                    CashTime = cashTime,
                    CashAmount =Math.Abs(orderEo.Amount),
                    CurrencyId = orderEo.CurrencyID,
                    Meta = orderEo.Meta,
                    UserId = orderEo.UserID,
                    CountryId = orderEo.CountryID,
                    UserKind = orderEo.UserKind,
                    OperatorId = orderEo.OperatorID,
                    Status = status ? 0 : 1,
                    OrderID= orderEo.OrderID,
                    AppOrderId= orderEo.AppOrderId
                };
                await MQUtil.PublishAsync(firstCashMsg);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送用户提现消息异常！");
            }
        }
    }
}
