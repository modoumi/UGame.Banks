using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Letspay.Ipo
{
    public class LetsProxyPayIpo : PayIpoBase
    {
        //public string cashAuditId { get; set; }
        public string accountName { get;set; }
        /// <summary>
        /// accountNo 类型有 cpf,cnpj,email,phone,evp
        /// </summary>
        public string accountNo { get;set; }
        /// <summary>
        /// cpf|cnpj|email|phone|evp  
        /// </summary>
        public string bankCode { get;set; } //cpf

        public string email { get; set; } // "520155@gmail.com",
        public string phone { get; set; } //"9784561230",
        /// <summary>
        /// 提现模式：巴西-pix，墨西哥：bank,clabe
        /// </summary>
        public string mode { get; set; } //"pix",

        public string cpf { get; set; } //

        /// <summary>
        /// 
        /// </summary>
        public string taxId { get; set; }

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action =>  BankAction.LetsCash;

        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(LetsProxyPayDto);
    }

    public class LetsProxyPayDto : PayDtoBase
    {

    }
}
