
using Lobby.Flow.Common;
using Lobby.Flow.DAL;
using SqlSugar;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Data.SqlSugar;
using TinyFx.DbCaching;
using TinyFx.Randoms;
using UGame.Banks.Client.BLL;
using Xxyy.Common;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 自动审批服务
    /// </summary>
    internal class AutoCashAuditService : IAutoCashAuditService
    {
        /// <summary>
        /// false:继续往下走，人工审核流程---true:走自动审核
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        public async Task<AutoAuditResultEnum> AuditCash(BraWithDrawIpo ipo)
        {
            var cashAuditTmplPo = DbCachingUtil.GetSingle<Sc_cash_audit_templPO>(ipo.OperatorId);
            if (cashAuditTmplPo == null || !cashAuditTmplPo.Status)
                return AutoAuditResultEnum.Return2OldAudit;

            var cashOperTempls = DbCachingUtil.GetList<Sc_cash_oper_templPO>(it => it.OperatorID, ipo.OperatorId);
            if (cashOperTempls == null || cashOperTempls.Count == 0)
                return AutoAuditResultEnum.AutoAuditRefused;
                //throw new CustomException(FlowResponseCodes.RS_CASH_AUTO_AUDIT_ERROR, "withdraw rule config(sc_cash_oper_templ) not valid");

            var cashUserTempls = DbCachingUtil.GetList<Sc_cash_user_templPO>(it => it.OperatorID, ipo.OperatorId);
            if (cashUserTempls == null || cashUserTempls.Count == 0)
                return AutoAuditResultEnum.AutoAuditRefused;
            //throw new CustomException(FlowResponseCodes.RS_CASH_AUTO_AUDIT_ERROR, "withdraw rule config(sc_cash_user_templ) not valid");

            var startTime = DateTime.UtcNow.ToLocalTime(ipo.OperatorId).Date.ToUtcTime(ipo.OperatorId);
            var endTime =startTime.AddDays(1);

            //当天渠道sb_bank_order充值总数
            var chargeType = (int)OrderTypeEnum.Charge;
            var payStatus = (int)BankOrderStatusEnum.Success;
            var operTotalPayAmount = await DbUtil.GetRepository<Sb_bank_orderPO>().AsQueryable()
                .Where(o=>o.RecDate>=startTime&&o.RecDate<endTime&&o.OperatorID==ipo.OperatorId&&o.Status== payStatus && o.OrderType== chargeType&&o.UserKind==1)
                .SumAsync(o=>o.Amount);

            //当天渠道的提现总数(仅统计真金)
            var cashStatus = (int)CashAuditStatusEnum.Success;
            var operTotalCashAmount =Math.Abs(await DbUtil.GetRepository<Sc_cash_auditPO>().AsQueryable()
                .Where(o=>o.OperatorID==ipo.OperatorId&& o.Status== cashStatus && o.AuditTime>=startTime&&o.AuditTime<endTime&&o.AmountBalance<o.AmountBonus&&o.UserKind==1).SumAsync(o=>o.AmountBalance-o.AmountBonus));

            //渠道充提比
            var operPayCashRatio = 0m;
            if(operTotalPayAmount != 0)
            {
                operPayCashRatio = operTotalCashAmount.AToM(ipo.CurrencyId)/operTotalPayAmount.AToM(ipo.CurrencyId);
            }
            else
            {
                operPayCashRatio =operTotalCashAmount.AToM(ipo.CurrencyId);
            }

            //匹配渠道充提比
            var matchedCashOperTempl = cashOperTempls.FirstOrDefault(x=>x.PayCashRatioStart<=operPayCashRatio&& operPayCashRatio<x.PayCashRatioEnd);
            if(null==matchedCashOperTempl)
            {
                var errorMsg = $"withdraw rule operPayCashRatio not matched!operTotalPayMoney:{operTotalPayAmount.AToM(ipo.CurrencyId)},operTotalCashMoney:{operTotalCashAmount.AToM(ipo.CurrencyId)}";
                if (ConfigUtil.Environment.IsProduction)
                    errorMsg = "withdraw rule operPayCashRatio not matched!";
                return AutoAuditResultEnum.AutoAuditRefused;
                //throw new CustomException(FlowResponseCodes.RS_CASH_AUTO_AUDIT_ERROR, errorMsg);
            }

            //用户总的充值
            var userTotalPayAmount =await DbUtil.GetRepository<Sb_bank_orderPO>().AsQueryable()
                .Where(o=>o.UserID==ipo.UserId&&o.Status== payStatus && o.OperatorID==ipo.OperatorId&&o.OrderType== chargeType)
                .SumAsync(o=>o.Amount);

            //用户总的提现
            var userTotalCashAmount = Math.Abs(await DbUtil.GetRepository<Sc_cash_auditPO>().AsQueryable()
                .Where(o => o.UserID == ipo.UserId && o.Status == cashStatus && o.AmountBalance < o.AmountBonus).SumAsync(o => o.AmountBalance - o.AmountBonus));

            //用户的充-提
            var userPayMinusCash = (userTotalPayAmount - userTotalCashAmount).AToM(ipo.CurrencyId);
            
            //用户的充提比(提/充)
            var userTotalCashMoney = userTotalCashAmount.AToM(ipo.CurrencyId) + ipo.Amount;
            var userTotalPayMoney = 0m;
            var userPayCashRatio= 0m;
            if (userTotalPayAmount==0)
            {
                userPayCashRatio = userTotalCashMoney;
            }
            else
            {
                userTotalPayMoney = userTotalPayAmount.AToM(ipo.CurrencyId);
                userPayCashRatio = userTotalCashMoney / userTotalPayMoney;
            }

            var matchedUserPayCashRatio = cashUserTempls.FirstOrDefault(o=>o.OperTempID==matchedCashOperTempl.OperTempID&&o.PayMinusCashStart<=userPayMinusCash&&userPayMinusCash<o.PayMinusCashEnd&&o.PayCashRatioStart<=userPayCashRatio&&o.PayCashRatioEnd>userPayCashRatio);

            if (matchedUserPayCashRatio == null)
            {
                var errorMsg = $"withdraw rule userPayCashRatio not matched! matchedUserPayCashRatio is null,matchedCashOperTempl:{matchedCashOperTempl.OperTempID},userTotalCashMoney:{userTotalCashMoney},userTotalPayMoney:{userTotalPayMoney},userPayMinusCash:{userPayMinusCash}--operTotalPayMoney:{operTotalPayAmount.AToM(ipo.CurrencyId)},operTotalCashMoney:{operTotalCashAmount.AToM(ipo.CurrencyId)}";
                if (ConfigUtil.Environment.IsProduction)
                    errorMsg = "withdraw rule userPayCashRatio not matched! ";
                return AutoAuditResultEnum.AutoAuditRefused;
                //throw new CustomException(FlowResponseCodes.RS_CASH_AUTO_AUDIT_ERROR, errorMsg);
            }

            //匹配用户的充提比得到通过率,1-通过，0-不通过,其他按通过率随机
            if (matchedUserPayCashRatio.PassRate == 0m)
            {
                var errorMsg = $"withdraw rule userPayCashRatio matched but PassRate is Zero!usertmplid:{matchedUserPayCashRatio.UserTempID},passrate:{matchedUserPayCashRatio.PassRate},matchedCashOperTempl:{matchedCashOperTempl.OperTempID},userTotalCashMoney:{userTotalCashMoney},userTotalPayMoney:{userTotalPayMoney},userPayMinusCash:{userPayMinusCash}--operTotalPayMoney:{operTotalPayAmount.AToM(ipo.CurrencyId)},operTotalCashMoney:{operTotalCashAmount.AToM(ipo.CurrencyId)}";
                if (ConfigUtil.Environment.IsProduction)
                    errorMsg = "withdraw rule userPayCashRatio matched but PassRate is Zero!";
                return AutoAuditResultEnum.AutoAuditRefused;
                //throw new CustomException(FlowResponseCodes.RS_CASH_AUTO_AUDIT_ERROR,errorMsg);
            }
            if (matchedUserPayCashRatio.PassRate == 1m)
                return AutoAuditResultEnum.DirectWithdraw;

            var rnd = Random.Shared.Next(0, 101) / 100m;
            if (rnd > matchedUserPayCashRatio.PassRate)
            {
                var errorMsg = $"withdraw rule Pass Rate is not satisfactory! rnd:{rnd},usertmpid:{matchedUserPayCashRatio.UserTempID},passrate:{matchedUserPayCashRatio.PassRate},matchedCashOperTempl:{matchedCashOperTempl.OperTempID},userTotalCashMoney:{userTotalCashMoney},userTotalPayMoney:{userTotalPayMoney},userPayMinusCash:{userPayMinusCash}--operTotalPayMoney:{operTotalPayAmount.AToM(ipo.CurrencyId)},operTotalCashMoney:{operTotalCashAmount.AToM(ipo.CurrencyId)}";
                if (ConfigUtil.Environment.IsProduction)
                    errorMsg = "withdraw rule Pass Rate is not satisfactory!";
                throw new CustomException(FlowResponseCodes.RS_CASH_AUTO_AUDIT_ERROR, errorMsg);
            }
            return AutoAuditResultEnum.DirectWithdraw;
            //return true;
        }
    }
}
