using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Hubtel.Proxy
{
    public class ReceiveStatusCheckReq
    {

    }

    public class ReceiveStatusCheckRsp
    {
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string TransactionId { get; set; }
        public string PaymentMethod { get; set; }
        public string ClientReference { get; set; }
        public string CurrencyCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Charges { get; set; }
        public decimal AmountAfterCharges { get; set; }
        //public decimal IsFulfilled { get; set; }
    }
}
