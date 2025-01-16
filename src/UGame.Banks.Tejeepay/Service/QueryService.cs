using StackExchange.Redis;
using System.ComponentModel.DataAnnotations;
using TinyFx;
using TinyFx.Data;
using TinyFx.Logging;
using UGame.Banks.Service;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Services.SyncOrders;
using UGame.Banks.Tejeepay.Dto;
using UGame.Banks.Tejeepay.Ipo;
using Xxyy.Banks.DAL;
using Xxyy.Common;


namespace UGame.Banks.Tejeepay.Service
{
    public class QueryService //: VerifyOrderBase, IVerifyOrder
    {
        private const string BANKID = "tejeepay";
        private const int MULTIPLE = 100;

        ///// <summary>
        ///// 代收查询
        ///// </summary>
        ///// <param name="ipo"></param>
        ///// <returns></returns>
        //public async Task<TejeePayQueryDto> PayQuery(TejeePayQueryIpo ipo)
        //{
        //    var ret = new TejeePayQueryDto()
        //    {
        //        Status = PartnerCodes.RS_OK
        //    };
        //    try
        //    {
        //        await new BankProxy(ipo.BankId).PayQuery(ipo);//ipo, ret
        //    }
        //    catch (Exception ex)
        //    {
        //        var exc = ExceptionUtil.GetException<CustomException>(ex);
        //        ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
        //    }
        //    return ret;
        //}


        ///// <summary>
        ///// 代付查询
        ///// </summary>
        ///// <param name="ipo"></param>
        ///// <returns></returns>
        //public async Task<TejeeProxyQueryDto> ProxyQuery(TejeeProxyQueryIpo ipo)
        //{
        //    var ret = new TejeeProxyQueryDto()
        //    {
        //         Status= PartnerCodes.RS_OK,
        //    };

        //    try
        //    {
        //        await new BankProxy(ipo.BankId).ProxyQuery(ipo, ret);
        //    }
        //    catch (Exception ex)
        //    {
        //        var exc = ExceptionUtil.GetException<CustomException>(ex);
        //        ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
        //    }
        //    return ret;
        //}

        /// <summary>
        /// 余额查询
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<TejeeBalanceQueryDto> BalanceQuery(TejeeBalanceQueryIpo ipo)
        {
            var ret = new TejeeBalanceQueryDto()
            {
                Status = PartnerCodes.RS_OK,
            };

            try
            {
                //1.不存在调用对方
                var func = async (TransactionManager tm) =>
                {
                    ipo.OwnOrderId = ipo.OrderId;
                    await new BankProxy(ipo.BankId).BalanceQuery(ipo, ret);
                };
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = exc != null ? exc.Code : PartnerCodes.RS_UNKNOWN;
            }
            return ret;
        }

        ///// <summary>
        ///// 计算充值手续费
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <returns></returns>
        //private decimal CalcPayFee(Sb_bank_orderEO orderEo)
        //{
        //    var bankEo = DbBankCacheUtil.GetBank(orderEo.BankID);
        //    return orderEo.OrderMoney * bankEo.PayFee;
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


        ///// <summary>
        ///// 验证订单
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <returns></returns>
        //public async Task VerifyOrder(Sb_bank_orderEO orderEo)
        //{
        //    // var proxy = new BankProxy(BANKID);
        //    var proxy = DIUtil.GetService<BankProxy>();
        //    switch (orderEo.OrderType)
        //    {
        //        case (int)OrderTypeEnum.Charge:
        //            var payQueryResult = await proxy.PayQuery(new TejeePayQueryIpo
        //            {
        //                BankId = BANKID,
        //                CurrencyId = orderEo.CurrencyID,
        //                OrderId = orderEo.OrderID,
        //                OrderEo = orderEo
        //            });

        //            if (payQueryResult?.body?.amount.To<int>() != (int)orderEo.TransMoney)
        //                throw new Exception($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.transmoney:{orderEo.TransMoney},tejeepay.amount:{payQueryResult?.body?.amount}");
        //            if (payQueryResult?.head?.respCode != "0000")
        //            {
        //                LogUtil.Info("验证tejeepay代收订单查询失败！orderid:{0},对方返回值：{1}", orderEo.OrderID, SerializerUtil.SerializeJsonNet(payQueryResult));
        //                return;
        //            }
        //            //if (payQueryResult?.head?.respCode == "0000")
        //            //{
        //            orderEo.OwnFee = CalcPayFee(orderEo);
        //            orderEo.BankTime = string.IsNullOrWhiteSpace(payQueryResult.body.chargeTime) ? DateTime.UtcNow : payQueryResult.body.chargeTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(orderEo.OperatorID);
        //            orderEo.BankCallbackTime = DateTime.UtcNow;
        //            orderEo.CompleteFlag = 1;
        //            if (payQueryResult?.body?.status == "SUCCESS")
        //            {   //代收成功
        //                await this.PaySuccess(orderEo, payQueryResult);
        //            }
        //            else if (payQueryResult?.body?.status == "FAILURE")
        //            {
        //                //代收失败
        //                await this.PayFail(orderEo, payQueryResult);
        //            }
        //            else if (payQueryResult?.body?.status == "UNKNOW")
        //            {
        //                return;
        //            }
        //            else
        //            {
        //                throw new Exception($"tejeepay返回未知订单状态！orderid:{orderEo.OrderID},我方订单状态status：{orderEo.Status},tejee返回值：{SerializerUtil.SerializeJsonNet(payQueryResult)}");
        //            }
        //            //}
        //            break;
        //        case (int)OrderTypeEnum.Draw:
        //            var cashQueryResult = await proxy.ProxyQuery(new TejeeProxyQueryIpo
        //            {
        //                BankId = BANKID,
        //                CurrencyId = orderEo.CurrencyID,
        //                OrderId = orderEo.OrderID,
        //                OrderEo = orderEo
        //            });
        //            var detail = cashQueryResult?.detail?.FirstOrDefault();
        //            if (null == detail)
        //            {
        //                LogUtil.Error($"查询tejeepay验证订单出错,detail不能为空！orderid:{orderEo.OrderID},对方返回值：{SerializerUtil.SerializeJsonNet(cashQueryResult)}");
        //                return;
        //            }

        //            if (detail.amount.To<int>() != (int)orderEo.TransMoney)
        //                throw new Exception($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.transmoney:{orderEo.TransMoney},tejeepay.amount:{detail.amount}");

        //            orderEo.OwnFee = CalcCashFee(orderEo);
        //            var bankTime = detail.finishTime;
        //            orderEo.BankTime = string.IsNullOrWhiteSpace(bankTime) ? DateTime.UtcNow : bankTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(orderEo.OperatorID);
        //            orderEo.BankCallbackTime = DateTime.UtcNow;
        //            orderEo.CompleteFlag = 1;
        //            if (detail.status == "SUCCESS")
        //            {
        //                //代付成功
        //                await CashSuccess(orderEo, cashQueryResult);
        //            }
        //            else if (detail.status == "FAIL")
        //            {
        //                //代付失败
        //                await CashFail(orderEo, cashQueryResult);
        //            }
        //            else
        //            {
        //                return;
        //            }
        //            break;
        //        default:
        //            throw new ArgumentException($"订单orderid:{orderEo.OrderID}未知的{nameof(orderEo.OrderType)}:{orderEo.OrderType}属性");
        //    }
        //}

        ///// <summary>
        ///// 验证订单
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <returns></returns>
        //public async Task VerifyExceptionOrders()
        //{
        //    // var proxy = new BankProxy(BANKID);
        //    var proxy = DIUtil.GetService<BankProxy>();
        //    var startdate = new DateTime(2023, 10, 20, 3, 0, 0, DateTimeKind.Utc);
        //    var enddate = new DateTime(2023, 10, 20, 21, 10, 00, DateTimeKind.Utc);
        //    var orderEos = await new Sb_bank_orderMO().GetAsync("recdate>=@startdate and recdate<=@enddate and bankid='tejeepay' and ordertype=2 and status!=2 ", startdate, enddate);
        //    var successorders = new List<string>(orderEos.Count);
        //    var failorders = new List<string>(orderEos.Count);
        //    var otherorderids = new List<string>(orderEos.Count);
        //    foreach (var orderEo in orderEos)
        //    {
        //        try
        //        {
        //            //var orderEo = await new Sb_bank_orderMO().GetByPKAsync(orderid);
        //            var cashQueryResult = await proxy.ProxyQuery(new TejeeProxyQueryIpo
        //            {
        //                BankId = BANKID,
        //                OrderId = orderEo.OrderID,
        //                OrderEo = orderEo
        //            });
        //            var detail = cashQueryResult?.detail?.FirstOrDefault();
        //            if (null == detail)
        //            {
        //                otherorderids.Add($"{orderEo.OrderID}|{cashQueryResult?.desc}");
        //                Console.WriteLine($"orderid查询失败！detail为null");
        //                continue;
        //            }

        //            if (detail.amount.To<int>() != (int)orderEo.TransMoney)
        //            {
        //                Console.WriteLine($"orderid:{orderEo.OrderID}交易金额不一致！sb_bank_order.transmoney:{orderEo.TransMoney},tejeepay.amount:{detail.amount}");
        //                otherorderids.Add(orderEo.OrderID);
        //                continue;
        //            }
        //            orderEo.OwnFee = CalcCashFee(orderEo);
        //            var bankTime = detail.finishTime;
        //            orderEo.BankTime = string.IsNullOrWhiteSpace(bankTime) ? DateTime.UtcNow : bankTime.ToDateTime("yyyyMMddHHmmss").ToUtcTime(orderEo.OperatorID);
        //            orderEo.BankCallbackTime = DateTime.UtcNow;
        //            orderEo.CompleteFlag = 1;

        //            if (detail.status == "SUCCESS")
        //            {
        //                successorders.Add(orderEo.OrderID);
        //                //代付成功
        //                await CashSuccess(orderEo, cashQueryResult);
        //            }
        //            else if (detail.status == "FAIL")
        //            {
        //                //代付失败
        //                //await CashFail(orderEo, cashQueryResult);
        //                Console.WriteLine($"orderid:{orderEo.OrderID}tejeepay代付失败!{detail.desc}");
        //                failorders.Add($"{orderEo.OrderID}|{detail.desc}");
        //            }
        //            else
        //            {
        //                otherorderids.Add(orderEo.OrderID);
        //                Console.WriteLine($"tejeepay返回状态其他，{0}", SerializerUtil.SerializeJsonNet(detail));
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            otherorderids.Add(orderEo.OrderID);
        //            Console.WriteLine($"orderid:{orderEo.OrderID}处理异常，{ex.StackTrace},msg:{ex.Message}");
        //        }
        //    }
        //    Console.WriteLine($"成功订单：{string.Join("','", successorders)}");
        //    Console.WriteLine($"失败订单：{string.Join("','", failorders)}");
        //    Console.WriteLine($"其他订单：{string.Join("','", otherorderids)}");
        //}

        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public List<Sb_bankcodePO> GetBankList(TejeeBankListIpo ipo)
        {
            var bankList = DbBankCacheUtil.GetBankList(ipo.BankId);
            return bankList?.Where(x => x.CountryID == ipo.CountryId)?.ToList();
        }
    }
}
