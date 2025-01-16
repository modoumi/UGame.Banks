using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Mongopay
{

    public class XxyyMongoCashIpo
    {
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
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 收款账号名称
        /// </summary>
        public string AccName { get; set; }

        /// <summary>
        /// 收款银行代码：见附录
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 收款银行账号
        /// </summary>
        public string AccNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CashAuditId { get; set; }

        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }
    }
}
