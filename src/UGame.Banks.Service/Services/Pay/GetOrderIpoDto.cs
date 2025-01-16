using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Extensions.AutoMapper;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Services.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class GetOrderIpo:BankIpoBase
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public string AppId { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderId { get; set; }

        ///// <summary>
        ///// 用户 编号
        ///// </summary>
        //public string UserId { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[JsonIgnore]
        //public override Type DtoType => typeof(GetOrderDto);
    }

    

    /// <summary>
    /// 
    /// </summary>
    public class GetOrderDto: GetOrderViewDto,IMapFrom<GetOrderViewDto>
    {
        ///// <summary>
        ///// 订单编号
        ///// </summary>
        //public string OrderId { get; set; }

        ///// <summary>
        ///// 用户 编号
        ///// </summary>
        //public string UserId { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string AppId { get; set; }

        ///// <summary>
        ///// 货币类型
        ///// </summary>
        //public string CurrencyID { get; set; }

        ///// <summary>
        ///// 实际到账金额
        ///// </summary>
        //public long Amount { get; set; }

        /// <summary>
        /// 订单状态
        /// </summary>
        public BankOrderStatusEnum OrderStatus { get; set; }

        /// <summary>
        /// 充值、返现
        /// </summary>
        public new OrderTypeEnum OrderType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public new PayTypeEnum PaytypeID { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public int PaytypeChannel { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string ChannelName { get; set; }



        ///// <summary>
        ///// 
        ///// </summary>
        //public long Amount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public new string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public void MapFrom(GetOrderViewDto source)
        {
            //this.OrderId = source.OrderID;
            //this.AppId = source.AppID;
            //this.UserId = source.UserID;
            this.OrderStatus = source.Status.ToEnum<BankOrderStatusEnum>();
            this.OrderType = source.OrderType.ToEnum<OrderTypeEnum>();
            this.PaytypeID = source.PaytypeID.ToEnum<PayTypeEnum>();
            this.ChannelName = source.ChannelName;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetOrderViewDto:Sb_bank_orderEO,IMapFrom<Sb_bank_orderEO>
    {

        /// <summary>
        /// 
        /// </summary>
        [Newtonsoft.Json.JsonProperty]
        public string ChannelName { get; set; }
   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public void MapFrom(Sb_bank_orderEO source)
        {
            this.ChannelName = BankUtil.GetChannelName(source.BankID,source.PaytypeID, source.PaytypeChannel);
        }
    }
}
