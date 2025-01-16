using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Orionpay
{
    internal class OrionProxyPayIpo : BaseIpo
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
    }

    public class OrionProxyPayDto:BaseDto
    {
        public string tradeId { get; set; }
        public string authorizationCode { get; set; }
        public string createdAt { get; set; }
    }
}
