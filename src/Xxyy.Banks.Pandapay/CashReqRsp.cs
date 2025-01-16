using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Pandapay
{
    public class CashReq
    {
        public string reference { get; set; }
        public decimal amount { get; set; }
        public string name { get; set; }
        public string taxId { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string branchCode { get; set; }
        public string bankAccountNumber { get; set; }
        public string accountType { get; set; }
    }

    public class CashRsp //: PandaPayRspBase<CashRsp>
    {
        public decimal amount { get; set; }
        public decimal fee { get; set; }
        public string reference { get; set; }
        public string transactionId { get; set; }
        public string transactionDescription { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string bankAccountNumber { get; set; }
        public string status { get; set; }
    }
}
