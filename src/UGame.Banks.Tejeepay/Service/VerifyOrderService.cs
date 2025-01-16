using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;
using TinyFx;
using TinyFx.Data;
using TinyFx.Logging;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Services.SyncOrders;
using Xxyy.Banks.DAL;
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Ipo;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace UGame.Banks.Tejeepay.Service
{
    public class VerifyOrderService : VerifyOrderBase, IVerifyOrder
    {
        private const decimal MEXFEE = 3m;


        /// <summary>
        /// 计算充值手续费
        /// </summary>
        /// <param name="orderEo"></param>
        /// <returns></returns>
        private decimal CalcPayFee(Sb_bank_orderEO orderEo)
        {
            var bankEo = DbBankCacheUtil.GetBank(orderEo.BankID);
            var payFee = orderEo.OrderMoney * bankEo.PayFee;
            var operatorEo = DbCacheUtil.GetOperator(orderEo.OperatorID);
            if (operatorEo.CountryID == "MEX")
            {
                bankEo = DbBankCacheUtil.GetBank("tejeepay_mex");
                payFee = orderEo.OrderMoney * bankEo.PayFee;
                return payFee < MEXFEE ? MEXFEE : payFee;
            }
            return payFee;
        }

        /// <summary>
        /// 计算提现手续费
        /// </summary>
        /// <param name="orderEo"></param>
        /// <returns></returns>
        private decimal CalcCashFee(Sb_bank_orderEO orderEo)
        {
            var bankEo = DbBankCacheUtil.GetBank(orderEo.BankID);
            var cashFee = orderEo.OrderMoney * bankEo.CashFee;
            var operatorEo = DbCacheUtil.GetOperator(orderEo.OperatorID);
            if (operatorEo.CountryID == "MEX")
            {
                bankEo = DbBankCacheUtil.GetBank("tejeepay_mex");
                cashFee = orderEo.OrderMoney * bankEo.CashFee;
                return cashFee < MEXFEE ? MEXFEE : cashFee;
            }
            return cashFee;
        }


        /// <summary>
        /// 验证订单
        /// </summary>
        /// <param name="orderEo"></param>
        /// <returns></returns>
        public async Task VerifyOrder(VerifyOrderIpo ipo)
        {
            //var proxy = DIUtil.GetService<BankProxy>();
            //switch (orderEo.OrderType)
            //{
            //    case (int)OrderTypeEnum.Charge:
            //        var resp = await proxy.PayQuery(new TejeePayQueryIpo
            //        {
            //            BankId = orderEo.BankID,
            //            CurrencyId = orderEo.CurrencyID,
            //            OrderId = orderEo.OrderID,
            //            OrderEo = orderEo
            //        });
            //        if (!resp.Success || null == resp.SuccessResult?.body || resp.SuccessResult?.head?.respCode != "0000")
            //        {
            //            LogUtil.GetContextLogger()
            //                .AddField("banks.orderid", orderEo.OrderID)
            //                .AddField("banks.userid", orderEo.UserID)
            //                .AddField("banks.bankid", orderEo.BankID)
            //                .AddField("banks.tejeepay.payqueryrsp", resp.ResultString)
            //                .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning).AddMessage($"验证tejeepay代收订单失败！orderid:{orderEo.OrderID}").Save();
            //            return;
            //        }
            //        var payQueryResult = resp.SuccessResult;
            //        if (payQueryResult.body.amount.To<int>() != (int)orderEo.TransMoney)
            //        {
            //            LogUtil.GetContextLogger()
            //                .AddField("banks.orderid", orderEo.OrderID)
            //                .AddField("banks.userid", orderEo.UserID)
            //                .AddField("banks.bankid", orderEo.BankID)
            //                .AddField("banks.tejeepay.payqueryrsp", resp.ResultString)
            //                .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning).AddMessage($"orderid:{orderEo.OrderID}交易金额不一致！orderamount:{orderEo.TransMoney},tejeepay.amount:{payQueryResult.body.amount}").Save();
            //        }

            //        orderEo.OwnFee = CalcPayFee(orderEo);
            //        orderEo.BankTime = string.IsNullOrWhiteSpace(payQueryResult.body.chargeTime) ? DateTime.UtcNow : payQueryResult.body.chargeTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(orderEo.OperatorID);
            //        orderEo.BankCallbackTime = DateTime.UtcNow;
            //        orderEo.CompleteFlag = 1;
            //        if (payQueryResult.body.status == "SUCCESS")
            //        {   //代收成功
            //            await this.PaySuccess(orderEo, payQueryResult);
            //        }
            //        else if (payQueryResult.body.status == "FAILURE")
            //        {
            //            //代收失败
            //            await this.PayFail(orderEo, payQueryResult);
            //        }
            //        else if (payQueryResult.body.status == "UNKNOW")
            //        {
            //            return;
            //        }
            //        else
            //        {
            //            LogUtil.GetContextLogger()
            //                .AddField("banks.orderid", orderEo.OrderID)
            //                .AddField("banks.userid", orderEo.UserID)
            //                .AddField("banks.bankid", orderEo.BankID)
            //                .AddField("banks.tejeepay.payqueryrsp", resp.ResultString)
            //                .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning)
            //                .AddMessage($"tejeepay返回未知订单状态！orderid:{orderEo.OrderID},我方订单状态status：{orderEo.Status}").Save();
            //        }
            //        break;
            //    case (int)OrderTypeEnum.Draw:
            //        var cashQueryResult = await proxy.ProxyQuery(new TejeeProxyQueryIpo
            //        {
            //            BankId = orderEo.BankID,
            //            CurrencyId = orderEo.CurrencyID,
            //            OrderId = orderEo.OrderID,
            //            OrderEo = orderEo
            //        });
            //        var detail = cashQueryResult.detail?.FirstOrDefault();
            //        if (null == detail)
            //            return;

            //        if (detail.amount.To<int>() != (int)orderEo.TransMoney)
            //        {
            //            LogUtil.GetContextLogger()
            //                .AddField("banks.orderid", orderEo.OrderID)
            //                .AddField("banks.userid", orderEo.UserID)
            //                .AddField("banks.bankid", orderEo.BankID)
            //                .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning).AddMessage($"orderid:{orderEo.OrderID}交易金额不一致！orderamount:{orderEo.TransMoney},tejeepay.amount:{detail.amount}").Save();
            //            return;
            //        }
            //        orderEo.OwnFee = CalcCashFee(orderEo);
            //        var bankTime = detail.finishTime;
            //        orderEo.BankTime = string.IsNullOrWhiteSpace(bankTime) ? DateTime.UtcNow : bankTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(orderEo.OperatorID);
            //        orderEo.BankCallbackTime = DateTime.UtcNow;
            //        orderEo.CompleteFlag = 1;
            //        if (detail.status == "SUCCESS")
            //        {
            //            //代付成功
            //            await CashSuccess(orderEo, cashQueryResult);
            //        }
            //        else if (detail.status == "FAIL")
            //        {
            //            //代付失败
            //            await CashFail(orderEo, cashQueryResult);
            //        }
            //        break;
            //    default:
            //        LogUtil.GetContextLogger()
            //               .AddField("banks.orderid", orderEo.OrderID)
            //               .AddField("banks.userid", orderEo.UserID)
            //               .AddField("banks.bankid", orderEo.BankID)
            //               .SetLevel(Microsoft.Extensions.Logging.LogLevel.Information)
            //               .AddMessage($"订单orderid:{orderEo.OrderID}未知的{nameof(orderEo.OrderType)}:{orderEo.OrderType}属性").Save();
            //        break;
            //}
        }
    }
}
