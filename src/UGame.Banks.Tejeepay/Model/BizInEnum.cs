using System.ComponentModel;

namespace UGame.Banks.Tejeepay.Model
{
    public enum BizInEnum
    {
        [Description("pix代付传")]
        bq101 = 0,

        [Description("巴西扫码API[区别于bq101是直接返回支付底链信息商户自主生成二维码")]
        bq102 = 1,

        [Description("收银台支付方式")]
        ca001 = 2,

        [Description("数字货币支付")]
        us101 = 3,

        [Description("墨西哥转账支付")]
        mc101 = 4,
    }
}
