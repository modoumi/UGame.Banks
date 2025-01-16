using TinyFx;
using TinyFx.Logging;
using UGame.Banks.Letspay.Ipo;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Services.SyncOrders;
using Xxyy.Banks.DAL;
using Xxyy.Common;

namespace UGame.Banks.Letspay.Service
{
    public class QueryService// : VerifyOrderBase, IVerifyOrder
    {

        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public List<Sb_bankcodePO> GetBankList(LetspayBankListIpo ipo)
        {
            var bankList = DbBankCacheUtil.GetBankList(ipo.BankId,ipo.CountryId);
            return bankList;
            //return bankList?.Where(x => x.CountryID == ipo.CountryId)?.ToList();
        }

        ///// <summary>
        ///// 代收订单查询
        ///// </summary>
        ///// <param name="ipo"></param>
        ///// <returns></returns>
        //public async Task<QueryPayOrderResponse> QueryPayOrder(QueryPayOrderIpo ipo)
        //{
        //    QueryPayOrderResponse ret = null;
        //    try
        //    {
        //        ret = await new BankProxy(ipo.BankId).QueryPayOrder(ipo);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex, "调用bankproxy.QueryPayOrder查询支付订单异常！");
        //    }
        //    return ret;
        //}

        ///// <summary>
        ///// 代付订单查询
        ///// </summary>
        ///// <param name="ipo"></param>
        ///// <returns></returns>
        //public async Task<QueryTransOrderResponse> QueryTransOrder(QueryTransOrderIpo ipo)
        //{
        //    QueryTransOrderResponse ret = null;
        //    try
        //    {
        //        ret = await new BankProxy(ipo.BankId).QueryTransOrder(ipo);
        //    }
        //    catch (Exception ex)
        //    {
        //        LogUtil.Error(ex,"调用bankproxy.querytransorder异常！");
        //    }
        //    return ret;
        //}

        ///// <summary>
        ///// 计算充值手续费
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <returns></returns>
        //private decimal CalcPayFee(Sb_bank_orderEO orderEo)
        //{
        //    var bankEo = DbBankCacheUtil.GetBank(orderEo.BankID);
        //    return orderEo.OrderMoney *bankEo.PayFee;
        //}

        ///// <summary>
        ///// 计算充值手续费
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <returns></returns>
        //private decimal CalcCashFee(Sb_bank_orderEO orderEo)
        //{
        //    var bankEo = DbBankCacheUtil.GetBank(orderEo.BankID);
        //    return orderEo.OrderMoney * bankEo.CashFee;
        //}


        //public async Task VerifyOrder(Sb_bank_orderEO orderEo)
        //{
        //    //var orderPayConfig = ConfigUtil.AppConfigs.Get<OrderPayConfig>("orderpayconfig");
        //    //var proxy = new BankProxy(BANKID);
        //    var proxy = DIUtil.GetService<BankProxy>();
        //    switch (orderEo.OrderType)
        //    {
        //        case (int)OrderTypeEnum.Charge:
        //            var queryPayOrderIpo = new QueryPayOrderIpo
        //            {
        //                OrderId = orderEo.OrderID
        //            };
        //            var payQueryResult = await proxy.QueryPayOrder(queryPayOrderIpo);

        //            if (payQueryResult?.amount.MToA(orderEo.CurrencyID) != orderEo.OrderMoney.MToA(orderEo.CurrencyID))
        //                throw new Exception($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.ordermoney:{orderEo.OrderMoney},letspay.amount:{payQueryResult?.amount}");
        //            if(payQueryResult?.retCode != "SUCCESS")
        //            {
        //                LogUtil.Info("验证letspay代收订单查询失败！orderid:{0},对方返回值：{1}", orderEo.OrderID, SerializerUtil.SerializeJsonNet(payQueryResult));
        //                return;
        //            }
        //            //if (payQueryResult?.retCode == "SUCCESS")
        //            //{
        //                orderEo.OwnFee = CalcPayFee(orderEo);
        //                orderEo.BankCallbackTime =orderEo.BankTime = DateTime.UtcNow;
        //                orderEo.CompleteFlag = 1;
        //                if (payQueryResult?.status ==2)
        //                {   //代收成功
        //                    await this.PaySuccess(orderEo,payQueryResult);
        //                }
        //                else if (payQueryResult?.status == 1|| payQueryResult?.status == 5)
        //                {
        //                    //支付中，失效
        //                    return;
        //                }
        //                else
        //                {
        //                    throw new Exception($"letspay返回未知订单状态！orderid:{orderEo.OrderID},我方订单状态status：{orderEo.Status},letspay返回值：{SerializerUtil.SerializeJsonNet(payQueryResult)}");
        //                }
        //            //}
        //            break;
        //        case (int)OrderTypeEnum.Draw:
        //            var cashQueryResult = await proxy.QueryTransOrder(new QueryTransOrderIpo { 
        //             OrderId=orderEo.OrderID
        //            });

        //            if (cashQueryResult?.amount.MToA(orderEo.CurrencyID) != orderEo.OrderMoney.MToA(orderEo.CurrencyID))
        //                throw new Exception($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.ordermoney:{orderEo.OrderMoney},letspay.amount:{cashQueryResult?.amount}");
        //            orderEo.UserFee = CalcCashFee(orderEo);
        //            orderEo.BankCallbackTime = orderEo.BankTime = DateTime.UtcNow;
        //            orderEo.CompleteFlag = 1;
        //            if(cashQueryResult?.retCode != "SUCCESS")
        //            {
        //                LogUtil.Info("验证代付订单查询失败！orderid:{0},对方返回值：{1}",orderEo.OrderID,SerializerUtil.SerializeJsonNet(cashQueryResult));
        //                return;
        //            }
        //            if (cashQueryResult?.status ==2)
        //            {
        //                //代付成功
        //                await CashSuccess(orderEo,cashQueryResult);
        //            }
        //            else if (cashQueryResult?.status == 3)
        //            {
        //                //代付失败
        //                await CashFail(orderEo, cashQueryResult);
        //            }
        //            else if (cashQueryResult?.status == 1)
        //            {
        //                //处理中
        //                return;
        //                //await MQUtil.FuturePublishAsync(new OrderProcessingMsg()
        //                //{
        //                //    BankId = orderEo.BankID,
        //                //    OrderType = orderEo.OrderType.ToEnum<OrderTypeEnum>(),
        //                //    BankOrderId = orderEo.BankOrderId,
        //                //    OrderId = orderEo.OrderID,
        //                //    Channel = orderEo.PaytypeChannel,
        //                //    Money = orderEo.OrderMoney,
        //                //    OwnOrderId = orderEo.OwnOrderId,
        //                //    Paytype = orderEo.PaytypeID,
        //                //    UserId = orderEo.UserID,
        //                //    Recdate = orderEo.RecDate
        //                //}, TimeSpan.FromMinutes(orderPayConfig?.PayTimeout ?? 5));
        //            }
        //            break;
        //        default:
        //            throw new ArgumentException($"orderid:{orderEo.OrderID}订单未知的{nameof(orderEo.OrderType)}:{orderEo.OrderType}属性!");
        //    }
        //}
    }
}
