using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Mlpay.Common
{
    public class MlpayConfig
    {
        /// <summary>
        /// 是否测试账户
        /// </summary>
        public bool IsTesting { get; set; }
        /// <summary>
        /// 商户id
        /// </summary>
        public string PartnerId { get; set; }

        /// <summary>
        /// 应用id
        /// </summary>
        public long ApplicationId { get; set; }

        /// <summary>
        /// 支付方式ID 固定值 2
        /// </summary>
        public int PayWay { get; set; }

        /// <summary>
        /// 签名用代收key
        /// </summary>
        public string PayKey { get; set; }

        /// <summary>
        /// 签名用代付key
        /// </summary>
        public string CashKey { get; set; }

        /// <summary>
        /// 接口基地址
        /// </summary>
        public string BaseAddress { get; set; }

        /// <summary>
        /// 我方代收异步通知地址
        /// </summary>
        public string PayNotify { get; set; }

        /// <summary>
        /// 我方代付异步通知地址
        /// </summary>
        public string CashNotify { get; set; }

        /// <summary>
        /// 对方接口版本号
        /// </summary>
        public string Version { get; set; }
    }
}
