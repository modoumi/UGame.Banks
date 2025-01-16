using Microsoft.AspNetCore.Http;
using TinyFx;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using Xxyy.Banks.BLL;
using Xxyy.Banks.BLL.Caching;
using Xxyy.Banks.BLL.MQMsg;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;
using Xxyy.Banks.Mongopay.Models.Dto;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.DAL;

namespace Xxyy.Banks.Mongopay.Service
{
    /// <summary>
    /// mongoPay回调服务
    /// </summary>
    public class CallbackService : PayCallbackServiceBase<CallbackIpoCommonBase, string>
    {
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private const string BANKID = "mongopay";
        private const int MULTIPLE = 100;
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
        public async Task<string> SpeiPayCallback(PayNotifyIpo ipo)
        {
            var ret = "FAIL";
            try
            {
                //1.添加银行通讯日志
                await AddBankTransLog(ipo, ipo.OrderNum, BANKID, _request.Path.Value, null, 0, null, null);

                //2.获取订单信息
                var order = ipo.Order = await _bankOrderMo.GetByPKAsync(ipo.OrderNum);
                var userId = order.UserID;
                var bank = DbBankCacheUtil.GetBank(BANKID);
                if (order == default)
                {
                    string errmsg = $"mongopay支付回调错误,userName:{ipo.Name},订单{ipo.OrderNum}不存在!";
                    LogUtil.Error(errmsg);
                    return ret;
                }
                else
                {
                    //已经成功的，直接返回
                    if (order.Status == 2) return ret = "SUCCESS";

                    if (order.TransMoney != ipo.PayMoney)
                        throw new Exception($"代付金额amount:{ipo.PayMoney}与订单金额transmoney:{order.TransMoney}不一致！orderid:{order.OrderID}");

                    var userDcache = new GlobalUserDCache(order.UserID);
                    string countryId = await userDcache.GetCountryIdAsync();
                    if (!await userDcache.KeyExistsAsync())
                    {
                        var s_userEo = await DbSink.BuildUserMo(ipo.Name).GetByPKAsync(ipo.Name);
                        if (null == s_userEo) throw new Exception($"用户不存在！UserID:{ipo.Name}");
                        await userDcache.SetBaseValues(s_userEo);
                    }
                    var userKind = (int)await userDcache.GetUserKindAsync();
                    if (userKind != (int)UserKind.LocalTester)
                    {
                        if (!VerifyResponseDataByPublicKey(ipo.PlatSign, bank.TrdPublicKey, () => SignHelper.GetSign(ipo)))
                        {
                            throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE);
                        }
                    }

                    var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
                    try
                    {
                        var currencyId = await userDcache.GetCurrencyIdAsync();
                        var operatorId = await userDcache.GetOperatorIdAsync();
                        var ownMoney = ipo.PayMoney.MToA(currencyId);
                        var bankOrderSuccessTime = DateTime.UtcNow;
                        if (ipo.Status == "SUCCESS")
                        {
                            var userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId, tm);
                            if (null == userEo)
                                throw new Exception($"用户不存在！userId:{userId}");

                            //1.更新用户账户                            
                            var (endBalance, endBonus) = await BankUtil.UpdateUserCash(order.UserID, ownMoney, tm);
                            if (ipo.Order.IsAddBalance)
                            {
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
                            await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.PayFee, order.UserFee, order.UserMoney, BankOrderStatusEnum.Success, OrderTypeEnum.Charge, bankOrderSuccessTime, tm);
                            //3.添加银行通讯日志
                            await UpdateBankTransaLog(ipo, 1, null, tm);
                            tm.Commit();
                            ret = "SUCCESS";
                            //4.发送用户充值消息
                            await SendUserPayMsg(ipo.Order, countryId, (long)ipo.PayMoney);
                        }
                        else
                        {
                            //失败更新订单状态
                            await UpdateBankOrder(ipo, ipo.PlatOrderNum, ipo.Order.OwnFee, ipo.Order.UserFee, order.UserMoney, BankOrderStatusEnum.Fail, OrderTypeEnum.Charge, bankOrderSuccessTime, tm);
                            //更新银行通讯日志
                            await UpdateBankTransaLog(ipo, 2, null, tm);
                            await MQUtil.PublishAsync(new BankErrorMsg
                            {
                                BankId = BANKID,
                                Channel = 0,
                                Money = order.TransMoney / MULTIPLE,
                                CurrencyId = order.CurrencyID,
                                ErrorMsg = $"orderid:{ipo.OrderNum},userid:{ipo.Order.UserID}充值回调失败！status:{ipo.Status},msg:{ipo.Msg}",
                                OrderType = OrderTypeEnum.Charge,
                                Paytype = PayTypeEnum.Tejeepay,
                                UserId = order.UserID,
                                OrderId = ipo.OrderNum,
                                RecDate = bankOrderSuccessTime,
                                Remark = ipo
                            });
                            tm.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        tm.Rollback();
                        ret = "FAIL";
                        await UpdateBankTransaLog(ipo, 2, ex, null);
                    }
                }
            }
            catch (Exception ex)
            {
                ret = "FAIL";
                LogUtil.Error(ex, "spei支付回调处理异常");
            }
            return ret;
        }
    }
}
