using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Req
{
    public class Subscriptions
    {
        public string id { get; set; }
        public string marketplaceId { get; set; }
        public string method { get; set; }
        public string url { get; set; }
        public DateTime createdAt { get; set; }
    }
}
