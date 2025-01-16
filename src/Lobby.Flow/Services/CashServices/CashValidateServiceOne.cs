
using Lobby.Flow.Common;
using TinyFx;
using Xxyy.Common;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 长版提现规则1验证服务--原来旧的长版提现规则WithdrawRuleMode:1
    /// </summary>
    internal class CashValidateServiceOne : ICashValidateService
    {
        private IAutoCashAuditService _autoCashAuditService;

        public CashValidateServiceOne()
        {
            _autoCashAuditService = new AutoCashAuditService();
        }
        public async Task<(bool?, AutoAuditResultEnum)> ValidateCash(BraWithDrawIpo ipo)
        {
            await this.CheckCashCondition(ipo);
            var auditRet = await this._autoCashAuditService.AuditCash(ipo);
            if (auditRet == Common.AutoAuditResultEnum.Return2OldAudit)
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

            //提现金额大于账户余额（真金+bonus）
            if (ipo.Amount > ipo.UserEo.Cash.AToM(ipo.CurrencyId))
                throw new CustomException(CommonCodes.RS_NOT_ENOUGH_MONEY, "Sorry, your credit is running low.");

            //如果当前运营商需要验证手机号，并且用户未绑定手机号的话，则不允许提现
            if (ipo.CashConfigEo.IsVerifyMobile && string.IsNullOrWhiteSpace(ipo.UserEo.Mobile))
                throw new CustomException(Common.FlowResponseCodes.RS_CASH_NOTEXISTSMOBILE, "Condition not met.1");

            //无可提现金额
            var flowService = FlowServiceFactory.CreateFlowService(ipo.UserId, ipo.AppId, ipo.OperatorId);
            var drawAmount = await flowService.GetAllowCashMoney(ipo.UserId, ipo.CurrencyId);
            //var drawAmount = await LobbyUtil.GetAllowCashAmount(ipo.UserId, ipo.CurrencyId);
            if (drawAmount == 0)
                throw new CustomException(Common.FlowResponseCodes.RS_UNKNOWN, "Condition not met.2");

            //用户当前vip等级配置
            ipo.CurrVipConfig = Caching.DbCacheUtil.GetVipConfig(ipo.OperatorId, ipo.UserEo.VIP);
            //当前提现金额大于vip等级对应的当日最大提现金额
            if (ipo.Amount > ipo.CurrVipConfig.DayCashAmountLimit.AToM(ipo.CurrencyId))
                throw new CustomException(Common.FlowResponseCodes.RS_UNKNOWN, $"Maximum amount {ipo.CurrVipConfig.DayCashAmountLimit.AToM(ipo.CurrencyId)}.");

            var userCashInfo = await new UserCashService().GetTotalCashNumOrAmount(ipo.UserId);
            ipo.SumCashNum = userCashInfo.sumCashNum;
            ipo.SumCashAmount = userCashInfo.sumCashAmount;
            //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
            ipo.CashRate = ipo.CurrVipConfig.CashRate;

            //获取时间查询区间
            var timeInterval = Common.FlowUtil.GetDBTimeInterval(ipo.OperatorId);
            ipo.StartTime = timeInterval.startTime;
            ipo.EndTime = timeInterval.endTime;

            //如果当天提现次数超过配置值
            if (ipo.SumCashNum + 1 > ipo.CurrVipConfig.DayCashNumLimit)
                throw new CustomException(Common.FlowResponseCodes.RS_CASH_NUM_LIMIT, "The withdrawal frequency has reached the upper limit");

            //用户提现总额
            if (ipo.SumCashAmount + ipo.Amount.MToA(ipo.CurrencyId) > ipo.CurrVipConfig.DayCashAmountLimit)
                throw new CustomException(Common.FlowResponseCodes.RS_DAY_CASH_AMOUNT_LIMIT, "Exceeding the daily withdrawal limit");
        }

        private async Task<bool> IsAudit(BraWithDrawIpo ipo)
        {

            //是否审批
            if (ipo.CashConfigEo.IsAudit)
                return true;

            if (
                ipo.Amount < ipo.CashConfigEo.CurrCashMaxLimit.AToM(ipo.CurrencyId)
                && ipo.UserExEo.TotalPayAmount > 0
                )
                return false;

            return true;
        }
    }
}
