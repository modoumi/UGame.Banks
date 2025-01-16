using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Req
{
    public class Address
    {
        public string zipCode { get; set; }
    }

    public class Customer
    {
        public Identify identify { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
    }

    public class Identify
    {
        public string type { get; set; }
        public string number { get; set; }
    }

    public class PayInRequest
    {
        public string type { get; set; }
        public long amount { get; set; }
        public string currency { get; set; }
        public Customer customer { get; set; }
    }
}
