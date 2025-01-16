using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Tejeepay
{
    public enum BizOutEnum
    {
        [Description("pix代付传")]
        df104 = 0,

        [Description("银行卡代付")]
        df101 = 1,

        [Description("USDT代付传")]
        df105 = 2,

        [Description("钱包代付")]
        df103 = 3,
    }
}
