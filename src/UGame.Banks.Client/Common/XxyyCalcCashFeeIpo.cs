using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Serialization;

namespace UGame.Banks.Client.BLL
{
    public class XxyyCalcCashFeeIpo
    {
        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyId { get; set; }

        /// <summary>
        /// 银行编码
        /// </summary>
        public string BankId { get; set; }

        /// <summary>
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// vip提现时扣除的手续费费率
        /// </summary>
        public decimal CashRate { get; set; }
        
        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JsonMeta AdditionalParameters { get; set; }
    }
}
