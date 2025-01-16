using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Req
{
     

    public class PayOutRequest
    {
        public string dictKey { get; set;}
        public string dictType { get; set;}
        public string type { get; set; }
        public long amount { get; set; }
        public string currency { get; set; }
        public Customer customer { get; set; }
    }
}
