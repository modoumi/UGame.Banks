using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    public enum CashAuditStatusEnum
    {
        /// <summary>
        /// 初始
        /// </summary>
        Init = -1,
        /// <summary>
        /// 等待后台审核
        /// </summary>
        Auditing = 0,
        /// <summary>
        /// 已提交，等待银行确认
        /// </summary>
        Confirmation = 1,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 4,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 5,
        /// <summary>
        /// 后台人工挂起，待处理
        /// </summary>
        Pending = 3,
        /// <summary>
        /// 已拒绝
        /// </summary>
        Rejected = 2,
        /// <summary>
        /// 24小时后自动回退
        /// </summary>
        AutoReturn=6
    }
}
