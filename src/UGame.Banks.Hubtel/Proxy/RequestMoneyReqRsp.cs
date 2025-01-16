using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Hubtel
{


    /// <summary>
    /// 充值请求类
    /// </summary>
    public class RequestMoneyReq: HubtelRequestIpoBase
    {
        public string CustomerName { get; set; }
        public string CustomerMsisdn { get; set; }
    }

    /// <summary>
    /// 充值返回类
    /// </summary>
    public class RequestMoneyRsp: HubtelRspDtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal AmountAfterCharges { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal AmountCharged { get; set; }
        
    }

    /// <summary>
    /// 充值提现返回值模型的基类
    /// </summary>
    public class HubtelRspDtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string TransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ClientReference { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExternalTransactionId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Charges { get; set; }
    }
    

    /// <summary>
    /// hubtel统一返回值基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HubtelRspDtoBase<T> {

        /// <summary>
        /// 
        /// </summary>
        public string ResponseCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }
    }
}
