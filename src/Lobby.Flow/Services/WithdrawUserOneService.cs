using Lobby.Flow.Caching;
using Lobby.Flow.Common;
using Lobby.Flow.DAL;
using Lobby.Flow.IpoDto;
using Nacos.Naming.Core;
using Org.BouncyCastle.Ocsp;
using TinyFx.Data;
using TinyFx.Data.SqlSugar;
using TinyFx.Logging;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.MQ.Bank;
using Xxyy.MQ.Xxyy;

namespace Lobby.Flow.Services
{
    /// <summary>
    /// 用于新的打码方式模式
    /// </summary>
    public class WithdrawUserOneService : IWithdrawUserService
    {
        /// <summary>
        /// 所有数值字段放大的倍数默认100，返回前端可提现额时缩小100
        /// </summary>
        private const int MULTIPLE = 100;
        private readonly WithdrawUserServiceDto _dto;
        private readonly Sc_user_cash_amountMO _userCashAmountMo = new();
        public WithdrawUserOneService(WithdrawUserServiceDto dto){
            _dto = dto;
        }

        /// <summary>
        /// 活动或后台审核拒绝
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task DealCurrencyChange(CurrencyChangeMsg msg, TransactionManager tm = null)
        {
            var oper = Xxyy.Common.Caching.DbCacheUtil.GetOperator(msg.OperatorId);
            //if (oper.FlowMode != (int)FlowModeEnum.Three)
            //    return;
            if (oper.BetRatioOfWithdrawAmount == 0 && oper.WinRatioOfWithdrawAmount == 0)
                return;
            //赠送的真金>0
            if (!(msg.Amount > 0 && (msg.Amount - msg.Bonus > 0)))
                return;
            //真金余额
            var balanceInfo =this._dto.BalanceInfo??=await this._dto.UserSvc.GetBalanceInfo(tm, false);
            var cashBalance = (balanceInfo.Balance - balanceInfo.Bonus) * MULTIPLE;
            if (cashBalance < 0)
                cashBalance = 0;
            var userExists = await this.UserExists(msg.UserId);
            if(!userExists)
            {
                try
                {
                    var userCashAmountPo = new Sc_user_cash_amountEO
                    {
                        UserID = msg.UserId,
                        OperatorID = msg.OperatorId,
                        CountryID = msg.CountryId,
                        CurrencyID = msg.CurrencyId,
                        BetCashAmount = 0,
                        WinCashAmount = 0,
                        BalanceCashAmount = cashBalance,
                        WithdrawAmount = (msg.SourceType==1? Math.Abs(msg.Amount - msg.Bonus) * MULTIPLE : 0)
                    };
                    await _userCashAmountMo.AddAsync(userCashAmountPo,tm);
                    //await DbUtil.GetRepository<Sc_user_cash_amountPO>().InsertAsync(userCashAmountPo);
                }
                catch (Exception ex) when (ex.Message.StartsWith("Duplicate entry"))
                {
                    if (msg.SourceType == 1)
                        await UpdateWithdrawUserWhenRefund(msg,tm);
                    else
                        await UpdateWithdrawUserWhenPayOrActivity(cashBalance, msg.UserId,tm);
                }
                return;
            }
            if (msg.SourceType == 1)
                await UpdateWithdrawUserWhenRefund(msg, tm);
            else
                await UpdateWithdrawUserWhenPayOrActivity(cashBalance, msg.UserId, tm);
        }

        private async Task<bool> UserExists(string userId) => await DbUtil.GetRepository<Sc_user_cash_amountPO>().IsAnyAsync(x => x.UserID == userId);

        public async Task DealUserBet(UserBetMsg msg, TransactionManager tm = null)
        {
            var oper = Xxyy.Common.Caching.DbCacheUtil.GetOperator(msg.OperatorId);
            //if (oper.FlowMode != (int)FlowModeEnum.Three)
            //    return;
            if (oper.BetRatioOfWithdrawAmount == 0 && oper.WinRatioOfWithdrawAmount == 0)
                return;
            if (msg.BetType == 4)
                return;
            int betRatioOfWithdrawAmount = (int)(oper.BetRatioOfWithdrawAmount * MULTIPLE);
            int winRatioOfWithdrawAmount = (int)(oper.WinRatioOfWithdrawAmount * MULTIPLE);
            //真金下注
            var betCashAmount = (msg.BetAmount - msg.BetBonus) * MULTIPLE;
            //真金返奖
            var winCashAmount = (msg.WinAmount - msg.WinBonus) * MULTIPLE;
            //真金balance
            var balanceInfo= await this._dto.UserSvc.GetBalanceInfo(tm,true);
            var balanceCashAmount = (balanceInfo.Balance-balanceInfo.Bonus)*MULTIPLE;
            if (balanceCashAmount < 0)
                balanceCashAmount = 0;

            var userExists = await UserExists(msg.UserId);
            if (!userExists)
            {
                //都放大100，前端返回前缩小100
                var withdrawAmount = (betRatioOfWithdrawAmount, winRatioOfWithdrawAmount) switch
                {
                    (0, 0) => balanceCashAmount,
                    (0, _) => Math.Min((long)(oper.WinRatioOfWithdrawAmount * winCashAmount), balanceCashAmount),
                    (_, 0) => Math.Min((long)(oper.BetRatioOfWithdrawAmount * betCashAmount), balanceCashAmount),
                    (_, _) => (new[] { (long)(oper.BetRatioOfWithdrawAmount * betCashAmount), (long)(oper.WinRatioOfWithdrawAmount * winCashAmount), balanceCashAmount }).Min()
                };
                try
                {
                    var userCashAmountEo = new Sc_user_cash_amountEO
                    {
                        UserID = msg.UserId,
                        OperatorID = msg.OperatorId,
                        CountryID = msg.CountryId,
                        CurrencyID = msg.CurrencyId,
                        BetCashAmount = betCashAmount,
                        WinCashAmount = winCashAmount,
                        BalanceCashAmount = balanceCashAmount,
                        WithdrawAmount = withdrawAmount
                    };
                    //var ret = await DbUtil.GetRepository<Sc_user_cash_amountPO>().InsertAsync(userCashAmountEo);
                    await _userCashAmountMo.AddAsync(userCashAmountEo,tm);
                }
                catch (Exception ex) when(ex.Message.StartsWith("Duplicate entry"))
                {
                    await UpdateWithdrawUser(tm);
                }catch(Exception ex)
                {
                    LogUtil.Error(ex,"处理下注消息DealUserBet添加计算可提现额时异常！");
                }
                return;
            }

            await UpdateWithdrawUser(tm);
            async Task UpdateWithdrawUser(TransactionManager tm)
            {
                //var set = $"update sc_user_cash_amount set BalanceCashAmount={balanceCashAmount} ";
                var set = $"BalanceCashAmount={balanceCashAmount} ";
                if (betCashAmount > 0)
                    set += $",BetCashAmount=BetCashAmount+{betCashAmount}";
                if (winCashAmount > 0)
                    set += $",WinCashAmount=WinCashAmount+{winCashAmount}";

                var setWithdrawAmountFunc = (int flag) => flag switch
                {
                    0 => (oper.BetRatioOfWithdrawAmount, oper.WinRatioOfWithdrawAmount) switch
                    {
                        (0m, 0m) => $"BalanceCashAmount",
                        (0m, _) => $"LEAST(WinCashAmount*{oper.WinRatioOfWithdrawAmount},BalanceCashAmount)",
                        (_, 0m) => $"LEAST(BetCashAmount*{oper.BetRatioOfWithdrawAmount},BalanceCashAmount)",
                        _ => $"LEAST(BetCashAmount*{oper.BetRatioOfWithdrawAmount},WinCashAmount*{oper.WinRatioOfWithdrawAmount},BalanceCashAmount)"
                    },
                    1 => (oper.BetRatioOfWithdrawAmount, oper.WinRatioOfWithdrawAmount) switch
                    {
                        (0m, 0m) => $"BalanceCashAmount-TempWithdrawAmount",
                        (0m, _) => $"LEAST(WinCashAmount*{oper.WinRatioOfWithdrawAmount},BalanceCashAmount-TempWithdrawAmount)",
                        (_, 0m) => $"LEAST(BetCashAmount*{oper.BetRatioOfWithdrawAmount},BalanceCashAmount-TempWithdrawAmount)",
                        _ => $"LEAST(BetCashAmount*{oper.BetRatioOfWithdrawAmount},WinCashAmount*{oper.WinRatioOfWithdrawAmount},BalanceCashAmount-TempWithdrawAmount)"
                    },
                    _ => throw new ArgumentException($"{nameof(flag)}参数错误！不支持的值：{flag}")
                };

                //set += $",WithdrawAmount=case when TempWithdrawAmount=0 then {setWithdrawAmountFunc(0)} when TempWithdrawAmount>0 and BalanceCashAmount>TempWithdrawAmount then TempWithdrawAmount+{setWithdrawAmountFunc(1)} when TempWithdrawAmount>0 and BalanceCashAmount<=TempWithdrawAmount then {setWithdrawAmountFunc(0)} end,TempWithdrawAmount=case when TempWithdrawAmount>0 and BalanceCashAmount<=TempWithdrawAmount then 0 else TempWithdrawAmount end where UserId='{msg.UserId}'";
                //var rows = await DbUtil.GetDb<Sc_user_cash_amountPO>().Ado.ExecuteCommandAsync(set);
                
                try
                {
                    set += $",WithdrawAmount=case when TempWithdrawAmount=0 then {setWithdrawAmountFunc(0)} when TempWithdrawAmount>0 and BalanceCashAmount>TempWithdrawAmount then TempWithdrawAmount+{setWithdrawAmountFunc(1)} when TempWithdrawAmount>0 and BalanceCashAmount<=TempWithdrawAmount then {setWithdrawAmountFunc(0)} end,TempWithdrawAmount=case when TempWithdrawAmount>0 and BalanceCashAmount<=TempWithdrawAmount then 0 else TempWithdrawAmount end";
                    var rows = await _userCashAmountMo.PutAsync(set, $"UserId='{msg.UserId}'", tm);
                }
                catch (Exception ex)
                {
                    LogUtil.Error(ex,$"处理下注消息更新sc_user_cash_amount可提现额异常!");
                }
            };
        }

        /// <summary>
        /// 提现
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public async Task DealUserCash(CurrencyChangeMsg msg)
        {
            var oper = Xxyy.Common.Caching.DbCacheUtil.GetOperator(msg.OperatorId);
            //if (oper.FlowMode != (int)FlowModeEnum.Three)
            //    return;
            if (oper.BetRatioOfWithdrawAmount == 0 && oper.WinRatioOfWithdrawAmount == 0)
                return;
            var withdrawCashAmount = Math.Abs(msg.Amount - msg.Bonus) * MULTIPLE;
            if (!(msg.Amount < 0 && withdrawCashAmount > 0))
                return;
            //var cashBalance = (msg.EndBalance - msg.EndBonus)*MULTIPLE;
            var balanceInfo = await _dto.UserSvc.GetBalanceInfo(null, true);
            var cashBalance = (balanceInfo.Balance - balanceInfo.Bonus) * MULTIPLE;
            if (cashBalance < 0)
                cashBalance = 0;
            var userExists = await this.UserExists(msg.UserId);
            if (!userExists)
            {
                try
                {
                    //var oper = Xxyy.Common.Caching.DbCacheUtil.GetOperator(msg.OperatorId);
                    await DbUtil.GetRepository<Sc_user_cash_amountPO>().InsertAsync(new Sc_user_cash_amountPO {
                        UserID = msg.UserId,
                        OperatorID = msg.OperatorId,
                        CountryID = msg.CountryId,
                        CurrencyID = msg.CurrencyId,
                        BetCashAmount = 0,
                        WinCashAmount = 0,
                        BalanceCashAmount = cashBalance,
                        WithdrawAmount = 0,
                        TempWithdrawAmount = 0
                    });
                }
                catch (Exception ex) when (ex.Message.StartsWith("Duplicate entry"))
                {
                    await UpdateWithdrawUser();
                }
                return;
            }
            await UpdateWithdrawUser();
            //真金变化额
            async Task UpdateWithdrawUser()
            {
                var set = $"update sc_user_cash_amount set BetCashAmount=case when BetCashAmount-{withdrawCashAmount}>0 then BetCashAmount-{withdrawCashAmount} else 0 end,WinCashAmount=case when WinCashAmount-{withdrawCashAmount} >0 then WinCashAmount-{withdrawCashAmount} else 0 end,BalanceCashAmount={cashBalance},WithdrawAmount=case when WithdrawAmount-{withdrawCashAmount} >0 then WithdrawAmount-{withdrawCashAmount} else 0 end where UserID='{msg.UserId}'";
                var rows = await DbUtil.GetDb<Sc_user_cash_amountPO>().Ado.ExecuteCommandAsync(set);
            }
        }

        public async Task DealUserPay(UserPayMsg msg)
        {
            var oper = Xxyy.Common.Caching.DbCacheUtil.GetOperator(msg.OperatorId);
            //if (oper.FlowMode != (int)FlowModeEnum.Three)
            //    return;
            if (oper.BetRatioOfWithdrawAmount == 0 && oper.WinRatioOfWithdrawAmount == 0)
                return;
            //var cashBalance = (msg.EndBalance - msg.EndBonus)*MULTIPLE;
            var balanceInfo = await _dto.UserSvc.GetBalanceInfo(null, true);
            var cashBalance = (balanceInfo.Balance-balanceInfo.Bonus) * MULTIPLE;
            if (cashBalance < 0)
                cashBalance = 0;
            var userExists = await this.UserExists(msg.UserId);
            if(!userExists)
            {
                try
                {
                    //var oper = Xxyy.Common.Caching.DbCacheUtil.GetOperator(msg.OperatorId);
                    var ret = await DbUtil.GetRepository<Sc_user_cash_amountPO>().InsertAsync(new Sc_user_cash_amountPO
                    {
                        UserID = msg.UserId,
                        OperatorID = msg.OperatorId,
                        CountryID = msg.CountryId,
                        CurrencyID = msg.CurrencyId,
                        BetCashAmount = 0,
                        WinCashAmount = 0,
                        BalanceCashAmount = cashBalance,
                        WithdrawAmount = 0,
                        TempWithdrawAmount = 0
                    });
                }
                catch (Exception ex) when (ex.Message.StartsWith("Duplicate entry"))
                {
                    await UpdateWithdrawUserWhenPayOrActivity(cashBalance,msg.UserId,null);
                }
                return;
            }
            await UpdateWithdrawUserWhenPayOrActivity(cashBalance,msg.UserId,null);
        }

        /// <summary>
        /// 后台审核拒绝
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        private async Task<int> UpdateWithdrawUserWhenRefund(CurrencyChangeMsg msg,TransactionManager tm)
        {
            //真金余额
            //var cashBalance = (msg.EndBalance - msg.EndBonus) * MULTIPLE;
            var balanceInfo = await _dto.UserSvc.GetBalanceInfo(tm, true);
            var cashBalance = (balanceInfo.Balance-balanceInfo.Bonus) * MULTIPLE;
            if (cashBalance < 0)
                cashBalance = 0;
            string userId = msg.UserId;
            var withdrawCashAmount = Math.Abs(msg.Amount - msg.Bonus) * MULTIPLE;
            //var set = $"update sc_user_cash_amount set BetCashAmount=BetCashAmount+{withdrawCashAmount},WinCashAmount=WinCashAmount+{withdrawCashAmount},BalanceCashAmount={(cashBalance < 0 ? 0 : cashBalance)},WithdrawAmount=WithdrawAmount+{withdrawCashAmount} where UserID='{userId}'";
            //var rows = await DbUtil.GetDb<Sc_user_cash_amountPO>().Ado.ExecuteCommandAsync(set);
            var set = $"BetCashAmount=BetCashAmount+{withdrawCashAmount},WinCashAmount=WinCashAmount+{withdrawCashAmount},BalanceCashAmount={(cashBalance < 0 ? 0 : cashBalance)},WithdrawAmount=WithdrawAmount+{withdrawCashAmount}";
            var rows = await _userCashAmountMo.PutAsync(set, $"UserID='{userId}'", tm);
            return rows;
        }

        /// <summary>
        /// 充值或者活动赠送
        /// </summary>
        /// <param name="cashBalance"></param>
        /// <param name="userId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        private async Task<int> UpdateWithdrawUserWhenPayOrActivity(long cashBalance,string userId,TransactionManager tm)
        {
            //var set = $"update sc_user_cash_amount set BetCashAmount=0,WinCashAmount=0,BalanceCashAmount={(cashBalance < 0 ? 0 : cashBalance)},TempWithdrawAmount=WithdrawAmount where UserID='{userId}'";
            //var rows = await DbUtil.GetDb<Sc_user_cash_amountPO>().Ado.ExecuteCommandAsync(set);
            var set = $"BetCashAmount=0,WinCashAmount=0,BalanceCashAmount={(cashBalance < 0 ? 0 : cashBalance)},TempWithdrawAmount=WithdrawAmount";
            //var rows = await DbUtil.GetDb<Sc_user_cash_amountPO>().Ado.ExecuteCommandAsync(set);
            var rows = await _userCashAmountMo.PutAsync(set,$"UserID='{userId}'",tm);
            return rows;
        }

        public async Task<decimal> GetWithdrawMoney(WithdrawUserServiceDto dto)
        {
            if (dto.OperatorEo.BetRatioOfWithdrawAmount == 0m && dto.OperatorEo.WinRatioOfWithdrawAmount == 0m)
            {
                var userInfo = await dto.UserSvc.GetBalanceInfo(dto.TM);
                return userInfo.ValidAmount.AToM(dto.CurrencyId);
            }
            var withdrawUserPo = await DbUtil.GetRepository<Sc_user_cash_amountPO>().GetFirstAsync(x => x.UserID == dto.UserSvc.UserId);
            if (null == withdrawUserPo)
                return 0m;
            return withdrawUserPo.WithdrawAmount.AToM(dto.CurrencyId)/MULTIPLE;
        }

    }
}
