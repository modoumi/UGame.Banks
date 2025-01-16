using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using Xxyy.Common.Caching;
using Xxyy.Common;

using TinyFx.Logging;
using UGame.Banks.Repository;
using TinyFx.Extensions.RabbitMQ;
using UGame.Banks.Service.MQMsg;
using TinyFx.Configuration;
using UGame.Banks.Service.Caching;

namespace UGame.Banks.Service.Services.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BankServiceBase
    {
        //private readonly Sb_bank_currencyMO _bankCurrencyMo = new();
        protected readonly Sb_bank_orderMO _bankOrderMo = new();
        private const string HEADER_NAME = "X-ING-Signature";
        private readonly Sc_cash_auditMO _cashAuditMo = new();


        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="orderType">订单类型（1.充值 2.提现）</param>
        /// <param name="payType">支付方式：0.综合、1.visa、2.spei、3.wallet（电子钱包）4.pandapay</param>
        /// <param name="transMark"></param>
        /// <param name="channel"></param>
        /// <param name="func"></param>
        /// <param name="isolationLevel"></param>
        public async Task Execute(PayIpoBase ipo, PayDtoBase dto, OrderTypeEnum orderType, PayTypeEnum payType, string transMark, int channel, Func<TransactionManager, Task> func, System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.RepeatableRead)
        {
            //LogUtil.Info($"BankServiceBase.Execute:0,param:{SerializerUtil.SerializeJsonNet(new { ipo, dto, orderType, payType, transMark, channel })}");
            //CheckIpo
            await CheckIpo(ipo,orderType);
            //检查验证用户，app,运营商和提供商以及logintoken
            await CheckAndSetIpo(ipo,orderType);
            //LogUtil.Info($"BankServiceBase.Execute:1,param:{SerializerUtil.SerializeJsonNet(new { ipo, dto, orderType, payType, transMark, channel })}");
            dto.OrderId = ipo.OrderId = ipo.RequestUUID;
            if (!string.IsNullOrWhiteSpace(ipo.CashAuditId) && ipo.AppOrderId != ipo.CashAuditId)
                ipo.AppOrderId = ipo.CashAuditId;
            //银行和货币是否受支持
            await CheckBankCurrency(ipo);
            //LogUtil.Info($"BankServiceBase.Execute:2,param:{SerializerUtil.SerializeJsonNet(new { ipo, dto, orderType, payType, transMark, channel })}");
            var isRepeat = await CheckRepeatRequestAppOrder(ipo, dto);
            if (isRepeat)
                return;
            //LogUtil.Info($"BankServiceBase.Execute:2,param:{SerializerUtil.SerializeJsonNet(new { ipo, dto, orderType, payType, transMark, channel })}");
            //添加订单
            //await BankUtil.AddBankOrder(ipo, dto, orderType, payType, channel, null);
            await AddBankOrder(ipo, dto, orderType, payType, channel, null);

            TransactionManager tm = new TransactionManager(isolationLevel);
            try
            {
                if(orderType== OrderTypeEnum.Draw) {
                    await CheckBalanceBeforeProxyPay(ipo,dto,tm);
                }
                //创建Proxy并发起支付请求
                await func(tm);
                //更新银行订单信息
                await BankUtil.UpdateBankOrder(ipo, BankOrderStatusEnum.Processing, dto, tm);
                ////添加App通讯日志
                //await BankUtil.AddAppTransLog(ipo, dto, 1, null, transMark, null);
                //添加银行通讯日志
                await BankUtil.AddBankTransLog(ipo, dto, 1, null, null);
                tm.Commit();
                //LogUtil.Info($"BankServiceBase.Execute:3,param:{SerializerUtil.SerializeJsonNet(new { ipo, dto, orderType, payType, transMark, channel })}");
            }
            catch (Exception ex)
            {
                tm.Rollback();

                var exc = ExceptionUtil.GetException<CustomException>(ex);
                dto.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
                dto.Message = (exc != null) ? exc.Message : $"{(orderType == OrderTypeEnum.Charge ? "充值" : "提现")}出错:{ex.Message}";
                var status = dto.OperatorSuccess ? BankOrderStatusEnum.Exception : BankOrderStatusEnum.Fail;
                await BankUtil.UpdateBankOrder(ipo, status, dto, null);

                ////app通讯日志
                //await BankUtil.AddAppTransLog(ipo, dto, 2, null, transMark, null);
                //添加银行通讯日志
                await BankUtil.AddBankTransLog(ipo, dto, 2, null, null);
                LogUtil.Error(ex, $"BankServiceBase.Execute:4,param:{SerializerUtil.SerializeJsonNet(new { ipo, dto, orderType, payType, channel })}");
                return;
            }
        }

        /// <summary>
        /// 设置提款银行信息
        /// </summary>
        /// <param name="order"></param>
        /// <param name="ipo"></param>
        /// <returns></returns>
        protected abstract void SetSbBankOrderEo(Sb_bank_orderEO order,PayIpoBase ipo);

        private async Task AddBankOrder(PayIpoBase ipo, PayDtoBase dto, OrderTypeEnum orderType, PayTypeEnum payType, int channel, TransactionManager tm)
        {
            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            var operatorId = await userDCache.GetOperatorIdAsync();
            if (string.IsNullOrWhiteSpace(ipo.CountryId))
            {
                ipo.CountryId = await userDCache.GetCountryIdAsync();
            }
            var orderEo = new Sb_bank_orderEO
            {
                OrderID = ipo.OrderId,
                BankID = ipo.BankId,
                ProviderID = ipo.Provider.ProviderID,
                AppID = ipo.AppId,
                OperatorID = operatorId,
                UserID = ipo.UserId,
                FromMode = await userDCache.GetFromModeAsync(),
                FromId = await userDCache.GetFromIdAsync(),
                UserKind = (int)await userDCache.GetUserKindAsync(), //userEo.UserKind,
                RegistDate= await userDCache.GetRegistDateAsync(),
                OrderType = (int)orderType,
                PaytypeID = (int)payType,
                PaytypeChannel = channel,
                CurrencyID = ipo.CurrencyId,
                PlanAmount = (orderType == OrderTypeEnum.Charge ? ipo.Amount : -ipo.Amount),
                RecDate = DateTime.UtcNow,
                AppRequestUUID = ipo.RequestUUID,
                AppOrderId = ipo.AppOrderId,
                AppReqComment = ipo.ReqComment,
                AppRequestTime = DateTime.UtcNow,
                AccName = "",
                AccNumber = "",
                BankCode = "",
                Meta = SerializerUtil.SerializeJson(new { AppMeta = ipo.Meta }),
                Status = (int)BankOrderStatusEnum.Initial,
                Amount = (orderType == OrderTypeEnum.Charge ? ipo.Amount : -ipo.Amount),
                UserIP = ipo.UserIp,
                ActivityIds=ipo.ActivityIds!=null?string.Join("|",ipo.ActivityIds):null,
                IsAddBalance=ipo.IsAddBalance,
                IsAuditOrder=!string.IsNullOrWhiteSpace(ipo.CashAuditId),
                CountryID=ipo.CountryId,
                UserFeeAmount=ipo.UserFeeAmount
            };
            if (orderType == OrderTypeEnum.Draw)
            {
                SetSbBankOrderEo(orderEo, ipo);
            }
            ipo.Order = orderEo;
            await _bankOrderMo.AddAsync(orderEo, tm);
        }

        #region Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        private async Task CheckBankCurrency(PayIpoBase ipo)
        {
            var bankCurrencyEo = DbBankCacheUtil.GetBankCurrency(ipo.BankId,ipo.CurrencyId,false);
            //var bankCurrencyEo = await _bankCurrencyMo.GetByPKAsync(ipo.BankId, ipo.CurrencyId);
            if (bankCurrencyEo == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"不支持的银行和货币BankId:{ipo.BankId},currencyId：{ipo.CurrencyId}");
        }

        /// <summary>
        /// 检查相关设置
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="orderType"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public async Task CheckAndSetIpo(BankIpoBase ipo,OrderTypeEnum orderType)
        {
            if (string.IsNullOrWhiteSpace(ipo.RequestUUID) || string.IsNullOrWhiteSpace(ipo.UserId) || string.IsNullOrWhiteSpace(ipo.AppId) || string.IsNullOrWhiteSpace(ipo.CurrencyId))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"PayIpoBase中的参数不能为空");

            //ipo.OrderId = ipo.RequestUUID;
            // appId
            ipo.App = DbCacheUtil.GetApp(ipo.AppId, false);
            if (ipo.App == null)
                throw new CustomException(PartnerCodes.RS_INVALID_APP, $"未知App。 appId:{ipo.AppId}");

            // provider
            ipo.Provider = DbCacheUtil.GetProvider(ipo.App.ProviderID, false);
            if (ipo.Provider == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"未知Provider。 providerId:{ipo.App.ProviderID}");
            if (ipo.Provider.Status == 0)
                throw new CustomException(PartnerCodes.RS_INVALID_PROVIDER, $"提供商被禁用。 providerId:{ipo.Provider.ProviderID}");

            // sign
            await CheckSign(ipo.Provider.OwnPublicKey, $"s_provider没有定义TrdPublicKey。providerId:{ipo.Provider.ProviderID}");


            // user status
            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            if (!await userDCache.KeyExistsAsync())
            {
                var user = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId);
                if(user == null)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"用户不存在。userId:{ipo.UserId}");
                await userDCache.SetBaseValues(user);
            }
            if (await userDCache.GetUserStatusAsync() != UserStatus.Normal)
                throw new CustomException(PartnerCodes.RS_USER_DISABLED, $"用户被禁用/锁定并且无法充值。 userId:{ipo.UserId}");
            if (await userDCache.GetUserModeAsync() != UserMode.Register)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"非注册用户无法充值。 userId:{ipo.UserId}");

            //联调测试用户禁止提现
            if (await userDCache.GetUserKindAsync() == UserKind.Debug&&orderType== OrderTypeEnum.Draw)
                throw new Exception("联调测试用户禁止提现");
            // currencyId
            var currencyType = DbCacheUtil.GetCurrencyType(ipo.CurrencyId);
            if (currencyType != CurrencyType.Cash)
                throw new CustomException(PartnerCodes.RS_WRONG_CURRENCY, $"不支持的交易货币。CurrencyId:{ipo.CurrencyId}");
            var currencyId = await userDCache.GetCurrencyIdAsync();
            if (currencyId != ipo.CurrencyId)
                throw new CustomException(PartnerCodes.RS_WRONG_CURRENCY, $"交易货币不同于用户的钱包货币。user:{currencyId} ipo:{ipo.CurrencyId}");

            // operator status
            var operatorId=await userDCache.GetOperatorIdAsync();
            ipo.Operator = DbCacheUtil.GetOperator(operatorId, false);
            if (ipo.Operator == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"未知Operator。 operatorId:{operatorId}");
            if (ipo.Operator.Status == 0)
                throw new CustomException(PartnerCodes.RS_INVALID_OPERATOR, $"运营商商被禁用。 operatorId:{operatorId}");
            //ipo.OperatorApp = DbCacheUtil.GetOperatorApp(operatorId, ipo.AppId);
        }



        private async Task CheckSign(string trdPublicKey, string exceptionMsg)
        {
            if (string.IsNullOrEmpty(trdPublicKey))
                throw new Exception(exceptionMsg);
            // if (!await AspNetUtil.VerifyRequestHeaderSign(HEADER_NAME, trdPublicKey))
            if(!await new RequestBodySignValidator(trdPublicKey).VerifyByHeader(HEADER_NAME, HttpContextEx.Current))
                throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE, "验证签名错误");
        }

       
        /// <summary>
        /// 重复验证
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> CheckRepeatRequestAppOrder(PayIpoBase ipo, PayDtoBase dto)
        {
            //var transactionId = ipo.AppOrderId;
            var orderEos = await _bankOrderMo.GetAsync("BankID=@BankID and AppOrderId=@AppOrderId", ipo.BankId, ipo.AppOrderId);
            if (orderEos == null || orderEos.Count == 0)
                return false;
            throw new CustomException(PartnerCodes.RS_DUPLICATE_TRANSACTION, $"发送了具有相同 AppOrderId 的交易");
        }

        /// <summary>
        /// 代付之前判断账户余额
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task CheckBalanceBeforeProxyPay(PayIpoBase ipo, PayDtoBase dto, TransactionManager tm)
        {
            if (!string.IsNullOrWhiteSpace(ipo.CashAuditId))
            {
                var cashAuditEo = await _cashAuditMo.GetByPKAsync(ipo.CashAuditId);
                if (null == cashAuditEo)
                    throw new CustomException($"参数异常!CashAuditId:{ipo.CashAuditId}");
                if (cashAuditEo.Status != 0&& cashAuditEo.Status!=3)
                    throw new CustomException($"参数异常!CashAuditId:{ipo.CashAuditId},已审核");
            }
            var userEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm);
            if (null == userEo)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"userEo为null,参数userId:{ipo.UserId}错误");
            dto.EndBalance = userEo.Cash;
            dto.EndBonus = userEo.Bonus;
            //else
            //{
            //    //账户余额是否满足
            //    var userEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm, true);
            //    if (ipo.Amount > userEo.Cash)
            //        throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");

            //    long amountBonus = 0;
            //    if (userEo.Bonus > 0 && userEo.Bonus >= ipo.Amount)
            //        amountBonus = ipo.Amount;
            //    else
            //        amountBonus = userEo.Bonus <= 0 ? 0 : userEo.Bonus;//没有bonus，或者bonus余额不足押注
            //                                                           //扣账户
            //    string _set = $"Cash=Cash-@Amount,Bonus=Bonus-@amountBonus";
            //    string _where = "UserID=@UserID and Cash>=@amount2 and Bonus>=@amountBonus";
            //    var rows = await DbSink.BuildUserMo(ipo.UserId).PutAsync(_set, _where, tm, ipo.Amount, amountBonus, ipo.UserId, ipo.Amount);
            //    if (rows <= 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额");
            //    //赋值amountbonus
            //    ipo.Order.AmountBonus = -amountBonus;

            //    //获取最新账户
            //    userEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId, tm);

            //    dto.EndBalance = userEo.Cash; //= await DbSink.BuildUserMo(ipo.UserId).GetCashByPKAsync(ipo.UserId, tm);
            //    dto.EndBonus = userEo.Bonus;
            //    if (dto.EndBalance < 0 || dto.EndBonus < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"提取金额不能超过账户余额,扣除账户余额出错");
            //    //if (ret.EndBonus < 0) throw new CustomException(PartnerCodes.RS_NOT_ENOUGH_MONEY, $"扣除bonus异常");
            //}
        }

        private async Task CheckIpo(PayIpoBase ipobase, OrderTypeEnum orderType)
        {
            switch (orderType)
            {
                case OrderTypeEnum.Charge:
                    await CheckCommonPayIpo(ipobase);
                    break;
                case OrderTypeEnum.Draw:
                    await CheckProxyPayIpo(ipobase);
                    break;
                default:
                    break;
            }
        }

        protected virtual async Task CheckCommonPayIpo(PayIpoBase ipobase)
        {
        }

        protected virtual async Task CheckProxyPayIpo(PayIpoBase ipobase)
        {
        }
        #endregion
    }
}
