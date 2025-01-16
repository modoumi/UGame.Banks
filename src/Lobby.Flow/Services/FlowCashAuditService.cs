using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using TinyFx.Logging;
using TinyFx;
using UGame.Banks.Client.BLL;
using Lobby.Flow.DAL;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.Text;
using Xxyy.Common.Services;
using Xxyy.Common;
using Xxyy.DAL;
using Xxyy.MQ.Xxyy;
using Lobby.Flow.IpoDto;
using Xxyy.Common.Caching;
using Lobby.Flow.Common;

namespace Lobby.Flow.Services
{
    internal class FlowCashAuditService
    {
        protected readonly S_currency_changeMO _currencyChangeMo = new();
        protected readonly Sc_cash_audit_logMO _cashAuditLogMo = new();

        /// <summary>
        /// 后台审核提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="cashAuditMo"></param>
        /// <returns></returns>
        public async Task<bool> CashAudit(FlowCashAuditIpo ipo, Sc_cash_auditMO cashAuditMo,V_s_operatorEO operatorEo)
        {
            var tm = new TinyFx.Data.TransactionManager(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                var cashAuditEo = await cashAuditMo.GetByPKAsync(ipo.CashAuditId, tm, true);
                if (null == cashAuditEo) throw new CustomException($"参数异常，未找到对应的提款申请!CashAuditId:{ipo.CashAuditId}");
                if (cashAuditEo.Status != 0 && cashAuditEo.Status != 3) throw new CustomException($"该提款CashAuditId:{ipo.CashAuditId}已处理，不用重复审核，status:{cashAuditEo.Status}");
                cashAuditEo.AuditTime = DateTime.UtcNow;
                if (ipo.Status == 1)
                {
                    cashAuditEo.RequestTime = cashAuditEo.AuditTime;
                    await SendBankAudit(cashAuditEo);
                    cashAuditEo.ResponseTime = DateTime.UtcNow;
                }

                //2.cashaudit vo.CashAuditId,
                var rows = await cashAuditMo.PutAsync("Status=@Status,AuditTime=@AuditTime,OperatorUser=@OperatorUser,RequestTime=@RequestTime,ResponseTime=@ResponseTime,Reason=@reason", "CashAuditId=@CashAuditId and Status=@oldstatus", tm, ipo.Status, cashAuditEo.AuditTime, ipo.UserName,cashAuditEo.RequestTime,cashAuditEo.ResponseTime, $"流水倍数:{ipo.BonusMultip}", ipo.CashAuditId, cashAuditEo.Status);
                if (rows <= 0) throw new Exception($"CashAduitId:{ipo.CashAuditId}提款审核失败！更新审核项失败");
                if (ipo.Status == 2)
                {
                    //2.1 拒绝还钱
                    var userSvc = new UserService(cashAuditEo.UserID);
                    //var currencyChangeEoList = await _currencyChangeMo.GetTopAsync("SourceId=@SourceId and AmountBonus<0", 1, tm, cashAuditEo.CashAuditID);
                    //var bonusAmount = 0L;
                    //var useBonus = false;
                    //var flowMultip = 30f;
                    //if (null != currencyChangeEoList && currencyChangeEoList.Any())
                    //{
                    //    var bonusCurrencyChange = currencyChangeEoList.First();
                    //    flowMultip = bonusCurrencyChange.FlowMultip;
                    //    bonusAmount = -bonusCurrencyChange.AmountBonus;
                    //    useBonus = true;
                    //}
                    //var changeAmount = 0l;
                    //if (operatorEo.FlowMode == (int)FlowModeEnum.Three)
                    //    changeAmount = cashAuditEo.Amount+bonusAmount;
                    //else
                    //    changeAmount = cashAuditEo.Amount;
                    var changeAmount = Math.Abs(cashAuditEo.AmountBalance);
                    var bonusAmount = Math.Abs(cashAuditEo.AmountBonus);

                    var isSuccess = await userSvc.UpdateBalance(cashAuditEo.CurrencyID, changeAmount, tm, bonusAmount);
                    if (!isSuccess)
                        throw new Exception($"拒绝失败！更新账户余额失败！CashAuditId:{ipo.CashAuditId}");
                    //var userEo = await userSvc.GetUserMo().GetByPKAsync(cashAuditEo.UserID, tm);
                    var balanceInfo = await userSvc.GetBalanceInfo(tm, true);
                    var appEo = Xxyy.Common.Caching.DbCacheUtil.GetApp(cashAuditEo.AppID);
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
                        CurrencyType = (int)Xxyy.Common.Caching.DbCacheUtil.GetCurrencyType(cashAuditEo.CurrencyID),
                        //IsBonus = false,
                        FlowMultip = 0,
                        Reason = "提现审核拒绝",
                        PlanAmount = cashAuditEo.AmountBalance,
                        Meta = null,
                        SourceTable = "sc_cash_audit",
                        SourceId = cashAuditEo.CashAuditID,
                        SourceType = 1,
                        IsBonus=false,
                        Status = 2,
                        RecDate = DateTime.UtcNow,
                        DealTime = DateTime.UtcNow,
                        Amount = changeAmount,
                        AmountBonus = bonusAmount,
                        EndBalance = balanceInfo.Balance, //userEo.Cash,
                        EndBonus = balanceInfo.Bonus //userEo.Bonus
                    };
                    rows = await _currencyChangeMo.AddAsync(currencyChangeEo, tm);
                    if (rows <= 0) throw new Exception($"CashAuditId:{ipo.CashAuditId}拒绝失败！添加s_currency_change失败！");
                    var currencyChangeMsg = new CurrencyChangeMsg
                    {
                        UserId = currencyChangeEo.UserID,
                        UserKind = currencyChangeEo.UserKind.ToEnum<UserKind>(),
                        AppId = currencyChangeEo.AppID,
                        OperatorId = currencyChangeEo.OperatorID,
                        CountryId = currencyChangeEo.CountryID,
                        CurrencyId = currencyChangeEo.CurrencyID,
                        FlowMultip = ipo.BonusMultip,
                        CurrencyType = Xxyy.Common.Caching.DbCacheUtil.GetCurrencyType(currencyChangeEo.CurrencyID),
                        ChangeTime = DateTime.UtcNow,
                        SourceType = 1,
                        SourceId=cashAuditEo.CashAuditID,
                        SourceTable="sc_cash_audit",
                        Reason = currencyChangeEo.Reason,
                        Amount = changeAmount,
                        FromMode = currencyChangeEo.FromMode,
                        FromId = currencyChangeEo.FromId,
                        Bonus = bonusAmount,
                        EndBalance = balanceInfo.Balance,//currencyChangeEo.EndBalance,
                        EndBonus = balanceInfo.Bonus //currencyChangeEo.EndBonus
                    };
                    await MQUtil.PublishAsync(currencyChangeMsg);
                }
                //3.cashauditlog
                rows = await _cashAuditLogMo.AddAsync(new Sc_cash_audit_logEO
                {
                    AuditLogID = Guid.NewGuid().ToString(),
                    Action = ipo.Status,
                    CashAuditID = ipo.CashAuditId,
                    OperatorId = ipo.UserName,
                    OperatorName = ipo.UserName,
                    RecDate = DateTime.UtcNow,
                }, tm);
                tm.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error(ex, "提款审核异常！CashAuditId:{0}",ipo.CashAuditId);
                throw;
            }
        }

        /// <summary>
        /// 银行审核
        /// </summary>
        /// <param name="cashAuditEo"></param>
        /// <returns></returns>
        private async Task SendBankAudit(Sc_cash_auditEO cashAuditEo)
        {
            if (string.IsNullOrWhiteSpace(cashAuditEo.RequestParam))
                throw new Exception($"CashAuditId:{cashAuditEo.CashAuditID}参数异常！RequestParam：{cashAuditEo.RequestParam}");
            ApiResult<BaseDto> result = null;
            switch (cashAuditEo.BankID)
            {
                case "tejeepay":
                    var tejeepayIpo = SerializerUtil.DeserializeJsonNet<UGame.Banks.Client.BLL.Tejeepay.XxyyTejeeProxyPayIpo>(cashAuditEo.RequestParam);
                    var tejeepayResult = await new UGame.Banks.Client.BLL.Tejeepay.TejeepayClient().TejeeCash(tejeepayIpo);
                    if (tejeepayResult == null || (tejeepayResult?.Result?.Status != "RS_OK" && tejeepayResult?.Result?.Status != "SUCCESS"))
                    {
                        string msg = $"CashAuditId:{cashAuditEo.CashAuditID}提款审核异常" + $"!ipo:{SerializerUtil.SerializeJsonNet(tejeepayIpo)},result:{SerializerUtil.SerializeJsonNet(tejeepayResult)}";
                        LogUtil.Error(msg);
                        throw new CustomException(msg);
                    }
                    break;
                case "letspay":
                    var letspayIpo = SerializerUtil.DeserializeJsonNet<UGame.Banks.Client.BLL.Letspay.XxyyLetsProxyPayIpo>(cashAuditEo.RequestParam);
                    Console.WriteLine(JsonConvert.SerializeObject(letspayIpo));
                    var letspayResult = await new UGame.Banks.Client.BLL.Letspay.LetspayClient().LetsCash(letspayIpo);
                    if (letspayResult == null || (letspayResult?.Result?.Status != "RS_OK" && letspayResult?.Result?.Status != "SUCCESS"))
                    {
                        string msg = $"CashAuditId:{cashAuditEo.CashAuditID}提款审核异常" + $"!ipo:{SerializerUtil.SerializeJsonNet(letspayIpo)},result:{SerializerUtil.SerializeJsonNet(letspayResult)}";
                        LogUtil.Error(msg);
                        throw new CustomException(msg);
                    }
                    break;
                case "mlpay":
                    var mlpayIpo = SerializerUtil.DeserializeJsonNet<UGame.Banks.Client.BLL.Mlpay.XxyyMlpayCashIpo>(cashAuditEo.RequestParam);
                    var mlpayResult = await new UGame.Banks.Client.BLL.Mlpay.MlpayClient().MlpayCash(mlpayIpo);
                    if (mlpayResult == null || (mlpayResult?.Result?.Status != "RS_OK" && mlpayResult?.Result?.Status != "SUCCESS"))
                    {
                        string msg = $"CashAuditId:{cashAuditEo.CashAuditID}提款审核异常" + $"!ipo:{SerializerUtil.SerializeJsonNet(mlpayIpo)},result:{SerializerUtil.SerializeJsonNet(mlpayResult)}";
                        LogUtil.Error(msg);
                        throw new CustomException(msg);
                    }
                    break;
                case "bfpay":
                    var bfpayIpo = SerializerUtil.DeserializeJsonNet<UGame.Banks.Client.BLL.Bfpay.XxyyBfpayCashIpo>(cashAuditEo.RequestParam);
                    var bfpayResult = await new UGame.Banks.Client.BLL.Bfpay.BfpayClient().BfpayCash(bfpayIpo);
                    if (bfpayResult == null || (bfpayResult?.Result?.Status != "RS_OK" && bfpayResult?.Result?.Status != "SUCCESS"))
                    {
                        string msg = $"CashAuditId:{cashAuditEo.CashAuditID}提款审核异常" + $"!ipo:{SerializerUtil.SerializeJsonNet(bfpayIpo)},result:{SerializerUtil.SerializeJsonNet(bfpayResult)}";
                        LogUtil.Error(msg);
                        throw new CustomException(msg);
                    }
                    break;
                case "hubtel":
                    var hubtelPayIpo = SerializerUtil.DeserializeJsonNet<UGame.Banks.Client.BLL.Hubtel.XxyyHubtelCashIpo>(cashAuditEo.RequestParam);
                    var hubtelPayResult = await new UGame.Banks.Client.BLL.Hubtel.HubtelClient().Cash(hubtelPayIpo);
                    if (hubtelPayResult == null || (hubtelPayResult?.Result?.Status != "RS_OK" && hubtelPayResult?.Result?.Status != "SUCCESS"))
                    {
                        string msg = $"CashAuditId:{cashAuditEo.CashAuditID}提款审核异常" + $"!ipo:{SerializerUtil.SerializeJsonNet(hubtelPayIpo)},result:{SerializerUtil.SerializeJsonNet(hubtelPayResult)}";
                        LogUtil.Error(msg);
                        throw new CustomException(msg);
                    }
                    break;
                default:
                    throw new ArgumentException(nameof(cashAuditEo.BankID));
            };
        }
    }
}
