namespace Xxyy.Banks.Mongopay
{
    /// <summary>
    /// 
    /// </summary>
    public class MongopayBaseRsp
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        public string PlatRespCode { get; set; }

        /// <summary>
        /// 应答描述
        /// </summary>
        public string PlatRespMessage { get; set; }
    }
}
