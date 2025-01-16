using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Pandapay.CallbackSvc
{
    public class PayCallbackIpo: CallbackIpoCommonBase
    {
        public string amount { get; set; }
        public string type { get; set; }
        public string barCode { get; set; }
        public string expirationTime { get; set; }
        public string repayTime { get; set; }
        public decimal fee { get; set; }
        public string reference { get; set; }
        public string createCodeReference { get; set; }
        public string barCodeStatus { get; set; }
        public string status { get; set; }
        public string transactionId { get; set; }
        public string transactionDescription { get; set; }
    }
}
