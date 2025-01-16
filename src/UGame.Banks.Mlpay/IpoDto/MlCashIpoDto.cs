using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Mlpay.IpoDto
{
    public class MlpayCashIpo : PayIpoBase
    {
        public string AccountName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AccountNo { get; set; }
        

        public string Email { get; set; } // "520155@gmail.com",
        public string Phone { get; set; } //"9784561230",

        /// <summary>
        /// 对应的各个国家银行编码
        /// </summary>
        public string BankCode { get; set; }
        /// <summary>
        /// 巴西代付使用-填写收款人税号
        /// </summary>
        public string TaxId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.None;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(MlpayCashDto);
    }

    public class MlpayCashDto : PayDtoBase
    {

    }
}
