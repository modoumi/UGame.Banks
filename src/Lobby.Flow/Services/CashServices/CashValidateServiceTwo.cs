
using Lobby.Flow.Common;
using TinyFx;
using Xxyy.Common;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 新货币算法-长版提现规则2验证服务,WithdrawRuleMode:2
    /// </summary>
    internal class CashValidateServiceTwo : ICashValidateService
    {
        private IAutoCashAuditService _autoCashAuditService;

        public CashValidateServiceTwo()
        {
            _autoCashAuditService = new AutoCashAuditService();
        }
        public async Task<(bool?, AutoAuditResultEnum)> ValidateCash(BraWithDrawIpo ipo)
        {
            await this.CheckCashCondition(ipo);
            var auditRet = await this._autoCashAuditService.AuditCash(ipo);
            if (auditRet== AutoAuditResultEnum.Return2OldAudit)
            {
                return (await IsAudit(ipo),auditRet);
            }
            return (null,auditRet);
        }

        private async Task CheckCashCondition(BraWithDrawIpo ipo)
        {
            //提现审批校验
            var cashConfig = await Common.FlowUtil.GetCashConfig(ipo.OperatorId, ipo.CurrencyId);
            ipo.CashConfigEo = cashConfig;
            if (ipo.UserExEo.TotalCashCount == 0)
            {
                //首次提现金额小于首次提现最小提现金额
                if (ipo.Amount < cashConfig.FirstCashMinAmount.AToM(ipo.CurrencyId))
                    throw new CustomException(Common.FlowResponseCodes.RS_UNKNOWN, $"Minimum amount {cashConfig.CashMinAmount.AToM(ipo.CurrencyId)}.");
            }
            else
            {
                //如果提现金额小于非首次提现最小提现金额
                if (ipo.Amount < cashConfig.CashMinAmount.AToM(ipo.CurrencyId))
                    throw new CustomException(Common.FlowResponseCodes.RS_UNKNOWN, $"Minimum amount {cashConfig.CashMinAmount.AToM(ipo.CurrencyId)}.");
            }
            if (ipo.Amount > cashConfig.CashMaxAmount.AToM(ipo.CurrencyId))
                throw new CustomException(FlowResponseCodes.RS_UNKNOWN, $"Maximum amount {cashConfig.CashMaxAmount.AToM(ipo.CurrencyId)}.");

            //如果当前运营商需要验证手机号，并且用户未绑定手机号的话，则不允许提现
            if (ipo.CashConfigEo.IsVerifyMobile && string.IsNullOrWhiteSpace(ipo.UserEo.Mobile))
                throw new CustomException(Common.FlowResponseCodes.RS_CASH_NOTEXISTSMOBILE, "Please bind your phone number first");

            //如果提现时，用户充值总额 < 提现配置的最低充值金额
            if (cashConfig.CashPayAmount > 0 && ipo.UserExEo.TotalPayAmount < cashConfig.CashPayAmount)
                throw new CustomException(FlowResponseCodes.RS_CASH_NOTMEETMINPAY, "The total amount of historical recharge is too low");

            //无可提现金额
            var flowService = FlowServiceFactory.CreateFlowService(ipo.UserId, ipo.AppId, ipo.OperatorId);
            var drawAmount = await flowService.GetAllowCashMoney(ipo.UserId, ipo.CurrencyId);
            //if (ipo.Amount > drawAmount.AToM(ipo.CurrencyId))
            if (ipo.Amount > drawAmount)
                throw new CustomException(CommonCodes.RS_NOT_ENOUGH_MONEY, "Sorry, your credit is running low.");
            //用户当前vip等级配置
            ipo.CurrVipConfig = Caching.DbCacheUtil.GetVipConfig(ipo.OperatorId, ipo.UserEo.VIP);
            //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
            ipo.CashRate = ipo.CurrVipConfig.CashRate;

            var userCashInfo = await new UserCashService().GetTotalCashNumOrAmount(ipo.UserId);
            ipo.SumCashNum = userCashInfo.sumCashNum;
            ipo.SumCashAmount = userCashInfo.sumCashAmount;

            //获取时间查询区间
            var timeInterval = Common.FlowUtil.GetDBTimeInterval(ipo.OperatorId);
            ipo.StartTime = timeInterval.startTime;
            ipo.EndTime = timeInterval.endTime;

            //用户当天提现总次数、总金额
            //var userCurrDayCashInfo = await ipo.UserCashService.GetTotalCashNumAndAmount(ipo.UserId, true);
            ipo.UserCurrDayCashInfo = new UserCashInfo()
            {
                //用户当天提现总次数
                SumCashNum = (int)userCashInfo.sumCashNum,
                //用户当天提现总金额
                SumCashAmount = userCashInfo.sumCashAmount
            };

            ipo.SumCashNum = ipo.UserCurrDayCashInfo.SumCashNum;

            //如果当天提现次数超过配置值
            if (ipo.SumCashNum + 1 > ipo.CashConfigEo.DayCashNumLimit)
                throw new CustomException(FlowResponseCodes.RS_CASH_NUM_LIMIT, "The withdrawal frequency has reached the upper limit");

            //当天提现总额限制
            if (ipo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) > ipo.CashConfigEo.DayCashMaxLimitAmount)
                throw new CustomException(FlowResponseCodes.RS_DAY_CASH_AMOUNT_LIMIT, "Exceeding the daily withdrawal limit");
            //用户历史提现总次数、总金额
            var historyUserCashInfo = await ipo.UserCashService.GetTotalCashNumAndAmount(ipo.UserId);
            ipo.HistoryUserCashInfo = new UserCashInfo()
            {
                //用户历史提现总次数
                SumCashNum = historyUserCashInfo.sumCashNum,
                //用户历史提现总金额
                SumCashAmount = historyUserCashInfo.sumCashAmount
            };
            //TODO 提现对比充值倍数（超过此倍数，不允许提现）
            if (ipo.CashConfigEo.CashComparePayMultiple>0&&(ipo.Amount + ipo.HistoryUserCashInfo.SumCashAmount.Value.AToM(ipo.CurrencyId)) > ipo.UserExEo.TotalPayAmount.AToM(ipo.CurrencyId) * ipo.CashConfigEo.CashComparePayMultiple)
                throw new CustomException(FlowResponseCodes.RS_CASH_NOTMEETMINPAY, "The total amount of historical recharge is too low");
        }

        private async Task<bool> IsAudit(BraWithDrawIpo ipo)
        {
            //是否审批
            if (ipo.CashConfigEo.IsAudit)
                return true;

            if (ipo.CashConfigEo.HistoryCashComparePayMultiple > 0 && (ipo.HistoryUserCashInfo.SumCashAmount.Value.AToM(ipo.CurrencyId) + ipo.Amount) > ipo.UserExEo.TotalPayAmount.AToM(ipo.CurrencyId) * (decimal)ipo.CashConfigEo.HistoryCashComparePayMultiple)
                return true;

            //单次上限
            if (ipo.Amount >= ipo.CashConfigEo.CurrCashMaxLimit.AToM(ipo.CurrencyId))
                return true;

            //是否首次提现
            var userHasCash = await ipo.GlobalUserDCache.GetHasCashAsync();
            if (!userHasCash)
            {
                if (ipo.CashConfigEo.GlobalFirstCashAuditLimit>0&&ipo.Amount >= ipo.CashConfigEo.GlobalFirstCashAuditLimit.AToM(ipo.CurrencyId))
                    return true;
            }

            if (ipo.Amount >= ipo.CashConfigEo.AuditStartAmount.AToM(ipo.CurrencyId))
                return true;

            return false;
        }
    }
}
