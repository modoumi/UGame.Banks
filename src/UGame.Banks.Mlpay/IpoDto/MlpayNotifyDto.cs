namespace UGame.Banks.Mlpay.IpoDto
{
    public class MlpayNotifyDto
    {
        /// <summary>
        /// 商户系统接收并处理回调通知后，直接返回 0 值表示处理成功。如无返回，或返回非 0 值，该回调通知将按 10/30/300/1800/1800/3600(单位：秒)的频率重新发起。
        /// </summary>
        public int Status { get; set; }
    }
}
