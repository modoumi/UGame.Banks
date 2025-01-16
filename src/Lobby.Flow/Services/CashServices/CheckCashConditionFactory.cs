using Lobby.Flow.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Services.CashServices
{
    internal static class CheckCashConditionFactory
    {
        public static ICheckCashCondition Create(int flowMode) => flowMode switch
        {
            (int)FlowModeEnum.Three =>new CheckCashConditionTwo(),
            _=>new CheckCashConditionOne()
        };
    }
}
