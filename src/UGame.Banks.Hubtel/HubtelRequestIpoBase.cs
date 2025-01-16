namespace UGame.Banks.Hubtel
{
    /// <summary>
    /// hubtel充值提现基类
    /// </summary>
    public class HubtelRequestIpoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string CustomerEmail { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PrimaryCallbackURL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientReference { get; set; }
    }
}
