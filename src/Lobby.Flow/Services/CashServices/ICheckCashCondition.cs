namespace Lobby.Flow.Services.CashServices
{
    public interface ICheckCashCondition
    {
        Task CheckCashCondition(BraWithDrawIpo t);
        Task<bool> IsAudit(BraWithDrawIpo t);
    }
}
