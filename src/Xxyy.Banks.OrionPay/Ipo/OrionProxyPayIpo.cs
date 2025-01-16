using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using Xxyy.Banks.BLL.Common;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.Orionpay.Model;

namespace Xxyy.Banks.Orionpay.Dto
{
    public class OrionProxyPayIpo : PayIpoBase
    {
     
       
        public string cashAuditId { get; set; }
       
        /// <summary>
        /// 默认 CPF, CNPJ, PHONE, EMAIL, EVP
        /// </summary>
        public string certType { get; set; }

        /// <summary>
        /// CPF CNPJ PHONE, EMAIL, EVP
        /// </summary>
        public string certValue { get; set; }


        /// <summary>
        /// CPF, CNPJ
        /// </summary>
        public string identifyType { get; set; }
     
        /// <summary>
        /// 
        /// </summary>
        public string identifyValue { get; set; }


        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string zipCode { get; set; }


        public override BankAction Action => BankAction.OrionCash;

        public override Type DtoType => typeof(OrionProxyPayDto);
    }


    public class OrionProxyPayDto : PayDtoBase
    {
        public string tradeId { get; set; }
        public string authorizationCode { get; set;}
        public string createdAt { get; set;}
    }
}
