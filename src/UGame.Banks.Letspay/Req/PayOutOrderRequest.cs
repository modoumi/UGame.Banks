using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Req
{
    public class PayOutOrderRequest
    {
        public string mchId { get; set; }
        public string mchTransNo { get; set; }
        public string sign { get; set; }
    }
}
