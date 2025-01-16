using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Req
{
    public class PayOutRequest
    {
        /// <summary>
        /// api
        /// </summary>
        public string type { get; set; }
        public string mchId { get; set; }
        public string mchTransNo { get; set; }
        public string amount { get; set; }
        public string notifyUrl { get; set; }
        public string accountName { get; set; }
        public string accountNo { get; set; }
        /// <summary>
        /// cpf|cnpj|email|phone|evp
        /// </summary>
        public string bankCode { get; set; }

        public string remarkInfo { get; set; }
        public string sign { get; set; }
    }

    public class RemarkInfo
    {
        public string email { get; set; }
        public string phone { get; set; }
        public string mode { get; set; }
        public string cpf { get; set; }

        public override string ToString()
        {
            return $"email:{email}/phone:{phone}/mode:{mode}/cpf:{cpf}";
        }
    }
}
