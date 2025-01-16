using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.BFpay.IpoDto
{
    public class BfpayPayIpo : PayIpoBase
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
 
        /// <summary>
        /// 巴西：税号，其他国家忽略
        /// </summary>
        public string TaxId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.None;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(BfpayPayDto);
    }
    public class BfpayPayDto : PayDtoBase
    {
        public string code { get; set; }
        public string payUrl { get; set; }

    }
}
