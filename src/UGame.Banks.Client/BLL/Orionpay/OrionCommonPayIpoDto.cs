using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Orionpay
{
    internal class OrionCommonPayIpo : BaseIpo
    {
        /// <summary>
        /// CPF or CNPJ
        /// </summary>
        [RequiredEx("", "type cannot be empty")]
        public string type { get; set; }

        [RequiredEx("", "number cannot be empty")]
        public string number { get; set; }

        public string zipCode { get; set; }

        public string phone { get; set; }

        public string name { get; set; }
        public string email { get; set; }

        public string ClientIp { get; set; }
    }

    public class OrionCommonPayDto:BaseDto
    {
        public string AuthorizationCode { get; set; }
        public string CreateAt { get; set; }
    }
}
