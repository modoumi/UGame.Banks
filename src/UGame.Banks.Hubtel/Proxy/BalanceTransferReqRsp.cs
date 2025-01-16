using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Hubtel.Proxy
{
    public class BalanceTransferReq
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string ClientReference { get; set; }
        public string DestinationAccountNumber { get; set; }
        public string PrimaryCallbackUrl { get; set; }
    }

    public class BalanceTransferRsp
    {
        public string ClientReference { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal Charges { get; set; }
        public string RecipientName { get; set; }
    }
}
