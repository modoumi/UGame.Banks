using Newtonsoft.Json;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Mongopay
{
    /// <summary>
    /// spei充值、提现通知基类
    /// </summary>
    public class SpeiNotifyIpoBase: CallbackIpoCommonBase
    {
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 平台订单号
        /// </summary>
        public string PlatOrderNum { get; set; }

        /// <summary>
        /// 签名，详见 1.4签名规则
        /// </summary>
        public string PlatSign { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public Sb_bank_orderEO Order { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public long Balance { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public Sb_order_trans_logEO BankTransLog { get; set; }

        ///// <summary>
        ///// 转换后的金额
        ///// </summary>
        //[JsonIgnore]
        //public long OwnMoney { get; set; }
    }

    /// <summary>
    /// spei充值异步通知实体对象
    /// </summary>
    public class SpeiPayNotifyIpo : SpeiNotifyIpoBase
    {
        /// <summary>
        /// 支付订单类别（0 - 通过 3.2一次性付款码 支付订单，1 - 通过 3.1线上还款 支付订单）
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// SUCCESS
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///Payment Success 
        /// </summary>
        public string Msg { get; set; }

        ///// <summary>
        ///// 商户下单时请求的商户订单号，type 为1 时指创建虚拟账号时上送的商户流水号
        ///// </summary>
        //public string OrderNum { get; set; }

        ///// <summary>
        ///// 平台生成的订单号，平台唯一标识
        ///// </summary>
        //public string PlatOrderNum { get; set; }

        /// <summary>
        /// 下单时客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 单位为墨西哥比索，保留两位小数
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 单位为墨西哥比索，保留两位小数
        /// </summary>
        public decimal PayFee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VaNumber { get; set; }

        

        ///// <summary>
        ///// 签名，详见 1.4签名规则
        ///// </summary>
        //public string PlatSign { get; set; }

        //[JsonIgnore]
        //public Sb_bank_orderEO Order { get; set; }

        //[JsonIgnore]
        //public long Balance { get; set; }
    }
}
