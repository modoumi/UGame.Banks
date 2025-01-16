using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.Orionpay.Req;

namespace Xxyy.Banks.Orionpay.Resp
{
    public class OrionPayAsyncResponse : CallbackIpoCommonBase
    {
        public string id { get; set; }
        public string applicationId { get; set; }

        public string authorizationCode { get; set; }

        public string marketplaceId { get; set; }
        public string holderName { get; set; }
        /// <summary>
        /// CREDIT or DEBIT
        /// </summary>
        public string operationType { get; set; }
        /// <summary>
        /// DEPOSIT or WITHDRAW
        /// </summary>
        public string transactionMode { get; set; }
        /// <summary>
        /// PIX
        /// </summary>
        public string transactionType { get; set; }
   
        public string description { get; set; }
       
        /// <summary>
        /// 分单位
        /// </summary>
        public long amount { get; set; }
        public int grossAmount { get; set; }
        /// <summary>
        /// 分单位，交易费
        /// </summary>
        public decimal fee { get; set; }

        public string currency { get; set; }
        /// <summary>
        /// NEW, CREATED, PROCESSING, WAITING PAYMENT, COMPLETED, FAILED, CANCELED
        /// </summary>
        public string status { get; set; }

        public DetailedInfo detailedInfo { get; set; }
        //public string metadata { get; set; }
        public string end2end { get; set; }

        public List<Subscriptions> subscriptions { get; set; }
        
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
    public class DetailedInfo
    {
        public string brcode { get; set; }
        public string qrcode { get; set; }
    }
}
