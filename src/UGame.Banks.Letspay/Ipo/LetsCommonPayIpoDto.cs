using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Letspay.Ipo
{
    public class LetsCommonPayIpo : PayIpoBase
    {
        public string ClientIp { get; set; }
        
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string bankCode { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.LetsPay;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(LetsCommonPayDto);
    }
    public class LetsCommonPayDto : PayDtoBase
    {



        public string code { get; set; }
        public string payUrl { get; set; }

    }
}
