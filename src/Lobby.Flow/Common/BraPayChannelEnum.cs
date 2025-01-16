using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    /// <summary>
    /// 巴西支付渠道（尽量与sb_paytype.PayTypeID保持一致）
    /// </summary>
    public enum BraPayChannelEnum
    {
        hubtel=3,
        /// <summary>
        /// panda pay
        /// </summary>
        pandapay = 4,

        /// <summary>
        /// tejee pay
        /// </summary>
        tejeepay = 5,

        /// <summary>
        /// letspay
        /// </summary>
        letspay = 7,

        /// <summary>
        /// mlpay
        /// </summary>
        mlpay = 8,
        /// <summary>
        /// bfpay
        /// </summary>
        bfpay = 9
    }
}
