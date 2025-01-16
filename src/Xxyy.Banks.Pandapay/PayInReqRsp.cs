using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Pandapay
{
    public class PayInReq
    {
        public string reference { get; set; }
        public decimal amount { get; set; }
        public string name { get; set; }
        public string taxId { get; set; }

        /// <summary>
        /// INVOICE   BOLETO  BRCODE
        /// </summary>
        public string payInType { get; set; }
        public string streetLineOne { get; set; }
        public string streetLineTwo { get; set; }
        public string disctrict { get; set; }
        public string city { get; set; }
        public string stateCode { get; set; }
        public string zipCode { get; set; }
    }

    public class PayInRsp//:PandaPayRspBase<PayInRsp>
    {
        public string reference { get; set; }
        public string transactionId { get; set; }
        public string type { get; set; }
        public string transactionDescription { get; set; }
        public string amount { get; set; }
        public string barCodeFee { get; set; }
        public string fee { get; set; }
        public string barCode { get; set; }
        public string expirationTime { get; set; }
        public string barCodeStatus { get; set; }
        public string status { get; set; }
    }
}
