using Lobby.Flow.IpoDto;
using TinyFx.Data;
using TinyFx.Data.SqlSugar;
using Xxyy.MQ.Bank;
using Xxyy.MQ.Xxyy;

namespace Lobby.Flow.Services
{
    public interface IWithdrawUserService
    {
        Task<decimal> GetWithdrawMoney(WithdrawUserServiceDto dto);
        Task DealUserBet(UserBetMsg msg, TransactionManager tm = null);
        Task DealUserPay(UserPayMsg msg);
        Task DealUserCash(CurrencyChangeMsg msg);
        Task DealCurrencyChange(CurrencyChangeMsg msg,TransactionManager tm=null);
    }
}
