using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Mongopay
{

    internal class MongoCashIpo : BaseIpo
    {

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
    }
}
