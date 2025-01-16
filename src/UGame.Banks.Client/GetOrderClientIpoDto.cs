//using StackExchange.Redis;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.Serialization;
//using System.Text;
//using System.Threading.Tasks;

//namespace UGame.Banks.Client
//{

//    /// <summary>
//    /// 
//    /// </summary>
//    public class GetOrderClientIpo : BankIpoClientBase
//    {
//        ///// <summary>
//        ///// 
//        ///// </summary>
//        //public string AppId { get; set; }
//        /// <summary>
//        /// 订单编号
//        /// </summary>
//        public string OrderId { get; set; }

//        ///// <summary>
//        ///// 用户 编号
//        ///// </summary>
//        //public string UserId { get; set; }

//    }



//    /// <summary>
//    /// 
//    /// </summary>
//    public class GetOrderClientDto
//    {
//        /// <summary>
//        /// 订单编号
//        /// </summary>
//        public string OrderId { get; set; }

//        /// <summary>
//        /// 用户 编号
//        /// </summary>
//        public string UserId { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string AppId { get; set; }

//        /// <summary>
//		/// 应用提供商编码
//		/// 【字段 varchar(50)】
//		/// </summary>
//        public string ProviderId { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string OperatorId { get; set; }

//        /// <summary>
//        /// 我方承担的手续费
//        /// </summary>
//        public decimal OwnFee { get; set; }

//        /// <summary>
//        /// 用户承担的手续费
//        /// </summary>
//        public decimal UserFee { get; set; }

//        /// <summary>
//        /// 用户实际收到或者实际支付的金额
//        /// </summary>
//        public decimal UserMoney { get; set; }

//        /// <summary>
//        /// 下单时间
//        /// </summary>
//        public DateTime RecDate { get; set; }

//        /// <summary>
//        /// 订单状态
//        /// </summary>
//        public BankOrderStatusClientEnum OrderStatus { get; set; }

//        /// <summary>
//        /// 充值、返现
//        /// </summary>
//        public ClientOrderTypeEnum OrderType { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public ClientPayTypeEnum PaytypeID { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public int PaytypeChannel { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string ChannelName { get; set; }

//        /// <summary>
//        /// 货币编码
//        /// </summary>
//        public string CurrencyId { get; set; }
//        /// <summary>
//        /// 计划变化金额（正负数）
//        /// 【字段 bigint】
//        /// </summary>
//        public long PlanAmount { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public long Amount { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public string Status { get; set; }
//    }
//}
