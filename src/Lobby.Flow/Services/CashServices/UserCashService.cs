using Lobby.Flow.DAL;
using Microsoft.Extensions.Logging;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Data.SqlSugar;
using TinyFx.Logging;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace Lobby.Flow.Services.CashServices
{
    public class UserCashService
    {
        private ILogger<UserCashService> _logger;

        public UserCashService()
        {
            _logger = LogUtil.CreateLogger<UserCashService>();
        }

        /// <summary>
        /// 获取用户总提现次数、总提现金额
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="IsCurrDay"></param>
        /// <returns></returns>
        public async Task<(int sumCashNum, long sumCashAmount)> GetTotalCashNumAndAmount(string userId, bool IsCurrDay = false)
        {
            (int sumCashNum, long sumCashAmount) ret = (0, 0L);

            var bankOrderExpressionable = Expressionable.Create<Sb_bank_orderPO>()
                .And(d => d.UserID.Equals(userId))
                .And(d => !d.IsAuditOrder)
                .And(d => d.OrderType == 2);

            var cashAuditExpressionable = Expressionable.Create<Sc_cash_auditPO>()
                .And(d => d.UserID.Equals(userId))
                .And(d=>d.IsAudit);

            if (IsCurrDay)
            {
                var globalUserDCache = await GlobalUserDCache.Create(userId);
                var operatorId = await globalUserDCache.GetOperatorIdAsync();
                var timeInterval = Common.FlowUtil.GetDBTimeInterval(operatorId);
                bankOrderExpressionable.And(d => d.RecDate >= timeInterval.startTime && d.RecDate < timeInterval.endTime);
                cashAuditExpressionable.And(d => d.ApplyTime >= timeInterval.startTime && d.ApplyTime < timeInterval.endTime);
            }

            var bankOrderExpression = bankOrderExpressionable.ToExpression();
            var cashAuditExpression = cashAuditExpressionable.ToExpression();

            //获取用户直接提现次数、直接提现金额（无视状态）
            var bankOrder = await DbUtil.GetRepository<Sb_bank_orderPO>().AsQueryable()
                .Where(bankOrderExpression)
                .Select(d => new UserCashInfo
                {
                    SumCashNum = SqlFunc.AggregateCount(d),
                    SumCashAmount = SqlFunc.Abs(SqlFunc.AggregateSumNoNull<long?>(d.Amount))
                }).FirstAsync();

            ret.sumCashNum = bankOrder.SumCashNum;
            if (bankOrder.SumCashAmount.HasValue)
                ret.sumCashAmount = bankOrder.SumCashAmount.Value;

            //获取用户需要审批的提现次数、提现金额（无视状态）
            var auditOrder = await DbUtil.GetRepository<Sc_cash_auditPO>().AsQueryable()
                .Where(cashAuditExpression)
                .Select(d => new UserCashInfo
                {
                    SumCashNum = SqlFunc.AggregateCount(d),
                    SumCashAmount = SqlFunc.Abs(SqlFunc.AggregateSumNoNull<long?>(d.Amount))
                }).FirstAsync();

            ret.sumCashNum += auditOrder.SumCashNum;
            if (auditOrder.SumCashAmount.HasValue)
                //提现审核表中的都是正值，此处需减去正值
                ret.sumCashAmount += auditOrder.SumCashAmount.Value;

            return ret;
        }

        /// <summary>
        /// 查询用户是否存在被挂起、退回的单子
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<bool> GetUserAuditError(string userId)
        {
            return await DbUtil.GetRepository<Sc_cash_auditPO>()
                .AsQueryable()
                .Where(d => d.UserID.Equals(userId) && d.Status == 3)
                .CountAsync() > 0;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<(long sumCashNum, long sumCashAmount)> GetTotalCashNumOrAmount(string userId)
        {
            var globalUserDCache = await GlobalUserDCache.Create(userId);
            var operatorId = await globalUserDCache.GetOperatorIdAsync();

            var timeInterval = Common.FlowUtil.GetDBTimeInterval(operatorId);

            (long sumCashNum, long sumCashAmount) ret = (0, 0);

            //直接提款次数，银行订单的提现金额是负值，取绝对值，并排除掉审核的金额，审核的金额会在下面计算
            var userCashInfo1 = await DbSink.MainDb.ExecSqlSingleAsync<UserCashInfo>($@"select                                                                            
	                                                                        count(*) as SumCashNum,
	                                                                        sum(ABS(Amount)) as SumCashAmount
                                                                        from sb_bank_order 
                                                                        where UserID = @userId
                                                                        and OrderType = 2
                                                                        and Status <= 2
                                                                        and IsAuditOrder=0
                                                                        and RecDate >= @startTime
                                                                        and RecDate < @endTime",
                                                                        userId,
                                                                        timeInterval.startTime,
                                                                        timeInterval.endTime);
            ret.sumCashNum = userCashInfo1.SumCashNum;
            if (userCashInfo1.SumCashAmount.HasValue)
                ret.sumCashAmount = userCashInfo1.SumCashAmount.Value;

            //sc_cash_audit 当天所有状态的提现
            //审核通过+未通过的金额，排除拒绝的金额
            var userCashInfo2 = await DbSink.MainDb.ExecSqlSingleAsync<UserCashInfo>($@"select 
	                                                                    count(*) as SumCashNum,
	                                                                    sum(ABS(Amount)) as SumCashAmount
                                                                    from sc_cash_audit 
                                                                    where UserID = @userId
                                                                    and `Status` !=5
                                                                    and ApplyTime >= @startTime 
                                                                    and ApplyTime < @endTime and IsAudit=1",
                                                                    userId,
                                                                    timeInterval.startTime,
                                                                    timeInterval.endTime);

            ret.sumCashNum += userCashInfo2.SumCashNum;
            if (userCashInfo2.SumCashAmount.HasValue)
                //提现审核表中的都是正值，此处需减去正值
                ret.sumCashAmount += userCashInfo2.SumCashAmount.Value;

            return ret;
        }

    }
}
