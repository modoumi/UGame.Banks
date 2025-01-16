using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    public enum WithdrawAmountModelEnum
    {
        [Description("默认-真金余额")]
        Zero=0,
        [Description("Min(bet,win,balance)最小值算法")]
        One=1,
        [Description("旧版本-账户余额")]
        Two =2
    }
}
