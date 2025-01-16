using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.IpoDto
{
    public class FlowCashAuditIpo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public string CashAuditId { get; set; }

        /// <summary>
        /// 目标状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 当前操作人名称
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 倍数
        /// </summary>
        public float BonusMultip { get; set; }
    }
}
