namespace Xxyy.Banks.Mongopay.Models.Dto
{
    /// <summary>
    /// 支付异步通知
    /// </summary>
    public class PayNotifyIpo : NotifyIpoBase
    {
        /// <summary>
        /// 0-通过3.2一次性付款码 支付订单
        /// 1-通过3.1线上还款支付订单
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 返回状态码
        /// SUCCESS
        /// </summary>
        public string Status { get; set; }        

        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 校验金额
        /// </summary>
        public decimal PayMoney { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        public decimal PayFee { get; set; }

    }
}
