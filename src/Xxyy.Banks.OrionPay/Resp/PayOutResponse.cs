using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Resp
{
    public class PayOutResponse
    {
        public string id { get; set; }
        public string authorizationCode { get; set; }
        public string holderName { get; set; }
        public string operationType { get; set; }
        public string transactionMode { get; set; }
        public string transactionType { get; set; }
        public string description { get; set; }
        public int amount { get; set; }
        public int grossAmount { get; set; }
        public int fee { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public object end2end { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
    }
}
