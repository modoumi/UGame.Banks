using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Services.Pay;
using Xxyy.Banks.DAL;
using static UGame.Banks.Hubtel.CallbackSvc.CashCallbackIpo;
using static UGame.Banks.Hubtel.CallbackSvc.PayCallbackIpo;

namespace UGame.Banks.Hubtel.CallbackSvc
{
    
    public class HubtelCallbackIpoBase<T> : CallbackIpoCommonBase where T : class, new()
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ResponseCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T Data { get; set; }


    }

    /// <summary>
    /// 支付回调
    /// </summary>
    public class PayCallbackIpo : HubtelCallbackIpoBase<PayCallbackIpo.ReceiveMoneyCallbackResponseData>
    {

        /// <summary>
        /// 
        /// </summary>
        public class ReceiveMoneyCallbackResponseData
        {

            /// <summary>
            /// 
            /// </summary>
            public decimal Amount { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public decimal Charges { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public decimal AmountAfterCharges { get; set; }

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
            public string TransactionId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string ExternalTransactionId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public decimal AmountCharged { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string OrderId { get; set; }
        }
    }

    /// <summary>
    /// 提现回调ipo
    /// </summary>
    public class CashCallbackIpo : HubtelCallbackIpoBase<CashCallbackIpo.SendMoneyCallbackResponseData>
    {
        public class SendMoneyCallbackResponseData
        {
            /// <summary>
            /// 
            /// </summary>
            public string TransactionId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string ExternalTransactionId { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string OrderId { get; set; }

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
            public decimal Amount { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public decimal AmountDebitted { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public decimal Charges { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string Meta { get; set; }

            /// <summary>
            /// 
            /// </summary>
            public string RecipientName { get; set; }
        }
    }

    public class BalanceTransferCallbackIpo
    {
        public string ClientReference { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal? Charges { get; set; }
        public string RecipientName { get; set; }
    }
}
