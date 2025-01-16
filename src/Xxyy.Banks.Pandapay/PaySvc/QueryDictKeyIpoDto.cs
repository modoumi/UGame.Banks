using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Pandapay.PaySvc
{
    public class QueryDictKeyIpo : BankIpoBase
    {
        public string QueryKey { get; set; }
        public override Type DtoType => typeof(QueryDictKeyDto);
    }

    public class QueryDictKeyItemModel
    {
        /// <summary>
        /// 开户类型
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 开户时间
        /// </summary>
        public string accountCreated { get; set; }
        public string accountType { get; set; }
        public string name { get; set; }
        public string taxId { get; set; }
        public string ownerType { get; set; }
        public string bankName { get; set; }
        public string bankCode { get; set; }
        public string branchCode { get; set; }
        public string accountNumber { get; set; }
        public string status { get; set; }
        public string owned { get; set; }
        public string created { get; set; }
    }

    public class QueryDictKeyDto
    {

        public QueryDictKeyItemModel Data { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
