using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Pandapay
{
    public class QueryDictKeyReq
    {
        public string key { get; set; }
    }

    public class QueryDictKeyRsp
    {
        public string id { get; set; }
        public string type { get; set; }
        public string accountCreated { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string taxId { get; set; }
        public string ownerType { get; set; }
        public string bankName { get; set; }
        public string ispb { get; set; }
        public string branchCode { get; set; }
        public string accountNumber { get; set; }
        public string status { get; set; }
        public string owned { get; set; }
        public string created { get; set; }
    }
}
