using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Common;

namespace Xxyy.Banks.Orionpay.Dto
{
    public class OrionCommonPayIpo : PayIpoBase
    {
        //public int BizEnum { get; set; } = 1;
        /// <summary>
        /// CPF or CNPJ
        /// </summary>
        [RequiredEx("","type cannot be empty")]
        public string type { get; set; }

        [RequiredEx("", "number cannot be empty")]
        public string number { get; set; }

        //[RequiredEx("", "zipCode cannot be empty")]
        public string zipCode { get; set; }

        //[RequiredEx("", "phone cannot be empty")]
        public string phone { get; set; }

        public string name { get; set; }
        public string email { get; set; }

        public string ClientIp { get; set; }

        public override BankAction Action => BankAction.OrionPay;

        public override Type DtoType => typeof(OrionCommonPayDto);
    }


    public class OrionCommonPayDto : PayDtoBase
    {
      
        public string AuthorizationCode { get; set; }
        public string CreateAt { get; set; }
    }
}
