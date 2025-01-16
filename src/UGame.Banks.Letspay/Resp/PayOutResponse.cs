using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Resp
{
    public class PayOutResponse
    {
        public string retCode { get; set; }
        public string retMsg { get; set; }
        public string mchTransNo { get; set; }
        public string platOrder { get; set; }
        public string status { get; set; }
    }
}
