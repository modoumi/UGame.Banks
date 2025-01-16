using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Services.CashServices
{
    public class UserCashInfo
    {
        /// <summary>
        /// 提现总次数
        /// </summary>
        public int SumCashNum { get; set; }

        /// <summary>
        /// 提现总金额
        /// </summary>
        public long? SumCashAmount { get; set; }

    }
}
