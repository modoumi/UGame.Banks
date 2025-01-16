namespace Xxyy.Banks.Mongopay.Models.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class CashNotifyIpo : NotifyIpoBase
    {
        /// <summary>
        /// 2:代付成功
        /// 3和4;代付失败
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 手续费收取方式
        /// </summary>
        public string FeeType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 订单金额
        /// </summary>
        public decimal Money { get; set; }

        /// <summary>
        /// 手续费金额
        /// </summary>
        public decimal Fee { get; set; }

        /// <summary>
        /// 转账描述
        /// </summary>
        public string Description { get; set; }

    }
}
