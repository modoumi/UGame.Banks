using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    public enum WithdrawRuleModeEnum
    {
        [Description("短版提现规则")]
        Zero=0,
        [Description("旧的长版提现规则,flowmode:1")]
        One = 1,
        [Description("新货币算法提现规则,flowmode:3")]
        Two = 2
        //[Description("自动审批提现规则")]
        //Three = 3
    }
}
