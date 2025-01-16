using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Hubtel.Proxy
{
    public class SendStatusCheckReq
    {
    }
    public class SendStatusCheckRsp
    {
        public string TransactionId { get; set; }
        public string NetworkTransactionId { get; set; }
        public decimal Amount { get; set; }
        public decimal Fees { get; set; }
        public string ClientReference { get; set; }
        public string Channel { get; set; }
        public string CustomerNumber { get; set; }
        public string Description { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
