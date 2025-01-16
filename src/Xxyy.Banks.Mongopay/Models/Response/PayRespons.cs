namespace Xxyy.Banks.Mongopay.Models.Response
{
    /// <summary>
    /// 一次性付款码-响应
    /// </summary>
    public class PayRespons
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string PlatRespCode { get; set; }

        /// <summary>
        /// 应答描述
        /// </summary>
        public string PlatRespMessage { get; set; }

        /// <summary>
        /// 支付方式
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// 平台订单号
        /// </summary>
        public string PlatOrderNum { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderNum { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public string PayMoney { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        public string PayFee { get; set; }

        /// <summary>
        /// 交易描述
        /// </summary>
        public string ProductDetail { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustName { get; set; }

        /// <summary>
        /// 付款
        /// </summary>
        public object PayParams { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string PlatSign { get; set; }

    }
}
