using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Req
{
    public class PayInOrderRequest
    {
        public string mchId { get;set; }
        public string orderNo { get;set; }
        public string sign { get;set; }

    }

    
}
