namespace Xxyy.Banks.Mongopay.Models.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class PayRequest
    {
        /// <summary>
        /// 商户编码
        /// </summary>
        public string MerchantCode { get; set; }

        /// <summary>
        /// 应用Id
        /// </summary>
        //public string AppId { get; set; }

        /// <summary>
        /// 客户支付方式，具体见1.3.1支付方式
        /// bank_account:银行账号，store:线下便利店，oxxo_cash:OXXO便利店
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustName { get; set; }

        /// <summary>
        /// 客户邮件
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 客户手机号，method=oxxo_cash时必填
        /// 例如:5218181818181
        /// </summary>
        //public string? Phone { get; set; }

        /// <summary>
        /// 交易描述
        /// </summary>
        public string ProductDetail { get; set; }

        /// <summary>
        /// 异步通知地址
        /// </summary>
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 支付过期时间
        /// </summary>
        //public string? ExpiryPeriod { get; set; }

        /// <summary>
        /// 请求发起时间
        /// </summary>
        public string DateTime { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Sign { get; set; }
    }
}
