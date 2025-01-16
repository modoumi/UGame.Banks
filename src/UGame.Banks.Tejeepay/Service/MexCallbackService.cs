﻿using Newtonsoft.Json;
using System.Web;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.MQMsg;
using UGame.Banks.Service.Services.Cash;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Tejeepay.Common;
using UGame.Banks.Tejeepay.Ipo;
using UGame.Banks.Tejeepay.Resp;
using Xxyy.Banks.DAL;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Banks.Tejeepay.Service
{
    public class MexCallbackService : PayCallbackServiceBase<CallbackIpoCommonBase, TejeeCallbackDto>
    {
        //private HttpRequest _request;
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private Sb_bankEO _bank;
        private const int MULTIPLE = 100;
        private decimal payoutFee = 0;
        private decimal payinFee = 0;

        private string privateKey;
        private BankConfig _bankConfig;
        private const decimal PERFEE = 3M;
        /// <summary>
        /// 
        /// </summary>
        public MexCallbackService(string bankId)
        {
            //_request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext?.Request;
            
            _bank = DbBankCacheUtil.GetBank(bankId);
            _bankConfig = _bank.BankConfig.ToSafeDeserialize<BankConfig>();
            privateKey = _bankConfig.PrivateKey;
            payinFee = _bank.PayFee;
            payoutFee = _bank.CashFee;
        }

        /// <summary>
        /// tejeepay支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<TejeeCallbackDto> PayCallback(CommonPayAsyncResponse ipo)
        {
            var ret = new TejeeCallbackDto();
            try
            {
                string orderId = ipo.body.orderId;
                string bankOrderId = ipo.body.tradeId;

                //-1.添加银行通讯日志
                await AddBankTransLog(ipo, orderId, this._bank.BankID, HttpContextEx.Request?.Path.Value, null, 0, null, null);

                var order = await _bankOrderMo.GetByPKAsync(orderId);
                if (order == null)
                {
                    LogUtil.Warning($"tejeepay订单{orderId}没找到");
                    return ret;
                }
                else
                {
                    ipo.Order = order;
                    if (order.Status > 1&&order.Status!=(int)BankOrderStatusEnum.Fail)
                    {
                        LogUtil.Warning($"tejeepay订单{orderId}状态{order.Status}");
                        return ret;
                    }
                }

                string userId = order.UserID;
                decimal money = decimal.Parse(ipo.body.amount);

                if ((long)order.TransMoney != (long)money)
                    throw new Exception($"代付金额amount:{ipo.body.amount}与订单金额transmoney:{order.TransMoney}不一致！orderid:{order.OrderID}");
                var fee= long.Parse(ipo.body.amount) / MULTIPLE * payinFee;
                ipo.Order.OwnFee= ipo.fee = fee< PERFEE ? PERFEE : fee;

                var userDcache = await GlobalUserDCache.Create(userId);
                if (!await userDcache.KeyExistsAsync())
                {
                    var s_userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId);
                    if (null == s_userEo)
                        throw new Exception($"用户不存在！UserID:{userId}");
                    await userDcache.SetBaseValues(s_userEo);
                }
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    //string currencyId = await userDcache.GetCurrencyIdAsync();
                    string currencyId = ipo.Order.CurrencyID;
                    //string operatorId = ipo.Order.OperatorID;
                    //int userKind = (int)await userDcache.GetUserKindAsync();
                    string countryId = await userDcache.GetCountryIdAsync();

                    var ownMoney = (money / MULTIPLE).MToA(currencyId); //放大100倍
                    var bankOrderSuccessTime = string.IsNullOrWhiteSpace(ipo.body.chargeTime) ? DateTime.UtcNow : ipo.body.chargeTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(ipo.Order.OperatorID);
                    ipo.Order.SettlStatus = (int)SettlStatusEnum.Consistent;
                    if (ipo.head.respCode == "0000" && ipo.body.status == "SUCCESS")
                    { 
                        var userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId, tm);
                        if (null == userEo)
                            throw new Exception($"用户不存在！userId:{userId}");
                        if (ipo.Order.IsAddBalance)
                        {
                            //1.更新用户账户
                            var (endBalance, endBonus) = await BankUtil.UpdateUserCash(userId, ownMoney, tm);
                            ipo.Order.EndBalance = ipo.Balance = endBalance;
                            ipo.Order.EndBonus = ipo.Bonus = endBonus;
                        }
                        else
                        {
                            //充值不操作账户余额
                            ipo.Order.EndBalance = ipo.Balance = userEo.Cash;
                            ipo.Order.EndBonus = ipo.Bonus = userEo.Bonus;
                        }
                        //2.更新订单
                        await UpdateBankOrder(ipo, bankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Charge, bankOrderSuccessTime, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        tm.Commit();
                        ret.status = "SUCCESS";
                        //更新统计信息
                        //await SendPayMsg(userEo.Cash, ipo, userId, order.AppID, ipo.Order.UserKind, countryId, currencyId, ipo.Order.OperatorID, ownMoney, order);
                        await SendUserPayMsg(ipo.Order,countryId,userEo.Cash);
                    }
                    else
                    {
                        //添加失败订单
                        await UpdateBankOrder(ipo, bankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Charge,bankOrderSuccessTime, tm);
                        //更新银行通讯日志
                        await UpdateBankTransaLog(ipo, 2, null, tm);
                        await MQUtil.PublishAsync(new BankErrorMsg
                        {
                            BankId = this._bank.BankID,
                            Channel = 0,
                            Money = order.TransMoney/MULTIPLE,
                            CurrencyId= order.CurrencyID,
                            ErrorMsg = $"orderid:{orderId},userid:{ipo.Order.UserID}充值回调失败！respCode:{ipo.head?.respCode},status:{ipo.body?.status}",//ipo.head.respMsg
                            OrderType = OrderTypeEnum.Charge,
                            Paytype = PayTypeEnum.Tejeepay,
                            UserId =userId,
                            OrderId = orderId,
                            RecDate = bankOrderSuccessTime,
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
                LogUtil.Error(ex, "tejeepay支付回调处理异常！param:{0}", SerializerUtil.SerializeJsonNet(new { ipo,ret}));
            }
            return ret;
        }

        /// <summary>
        /// tejeepay提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<TejeeCallbackDto> CashCallback(ProxyPayAsyncResponse ipo)
        {
            var ret = new TejeeCallbackDto();
            try
            {
                string data = RSAUtils.decrypt(HttpUtility.UrlDecode(ipo.body.ToString()), privateKey);//jo["body"].ToString()
                LogUtil.Info($"tejeepay提现回调 body:{data}");
                var body = JsonConvert.DeserializeObject<ProxyPayAsynBody>(data);
                //var fee = long.Parse(body.totalAmount) / MULTIPLE * payoutFee;
                //ipo.fee = fee<PERFEE?PERFEE:fee;
                var orderId = body.batchOrderNo;
                var bankOrderId = body.tradeId;
                await AddBankTransLog(ipo, orderId, this._bank.BankID, HttpContextEx.Request?.Path.Value, null, 0, null, null);

                var orderPayCache = new OrderPayDCache(orderId);

                if ("NONE" == body.status)
                {
                    return ret;
                }

                //代付订单状态status:  SUCCESS, FAIL
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    //获取用户订单
                    var isOrderHandled = await CheckOrderHandled(ipo, orderId, tm);
                    if (isOrderHandled)
                    {
                        tm.Rollback();
                        ret.status = "SUCCESS";
                        return ret;
                    }
                    var detail = body.detail[0];
                    if (detail == null)
                        throw new ArgumentException($"tejee提现detail异常!detail为空！");
                    if (!decimal.TryParse(detail.amount, out var tejeeMoney))
                        throw new ArgumentException($"参数异常！amount:{detail.amount}");

                    if ((long)ipo.Order.TransMoney != (long)tejeeMoney)
                        throw new Exception($"代付金额amount:{detail.amount}与订单金额transmoney:{ipo.Order.TransMoney}不一致！orderid:{ipo.Order.OrderID}");

                    var ownMoney = (tejeeMoney / MULTIPLE).MToA(ipo.Order.CurrencyID);//放大100倍
                    LogUtil.Info($"tejeepay提现回调 detail:{detail}");
                    var bankTime =string.IsNullOrWhiteSpace(detail.finishTime)?DateTime.UtcNow:detail.finishTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(ipo.Order.OperatorID);
                    ipo.Order.SettlStatus = (int)SettlStatusEnum.Consistent;
                    if (ipo.head.respCode == "0000" && detail.status == "SUCCESS") //成功
                    {
                        //2.更新订单
                        decimal ownFee = 0M, userFee = 0M;
                        //用户实际到账金额
                        var userMoney = tejeeMoney / MULTIPLE;
                        //userFee = ipo.Order.UserFee;
                        //userFee = ipo.fee;
                        //ipo.Order.SettlStatus = (int)SettlStatusEnum.Consistent;
                        if (ipo.Order.UserFeeAmount > 0)
                        {
                            ipo.Order.OwnFee = ownFee = GetCashFee(ipo.Order.OrderMoney);
                        }
                        else
                        {
                            ipo.Order.UserFee = userFee = GetCashFee(ipo.Order.OrderMoney);
                        }
                        await UpdateBankOrder(ipo, bankOrderId, ownFee, userFee, userMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Draw, bankTime, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        //4.redis
                        await BankUtil.SetOrderCacheAsync(orderPayCache, -ownMoney, ipo.Order, (int)BankOrderStatusEnum.Success);
                        tm.Commit();
                        //发送提现消息
                        //await SendCashMsg(ipo.Order, userFee, ownFee, ownMoney);
                        await SendUserCashMsg2(ipo.Order, true);
                        ret.status = "SUCCESS";
                    }
                    else
                    {
                        LogUtil.Info($"tejeepay提现回调失败!data:{SerializerUtil.SerializeJsonNet(data)}");
                        ////账户余额还原
                        //var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                        var userEo = await DbSink.BuildUserMo(ipo.Order.UserID).GetByPKAsync(ipo.Order.UserID, tm);
                        if (null == userEo)
                            throw new Exception($"tejeepay提现回调失败!用户不存在!userid:{ipo.Order.UserID},orderid:{ipo.Order.OrderID}");
                        ipo.Order.EndBalance= ipo.Balance = userEo.Cash;
                        ipo.Order.EndBonus = ipo.Bonus = userEo.Bonus;
                        //更新订单状态:失败
                        await UpdateBankOrder(ipo, bankOrderId, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Draw,null, tm);
                        //记录银行日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Fail);
                        await MQUtil.PublishAsync(new BankErrorMsg
                        {
                            BankId = this._bank.BankID,
                            Channel = 0,
                            Money = ipo.Order.TransMoney / MULTIPLE,
                            CurrencyId=ipo.Order.CurrencyID,
                            ErrorMsg = $"orderid:{orderId},userid:{ipo.Order.UserID}提现回调失败！respCode:{ipo.head?.respCode},status:{detail.status}",// ipo.head.respMsg
                            OrderType = OrderTypeEnum.Draw,
                            UserId = ipo.Order.UserID,
                            OrderId = orderId,
                            RecDate = bankTime,
                            Remark = ipo
                        });
                        ret.status = "SUCCESS";
                        tm.Commit();
                        await SendUserCashMsg2(ipo.Order, false);
                    }
                }
                catch (OrderStatusException ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    LogUtil.Warning(ex, $"tejeepay提现回调处理订单状态异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (DuplicateUpdateOrderException ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    LogUtil.Warning(ex, $"tejeepay提现回调处理订单更新异常！ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    //更新订单状态
                    await UpdateBankOrder(ipo, bankOrderId, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Exception, OrderTypeEnum.Draw, null,null);
                    //银行日志
                    await UpdateBankTransaLog(ipo, 3, ex, null);
                    await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Exception);
                }
            }
            catch (Exception ex)
            {
                ret.status = "error";
                LogUtil.Error(ex, $"tejeepay提现回调处理异常!param:{SerializerUtil.SerializeJsonNet(new { ipo,ret})}");
            }
            return ret;
        }


        public async Task<decimal> GetFee(CalcCashFeeIpo ipo) => Math.Truncate(100 * Math.Max((ipo.Amount - ipo.UserFeeAmount).AToM(ipo.CurrencyId) * _bank.CashFee, PERFEE)) / 100;

        
        private decimal GetCashFee(decimal payMoney)
        {
            return Math.Truncate(100 * Math.Max(payMoney * _bank.CashFee, PERFEE)) / 100;
        }

        ///// <summary>
        ///// 发送提现消息
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <param name="countryId"></param>
        ///// <param name="userFee"></param>
        ///// <param name="ownFee"></param>
        ///// <param name="ownMoney"></param>
        ///// <returns></returns>
        //private async Task SendCashMsg(Sb_bank_orderEO orderEo, decimal userFee, decimal ownFee, long ownMoney)
        //{
        //    try
        //    {
        //        var oper = DbCacheUtil.GetOperator(orderEo.OperatorID);
        //        //await MQUtil.PublishAsync(new UserCashMsg
        //        //{
        //        //    UserId = orderEo.UserID,
        //        //    UserKind = orderEo.UserKind,
        //        //    CashAmount = ownMoney,
        //        //    CountryId = oper.CountryID,
        //        //    CurrencyId = orderEo.CurrencyID,
        //        //    CashTime = DateTime.UtcNow,
        //        //    OperatorId = orderEo.OperatorID,
        //        //    OwnFee = ownFee,
        //        //    UserFee = userFee,
        //        //    FirstCashOfDay = orderEo.IsFirstCashOfDay
        //        //});
        //        var userCashMsgDo = new UserCashMsgDo
        //        {
        //            UserId = orderEo.UserID,
        //            UserKind = orderEo.UserKind,
        //            CashAmount = ownMoney,
        //            CountryId = oper.CountryID,
        //            AppId = orderEo.AppID,
        //            CurrencyId = orderEo.CurrencyID,
        //            IsFirstCashOfDay = orderEo.IsFirstCashOfDay,
        //            OperatorId = orderEo.OperatorID,
        //            OwnFee = ownFee,
        //            UserFee = userFee,
        //            PayType = (int)PayTypeEnum.Tejeepay,
        //            Meta = orderEo.Meta,
        //            OrderID=orderEo.OrderID
        //        };
        //        await SendUserCashMsg(userCashMsgDo);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex, $"发送用户tejeepay提现消息异常！");
        //    }
        //}
    }
}
