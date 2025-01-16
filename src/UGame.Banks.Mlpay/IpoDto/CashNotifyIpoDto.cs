namespace UGame.Banks.Mlpay.IpoDto
{
    /// <summary>
    /// 代付回调通知类
    /// </summary>
    public class CashNotifyIpo
    {
        /// <summary>
        /// 状态（0：失败；1：成功）
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 非必选 代付上游错误信息（因渠道不同，需要获取到原始值后URLENCODE编码后验签）
        /// </summary>
        public string errorMsg { get; set; }

        /// <summary>
        /// 商户生成的代付号
        /// </summary>
        public string partnerWithdrawNo { get; set; }

        /// <summary>
        /// 平台生成的代付号
        /// </summary>
        public string withdrawNo { get; set; }

        /// <summary>
        /// 上游生成的代付号
        /// </summary>
        public string channelWithdrawNo { get; set; }

        /// <summary>
        /// 支付金额，单位分
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// 签名值，详见签名算法,签名值转为大写
        /// </summary>
        public string sign { get; set; }
    }
}
