using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Resp
{
    public class PayInOrderResponse
    {
        public string mchId { get; set; }
        public string orderNo { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string sign { get; set;   }
        public string retCode { get; set; }
    }
}
