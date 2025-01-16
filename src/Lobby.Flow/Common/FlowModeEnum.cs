using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    public enum FlowModeEnum
    {
        None=0,
        [Description("按时间流水+充值")]
        One=1,
        [Description("优先真金")]
        Two=2,
        [Description("新货币真金优先算法-仅bonus流水")]
        Three=3
    }
}
