using Lobby.Flow.Common;

namespace Lobby.Flow.Services.CashServices
{
    /// <summary>
    /// 提现自动审核服务接口
    /// </summary>
    internal interface IAutoCashAuditService
    {
        /// <summary>
        /// false:继续往下走，人工审核流程---true:走自动审核
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        Task<AutoAuditResultEnum> AuditCash(BraWithDrawIpo ipo);
    }
}
