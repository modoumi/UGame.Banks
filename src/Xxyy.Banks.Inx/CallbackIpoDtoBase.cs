using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Inx
{
    /// <summary>
    /// 银行回调基类
    /// </summary>
    public class CallbackIpoBase
    {
        /// <summary>
        /// 对方的订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 支付状态（A/D/R/T）A-成功
        /// </summary>
        public string Result { get; set; }

        /// <summary>
        /// 实际到账金额
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public Sb_bank_orderEO Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public Sb_bankEO Bank { get; set; }

        //[JsonIgnore]
        //public Sb_order_trans_logEO BankTransLog { get; set; }
    }
    /// <summary>
    /// 
    /// </summary>
    public class CallbackDtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long Balance { get; set; }
    }
}
