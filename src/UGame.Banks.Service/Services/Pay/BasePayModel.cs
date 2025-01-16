using System.Text.Json.Serialization;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Query;
using UGame.Banks.Repository;
using Xxyy.Common;
using Xxyy.DAL;

namespace UGame.Banks.Service.Services.Pay
{

    /// <summary>
    /// 
    /// </summary>
    public abstract class PayIpoBase:BankIpoBase
    {
        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// vip提现时扣除的手续费
        /// </summary>
        public long UserFeeAmount => (long)(this.Amount * this.CashRate);


        /// <summary>
        /// vip提现时扣除的手续费费率
        /// </summary>
        public decimal CashRate { get; set; }

        ///// <summary>
        ///// 运营商编码
        ///// </summary>
        //public string OperatorId { get; set; }

     


        /// <summary>
        /// app订单编码
        /// </summary>
        public string AppOrderId { get; set; }


        /// <summary>
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }

       



        #region Exts
        

        //[JsonIgnore]
        //[Newtonsoft.Json.JsonIgnore]
        //public abstract BankAction Action { get; }

        /// <summary>
        /// 订单编号
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string OrderId { get; set; }

        /// <summary>
        /// 我方传给银行的订单号（transaction_id）对账使用!
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public string OwnOrderId { get; set; }

       

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public S_userEO User { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Sb_bank_orderEO Order { get; set; }

        //[JsonIgnore]
        //public Sb_order_trans_logEO BankTransLog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public Sb_order_trans_logEO AppTransLog { get; set; }

       

        #endregion
    }

    /// <summary>
    ///支付返回数据类型基类
    /// </summary>
    public class PayDtoBase
    {
        /// <summary>
        /// 
        /// </summary>
        public string RequestUUID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>

        public string CurrencyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsFirstCashOfDay { get; set; }

        /// <summary>
        /// 扩展书
        /// </summary>
        public object Meta { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public bool OperatorSuccess { get; set; }



        /// <summary>
        /// 对方银行返回的订单编码
        /// </summary>
        [JsonIgnore]
        public string BankOrderId { get; set; }

        /// <summary>
        /// 当日是否有充值行为
        /// </summary>
        [JsonIgnore]
        public bool HasCash { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long EndBalance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public long EndBonus { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public string TransMark { get; set; }

        /// <summary>
        /// 传给银行的交易金额
        /// </summary>
        [JsonIgnore,Newtonsoft.Json.JsonIgnore]
        public decimal TransMoney { get; set; }

        /// <summary>
        /// 传给银行的交易金额
        /// </summary>
        [JsonIgnore,Newtonsoft.Json.JsonIgnore]
        public decimal OrderMoney { get; set; }

        /// <summary>
        /// 交易手续费
        /// </summary>
        [JsonIgnore, Newtonsoft.Json.JsonIgnore]
        public decimal Fee { get; set; }
    }
}
