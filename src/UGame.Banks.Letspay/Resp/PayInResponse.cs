using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Resp
{
    public class PayInResponse
    {
        public string code { get; set; }

        public string orderNo { get; set; }

        public string platOrder { get; set; }

        public string payUrl { get; set; }

        public string retCode { get; set; }

        public string sign { get; set; }

    }
}
