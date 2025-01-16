using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Mlpay.Common
{
    /// <summary>
    /// Mlpay错误码类
    /// </summary>
    public class MlpayResponseCodes
    {
        /// <summary>
        /// 成功
        /// </summary>
        public const string Rs_Success = "0000";

        /// <summary>
        /// 业务异常
        /// </summary>
        public const string Rs_BusinessException = "9999";

        /// <summary>
        /// 参数错误
        /// </summary>
        public const string Rs_ParameterError = "0001";

        /// <summary>
        /// 	商户错误
        /// </summary>
        public const string Rs_PartnersError = "0002";

        /// <summary>
        /// 应用错误
        /// </summary>
        public const string Rs_ApplicationError = "0003";

        /// <summary>
        /// 通道错误
        /// </summary>
        public const string Rs_ChannelError = "0004";

        /// <summary>
        /// 签名错误
        /// </summary>
        public const string Rs_SignError = "0005";

        /// <summary>
        /// 商户金额限制
        /// </summary>
        public const string Rs_PartnerAmountLimit = "0006";

        /// <summary>
        /// 上游错误
        /// </summary>
        public const string Rs_UpstreamError = "0007";        
    }
}
