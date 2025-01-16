using TinyFx.Configuration;
using Xxyy.Banks.BLL;
using Xxyy.Common;
using Xxyy.Common.Caching;
using Xxyy.DAL;

namespace Xxyy.Banks.Inx.Core
{
    public class InxBankConfig : BankConfigBase//, ICustomConfig
    {
        //public override string SignHeaderName => "X-Hub88-Signature";
        public const string BankAppId = "key_lisi";
        public const string BankAppSecret = "I9O6ZZ3D7FF2748AED89E90ZB7732M9";
        /// <summary>
        /// 商户编号
        /// </summary>
        public const string MerchantId = "8523973";

        /// <summary>
        /// 商户名称
        /// </summary>
        public const string MerchantName = "XALDO*NATURAL";

        /// <summary>
        /// 商户城市
        /// </summary>
        public const string MerchantCity = "DELICIAS";


        /// <summary>
        /// 子商户
        /// </summary>
        public const string SubMerchant = "";

       

        /// <summary>
        /// 支付密码
        /// </summary>
        public const string PassWord = null;

        /// <summary>
        /// 终端编号
        /// </summary>
        public const string TerminalId = null;

        /// <summary>
        /// 我方的回调接口地址
        /// </summary>
        public const string Callback = "http://localhost";

        /// <summary>
        /// 
        /// </summary>
        public string Key => "inx";

        /// <summary>
        /// 
        /// </summary>
        public string PayCallbackUrl { get; set; }
    }
}
