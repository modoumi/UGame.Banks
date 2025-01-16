using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Net;
using TinyFx;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Service;
using Xxyy.Common.Caching;
using Xxyy.Common;
using Xxyy.MQ.Bank;
using TinyFx.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using UGame.Banks.Service.Services.Cash;
using System.Security.Policy;
using Xxyy.Banks.DAL;
using UGame.Banks.Service.MQMsg;
using Pipelines.Sockets.Unofficial.Buffers;
using TinyFx.AspNet;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Letspay.Resp;

namespace UGame.Banks.Letspay.Service
{
    public abstract class MexCallbackServiceBase : PayCallbackServiceBase<CallbackIpoCommonBase, LetsCallbackDto>
    {
        //private HttpRequest _request;
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_bankMO _bankMo = new();
        private readonly Sb_order_trans_logMO _orderTranslogMo = new();
        /// <summary>
        /// 
        /// </summary>
        public MexCallbackServiceBase()
        {
            //_request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext?.Request;
        }

        public abstract decimal GetPayFee(decimal payMoney, string bankId);

        /// <summary>
        /// letspay支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<LetsCallbackDto> PayCallback(PayInAsyncResponse ipo)
        {
            var ret = new LetsCallbackDto();
            try
            {
                string orderId = ipo.orderNo;

                //-1.添加银行通讯日志
                await AddBankTransLog(ipo, orderId, "", HttpContextEx.Request?.Path.Value, null, 0, null, null);

                var order = await _bankOrderMo.GetByPKAsync(orderId);
                if (order == null)
                {
                    LogUtil.Warning($"letspay订单:{orderId}没找到");
                    return ret;
                }
                else
                {
                    ipo.Order = order;
                    if (order.Status > 1)
                    {
                        LogUtil.Warning($"letspay订单:{orderId}状态{order.Status}");
                        return ret;
                    }
                }

                decimal money = decimal.Parse(ipo.amount);
                ipo.Order.OwnFee = ipo.fee = GetPayFee(money,order.BankID);

                if (order.TransMoney.MToA(order.CurrencyID) != money.MToA(order.CurrencyID))
                    throw new Exception($"代收金额amount:{ipo.amount}与订单金额transmoney:{order.TransMoney}不一致！orderid:{order.OrderID}");

                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    var ownMoney = money.MToA(ipo.Order.CurrencyID);
                    var bankTime = string.IsNullOrWhiteSpace(ipo.paySuccTime) ? DateTime.UtcNow :DateTimeUtil.ParseTimestamp(ipo.paySuccTime.ToInt64(),true);
                    ipo.Order.SettlStatus = (int)SettlStatusEnum.Consistent;
                    if (ipo.status == "2")
                    {
                        var userEo = await DbSink.BuildUserMo(order.UserID).GetByPKAsync(order.UserID, tm);
                        if (null == userEo)
                            throw new Exception($"用户不存在！userId:{order.UserID}");
                        if (ipo.Order.IsAddBalance)
                        {
                            //1.更新用户账户
                            var (endBalance, endBonus) = await BankUtil.UpdateUserCash(order.UserID, ownMoney, tm);
                            ipo.Order.EndBalance = ipo.Balance = endBalance;
                            ipo.Order.EndBonus = ipo.Bonus = endBonus;
                        }
                        else
                        {
                            //充值不操作账户余额
                            //1.更新用户账户
                            ipo.Order.EndBalance = ipo.Balance = userEo.Cash;
                            ipo.Order.EndBonus = ipo.Bonus = userEo.Bonus;
                        }
                        //2.更新订单
                        await UpdateBankOrder(ipo, order.BankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Charge, bankTime, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        tm.Commit();
                        //更新统计信息
                        await SendUserPayMsg(ipo.Order, ipo.Order.CountryID, userEo.Cash);
                        ret.status = "success";
                    }
                    else
                    {
                        //添加失败订单
                        await UpdateBankOrder(ipo, order.BankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Charge, bankTime, tm);
                        //更新银行通讯日志
                        await UpdateBankTransaLog(ipo, 2, null, tm);
                        await MQUtil.PublishAsync(new BankErrorMsg
                        {
                            BankId = ipo.Order.BankID,
                            Channel = 0,
                            Money = order.OrderMoney,
                            CurrencyId = order.CurrencyID,
                            ErrorMsg = $"orderid:{orderId},userid:{order.UserID}充值回调失败！status:{ipo.status}",
                            OrderType = OrderTypeEnum.Charge,
                            Paytype = PayTypeEnum.Letspay,
                            UserId = order.UserID,
                            OrderId = orderId,
                            RecDate = bankTime,
                            Remark = ipo
                        });
                        tm.Commit();
                    }
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    await UpdateBankTransaLog(ipo, 2, ex, null);
                }
            }
            catch (Exception ex)
            {
                ret.status = "error";
                LogUtil.Error(ex, "letspay支付回调处理异常");
            }
            return ret;
        }

        /// <summary>
        /// letspay提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<LetsCallbackDto> CashCallback(PayOutAsyncResponse ipo)
        {
            var ret = new LetsCallbackDto() { };
            try
            {
                LogUtil.Info($"letspay提现回调 body:{ipo}");

                if (!decimal.TryParse(ipo.amount, out var cashMoney))
                    throw new ArgumentException($"参数异常！amount:{ipo.amount}");

                var orderId = ipo.mchTransNo;
                await AddBankTransLog(ipo, orderId,"", HttpContextEx.Request?.Path.Value, null, 0, null, null);

                var order = await _bankOrderMo.GetByPKAsync(orderId);
                if (order == null)
                {
                    LogUtil.Warning($"letspay订单{orderId}没找到");
                    return ret;
                }
                else
                {
                    ipo.Order = order;
                    if (order.Status > 1)
                    {
                        LogUtil.Warning($"letspay订单{orderId}状态{order.Status}");
                        return ret;
                    }
                }

                if(order.TransMoney!=cashMoney)
                    throw new Exception($"代付金额amount:{ipo.amount}与订单金额transmoney:{order.TransMoney}不一致！orderid:{order.OrderID}");
                string bankOrderId = order.BankOrderId;

                var orderPayCache = new OrderPayDCache(orderId);

                //代付订单状态status:  SUCCESS, FAIL
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    //获取用户订单
                    var isOrderHandled = await CheckOrderHandled(ipo, orderId, tm);
                    if (isOrderHandled)
                    {
                        tm.Rollback();
                        ret.status = "success";
                        return ret;
                    }

                    var ownMoney = cashMoney.MToA(ipo.Order.CurrencyID);//放大100倍
                    LogUtil.Info($"letspay提现回调 detail:{ipo}");
                    var bankTime = string.IsNullOrWhiteSpace(ipo.transSuccTime) ? DateTime.UtcNow :DateTimeUtil.ParseTimestamp(ipo.transSuccTime.ToInt64(),true);
                    ipo.Order.SettlStatus = (int)SettlStatusEnum.Consistent;
                    if (ipo.status == "2") //成功
                    {
                        //2.更新订单
                        decimal ownFee = 0M, userFee = 0M;
                        //用户实际到账金额
                        var userMoney = cashMoney;
                        if (ipo.Order.UserFeeAmount > 0)
                        {
                            ipo.Order.OwnFee = ownFee = ipo.fee = GetPayFee(cashMoney, order.BankID);
                        }
                        else
                        {
                            ipo.Order.UserFee = userFee = ipo.fee = GetPayFee(cashMoney, order.BankID);
                        }
                       //ipo.Order.UserFee= userFee = ipo.fee = GetPayFee(cashMoney, order.BankID);
                        await UpdateBankOrder(ipo, bankOrderId, ownFee, userFee, userMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Draw, bankTime, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        //4.redis
                        await BankUtil.SetOrderCacheAsync(orderPayCache, -ownMoney, ipo.Order, (int)BankOrderStatusEnum.Success);
                        tm.Commit();
                        //发送提现消息
                        //await SendCashMsg(ipo.Order, userFee, ownFee, ownMoney,true);
                        await SendUserCashMsg2(ipo.Order,true);
                        ret.status = "success";
                    }
                    else
                    {
                        LogUtil.Info("letspay提现回调失败ipo:{0}",SerializerUtil.SerializeJsonNet(ipo));
                        ////账户余额还原
                        //var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                        var userEo = await DbSink.BuildUserMo(ipo.Order.UserID).GetByPKAsync(ipo.Order.UserID, tm);
                        if (null == userEo)
                            throw new Exception($"letspay提现回调失败!用户不存在!userid:{ipo.Order.UserID}");
                        ipo.Order.EndBalance = ipo.Balance = userEo.Cash;
                        ipo.Order.EndBonus = ipo.Bonus = userEo.Bonus;
                        //更新订单状态:失败
                        await UpdateBankOrder(ipo, bankOrderId, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Draw, null, tm);
                        //记录银行日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Fail);
                        await MQUtil.PublishAsync(new BankErrorMsg
                        {
                            BankId = order.BankID,
                            Channel = 0,
                            Money = order.OrderMoney,
                            CurrencyId = order.CurrencyID,
                            ErrorMsg = $"orderid:{orderId},userid:{ipo.Order.UserID}提现回调失败！status:{ipo.status}",
                            OrderType = OrderTypeEnum.Draw,
                            Paytype = PayTypeEnum.Letspay,
                            UserId = ipo.Order.UserID,
                            OrderId = orderId,
                            RecDate = bankTime,
                            Remark = ipo
                        });
                        ret.status = "success";
                        tm.Commit();
                        //发送提现消息
                        await SendUserCashMsg2(ipo.Order, false);
                    }
                }
                catch (OrderStatusException ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    LogUtil.Warning(ex, $"letspay提现回调处理订单状态异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (DuplicateUpdateOrderException ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    LogUtil.Warning(ex, $"letspay提现回调处理订单更新异常！ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    //更新订单状态
                    await UpdateBankOrder(ipo, bankOrderId, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Exception, OrderTypeEnum.Draw, null, null);
                    //银行日志
                    await UpdateBankTransaLog(ipo, 3, ex, null);
                    await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Exception);
                }
            }
            catch (Exception ex)
            {
                ret.status = "error";
                LogUtil.Error(ex, $"letspay提现回调处理异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            }
            return ret;
        }



        ///// <summary>
        ///// 发送提现消息
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <param name="countryId"></param>
        ///// <param name="userFee"></param>
        ///// <param name="ownFee"></param>
        ///// <param name="ownMoney"></param>
        ///// <param name="status"></param>
        ///// <returns></returns>
        //private async Task SendCashMsg(Sb_bank_orderEO orderEo, decimal userFee, decimal ownFee, long ownMoney,bool status)
        //{
        //    try
        //    {
        //        var userCashMsgDo = new UserCashMsgDo
        //        {
        //            UserId = orderEo.UserID,
        //            UserKind = orderEo.UserKind,
        //            CashAmount = ownMoney,
        //            CountryId = orderEo.CountryID,
        //            AppId = orderEo.AppID,
        //            CurrencyId = orderEo.CurrencyID,
        //            IsFirstCashOfDay = orderEo.IsFirstCashOfDay,
        //            OperatorId = orderEo.OperatorID,
        //            OwnFee = ownFee,
        //            UserFee = userFee,
        //            PayType = (int)PayTypeEnum.Letspay,
        //            Meta = orderEo.Meta,
        //            OrderID = orderEo.OrderID,
        //            Status=status
        //        };
        //        await SendUserCashMsg(userCashMsgDo);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex, $"发送用户letspay提现消息异常！");
        //    }
        //}
    }
}
