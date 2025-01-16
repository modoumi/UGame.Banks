using Lobby.Flow.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using Xxyy.Common;
using Elasticsearch.Net;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 短版提现规则0验证服务,WithdrawRuleMode:0
    /// </summary>
    internal class CashValidateServiceZero : ICashValidateService
    {
        private IAutoCashAuditService _autoCashAuditService;
        public CashValidateServiceZero()
        {
            _autoCashAuditService=new AutoCashAuditService();
        }
        public async Task<(bool?, AutoAuditResultEnum)> ValidateCash(BraWithDrawIpo ipo)
        {
            await CheckCashCondition(ipo);
            var auditRet = await this._autoCashAuditService.AuditCash(ipo);
            if (auditRet== AutoAuditResultEnum.Return2OldAudit)
            {
                return (await IsAudit(ipo),auditRet);
            }
            return (null,auditRet);
        }

        /// <summary>
        /// 校验是否可以提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task CheckCashCondition(BraWithDrawIpo ipo)
        {
            //var ipo = t as BraWithDrawIpo;

            //提现审批校验
            var cashConfig = await Common.FlowUtil.GetCashConfig(ipo.OperatorId, ipo.CurrencyId);
            if (ipo.UserExEo.TotalCashCount == 0)
            {
                //首次提现金额小于首次提现最小提现金额
                if (ipo.Amount < cashConfig.FirstCashMinAmount.AToM(ipo.CurrencyId))
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, $"Minimum amount {cashConfig.CashMinAmount.AToM(ipo.CurrencyId)}.");
            }
            else
            {
                //如果提现金额小于非首次提现最小提现金额
                if (ipo.Amount < cashConfig.CashMinAmount.AToM(ipo.CurrencyId))
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, $"Minimum amount {cashConfig.CashMinAmount.AToM(ipo.CurrencyId)}.");
            }
            //如果提现金额大于最大提现金额
            if (ipo.Amount > cashConfig.CashMaxAmount.AToM(ipo.CurrencyId))
                throw new CustomException(FlowResponseCodes.RS_UNKNOWN, $"Maximum amount {cashConfig.CashMaxAmount.AToM(ipo.CurrencyId)}.");

            ipo.CashConfigEo = cashConfig;

            //如果当前运营商需要验证手机号，并且用户未绑定手机号的话，则不允许提现
            if (ipo.CashConfigEo.IsVerifyMobile && string.IsNullOrWhiteSpace(ipo.UserEo.Mobile))
                throw new CustomException(FlowResponseCodes.RS_CASH_NOTEXISTSMOBILE, "Please bind your phone number first");

            //如果提现时，用户充值总额 < 提现配置的最低充值金额
            if (cashConfig.CashPayAmount > 0 && ipo.UserExEo.TotalPayAmount < cashConfig.CashPayAmount)
                throw new CustomException(FlowResponseCodes.RS_CASH_NOTMEETMINPAY, "The total amount of historical recharge is too low");

            //无可提现金额
            var flowService = FlowServiceFactory.CreateFlowService(ipo.UserId, ipo.AppId, ipo.OperatorId);
            var drawAmount = await flowService.GetAllowCashMoney(ipo.UserId, ipo.CurrencyId);
            if (drawAmount == 0)
                throw new CustomException(CommonCodes.RS_NOT_ENOUGH_MONEY, "Sorry, your credit is running low.");

            //提现金额大于账户余额（真金+bonus）
            if (ipo.Amount.MToA(ipo.CurrencyId) > ipo.UserEo.Cash)
                throw new CustomException(CommonCodes.RS_NOT_ENOUGH_MONEY, "Sorry, your credit is running low.");

            //获取时间查询区间
            var timeInterval = Common.FlowUtil.GetDBTimeInterval(ipo.OperatorId);
            ipo.StartTime = timeInterval.startTime;
            ipo.EndTime = timeInterval.endTime;

            //用户历史提现总次数、总金额
            var historyUserCashInfo = await ipo.UserCashService.GetTotalCashNumAndAmount(ipo.UserId);
            ipo.HistoryUserCashInfo = new UserCashInfo()
            {
                //用户历史提现总次数
                SumCashNum = historyUserCashInfo.sumCashNum,
                //用户历史提现总金额
                SumCashAmount = historyUserCashInfo.sumCashAmount
            };

            //用户是否首次提现
            ipo.IsFirstCash = ipo.HistoryUserCashInfo.SumCashNum == 0;

            //用户当天提现总次数、总金额
            var userCurrDayCashInfo = await ipo.UserCashService.GetTotalCashNumAndAmount(ipo.UserId, true);
            ipo.UserCurrDayCashInfo = new UserCashInfo()
            {
                //用户当天提现总次数
                SumCashNum = userCurrDayCashInfo.sumCashNum,
                //用户当天提现总金额
                SumCashAmount = userCurrDayCashInfo.sumCashAmount
            };

            ipo.SumCashNum = ipo.UserCurrDayCashInfo.SumCashNum;
            ipo.SumCashAmount = ipo.UserCurrDayCashInfo?.SumCashAmount??0;

            //如果当天提现次数超过配置值
            if (ipo.SumCashNum + 1 > ipo.CashConfigEo.DayCashNumLimit)
                throw new CustomException(FlowResponseCodes.RS_CASH_NUM_LIMIT, "The withdrawal frequency has reached the upper limit");

            if (ipo.SOperatorEO != null && ipo.SOperatorEO.OperatorVersion == (int)OperatorVersionsEnum.longVersion)
            {
                if (ipo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) > ipo.CashConfigEo.DayCashMaxLimitAmount)
                    throw new CustomException(FlowResponseCodes.RS_DAY_CASH_AMOUNT_LIMIT, "Exceeding the daily withdrawal limit");
            }

            //sc_cach_condition_config 条件4
            var conditionList = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 4).OrderBy(d => d.FirstPayAmountStart).ToList();
            if (conditionList.Any())
            {
                var conditionConfigEo = conditionList.Where(d => ipo.UserEo.Cash >= d.BalanceStartAmount && ipo.UserEo.Cash < d.BalanceEndAmount).FirstOrDefault();
                if (conditionConfigEo != null)
                {
                    if (ipo.UserExEo.TotalPayAmount < conditionConfigEo.TotalPayAmount)
                        throw new CustomException(FlowResponseCodes.RS_NOT_PAYLIMIT, "Not meeting the recharge amount.", result: (conditionConfigEo.TotalPayAmount - ipo.UserExEo.TotalPayAmount).AToM(conditionConfigEo.CurrencyID));
                }
            }

            //用户当前vip等级配置---20240710侯帅要求增加短线版本增加vip
            ipo.CurrVipConfig = Caching.DbCacheUtil.GetVipConfigNoException(ipo.OperatorId, ipo.UserEo.VIP);
            if (ipo.CurrVipConfig != null)
            {
                //当前提现金额大于vip等级对应的当日最大提现金额
                if (ipo.CurrVipConfig.DayCashAmountLimit>0l&&ipo.Amount > ipo.CurrVipConfig.DayCashAmountLimit.AToM(ipo.CurrencyId))
                    throw new CustomException(Common.FlowResponseCodes.RS_DAY_CASH_AMOUNT_LIMIT, $"Maximum amount {ipo.CurrVipConfig.DayCashAmountLimit.AToM(ipo.CurrencyId)}.");

                //如果当天提现次数超过配置值
                if (ipo.CurrVipConfig.DayCashNumLimit>0&&ipo.SumCashNum + 1 > ipo.CurrVipConfig.DayCashNumLimit)
                    throw new CustomException(Common.FlowResponseCodes.RS_CASH_NUM_LIMIT, "The withdrawal frequency has reached the upper limit");

                //用户提现总额
                if (ipo.CurrVipConfig.DayCashAmountLimit>0&&(ipo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) > ipo.CurrVipConfig.DayCashAmountLimit))
                    throw new CustomException(Common.FlowResponseCodes.RS_DAY_CASH_AMOUNT_LIMIT, "Exceeding the daily withdrawal limit");

                ipo.CashRate = ipo.CurrVipConfig.CashRate;
            }
        }

        /// <summary>
        /// 提现是否进入审批
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        private async Task<bool> IsAudit(BraWithDrawIpo ipo)
        {
            //var ipo = t as BraWithDrawIpo;


            LogUtil.GetContextLogger()
                .AddMessage("DefaultVersionService_IsAudit_ipo")
                .AddField("ipo", JsonConvert.SerializeObject(ipo));


            //是否审批
            if (ipo.CashConfigEo.IsAudit)
                return true;

            //本次提现金额 >= 单次提现上线 => 进入审批
            if (ipo.Amount.MToA(ipo.UserEo.CurrencyID) >= ipo.CashConfigEo.CurrCashMaxLimit)
                return true;

            //历史总提现金额 <= 历史总充值金额 * 5
            //并且 用户余额 > 历史总充值金额 * 10
            //=> 进入审批
            //sc_cach_condition_config 条件5
            var cashConditionConfigEo = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 5).FirstOrDefault();
            if (cashConditionConfigEo != null)
            {
                var historyTotalPayAmountMultiple = cashConditionConfigEo.HistoryTotalPayAmountMultiple == 0 ? 5 : cashConditionConfigEo.HistoryTotalPayAmountMultiple;
                var historyTotalPayAmountMultiple1 = cashConditionConfigEo.HistoryTotalPayAmountMultiple1 == 0 ? 10 : cashConditionConfigEo.HistoryTotalPayAmountMultiple1;

                if (ipo.HistoryUserCashInfo.SumCashAmount <= ipo.UserExEo.TotalPayAmount * historyTotalPayAmountMultiple
                    && ipo.UserEo.Cash > ipo.UserExEo.TotalPayAmount * historyTotalPayAmountMultiple1)
                {
                    LogUtil.GetContextLogger()
                        .AddMessage("DefaultVersionService_IsAudit_ipo5")
                        .AddField("ConditionType5", 5);
                    return true;
                }

            }

            //首次提现
            if (ipo.IsFirstCash)
            {
                //sc_cach_condition_config 条件6
                var conditionList = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 6).OrderBy(d => d.TotalPayAmountStartLimit).ToList();
                foreach (var item in conditionList)
                {
                    if (item.CashMultipLimit == 0)
                    {
                        LogUtil.GetContextLogger().AddMessage($"提现配置异常6.ipo:{JsonConvert.SerializeObject(ipo)}");
                        throw new CustomException("sc_cash_condition_config.ConditionType5.HistoryTotalPayAmountMultiple error");
                    }

                    if (ipo.UserExEo.TotalPayAmount >= item.TotalPayAmountStartLimit
                        && ipo.UserExEo.TotalPayAmount < item.TotalPayAmountMaxLimit
                        && ipo.HistoryUserCashInfo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) < ipo.UserExEo.TotalPayAmount * item.CashMultipLimit
                        && ipo.HistoryUserCashInfo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) < item.CashAmountLimit
                        && ipo.UserEo.Cash < item.BalanceLimit
                        )
                    {
                        LogUtil.GetContextLogger()
                            .AddMessage("DefaultVersionService_IsAudit_ipo6")
                            .AddField("ConditionType6", 6);
                        return false;
                    }
                }
            }
            //非首次提现
            else
            {
                //sc_cach_condition_config 条件7
                cashConditionConfigEo = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 7).FirstOrDefault();
                if (cashConditionConfigEo != null)
                {
                    var historyTotalPayAmountMultiple = cashConditionConfigEo.HistoryTotalPayAmountMultiple == 0 ? 2 : cashConditionConfigEo.HistoryTotalPayAmountMultiple;
                    if (ipo.HistoryUserCashInfo.SumCashAmount > ipo.UserExEo.TotalPayAmount * cashConditionConfigEo.HistoryTotalPayAmountMultiple)
                    {
                        LogUtil.GetContextLogger()
                            .AddMessage("DefaultVersionService_IsAudit_ipo7")
                            .AddField("ConditionType7", 7);
                        return true;
                    }
                }
                //sc_cach_condition_config 条件8
                cashConditionConfigEo = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 8).FirstOrDefault();
                if (cashConditionConfigEo != null)
                {
                    var historyTotalPayAmountMultiple = cashConditionConfigEo.HistoryTotalPayAmountMultiple == 0 ? 2 : cashConditionConfigEo.HistoryTotalPayAmountMultiple;
                    var historyTotalPayAmountMultiple1 = cashConditionConfigEo.HistoryTotalPayAmountMultiple1 == 0 ? 5 : cashConditionConfigEo.HistoryTotalPayAmountMultiple1;
                    if (ipo.HistoryUserCashInfo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) <= ipo.UserExEo.TotalPayAmount * historyTotalPayAmountMultiple
                        && ipo.UserEo.Cash > ipo.UserExEo.TotalPayAmount * historyTotalPayAmountMultiple1
                        )
                    {
                        LogUtil.GetContextLogger()
                            .AddMessage("DefaultVersionService_IsAudit_ipo8")
                            .AddField("ConditionType8", 8);
                        return true;
                    }
                }
                //sc_cach_condition_config 条件9
                cashConditionConfigEo = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 9).FirstOrDefault();
                if (cashConditionConfigEo != null)
                {
                    var historyTotalPayAmountMultiple = cashConditionConfigEo.HistoryTotalPayAmountMultiple == 0 ? 2 : cashConditionConfigEo.HistoryTotalPayAmountMultiple;
                    if (ipo.HistoryUserCashInfo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) < ipo.UserExEo.TotalPayAmount * historyTotalPayAmountMultiple
                        && await ipo.UserCashService.GetUserAuditError(ipo.UserId)
                        )
                    {
                        LogUtil.GetContextLogger()
                            .AddMessage("DefaultVersionService_IsAudit_ipo9")
                            .AddField("ConditionType9", 9);
                        return true;
                    }
                }
                //sc_cach_condition_config 条件10
                var conditionList = ipo.CashConditionConfigEoList.Where(d => d.ConditionType == 10).OrderBy(d => d.TotalPayAmountStartLimit).ToList();
                foreach (var item in conditionList)
                {
                    if (item.CashMultipLimit == 0)
                    {
                        LogUtil.GetContextLogger().AddMessage($"提现配置异常10.ipo:{JsonConvert.SerializeObject(ipo)}");
                        throw new CustomException("sc_cash_condition_config.ConditionType10.HistoryTotalPayAmountMultiple error");
                    }

                    if (ipo.UserExEo.TotalPayAmount >= item.TotalPayAmountStartLimit
                        && ipo.UserExEo.TotalPayAmount < item.TotalPayAmountMaxLimit
                        && ipo.HistoryUserCashInfo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) < ipo.UserExEo.TotalPayAmount * item.CashMultipLimit
                        && ipo.HistoryUserCashInfo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) < item.CashAmountLimit
                        && ipo.UserEo.Cash < item.BalanceLimit
                        )
                    {
                        LogUtil.GetContextLogger()
                            .AddMessage("DefaultVersionService_IsAudit_ipo10")
                            .AddField("ConditionType10", 10);
                        return false;
                    }
                }
            }

            LogUtil.GetContextLogger()
                .AddMessage("DefaultVersionService_IsAudit_DefaultAudit_ipo")
                .AddField("IsAudit", true);

            return true;
        }
    }
}
