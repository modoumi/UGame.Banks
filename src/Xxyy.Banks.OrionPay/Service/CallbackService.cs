using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using Xxyy.Banks.BLL;
using Xxyy.Common.Caching;
using Xxyy.Common;
using TinyFx;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.Common;
using Microsoft.AspNetCore.Http;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.Orionpay.Ipo;
using Xxyy.Banks.Orionpay.Resp;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using Xxyy.MQ.Bank;
using System.Web;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using MySqlX.XDevAPI;
using System.Security.Cryptography.X509Certificates;
using TinyFx.Net;
using StackExchange.Redis;
using Xxyy.Banks.BLL.Services.Cash;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Orionpay.Service
{
    public class CallbackService : PayCallbackServiceBase<CallbackIpoCommonBase, OrionCallbackDto>
    {
        private HttpRequest _request;
        private HttpClientEx _client;
        private const string CLIENT_NAME = "banks.orionpay";
        private const string BANKID = "orionpay";
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_order_trans_logMO _orderTranslogMo = new();
        private Sb_bankEO _bank;
        private const string currencyType = "BRL";
        private const int MULTIPLE = 100;
        private decimal payinFee = 0;
        private decimal payoutFee = 0;
      
        //private string privateKey;
        /// <summary>
        /// 
        /// </summary>
        public CallbackService()
        {
            _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext?.Request;
            _client = HttpClientExFactory.CreateClientExFromConfig(CLIENT_NAME);
            //privateKey = _client.GetSettingValue<string>("privateKey");

            _bank = DbBankCacheUtil.GetBank(BANKID);
            payinFee = _bank.PayFee;
            payoutFee = _bank.CashFee;
        }

        /// <summary>
        /// Orionpay支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<OrionCallbackDto> PayCallback(OrionPayAsyncResponse ipo)
        {
            var ret = new OrionCallbackDto();
            try
            {
                string bankOrderId = ipo.id;
                string orderId = "";
                var order = await _bankOrderMo.GetSingleAsync("BankOrderId=@BankOrderId", bankOrderId);
                if (order == null)
                {
                    LogUtil.Warning($"Orionpay订单{bankOrderId}没找到");
                    return ret;
                }
                else
                {
                    ipo.Order = order;
                    orderId = order.OrderID;
                    if (ipo.Order.Status > 1)
                    {
                        LogUtil.Warning($"Orionpay订单{orderId}状态{order.Status}");
                        return ret;
                    }
                }

                //-1.添加银行通讯日志
                await AddBankTransLog(ipo, orderId, BANKID, _request.Path.Value, null, 0, null, null);
                string userId = order.UserID;
                decimal money = (decimal)ipo.amount;
                ipo.fee = ipo.amount / MULTIPLE * payinFee; //30
                ipo.Order.Meta = JsonConvert.SerializeObject(ipo.detailedInfo);//保存二维码信息
                var userDcache = new GlobalUserDCache(userId);
                if (!await userDcache.KeyExistsAsync())
                {
                    var s_userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId);
                    if (null == s_userEo)
                        throw new Exception($"用户不存在！UserID:{userId}");
                    await userDcache.SetBaseValues(s_userEo);
                }
                var tm = new TransactionManager();
                try
                {
                    LogUtil.Info($"Orionpay充值回调:{ipo.status}");
                    string currencyId = await userDcache.GetCurrencyIdAsync();
                    string operatorId = await userDcache.GetOperatorIdAsync();
                    int userKind = (int)await userDcache.GetUserKindAsync();
                    string countryId = await userDcache.GetCountryIdAsync();

                    var ownMoney = (money / MULTIPLE).MToA(currencyId); //放大100倍

                    if (ipo.status == "COMPLETED")
                    {
                        var userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId, tm);
                        if (null == userEo)
                            throw new Exception($"用户不存在！userId:{userId}");
                        //1.更新用户账户
                        var (endBalance,endBonus) = await BankUtil.UpdateUserCash(userId, ownMoney, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;
                        
                        //2.更新订单
                        await UpdateBankOrder(ipo, bankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Success,OrderTypeEnum.Charge,null, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        tm.Commit();
                        //更新统计信息
                        await SendPayMsg(userEo.Cash,orderId, order.AppID, ipo.fee, userId, userKind, countryId, currencyId, operatorId, ownMoney);
                        ////发送打点消息
                        //await SendBranchPoint("PAY_SUCCESS", currencyType, await userDcache.GetGAIDAsync(), orderId, operatorId, await userDcache.GetFromModeAsync(), await userDcache.GetFromIdAsync(), money, ipo.fee, userId);
                        ret.status = "success";
                    }
                    else if (ipo.status == "WAITING_PAYMENT")
                    {
                        //添加失败订单
                        await UpdateBankOrder(ipo, bankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Processing,OrderTypeEnum.Charge,null, tm);
                        //更新银行通讯日志
                        await UpdateBankTransaLog(ipo, 2, null, tm);
                        tm.Commit();
                    }
                    else
                    {
                        //添加失败订单
                        await UpdateBankOrder(ipo, bankOrderId, ipo.fee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Fail,OrderTypeEnum.Charge,null, tm);
                        //更新银行通讯日志
                        await UpdateBankTransaLog(ipo, 2, null, tm);
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
                LogUtil.Error(ex, "Orionpay支付回调处理异常");
            }
            return ret;
        }

        /// <summary>
        /// Orionpay提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<OrionCallbackDto> CashCallback(OrionPayAsyncResponse ipo)
        {
            var ret = new OrionCallbackDto();
            try
            {
                LogUtil.Info($"Orionpay提现回调 ipo:{ipo}");
                ipo.fee = ipo.amount / MULTIPLE * payoutFee; //10
                string bankOrderId = ipo.id;
                string orderId = "";
                var order = await _bankOrderMo.GetSingleAsync("BankOrderId=@BankOrderId", bankOrderId);
                if (order == null)
                {
                    LogUtil.Warning($"Orionpay订单{bankOrderId}没找到");
                    return ret;
                }
                else
                {
                    ipo.Order = order;
                    orderId = order.OrderID;
                    if (ipo.Order.Status > 1)
                    {
                        LogUtil.Warning($"Orionpay订单{orderId}状态{order.Status}");
                        return ret;
                    }
                }

                await AddBankTransLog(ipo, orderId, BANKID, _request.Path.Value, null, 0, null, null);
                var orderPayCache = new OrderPayDCache(orderId);

                //if ("NONE" == ipo.status)
                //{
                //    return ret;
                //}
                //代付订单状态status:  SUCCESS, FAIL
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    LogUtil.Info($"Orionpay提现回调:" + ipo.status);
                    //获取用户订单
                    var isOrderHandled = await CheckOrderHandled(ipo, orderId, tm);
                    if (isOrderHandled)
                    {
                        tm.Rollback();
                        return ret;
                    }
                    var orionMoney = ipo.amount;
                    var ownMoney = ((decimal)orionMoney / MULTIPLE).MToA(ipo.Order.CurrencyID);//放大100倍
                    if (ipo.status == "COMPLETED") //成功
                    {
                        //2.更新订单
                        decimal ownFee = 0M, userFee = 0M;
                        //用户实际到账金额
                        var userMoney = orionMoney / MULTIPLE;
                        if (ipo.Order.IsFirstCashOfDay)
                        {
                            ownFee = ipo.fee; //我方承担的手续费
                        }
                        else
                        {
                            userFee = ipo.fee; //用户承担的手续费为0
                        }
                        await UpdateBankOrder(ipo, bankOrderId, ownFee, userFee, userMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Draw,null, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        //4.redis
                        await BankUtil.SetOrderCacheAsync(orderPayCache, -ownMoney, ipo.Order, (int)BankOrderStatusEnum.Success);
                        //发送提现消息
                        await SendCashMsg(ipo.Order, userFee, ownFee, ownMoney);
                        ret.status = "success";
                    }
                    else if (ipo.status == "FAILED" || ipo.status == "CANCELED")
                    {
                        int status = ipo.status == "FAILED" ? 3 : 4;
                        //账户余额还原
                        var (endBalance,endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;
                        //更新订单状态:失败
                        await UpdateBankOrder(ipo, bankOrderId, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, (BankOrderStatusEnum)status,OrderTypeEnum.Draw,null, tm);
                        //记录银行日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);

                        await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, status);
                    }
                    tm.Commit();
                }
                catch (OrderStatusException ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    LogUtil.Warning(ex, $"Orionpay提现回调处理订单状态异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (DuplicateUpdateOrderException ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    LogUtil.Warning(ex, $"Orionpay提现回调处理订单更新异常！ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret.status = "error";
                    //更新订单状态
                    await UpdateBankOrder(ipo, bankOrderId, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Exception,OrderTypeEnum.Draw,null, null);
                    //银行日志
                    await UpdateBankTransaLog(ipo, 3, ex, null);
                    await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Exception);
                }
            }
            catch (Exception ex)
            {
                ret.status = "error";
                LogUtil.Error(ex, $"Orionpay提现回调处理异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
            }
            return ret;
        }


        public async Task<decimal> GetFee(CalcCashFeeIpo ipo)
        {
            var userDCache = new GlobalUserDCache(ipo.UserId);
            var lastCashDate = await userDCache.GetLastCashDateAsync();
            decimal feeIn, feeOut;
            if (lastCashDate.ToString("yyyyMMdd") != DateTime.UtcNow.ToString("yyyyMMdd"))
            {
                feeIn = ipo.Amount.AToM(ipo.CurrencyId) * payinFee;
                feeOut = 0;
            }
            else
            {
                feeIn = ipo.Amount.AToM(ipo.CurrencyId) * payinFee;
                feeOut = ipo.Amount.AToM(ipo.CurrencyId) * payoutFee;
            }
            return (feeOut);
        }

        //private async Task SendBranchPoint(string pointname, string currency, string gaid, string transactionid, string operatorId,
        //    int frommode, string fromid, decimal money, decimal fee, string userId)
        //{

        //    try
        //    {
        //        LogUtil.Info("发送Orionpay打点消息，params-userid:{0},money:{1},fee:{2},currency:{3}", userId, money, fee, currency);
        //        await MQUtil.PublishAsync(new PayPointMsg
        //        {
        //            PointName = pointname,
        //            Currency = currency,
        //            Gaid = gaid,
        //            Money = money,
        //            Fee = fee,
        //            UserId = userId,
        //            Transactionid = transactionid,
        //            OperatorId = operatorId,
        //            PayType = (int)PayTypeEnum.Orionpay,
        //            PayTime = DateTime.UtcNow,
        //            FromId = fromid,
        //            FromMode = frommode
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex, $"发送Orionpay打点消息异常");
        //    }
        //}


        private async Task SendPayMsg(long payBeforeAmount,string orderId,string appId, decimal fee, string userId, int userKind, string countryId, string currencyId, string operatorId, long ownMoney)
        {
            try
            {
                //var orderLogs = await _orderTranslogMo.GetTopAsync("OrderID=@OrderID and BankID=@BankID and TransType=@TransType and Status=@Status", 1, orderId, BANKID, 0, 1);
                //var orderTranslog = orderLogs?.FirstOrDefault();
                //var receiveBonus = orderTranslog?.ReceiveBonus ?? 0;
                ////if (null == orderTranslog)
                ////    return;
                //await MQUtil.PublishAsync(new UserPayMsg
                //{
                //    UserId = userId,
                //    UserKind = userKind,
                //    PayTime = DateTime.UtcNow,
                //    CountryId = countryId,
                //    PayType = (int)PayTypeEnum.Orionpay,
                //    OperatorId = operatorId,
                //    OwnFee = fee,
                //    PayAmount = ownMoney,
                //    CurrencyId = currencyId,
                //    UserFee = 0,
                //    OrderID = orderId,
                //    ReceiveBonus = receiveBonus
                //});
                var userPayMsgDo = new UserPayMsgDo
                {
                    OrderId =orderId,
                    BankId = BANKID,
                    UserId = userId,
                    AppId=appId,
                    UserKind = userKind,
                    CountryId = countryId,
                    CurrencyId = currencyId,
                    OperatorId = operatorId,
                    Fee = fee,
                    EventSourceUrl = "https://www.lucro777.com/",
                    OwnMoney = ownMoney,
                    PayTypeEnum = PayTypeEnum.Orionpay,
                    PayBeforeAmount=payBeforeAmount
                };
                await SendUserPayMsg(userPayMsgDo);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送tejee充值消息异常");
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
                var userCashMsgDo = new UserCashMsgDo
                {
                    UserId = orderEo.UserID,
                    UserKind = orderEo.UserKind,
                    CashAmount = ownMoney,
                    CountryId = oper.CountryID,
                    AppId = orderEo.AppID,
                    CurrencyId = orderEo.CurrencyID,
                    IsFirstCashOfDay = orderEo.IsFirstCashOfDay,
                    OperatorId = orderEo.OperatorID,
                    OwnFee = ownFee,
                    UserFee = userFee,
                    PayType = (int)PayTypeEnum.Orionpay,
                    Meta = orderEo.Meta,
                    OrderID=orderEo.OrderID
                };
                await SendUserCashMsg(userCashMsgDo);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送用户Orionpay提现消息异常！");
            }
        }
    }
}
