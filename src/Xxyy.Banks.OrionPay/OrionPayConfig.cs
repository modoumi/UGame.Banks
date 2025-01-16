using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Configuration;
using Xxyy.Banks.BLL;

namespace Xxyy.Banks.Orionpay
{
    internal class OrionPayConfig : BankConfigBase//, ICustomConfig
    {

        public string API_BASE_URL { get; set; }
        public string AUTH_BASE_URL { get; set; }
        public string account_id { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string marketplace_id { get; set; }

        public string host { get; set; }

        public string payCallback { get; set; }


        public string Key => "Orionpay";
    }
}
