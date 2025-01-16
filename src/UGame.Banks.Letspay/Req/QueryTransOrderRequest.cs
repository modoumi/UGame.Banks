using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Req
{
    /// <summary>
    /// 代收订单查询
    /// </summary>
    public class QueryTransOrderRequest
    {
        /// <summary>
        /// 商户号
        /// </summary>
        public string mchId { get; set; }

        /// <summary>
        /// 订单号
        /// </summary>
        public string mchTransNo { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }
    }
}
