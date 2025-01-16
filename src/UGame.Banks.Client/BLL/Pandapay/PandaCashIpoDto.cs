using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Pandapay
{
    internal class PandaCashIpo:BaseIpo
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
    }

}
