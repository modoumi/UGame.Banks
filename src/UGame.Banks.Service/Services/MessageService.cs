using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using UGame.Banks.Service.Common;
using Xxyy.Common.Caching;
using Xxyy.Common;
using Xxyy.MQ.Bank;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Services
{
    /// <summary>
    /// 消息服务（用户充值，用户提现）
    /// </summary>
    public class MessageService
    {
        private Sb_order_trans_logMO _orderTransLogMo=new();
        
        /// <summary>
        /// 发送用户充值消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="payBeforeAmount"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public async Task SendUserPayMsg(Sb_bank_orderEO orderEo, long payBeforeAmount, string countryId)
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
            var payUtcNow = DateTime.UtcNow;
            await MQUtil.PublishAsync(new UserPayMsg
            {
                UserId = orderEo.UserID,
                AppId = orderEo.AppID,
                UserKind = orderEo.UserKind,
                PayTime = payUtcNow,
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
                PayBeforeAmount = payBeforeAmount
            });


            ////是否是首充消息
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
                PayTime = payUtcNow,
                UserId = orderEo.UserID,
                UserKind = orderEo.UserKind,
                OperatorId = orderEo.OperatorID,
                OrderID = orderEo.OrderID,
                EventSourceUrl = ""
            };

            await MQUtil.PublishAsync(firstPayMsg);
        }


        /// <summary>
        /// 发送用户提现消息
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task SendUserCashMsg(Sb_bank_orderEO orderEo,bool status)
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
                //var countryId =await userDCache.GetCountryIdAsync();
                DateTime cashTime = DateTime.UtcNow;
                await MQUtil.PublishAsync(new UserCashMsg
                {
                    OrderID=orderEo.OrderID,
                    UserId = orderEo.UserID,
                    AppId=orderEo.AppID,
                    UserKind = orderEo.UserKind,
                    CashAmount =Math.Abs(orderEo.Amount),
                    CountryId = orderEo.CountryID,
                    CurrencyId = orderEo.CurrencyID,
                    CashTime = cashTime,
                    PayType = orderEo.PaytypeID,
                    PaytypeChannel=orderEo.PaytypeChannel,
                    Meta = orderEo.Meta,
                    OperatorId = orderEo.OperatorID,
                    OwnFee = orderEo.OwnFee,
                    UserFee = orderEo.UserFee,
                    FirstCashOfDay = orderEo.IsFirstCashOfDay,
                    IsFirst = isFirst,
                    Status = status ? 0 : 1,
                    AppOrderId = orderEo.AppOrderId
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
                    CountryId=orderEo.CountryID,
                    UserKind = orderEo.UserKind,
                    OperatorId = orderEo.OperatorID,
                    Status= status ? 0 : 1,
                    OrderID = orderEo.OrderID,
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
