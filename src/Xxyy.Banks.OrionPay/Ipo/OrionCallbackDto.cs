using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Ipo
{
    public class OrionCallbackDto
    {
        public string status { get; set; } = "fail";//SUCCESS
        public string msg { get; set; }
    }
}
