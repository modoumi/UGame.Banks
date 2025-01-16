using Grpc.Core;
using MySqlX.XDevAPI.Relational;
using Pipelines.Sockets.Unofficial.Buffers;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Data;
using TinyFx.Text;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Repository;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Banks.Service.Services
{
    /// <summary>
    /// 订单服务
    /// </summary>
    public class OrderService
    {
        private readonly Sb_bank_orderMO _bankOrderMo = new();
        private readonly Sb_order_trans_logMO _orderTransLogMo = new();
        //private readonly MessageService _messageService=new();
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<(long, long)> UpdateUserCash(string userId, long amount, TransactionManager tm)
        {
            //支付成功，更新用户账户余额
            var rows = await DbSink.BuildUserMo(userId).PutAsync("Cash=Cash+@Amount", "UserID=@UserID and 0<=Cash+@Amount2", tm, amount, userId, amount);
            if (rows <= 0)
                throw new Exception($"更新用户账户余额异常,userId:{userId},money:{amount}");
            var userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId, tm);
            if (null == userEo)
                throw new Exception($"用户不存在！userid:{userId}");
            return (userEo.Cash, userEo.Bonus);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="oldStatus"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public async Task<bool> UpdateOrderEo(Sb_bank_orderEO orderEo,int oldStatus,TransactionManager tm)
        {
            string sql = "Meta=@Meta,Status=@Status,OwnFee=@OwnFee,UserFee=@UserFee,UserMoney=@UserMoney,BankOrderId=@BankOrderId,EndBalance=@EndBalance,EndBonus=@EndBonus,BankCallbackTime=@BankCallbackTime,BankTime=@BankTime,CompleteFlag=@CompleteFlag,SettlStatus=@SettlStatus";
            var param = new List<object> {
                orderEo.Meta,orderEo.Status, orderEo.OwnFee,orderEo.UserFee,orderEo.UserMoney, orderEo.BankOrderId, orderEo.EndBalance,orderEo.EndBonus, orderEo.BankCallbackTime,orderEo.BankTime,orderEo.CompleteFlag,orderEo.SettlStatus, orderEo.OrderID, oldStatus
                };
            var rows = await _bankOrderMo.PutAsync(sql, "OrderID=@OrderID and Status=@OldStatus", tm, param.ToArray());
            //return rows > 0;
            if (rows == 0)
                throw new DuplicateUpdateOrderException($"更新订单状态失败!orderId:{orderEo.OrderID},oldstatus:{oldStatus},newstatus:{orderEo.Status}");
            return rows > 0;
        }

        /// <summary>
        /// 更新验证订单状态和订单时间
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="settlStatus"></param>
        /// <param name="oldSettlStatus"></param>
        /// <param name="resp"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public async Task<bool> UpdateSettlStatus(Sb_bank_orderEO orderEo, SettlStatusEnum settlStatus,int oldSettlStatus,object resp,TransactionManager tm)
        {
             var rows= await _bankOrderMo.PutAsync("SettlStatus=@SettlStatus", "orderid=@orderid and SettlStatus=@oldSettlStatus ",tm,(int)settlStatus,orderEo.OrderID,oldSettlStatus);
            if(rows>0)
                await AddBankTransLog(orderEo, $"订单{orderEo.OrderID}settlstatus从{orderEo.SettlStatus}更新为{settlStatus}", resp, tm);
            return rows > 0;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="resp"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdatePaySuccessOrder(Sb_bank_orderEO orderEo,object resp,TransactionManager tm)
        {
            ////0.获取更新前的cash
            //var userEo = await DbSink.BuildUserMo(orderEo.UserID).GetByPKAsync(orderEo.UserID, tm);
            //if (null == userEo)
            //    throw new Exception($"订单用户不存在！userId:{orderEo.UserID},orderid:{orderEo.OrderID}");
            //1.更新用户账户
            var (endBalance, endBonus) = await this.UpdateUserCash(orderEo.UserID, orderEo.Amount, tm);
            orderEo.EndBalance = endBalance;
            orderEo.EndBonus = endBonus;
            int oldStatus = orderEo.Status;
            orderEo.Status = (int)BankOrderStatusEnum.Success;
            //2.更新订单
            await this.UpdateOrderEo(orderEo,oldStatus, tm);
            //if (!result)
            //    return;

            //3.添加日志
            await this.AddBankTransLog(orderEo,$"代收成功,我方订单{orderEo.Status}更新我方订单",resp,tm);

            ////4.发送消息
            //await _messageService.SendUserPayMsg(orderEo, userEo.Cash, userEo.CountryID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="resp"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public async Task UpdateCashSuccess(Sb_bank_orderEO orderEo,object resp,TransactionManager tm)
        {
            int oldStatus = orderEo.Status;
            orderEo.Status = (int)BankOrderStatusEnum.Success;
            //1更新订单
            await this.UpdateOrderEo(orderEo,oldStatus,tm);
            //if (!result)
            //    return;
            //2.添加日志
            await this.AddBankTransLog(orderEo,$"代付成功,订单状态从{orderEo.Status}更新为{BankOrderStatusEnum.Success}",resp, tm);
            //3.更新缓存
            var orderPayCache = new OrderPayDCache(orderEo.OrderID);
            await BankUtil.SetOrderCacheAsync(orderPayCache, orderEo.Amount, orderEo, (int)BankOrderStatusEnum.Success);
            ////4.发送消息
            //await _messageService.SendUserCashMsg(orderEo);
        }


        public async Task UpdateCashFail(Sb_bank_orderEO orderEo,object resp,TransactionManager tm)
        {
            ////账户余额还原
            //var (endBalance, endBonus) = await UpdateUserCash(orderEo.UserID, Math.Abs(Math.Abs(orderEo.Amount)), tm);
            //orderEo.EndBalance=endBalance;
            //orderEo.EndBonus=endBonus;
            var oldStatus = orderEo.Status;
            orderEo.Status = (int)BankOrderStatusEnum.Fail;
            //更新order
            await UpdateOrderEo(orderEo,oldStatus,tm);
            //if (!result)
            //    return;
            //添加日志
            await AddBankTransLog(orderEo,$"代付失败,我方订单：{orderEo.Status}更新订单为失败",resp, tm);
            var orderPayCache = new OrderPayDCache(orderEo.OrderID);
            await BankUtil.SetOrderCacheAsync(orderPayCache, orderEo.Amount, orderEo, (int)BankOrderStatusEnum.Fail);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="transmark"></param>
        /// <param name="resp"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public async Task AddBankTransLog(Sb_bank_orderEO orderEo,string transmark,object resp,TransactionManager tm)
        {
            var utcNow = DateTime.UtcNow;
            var bankTransLogEo = new Sb_order_trans_logEO
            {
                TransLogID = ObjectId.NewId(),
                OrderID = orderEo.OrderID,
                BankID = orderEo.BankID,
                TransType = 0,
                TransMark = transmark,
                RequestBody = "",
                RequestTime = utcNow,
                Status =1 ,
                ResponseTime = utcNow,
                ResponseBody = SerializerUtil.SerializeJsonNet(resp),
                Exception = ""
            };
            var rows= await _orderTransLogMo.AddAsync(bankTransLogEo, tm);
            if (rows == 0)
                throw new Exception($"添加订单日志失败！orderid:{orderEo.OrderID}");
        }
    }
}
