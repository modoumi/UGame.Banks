using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Services.CashServices
{
    public interface ICashService<T>
    {
        /// <summary>
        /// 校验是否可以提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        Task CheckCashCondition(T ipo);

        /// <summary>
        /// 提现是否进入审批
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        Task<bool> IsAudit(T ipo);

    }
}
