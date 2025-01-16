using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Common
{
    public class BankConfig
    {
        public string BaseAddress { get; set; }
        public string MerchantId { get; set; }
        public string MerchantKey { get; set; }
        public string PublicKey { get; set; }
        public string PrivateKey { get; set; }
        public string Host { get; set; }
        public string PayNotify { get; set; }
        public string PayCallback { get; set; }
        public string CashNotify { get; set; }
    }
}
