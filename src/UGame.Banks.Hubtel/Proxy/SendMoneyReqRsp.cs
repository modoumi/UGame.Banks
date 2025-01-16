using static UGame.Banks.Hubtel.VerifyMobileMoneyRsp;

namespace UGame.Banks.Hubtel
{
    /// <summary>
    /// 提现请求类
    /// </summary>
    public class SendMoneyReq: HubtelRequestIpoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string RecipientName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RecipientMsisdn { get; set; }
    }

    /// <summary>
    /// 提现返回类
    /// </summary>
    public class SendMoneyRsp: HubtelRspDtoBase
    {

        /// <summary>
        /// 
        /// </summary>
        public decimal AmountDebited { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Meta { get; set; }

        public string RecipientName { get; set; }
    }

    /// <summary>
    /// 验证用户是否注册电子钱包
    /// </summary>
    public class VerifyMobileMoneyRsp
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsRegistered { get; set; }
    }
}
