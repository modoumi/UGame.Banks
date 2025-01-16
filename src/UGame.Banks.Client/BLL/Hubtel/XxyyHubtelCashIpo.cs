using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Hubtel
{
    public class XxyyHubtelCashIpo
    {
        /// <summary>
        /// 还款（充值）时的用户钱包
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 还款（充值）时的用channel
        /// </summary>
        public string Channel { get; set; }

        public string CashAuditId { get; set; }

        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// vip提现时扣除的手续费
        /// </summary>
        public decimal CashRate { get; set; }
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
        /// 国家编码
        /// </summary>
        public string CountryId { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }
        /// <summary>
        /// lobby订单id----CashAuditId
        /// </summary>
        public string AppOrderId { get; set; }

    }
}
