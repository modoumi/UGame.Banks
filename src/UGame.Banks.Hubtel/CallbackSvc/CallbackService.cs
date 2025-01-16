using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Common;
using UGame.Banks.Service;
using Xxyy.Common;
using UGame.Banks.Service.Services.Pay;
using Microsoft.AspNetCore.Http;
using Xxyy.DAL;
using TinyFx.Data;
using Microsoft.AspNetCore.Authorization.Policy;
using EasyNetQ.Events;
using Xxyy.Banks.DAL;
using TinyFx.Data.SqlSugar;
using TinyFx.Text;
using TinyFx.AspNet;

namespace UGame.Banks.Hubtel.CallbackSvc
{
    public class CallbackService : PayCallbackServiceBase2 //PayCallbackServiceBase<CallbackIpoCommonBase, string>
    {
        //private HttpRequest _request;
        //private static readonly S_userMO _userMo = new();
        private const string BANKID = "hubtel";
        protected override int MULTIPLE { set; get; } = 1;

        ///// <summary>
        ///// 
        ///// </summary>
        //public CallbackService()
        //{
        //    _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext!.Request;
        //}
        public override bool CheckPaySuccess(BankCallbackContext context) => ((PayCallbackIpo)context.Ipo).ResponseCode == "0000";

        public override bool CheckCashSuccess(BankCallbackContext context) => ((CashCallbackIpo)context.Ipo).ResponseCode == "0000";

        public override decimal GetPayFee(BankCallbackContext context)
        {
            var ipo = context.Ipo as PayCallbackIpo;
            return ipo.Data.Charges;
        }

        public override decimal GetCashFee(BankCallbackContext context)
        {
            var ipo = context.Ipo as CashCallbackIpo;
            return ipo.Data.Charges;
        }

        public override Task CheckIpo(BankCallbackContext context)
        {
            var (ipoAmount, platformOrderId) = context.Ipo switch
            {
                PayCallbackIpo payNotifyIpo => (payNotifyIpo.Data.Amount, payNotifyIpo.Data.TransactionId),
                CashCallbackIpo cashNotifyIpo => (cashNotifyIpo.Data.Amount, cashNotifyIpo.Data.TransactionId),
                _ => throw new Exception($"未知的Ipo参数！ipo:{SerializerUtil.SerializeJsonNet(context.Ipo)}")
            };
            if (context.OrderEo.OrderMoney != ipoAmount)
                throw new Exception($"支付金额amount:{ipoAmount}与订单金额ordermoney:{context.OrderEo.OrderMoney}不一致！orderid:{context.OrderEo.OrderID}");
            if (context.OrderEo.BankOrderId != platformOrderId)
                throw new Exception($"合作方订单号不一致！BankOrderId:{context.OrderEo.BankOrderId},平台订单号:{platformOrderId}");
            return Task.CompletedTask;
        }

        /// <summary>
        /// hubtel支付回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public virtual async Task<bool> PayCallback(BankCallbackContext context)
        {
            var result = await Execute(context);
            return result;
        }

        /// <summary>
        /// hubtel提现回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public virtual async Task<bool> CashCallback(BankCallbackContext context)
        {
            var result = await Execute(context);
            return result;
        }

        /// <summary>
        /// 内部转账回调
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task TransferOrder(HubtelCallbackIpoBase<BalanceTransferCallbackIpo> ipo)
        {
            var logPo = new Sb_hubtel_transferorder_logPO
            {
                TransferLogId = ObjectId.NewId(),
                OrderId = ipo.Data.ClientReference,
                RequestBody= SerializerUtil.SerializeJsonNet(ipo),
                RequestTime = DateTime.UtcNow,
                Status=1,
                TransType=1,
                TransMark=HttpContextEx.Request?.Path.Value
                //CallbackContent = SerializerUtil.SerializeJsonNet(ipo),
                //CallbackTime = DateTime.UtcNow,
            };
            var rows = await DbUtil.InsertAsync(logPo);
            //var orderPo = await DbUtil.GetRepository<Sb_hubtel_transferorderPO>().GetFirstAsync(x=>x.OrderId== ipo.Data.ClientReference);
            var tm = new DbTransactionManager();
            try
            {
                await tm.BeginAsync();
                if (ipo.ResponseCode == "0000")
                {   //成功
                    await tm.GetRepository<Sb_hubtel_transferorderPO>().UpdateSetColumnsTrueAsync(x => new Sb_hubtel_transferorderPO
                    {
                        Amount = ipo.Data.Amount,
                        Status = (int)TransferOrderStatuEnum.CallbackSuccess,
                        RecipientName = ipo.Data.RecipientName
                    }, x => x.OrderId == ipo.Data.ClientReference && x.Status != 3);
                }
                else
                {
                    await tm.GetRepository<Sb_hubtel_transferorderPO>().UpdateSetColumnsTrueAsync(x => new Sb_hubtel_transferorderPO
                    {
                        Amount = ipo.Data.Amount,
                        Status = (int)TransferOrderStatuEnum.CallbackFailed,
                        RecipientName = ipo.Data.RecipientName
                    }, x => x.OrderId == ipo.Data.ClientReference && x.Status != 4);
                }
                await tm.GetRepository<Sb_hubtel_transferorder_logPO>().UpdateSetColumnsTrueAsync(x=>new Sb_hubtel_transferorder_logPO { 
                   ResponseTime=DateTime.UtcNow
                },x=>x.TransferLogId==logPo.TransferLogId);
                await tm.CommitAsync();
            }
            catch (Exception ex)
            {
                await tm.RollbackAsync();
                var updateLogPo = new Sb_hubtel_transferorder_logPO
                {
                    Status = 2,
                    ResponseTime = DateTime.UtcNow,
                    Exception = SerializerUtil.SerializeJsonNet(ex)
                };
                await DbUtil.GetRepository<Sb_hubtel_transferorder_logPO>().UpdateSetColumnsTrueAsync(it=>updateLogPo,it=>it.TransferLogId== logPo.TransferLogId);
            }
        }
    }
}
