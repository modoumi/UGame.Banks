using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Pandapay
{
    public class XxyyPandaCashIpo
    {
        public string AccName { get; set; }
        public string TaxId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string BankCode { get; set; }

        public string BranchCode { get; set; }
        public string AccNumber { get; set; }

        /// <summary>
        /// Options are "checking", "savings" and "salary".
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CashAuditId { get; set; }
        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }

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
        /// 充值参与领取bonus状态，2不参与，1参与
        /// </summary>
        public int ReceiveBonus { get; set; }

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
    }
}
