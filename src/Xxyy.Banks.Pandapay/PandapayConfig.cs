using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Configuration;

namespace Xxyy.Banks.Pandapay
{
    public class PandapayConfig//: ICustomConfig
    {
        public string AppId { get; set; }
        public string ApiKey { get; set; }
        public string CompanyNo { get; set; }

        //public string Key => "pandapay";
    }
}
