using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Data.SqlSugar;
using TinyFx.Logging;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Services;
using UGame.Banks.Service.Services.SyncOrders;
using Xxyy.Banks.DAL;
using UGame.Banks.Hubtel.Proxy;
using Xxyy.DAL;

namespace UGame.Banks.Hubtel.PaySvc
{
    public class VerifyOrderService : VerifyOrderBase, IVerifyOrder
    {
        private const int PAGESIZE = 500;
        private const double ORDER_EXPIRED_TIMEOUT_FAIL = 30d;
        private const string BANKID = "hubtel";
        private readonly Sb_bank_orderMO _bankOrderMo = new();

        public async Task VerifyOrder(VerifyOrderIpo ipo)
        {
            if (ipo.VerifyTime == DateTime.MinValue)
                ipo.VerifyTime = DateTime.UtcNow;
            var pageSize = ConfigUtil.AppSettings.GetOrDefault<int>("VerifyOrderPageSize", PAGESIZE);
            var orderExpiredTime = ipo.VerifyTime.AddMinutes(-ORDER_EXPIRED_TIMEOUT_FAIL);
            var pageCount = await _bankOrderMo.GetPageCountAsync(pageSize, $" BankID=@BankID and SettlStatus=@SettlStatus and status=@status and RecDate<@now", "orderid", values: new object[] { BANKID, (int)SettlStatusEnum.Init, (int)BankOrderStatusEnum.Processing, orderExpiredTime });
            if (pageCount == 0)
                return;

            //IVerifyOrder verifyOrderSvc = DIUtil.GetService<Func<string, IVerifyOrder>>()("hubtel");
            for (var page = 1; page <= pageCount; page++)
            {
                var bankOrders = await _bankOrderMo.GetPagerListAsync(PAGESIZE, page, "BankID=@BankID and SettlStatus=@SettlStatus and status=@status and RecDate<@now", "orderid", values: new object[] { BANKID, (int)SettlStatusEnum.Init, (int)BankOrderStatusEnum.Processing, orderExpiredTime });
                if (null == bankOrders || !bankOrders.Any())
                    continue;
                foreach (var orderEo in bankOrders)
                {
                    try
                    {
                        await ProcessOrder(orderEo);
                    }
                    catch (Exception ex)
                    {
                        LogUtil.Error(ex, $"验证订单过程异常！orderid:{orderEo.OrderID}");
                    }
                }
            }
        }

        private async Task ProcessOrder(Sb_bank_orderEO orderEo)
        {
            switch (orderEo.OrderType)
            {
                case (int)OrderTypeEnum.Charge:
                    await ProcessPay(orderEo);
                    break;
                case (int)OrderTypeEnum.Draw:
                    await ProcessDraw(orderEo);
                    break;
                default:
                    throw new ArgumentException($"orderid:{orderEo.OrderID}订单未知的{nameof(orderEo.OrderType)}:{orderEo.OrderType}属性!");
            }
        }

        private async Task ProcessPay(Sb_bank_orderEO orderEo)
        {
            var proxy = DIUtil.GetService<BankProxy>();
            var payQueryResult = await proxy.ReceiveMoneyStatusCheck(orderEo.OrderID);
            if (payQueryResult?.Data == null)
            {
                LogUtil.Error("验证hubtel代收订单查询失败！orderid:{0},对方返回值：{1}", orderEo.OrderID, SerializerUtil.SerializeJsonNet(payQueryResult));
                return;
            }
            if (payQueryResult?.Data.Amount != orderEo.OrderMoney)
                throw new Exception($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.ordermoney:{orderEo.OrderMoney},hubtel.amount:{payQueryResult?.Data.Amount}");
            
            orderEo.OwnFee = payQueryResult.Data.Charges;
            orderEo.BankCallbackTime = DateTime.UtcNow;
            orderEo.BankTime = payQueryResult.Data.Date;
            orderEo.CompleteFlag = 1;
            switch (payQueryResult.Data.Status)
            {
                case "Paid":
                    //代收成功
                    await this.PaySuccess(orderEo, payQueryResult);
                    break;
                case "Unpaid":
                    //可能支付中，也可能失败，超过30分钟，认为失败
                    if(DateTime.UtcNow.Subtract(payQueryResult.Data.Date).TotalMinutes>=ORDER_EXPIRED_TIMEOUT_FAIL)
                    {
                        await this.PayFail(orderEo,payQueryResult);
                    }
                    break;
                default:
                    break;
            }
        }

        private async Task ProcessDraw(Sb_bank_orderEO orderEo)
        {
            var proxy = DIUtil.GetService<BankProxy>();
            var cashQueryResult = await proxy.SendMoneyStatusCheck(orderEo.OrderID);
            if (cashQueryResult?.Data == null)
            {
                LogUtil.Error("验证hubtel代付订单查询失败！orderid:{0},对方返回值：{1}", orderEo.OrderID, SerializerUtil.SerializeJsonNet(cashQueryResult));
                return;
            }
            if (cashQueryResult?.Data?.Amount != orderEo.OrderMoney)
                throw new Exception($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.ordermoney:{orderEo.OrderMoney},hubtel.amount:{cashQueryResult?.Data?.Amount}");
            if (orderEo.UserFeeAmount > 0)
            {
                orderEo.OwnFee = cashQueryResult.Data.Fees;
            }
            else
            {
                orderEo.UserFee = cashQueryResult.Data.Fees;
            }
            orderEo.BankCallbackTime =DateTime.UtcNow ;
            orderEo.BankTime = cashQueryResult.Data.CreatedAt;
            orderEo.CompleteFlag = 1;
            switch (cashQueryResult.Data.TransactionStatus)
            {
                case "success":
                    //代付成功
                    await CashSuccess(orderEo, cashQueryResult);
                    break;
                case "failed":
                    await CashFail(orderEo,cashQueryResult);
                    break;
                default:
                    LogUtil.Error("验证代付订单查询失败！orderid:{0},对方返回值：{1}", orderEo.OrderID, SerializerUtil.SerializeJsonNet(cashQueryResult));
                    break;
            }
        }
    }
}
