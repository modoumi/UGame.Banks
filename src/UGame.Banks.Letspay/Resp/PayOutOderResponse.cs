﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Resp
{
    public class PayOutOderResponse
    {
        public string mchId { get;set; }
        public string mchTransNo { get;set; }
        public string amount { get;set; }
        public string status { get;set; }
        public string sign { get;set; }
        public string retCode { get;set; }
    }
}
