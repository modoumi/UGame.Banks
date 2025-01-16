using System.ComponentModel;

namespace UGame.Banks.Tejeepay.Model
{
    // Enum.GetName(typeof(SocialType),0)
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
