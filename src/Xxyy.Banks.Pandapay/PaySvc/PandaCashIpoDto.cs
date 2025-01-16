using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Pandapay.PaySvc
{

    public class PandaCashIpo : PayIpoBase
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
        /// 
        /// </summary>
        public override BankAction Action => BankAction.PandaCash;

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override Type DtoType => typeof(PandaCashDto);
    }


    public class PandaCashDto : PayDtoBase
    {

    }
}
