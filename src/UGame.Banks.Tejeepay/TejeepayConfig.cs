using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Configuration;
using UGame.Banks.Service;

namespace UGame.Banks.Tejeepay
{
    internal class TejeepayConfig : BankConfigBase//, ICustomConfig
    {
        public string merchantId { get; set; }

        public string merchantKey { get; set; }

        public string publicKey { get; set; }

        public string privateKey { get; set; }

        public string host { get; set; }

        public string payNotify
        {
            get;
            set;
        }

        public string payCallback { get; set; }


        public string cashNotify
        {
            get;
            set;
        }

        public string Key => "tejeepay";
    }
}
