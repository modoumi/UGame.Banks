namespace Xxyy.Banks.Inx
{
    /// <summary>
    /// 
    /// </summary>
    public class PayWorksReq:RequestBase
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// 过期时间 格式MM/yy
        /// </summary>
        public string CardExp { get; set; }

        /// <summary>
        /// 金额比索，带两位小数位
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 0 visa 1 master
        /// </summary>
        public int CardType { get; set; }

        /// <summary>
        /// 交易流水,最大15位
        /// </summary>
        public string IdSecureTransaction { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 国家
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 姓氏
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// 州
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// 卡类型：0 CR: Creditcard（信用卡） 1 DB: Debitcard（储蓄卡）
        /// </summary>
        public int CreditType { get; set; }

        ///// <summary>
        ///// 用户编号
        ///// </summary>
        //public string UserId { get; set; }

        ///// <summary>
        ///// 支付密码
        ///// </summary>
        //public string PassWord { get; set; }


        /// <summary>
        /// CVV
        /// </summary>
        public string SecurityCode { get; set; }

        /// <summary>
        /// 回调地址
        /// </summary>
        public string Callback { get; set; }


        ///// <summary>
        ///// 3d验证返回的reference3d,交易的唯一编号
        ///// </summary>
        //public string ControlNumber { get; set; }

        ///// <summary>
        ///// 商户编号
        ///// </summary>
        //public string MerchantId { get; set; }

        ///// <summary>
        ///// 子商户
        ///// </summary>
        //public string SubMerchant { get; set; }

        
        ///// <summary>
        ///// 终端编号
        ///// </summary>
        //public string TerminalId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PayWorksRsp:PayRspBase
    {

    }
}
