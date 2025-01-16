using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Resp
{
    /// <summary>
    /// 查询代收订单返回实体
    /// </summary>
    public class QueryTransOrderResponse
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
        /// 金额
        /// </summary>
        public decimal amount { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { get; set; }

        /// <summary>
        /// 返回状态码
        /// </summary>
        public string retCode { get; set; }
    }
}
