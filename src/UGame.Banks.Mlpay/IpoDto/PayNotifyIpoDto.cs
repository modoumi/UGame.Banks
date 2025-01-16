namespace UGame.Banks.Mlpay.IpoDto
{
    /// <summary>
    /// 代收回调通知类
    /// </summary>
    public class PayNotifyIpo
    {
        /// <summary>
        /// 状态（0：失败；1：成功）
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 商户应用ID
        /// </summary>
        public int applicationId { get; set; }

        /// <summary>
        /// 支付方式ID（1：PAYPAL;2:PAYTM ）
        /// </summary>
        public int payWay { get; set; }

        /// <summary>
        /// 商户生成的代收号
        /// </summary>
        public string partnerOrderNo { get; set; }

        /// <summary>
        /// 平台生成的代收号
        /// </summary>
        public string orderNo { get; set; }

        /// <summary>
        /// 上游生成的代收号
        /// </summary>
        public string channelOrderNo { get; set; }

        /// <summary>
        /// 支付金额，单位分
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        public string cpf { get; set; }

        /// <summary>
        /// 签名值，详见签名算法,签名值转为大写
        /// </summary>
        public string sign { get; set; }
    }
}
