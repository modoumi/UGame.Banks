using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Model
{
    // Enum.GetName(typeof(SocialType),0)
    public enum BizOutEnum
    {
        ///pix代付传
        df104 = 0,
        ///银行卡代付传
        df101 = 1,
        ///USDT代付传
        df105 = 2
    }
}
