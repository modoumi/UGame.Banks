using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    [Flags]
    internal enum AutoAuditResultEnum
    {
        [Description("未定义")]
        None=0,
        [Description("没有配置或没有启用自动审批则执行原有的人工审批流程")]
        Return2OldAudit=1,
        [Description("自动审批通过,直接走提现流程")]
        DirectWithdraw=Return2OldAudit<<1,
        [Description("自动审批未通过,则走人工审核流程但24小时后自动拒绝")]
        AutoAuditRefused=DirectWithdraw<<1
    }
}
