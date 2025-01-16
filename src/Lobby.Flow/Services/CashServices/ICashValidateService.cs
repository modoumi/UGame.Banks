using Lobby.Flow.Common;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 提现规则服务接口由cashauditservicezero,cashauditserviceone,cashauditservicetwo,cashauditservicethree等规则类实现
    /// </summary>
    internal interface ICashValidateService
    {
        Task<(bool?,AutoAuditResultEnum)> ValidateCash(BraWithDrawIpo ipo);
    }
}
