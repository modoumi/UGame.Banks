using Lobby.Flow.Common;
using Lobby.Flow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Logging;
using TinyFx.Text;
using Xxyy.Common;
using Xxyy.Common.Services;
using Xxyy.DAL;
using Xxyy.MQ.Lobby;

namespace Lobby.Flow.Services
{
    internal class UserBalanceService
    {

        /// <summary>
        /// 账户回退
        /// </summary>
        /// <param name="cashAuditId"></param>
        /// <param name="cashAuditMo"></param>
        /// <param name="userSvc"></param>
        /// <param name="sendMsgAction"></param>
        /// <returns></returns>
        internal async Task ReturnBalance(string cashAuditId, Sc_cash_auditMO cashAuditMo, UserService userSvc,Func<S_currency_changeEO, CurrencyType, Task> sendMsgAction)
        {
            var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                var currencyChangeMo = new S_currency_changeMO();
                var cashAuditEo = await cashAuditMo.GetByPKAsync(cashAuditId, tm, true);
                if (null == cashAuditEo || cashAuditEo.Status != (int)CashAuditStatusEnum.AutoReturn)
                    throw new Exception($"该审核订单CashAuditId:{cashAuditId}不存在或状态Status:{cashAuditEo?.Status}不是等待24小时自动回退状态！");

                var sourceCurrencyChangeEo = (await currencyChangeMo.GetTopAsync("SourceId=@SourceId and SourceType=@SourceType", 1, tm, cashAuditEo.CashAuditID, 2)).FirstOrDefault();
                if (null == sourceCurrencyChangeEo)
                    throw new Exception($"CurrencyChange中没有找到该条SourceId:{cashAuditEo.CashAuditID}货币变化记录！");

                var changeAmount = Math.Abs(sourceCurrencyChangeEo.Amount);
                var bonusAmount = Math.Abs(sourceCurrencyChangeEo.AmountBonus);
                var isSuccess = await userSvc.UpdateBalance(cashAuditEo.CurrencyID, changeAmount, tm, bonusAmount);
                if (!isSuccess)
                    throw new Exception($"自动审批24小时后自动回退账户失败！更新账户余额失败！CashAuditId:{cashAuditEo.CashAuditID}");
                var balanceInfo = await userSvc.GetBalanceInfo(tm, true);
                var appEo = Xxyy.Common.Caching.DbCacheUtil.GetApp(sourceCurrencyChangeEo.AppID);
                var utcNow = DateTime.UtcNow;
                var currencyType = Xxyy.Common.Caching.DbCacheUtil.GetCurrencyType(cashAuditEo.CurrencyID);
                var currencyChangeEo = new S_currency_changeEO()
                {
                    ChangeID = ObjectId.NewId(),
                    ProviderID = appEo.ProviderID,
                    AppID = appEo.AppID,
                    OperatorID = cashAuditEo.OperatorID,
                    UserID = cashAuditEo.UserID,
                    UserKind = cashAuditEo.UserKind,
                    FromId = cashAuditEo.FromId,
                    FromMode = cashAuditEo.FromMode,
                    CountryID = cashAuditEo.CountryID,
                    CurrencyID = cashAuditEo.CurrencyID,
                    CurrencyType = (int)currencyType,
                    FlowMultip = 0,
                    Reason = "自动审批24小时后自动回退账户",
                    PlanAmount = changeAmount,
                    Meta = null,
                    SourceTable = "sc_cash_audit",
                    SourceId = cashAuditEo.CashAuditID,
                    SourceType = 1,
                    IsBonus = false,
                    Status = 2,
                    RecDate = utcNow,
                    DealTime = utcNow,
                    Amount = changeAmount,
                    AmountBonus = bonusAmount,
                    EndBalance = balanceInfo.Balance,
                    EndBonus = balanceInfo.Bonus
                };
                var rows = await currencyChangeMo.AddAsync(currencyChangeEo, tm);
                if (rows <= 0)
                    throw new Exception($"自动审批24小时后自动回退账户时,CashAuditId:{cashAuditId}添加s_currency_change失败！");

                //更新审核订单表sc_cash_audit
                cashAuditEo.AuditTime = utcNow;
                rows = await cashAuditMo.PutAsync("Status=@Status,AuditTime=@AuditTime,OperatorUser=@OperatorUser,RequestTime=@RequestTime,ResponseTime=@ResponseTime,Reason=@reason", "CashAuditId=@CashAuditId and Status=@oldstatus", tm, (int)CashAuditStatusEnum.Rejected, cashAuditEo.AuditTime, "system", cashAuditEo.RequestTime, cashAuditEo.ResponseTime, "自动审批24小时后自动回退", cashAuditId, cashAuditEo.Status);
                if (rows <= 0) throw new Exception($"CashAduitId:{cashAuditId}提款审核失败！更新审核项失败");
                tm.Commit();
                //发送消息等自定义逻辑
                if(sendMsgAction!=null)
                    await sendMsgAction(currencyChangeEo,currencyType);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage($"自动审批24小时后自动回退处理异常！")
                    .AddException(ex)
                    .AddField("CashAuditId", cashAuditId)
                    .Save();
            }
        }
    }
}
