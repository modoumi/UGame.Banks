using Microsoft.AspNetCore.Http;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Common.Caching;

using Xxyy.Common;
using Xxyy.DAL;
using Xxyy.MQ.Bank;
using TinyFx.Data;
using TinyFx.Text;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Mongopay.CallbackSvc
{
    /// <summary>
    /// 
    /// </summary>
    public class CallbackService : PayCallbackServiceBase<CallbackIpoCommonBase, string>
    {
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        //private readonly Sb_order_trans_logMO _orderTransLog = new();
        private readonly Sb_user_vanumberMO _userVanumberMo = new();
        //private readonly Sc_cash_auditMO _cashAuditMo = new();

        private const string BANKID = "mongopay";

        private HttpRequest _request;
        /// <summary>
        /// 
        /// </summary>
        public CallbackService()
        {
            _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext?.Request;
        }

        /// <summary>
        /// spei支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<string> SpeiPayCallback(SpeiPayNotifyIpo ipo)
        {
            var ret = "SUCCESS";
            try
            {
                //-1.添加银行通讯日志 
                //await AddBankTransLog(ipo, null, 0, null, null);
                await AddBankTransLog(ipo, ipo.OrderNum, BANKID, _request.Path.Value, null, 0, null, null);
                //获取银行信息
                var bank = DbBankCacheUtil.GetBank(BANKID);
                var userDcache = new GlobalUserDCache(ipo.Name);
                if (!await userDcache.KeyExistsAsync())
                {
                    var s_userEo = await DbSink.BuildUserMo(ipo.Name).GetByPKAsync(ipo.Name);
                    if (null == s_userEo) throw new Exception($"用户不存在！UserID:{ipo.Name}");
                    await userDcache.SetBaseValues(s_userEo);
                }
                var userKind = (int)await userDcache.GetUserKindAsync();
                if (userKind != (int)UserKind.LocalTester)
                {
                    // sign
                    if (!VerifyResponseDataByPublicKey(ipo.PlatSign, bank.TrdPublicKey, () => SignHelper.GetSign(ipo)))
                    {
                        //return "FAIL";
                        throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE);
                    }
                }
                var userVanumberEo = await _userVanumberMo.GetByPKAsync(ipo.Name);
                if (userVanumberEo == null || userVanumberEo.VaNumber != ipo.VaNumber)
                {
                    string errmsg = $"mongopay支付回调错误,uservanumber不存在！userId:{ipo.Name},vanumber:{ipo.VaNumber}";
                    LogUtil.Error(errmsg);
                    throw new Exception(errmsg);
                }
                //var orderPayCache = new OrderPayDCache(ipo.OrderNum);
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    //0.是否处理过
                    //var isOrderHandled = await CheckOrderHandled(ipo, tm);
                    var isOrderHandled = await CheckMongopayOrderHandled(ipo.PlatOrderNum, tm);
                    if (isOrderHandled)
                    {//已处理直接返回
                        tm.Rollback();
                        return ret;
                    }
                    string orderId = ObjectId.NewId();
                    //var userDcache = new GlobalUserDCache(ipo.Name);
                    //if (!userDcache.KeyExists())
                    //{
                    //    var s_userEo = await DbSink.BuildUserMo(ipo.Name).GetByPKAsync(ipo.Name);
                    //    if (null == s_userEo) throw new Exception($"用户不存在！UserID:{ipo.Name}");
                    //    await userDcache.SetBaseValues(s_userEo);
                    //}
                    string currencyId = await userDcache.GetCurrencyIdAsync();
                    string operatorId = await userDcache.GetOperatorIdAsync();
                    //int userKind = (int)userDcache.GetUserKind();
                    string countryId = await userDcache.GetCountryIdAsync();
                    var registDate = await userDcache.GetRegistDateAsync();
                    var ownMoney = ipo.PayMoney.MToA(currencyId);
                    var bankUtcTime = DateTime.UtcNow;
                    if (ipo.Status != "SUCCESS")
                    {
                        //添加失败订单
                        await AddBankOrder(ipo, orderId, 3, ownMoney, currencyId, operatorId, userKind, userVanumberEo.AppID, bankUtcTime, ipo.PayMoney, registDate,tm);
                        //更新银行通讯日志
                        await UpdateBankTransaLog(ipo, 2, null, tm);
                        tm.Commit();
                    }
                    else
                    {
                        var userEo = await DbSink.BuildUserMo(ipo.Name).GetByPKAsync(ipo.Name, tm);
                        if (null == userEo)
                            throw new Exception($"用户不存在！userId:{ipo.Name}");
                        //1.更新用户账户
                        //ipo.Balance = await BankUtil.UpdateUserCash(ipo.Name, ownMoney, tm);
                        var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Name, ownMoney, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;

                        //2.更新订单
                        await AddBankOrder(ipo, orderId, 2, ownMoney, currencyId, operatorId, userKind, userVanumberEo.AppID, bankUtcTime, ipo.PayMoney, registDate, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        tm.Commit();
                        //发送充值消息
                        await SendPayMsg(userEo.Cash,ipo,userVanumberEo.AppID, userKind, countryId, currencyId, operatorId, ownMoney);
                        //var gaid = await userDcache.GetGAIDAsync();
                        //var frommode = await userDcache.GetFromModeAsync();
                        //var fromid = await userDcache.GetFromIdAsync();
                        //await SendBranchPoint("PAY_SUCCESS", currencyId, gaid, orderId, operatorId, frommode, fromid, ipo);
                        //4.redis
                        //orderPayCache.SetOrderAndExpire((int)BankOrderStatusEnum.Success);
                    }
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret = "FAIL";
                    await UpdateBankTransaLog(ipo, 2, ex, null);
                }
            }
            catch (Exception ex)
            {
                ret = "FAIL";
                LogUtil.Error(ex, "spei支付回调处理异常");
            }
            return ret;
        }

        ///// <summary>
        ///// 发送branch打点
        ///// </summary>
        ///// <param name="pointname"></param>
        ///// <param name="currency"></param>
        ///// <param name="gaid"></param>
        ///// <param name="transactionid"></param>
        ///// <param name="operatorId"></param>
        ///// <param name="frommode"></param>
        ///// <param name="fromid"></param>
        ///// <param name="ipo"></param>
        ///// <returns></returns>
        //private async Task SendBranchPoint(string pointname, string currency, string gaid, string transactionid, string operatorId, int frommode, string fromid, SpeiPayNotifyIpo ipo)
        //{
        //    if (string.IsNullOrWhiteSpace(gaid)) return;

        //    try
        //    {
        //        await MQUtil.PublishAsync(new PayPointMsg
        //        {
        //            PointName = pointname,
        //            Currency = currency,
        //            Gaid = gaid,
        //            Money = ipo.PayMoney,
        //            Fee = ipo.PayFee,
        //            Transactionid = transactionid,
        //            UserId = ipo.Name,
        //            OperatorId = operatorId,
        //            PayType = (int)PayTypeEnum.Spei,
        //            PayTime = DateTime.UtcNow,
        //            FromId = fromid,
        //            FromMode = frommode
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex, $"发送speipay打点消息异常");
        //    }
        //}

        /// <summary>
        /// 发送充值消息
        /// </summary>
        /// <param name="payBeforeAmount"></param>
        /// <param name="ipo"></param>
        /// <param name="appId"></param>
        /// <param name="userKind"></param>
        /// <param name="countryId"></param>
        /// <param name="currencyId"></param>
        /// <param name="operatorId"></param>
        /// <param name="ownMoney"></param>
        /// <returns></returns>
        private async Task SendPayMsg(long payBeforeAmount, SpeiPayNotifyIpo ipo,string appId, int userKind, string countryId, string currencyId, string operatorId, long ownMoney)
        {
            try
            {
                //LogUtil.Info($"发送spei充值消息:{SerializerUtil.SerializeJsonNet(ipo)}");
                //await MQUtil.PublishAsync(new UserPayMsg
                //{
                //    UserId = ipo.Name,
                //    UserKind = userKind,
                //    PayTime = DateTime.UtcNow,
                //    CountryId = countryId,
                //    PayType = (int)PayTypeEnum.Spei,
                //    OperatorId = operatorId,
                //    OwnFee = ipo.PayFee,
                //    PayAmount = ownMoney,
                //    CurrencyId = currencyId,
                //    UserFee = 0
                //});
                var userPayMsgDo = new UserPayMsgDo { 
                 OrderId= ipo.Order.OrderID,
                 BankId=BANKID,
                 UserId=ipo.Name,
                 AppId=appId,
                 UserKind=userKind,
                 CountryId=countryId,
                 CurrencyId=currencyId,
                 OperatorId=operatorId,
                 Fee=ipo.PayFee,
                 EventSourceUrl= "https://www.lucro777.com/",
                 OwnMoney=ownMoney,
                 PayTypeEnum=PayTypeEnum.Spei,
                 PayBeforeAmount=payBeforeAmount,
                };
                await SendUserPayMsg(userPayMsgDo);

            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送spei充值消息异常");
            }
        }

        /// <summary>
        /// 检查是否处理过
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected async Task<bool> CheckMongopayOrderHandled(string orderId, TransactionManager tm)
        {
            //var orderEo = ipo.Order =
            var orderEos = await _bankOrderMo.GetAsync("BankId=@BankId and BankOrderId=@BankOrderId", tm, BANKID, orderId);
            return !(orderEos == null || orderEos.Count() == 0);
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="orderId"></param>
        /// <param name="status"></param>
        /// <param name="ownMoney"></param>
        /// <param name="currencyId"></param>
        /// <param name="operatorId"></param>
        /// <param name="userKind"></param>
        /// <param name="appId"></param>
        /// <param name="bankUtcTime"></param>
        /// <param name="transMoney"></param>
        /// <param name="registDate"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task AddBankOrder(SpeiPayNotifyIpo ipo, string orderId, int status, long ownMoney, string currencyId, string operatorId, int userKind, string appId,DateTime bankUtcTime,decimal transMoney,DateTime? registDate, TransactionManager tm)
        {
            //var appId = "lobby";
            var app = DbCacheUtil.GetApp(appId);
            //var provider = DbCacheUtil.GetProvider(app.ProviderID);
            var bankOrderEo = new Sb_bank_orderEO
            {
                OrderID = orderId,
                ProviderID = app.ProviderID,
                AppID = appId,
                OperatorID = operatorId,
                UserID = ipo.Name,
                UserKind = userKind,
                RegistDate= registDate,
                OrderType = (int)OrderTypeEnum.Charge,
                BankID = BANKID,
                PaytypeID = (int)PayTypeEnum.Spei,
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
                OrderMoney=transMoney,
                BankResponseTime = DateTime.UtcNow,
                BankOrderId = ipo.PlatOrderNum,
                BankCallbackTime = DateTime.UtcNow,
                BankTime= bankUtcTime,
                Amount = ownMoney,
                OwnFee = ipo.PayFee,
                UserFee = 0,
                UserMoney = -ipo.PayMoney,
                EndBalance = ipo.Balance,
                EndBonus = ipo.Bonus
            };
            ipo.Order = bankOrderEo;
            await _bankOrderMo.AddAsync(bankOrderEo, tm);
        }

        /// <summary>
        /// spei提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<string> SpeiCashCallback(SpeiCashNotifyIpo ipo)
        {
            var ret = "SUCCESS";
            try
            {
                await AddBankTransLog(ipo, ipo.OrderNum, BANKID, _request.Path.Value, null, 0, null, null);
                //获取银行信息
                var bank = DbBankCacheUtil.GetBank(BANKID);
                // sign
                if (!VerifyResponseDataByPublicKey(ipo.PlatSign, bank.TrdPublicKey, () => SignHelper.GetSign(ipo)))
                    throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE);
                var orderPayCache = new OrderPayDCache(ipo.OrderNum);

                //代付订单状态  2：代付成功    3和4：代付失败（注：存在返回2成功之后再返回4失败的情况，即退回。当状态更改时我们会再次发送通知，商户需实现处理该种情况的业务逻辑）
                var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                try
                {
                    var isOrderHandled = await CheckOrderHandled(ipo, ipo.OrderNum, tm);
                    var ownMoney = ipo.Money.MToA(ipo.Order.CurrencyID);
                    if (ownMoney != ipo.Order.TransMoney.MToA(ipo.Order.CurrencyID))
                        throw new Exception($"提现金额ipo.money:{ipo.Money}与订单金额TransMoney:{ipo.Order.TransMoney}不一致！orderid:{ipo.Order.OrderID}");
                    if (ipo.Status == "3")//失败
                    {
                        if (isOrderHandled)
                        {
                            tm.Rollback();
                            return ret;
                        }
                        //账户余额还原
                        var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;
                        //更新订单状态:失败
                        await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Draw,null, tm);
                        //记录银行日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);

                        await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Fail);
                        tm.Commit();
                    }
                    else if (ipo.Status == "4")
                    {
                        BankOrderStatusEnum orderStatus = BankOrderStatusEnum.Initial;
                        //存在之前返回2成功的订单需要回退处理
                        if (isOrderHandled)
                        {
                            #region MyRegion
                            //已处理的成功需要回退
                            //1.更新用户账户
                            //var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                            //ipo.Balance = endBalance;
                            //ipo.Bonus = endBonus;
                            ////2.更新订单
                            //await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Rollback, OrderTypeEnum.Draw, tm);
                            ////3.添加银行通讯日志
                            //await UpdateBankTransaLog(ipo, 1, null, tm);
                            ////4.redis
                            //await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Rollback);
                            #endregion
                            orderStatus = BankOrderStatusEnum.Rollback;
                        }
                        else
                        {
                            #region MyRegion
                            //账户余额还原
                            //var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                            //ipo.Balance = endBalance;
                            //ipo.Bonus = endBonus;
                            ////直接更新为失败
                            //await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Draw, tm);
                            //await UpdateBankTransaLog(ipo, 1, null, tm);
                            //await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Fail);
                            #endregion
                            orderStatus = BankOrderStatusEnum.Fail;
                        }
                        var (endBalance, endBonus) = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ipo.Order.Amount, tm);
                        ipo.Balance = endBalance;
                        ipo.Bonus = endBonus;
                        //2.更新订单
                        await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, orderStatus, OrderTypeEnum.Draw,null, tm);
                        //3.添加银行通讯日志
                        await UpdateBankTransaLog(ipo, 1, null, tm);
                        //4.redis
                        await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)orderStatus);
                        tm.Commit();
                    }
                    else if (ipo.Status == "2")
                    {
                        //0.是否处理过
                        if (isOrderHandled)
                        {
                            tm.Rollback();
                            return ret;
                        }
                        //1.更新用户账户 2023-04-11 成功不更新账户，修改状态
                        //ipo.Balance = await BankUtil.UpdateUserCash(ipo.Order.UserID, -ownMoney, tm);
                        //2.更新订单
                        var ownFee = 0M;
                        var userFee = 0M;
                        //用户实际到账金额
                        var userMoney = 0M;
                        if (ipo.FeeType == "0")
                        {
                            userFee = ipo.Fee;
                            userMoney = ipo.Money - ipo.Fee;
                        }
                        else if (ipo.FeeType == "1")
                        {
                            ownFee = ipo.Fee;
                            userMoney = ipo.Money;
                        }
                        else
                        {
                            throw new Exception($"未知的手续费收取方式:{ipo.FeeType}");
                        }
                        await UpdateBankOrder(ipo, ipo.PlatOrderNum, ownFee, userFee, userMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Draw,null, tm);
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
                        throw new Exception($"状态异常：没有该状态的逻辑{ipo.Status}");
                    }
                }
                catch (OrderStatusException ex)
                {
                    tm.Rollback();
                    ret = "FAIL";
                    LogUtil.Warning(ex, $"mongopay提现回调处理订单状态异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (DuplicateUpdateOrderException ex)
                {
                    tm.Rollback();
                    ret = "FAIL";
                    LogUtil.Warning(ex, $"mongopay提现回调处理订单更新异常！ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                }
                catch (Exception ex)
                {
                    tm.Rollback();
                    ret = "FAIL";
                    //更新订单状态
                    await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.Order.OwnFee, ipo.Order.UserFee, ipo.Order.UserMoney, BankOrderStatusEnum.Exception, OrderTypeEnum.Draw,null, null);
                    //银行日志
                    await UpdateBankTransaLog(ipo, 3, ex, null);
                    await BankUtil.SetOrderCacheAsync(orderPayCache, ipo.Order.Amount, ipo.Order, (int)BankOrderStatusEnum.Exception);
                }
            }
            catch (Exception ex)
            {
                ret = "FAIL";
                LogUtil.Error(ex, $"spei提现回调处理异常!ipo:{SerializerUtil.SerializeJsonNet(ipo)}");
                //var exc = ExceptionUtil.GetException<CustomException>(ex);
                //dto.Status = (exc != null) ? exc.Code : BankStatusCodes.RS_UNKNOWN;
            }
            return ret;
        }


        /// <summary>
        /// 更新提现统计信息
        /// </summary>
        /// <param name="orderEo"></param>
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
                    PayType = (int)PayTypeEnum.Spei,
                    Meta = orderEo.Meta,
                    OrderID = orderEo.OrderID
                };
                await SendUserCashMsg(userCashMsgDo);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, $"发送用户spei提现消息异常！");
            }
        }
    }
}
