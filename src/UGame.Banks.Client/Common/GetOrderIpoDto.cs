using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL
{
    internal class GetOrderIpo:BaseIpo
    {
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }
    }

    public class GetOrderDto:BaseDto
    {
        ///// <summary>
        ///// 订单编码GUID
        ///// 【主键 varchar(38)】
        ///// </summary>
        //public string OrderID { get; set; }
        /// <summary>
        /// 应用提供商编码
        /// 【字段 varchar(50)】
        /// </summary>
        public string ProviderID { get; set; }
        /// <summary>
        /// 应用编码
        /// 【字段 varchar(50)】
        /// </summary>
        public string AppID { get; set; }
        /// <summary>
        /// 运营商编码
        /// 【字段 varchar(50)】
        /// </summary>
        public string OperatorID { get; set; }
        ///// <summary>
        ///// 用户编码(GUID)
        ///// 【字段 varchar(38)】
        ///// </summary>
        //public string UserID { get; set; }
        /// <summary>
        /// 新用户来源方式
        ///              0-获得运营商的新用户(s_operator)
        ///              1-推广员获得的新用户（userid）
        ///              2-推广渠道通过url获得的新用户（s_channel_url)
        ///              3-推广渠道通过code获得的新用户（s_channel_code)
        /// 【字段 int】
        /// </summary>
        public int FromMode { get; set; }
        /// <summary>
        /// 对应的编码（根据FromMode变化）
        ///              FromMode=
        ///              0-运营商的新用户(s_operator)==> OperatorID
        ///              1-推广员获得的新用户（userid） ==> 邀请人的UserID
        ///              2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
        ///              3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
        /// 【字段 varchar(100)】
        /// </summary>
        public string FromId { get; set; }
        /// <summary>
        /// 
        /// 【字段 int】
        /// </summary>
        public int UserKind { get; set; }

        /// <summary>
        /// 银行编码
        /// 【字段 varchar(50)】
        /// </summary>
        public string BankID { get; set; }

        /// <summary>
        /// 支付方式下的渠道
        /// 【字段 int】
        /// </summary>
        public int PaytypeChannel { get; set; }

        ///// <summary>
        ///// 货币类型（货币缩写USD）
        ///// 【字段 varchar(5)】
        ///// </summary>
        //public string CurrencyID { get; set; }
        /// <summary>
        /// 记录时间
        /// 【字段 datetime】
        /// </summary>
        public DateTime RecDate { get; set; }
        /// <summary>
        /// 计划变化金额（正负数）
        /// 【字段 bigint】
        /// </summary>
        public long PlanAmount { get; set; }
        /// <summary>
        /// 请求唯一号
        /// 【字段 varchar(38)】
        /// </summary>
        public string AppRequestUUID { get; set; }
        /// <summary>
        /// app订单编码
        /// 【字段 varchar(38)】
        /// </summary>
        public string AppOrderId { get; set; }
        /// <summary>
        /// 请求备注
        /// 【字段 varchar(255)】
        /// </summary>
        public string AppReqComment { get; set; }
        /// <summary>
        /// 请求时间
        /// 【字段 datetime】
        /// </summary>
        public DateTime AppRequestTime { get; set; }
        /// <summary>
        /// 账户名称
        /// 【字段 varchar(50)】
        /// </summary>
        public string AccName { get; set; }
        /// <summary>
        /// 账户卡号
        /// 【字段 varchar(50)】
        /// </summary>
        public string AccNumber { get; set; }
        /// <summary>
        /// 银行编码
        /// 【字段 varchar(20)】
        /// </summary>
        public string BankCode { get; set; }
        
        /// <summary>
        /// 充值用户ip
        /// 【字段 varchar(50)】
        /// </summary>
        public string UserIP { get; set; }
        /// <summary>
        /// 我方传给银行的订单号（transaction_id）对账使用!
        /// 【字段 varchar(50)】
        /// </summary>
        public string OwnOrderId { get; set; }
        /// <summary>
        /// 传给银行的交易金额
        /// 【字段 decimal(15,6)】
        /// </summary>
        public decimal TransMoney { get; set; }
        /// <summary>
        /// 银行返回时间
        /// 【字段 datetime】
        /// </summary>
        public DateTime? BankResponseTime { get; set; }
        /// <summary>
        /// 银行订单编码
        /// 【字段 varchar(50)】
        /// </summary>
        [DataMember(Order = 30)]
        public string BankOrderId { get; set; }
        /// <summary>
        /// 银行回调时间
        /// 【字段 datetime】
        /// </summary>
        public DateTime? BankCallbackTime { get; set; }
        /// <summary>
        /// 银行订单的成功时间（对账使用）
        /// 【字段 datetime】
        /// </summary>
        public DateTime? BankTime { get; set; }
        /// <summary>
        /// 支付条形码
        /// 【字段 varchar(500)】
        /// </summary>
        public string BrCode { get; set; }
        /// <summary>
        /// 支付二维码
        /// 【字段 varchar(2000)】
        /// </summary>
        public string QrCode { get; set; }
        /// <summary>
        /// 我方承担的手续费
        /// 【字段 decimal(10,3)】
        /// </summary>
        public decimal OwnFee { get; set; }
        /// <summary>
        /// 用户承担的手续费
        /// 【字段 decimal(10,3)】
        /// </summary>
        public decimal UserFee { get; set; }
        /// <summary>
        /// 支付金额（提款金额）
        /// 【字段 decimal(10,2)】
        /// </summary>
        public decimal UserMoney { get; set; }
        /// <summary>
        /// 处理后余额
        /// 【字段 bigint】
        /// </summary>
        public long EndBalance { get; set; }
        /// <summary>
        /// bonus实际变化数量（正负数）
        /// 【字段 bigint】
        /// </summary>
        public long AmountBonus { get; set; }
        /// <summary>
        /// 处理后bonus余额
        /// 【字段 bigint】
        /// </summary>
        public long EndBonus { get; set; }

        /// <summary>
        /// channelname---sb_bank_paytype_channel.channelname
        /// </summary>
        public string ChannelName { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public BankOrderStatusEnum OrderStatus { get; set; }

        /// <summary>
        /// 充值、返现
        /// </summary>
        public OrderTypeEnum OrderType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PayTypeEnum PaytypeID { get; set; }


    }
}
