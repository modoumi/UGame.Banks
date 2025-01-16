using TinyFx;
using TinyFx.Data;
using TinyFx.Logging;
using UGame.Banks.Service.Common;
using UGame.Banks.Repository;
using Xxyy.Common;

namespace UGame.Banks.Service.Services.SyncOrders
{
    /// <summary>
    /// 验证三方订单
    /// </summary>
    public abstract class VerifyOrderBase
    {
        protected readonly OrderService _orderService=new();
        protected readonly MessageService _messageService = new();

        /// <summary>
        /// 三方代收成功
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public async Task PaySuccess(Sb_bank_orderEO orderEo,object resp)
        {
            var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                switch (orderEo.Status)
                {
                    case (int)BankOrderStatusEnum.Success:
                        await _orderService.UpdateSettlStatus(orderEo, SettlStatusEnum.Consistent,orderEo.SettlStatus,resp,tm);
                        tm.Commit();
                        break;
                    case (int)BankOrderStatusEnum.Processing:
                    case (int)BankOrderStatusEnum.Initial:
                    case (int)BankOrderStatusEnum.Exception:
                    case (int)BankOrderStatusEnum.Fail:
                        orderEo.SettlStatus = (int)SettlStatusEnum.Consistent;
                        //0.获取更新前的cash
                        var userEo = await DbSink.BuildUserMo(orderEo.UserID).GetByPKAsync(orderEo.UserID, tm);
                        if (null == userEo)
                            throw new Exception($"订单用户不存在！userId:{orderEo.UserID},orderid:{orderEo.OrderID}");
                        await _orderService.UpdatePaySuccessOrder(orderEo,resp,tm);
                        tm.Commit();
                        //4.发送消息
                        await _messageService.SendUserPayMsg(orderEo, userEo.Cash, userEo.CountryID);
                        break;
                    //case (int)BankOrderStatusEnum.ExceptionHandled:
                    //case (int)BankOrderStatusEnum.Rollback:
                    //    break;
                    default:
                        tm.Rollback();
                        break;
                }
            }
            catch (DuplicateUpdateOrderException ex)
            {
                tm.Rollback();
                LogUtil.GetContextLogger()
                    .AddField("banks.orderid", orderEo.OrderID)
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Warning)
                    .AddMessage($"验证三方订单时并发更新订单异常！orderid:{orderEo.OrderID}")
                    .Save();
                //LogUtil.Info(ex, "并发更新订单异常！orderid:{0}", orderEo.OrderID);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.GetContextLogger()
                    .AddField("banks.verifyorder.orderid", orderEo.OrderID)
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddMessage($"验证三方订单时三方代收成功，更新订单异常！orderid:{orderEo.OrderID}")
                    .Save();
                //LogUtil.Error(ex,"三方代收成功，更新订单异常！orderid:{0},我方订单状态：{1},对方返回值：{2}",orderEo.OrderID,orderEo.Status,SerializerUtil.SerializeJsonNet(resp));
                throw;
            }
        }

        /// <summary>
        /// 三方代收失败
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public async Task PayFail(Sb_bank_orderEO orderEo,object resp)
        {
            var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                switch (orderEo.Status)
                {
                    case (int)BankOrderStatusEnum.Fail:
                        var result = await _orderService.UpdateSettlStatus(orderEo, SettlStatusEnum.Consistent, orderEo.SettlStatus,resp, tm);
                        tm.Commit();
                        return;
                    case (int)BankOrderStatusEnum.Processing:
                    case (int)BankOrderStatusEnum.Initial:
                    case (int)BankOrderStatusEnum.Exception:
                        orderEo.SettlStatus = (int)SettlStatusEnum.Consistent;
                        var oldStatus = orderEo.Status;
                        orderEo.Status = (int)BankOrderStatusEnum.Fail;
                        await _orderService.UpdateOrderEo(orderEo, oldStatus, tm);
                        await _orderService.AddBankTransLog(orderEo,$"代收失败,订单{orderEo.OrderID}从{orderEo.Status}更新为{BankOrderStatusEnum.Fail}",resp,tm);
                        tm.Commit();
                        break;
                    case (int)BankOrderStatusEnum.Success:
                        await _orderService.UpdateSettlStatus(orderEo, SettlStatusEnum.OwnSuccessOtherFail, orderEo.SettlStatus,resp, tm);
                        tm.Commit();
                        break;
                    //case (int)BankOrderStatusEnum.ExceptionHandled:
                    //case (int)BankOrderStatusEnum.Rollback:
                    //    break;
                    default:
                        tm.Rollback();
                        break;
                }
            }
            catch (DuplicateUpdateOrderException ex)
            {
                tm.Rollback();
                LogUtil.Info(ex, "并发更新订单异常！orderid:{0}", orderEo.OrderID);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error(ex, "三方代收失败，更新订单异常！orderid:{0},我方订单状态：{1},对方返回值：{2}",orderEo.OrderID,orderEo.Status,SerializerUtil.SerializeJsonNet(resp));
                throw;
            }
        }



        /// <summary>
        /// 三方代付成功
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public async Task CashSuccess(Sb_bank_orderEO orderEo,object resp)
        {
            var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                switch (orderEo.Status)
                {
                    case (int)BankOrderStatusEnum.Success:
                        await _orderService.UpdateSettlStatus(orderEo, SettlStatusEnum.Consistent, orderEo.SettlStatus,resp, tm);
                        tm.Commit();
                        return;
                    case (int)BankOrderStatusEnum.Processing:
                    case (int)BankOrderStatusEnum.Initial:
                    case (int)BankOrderStatusEnum.Exception:
                    case (int)BankOrderStatusEnum.Fail:
                        orderEo.SettlStatus = (int)SettlStatusEnum.Consistent;
                        await _orderService.UpdateCashSuccess(orderEo,resp,tm);
                        tm.Commit();
                        //4.发送消息
                        await _messageService.SendUserCashMsg(orderEo,true);
                        break;
                    //case (int)BankOrderStatusEnum.ExceptionHandled:
                    //case (int)BankOrderStatusEnum.Rollback:
                    //    tm.Rollback();
                    //    break;
                    default:
                        tm.Rollback();
                        break;
                }
            }
            catch (DuplicateUpdateOrderException ex)
            {
                tm.Rollback();
                LogUtil.Info(ex,"并发更新订单异常！orderid:{0}",orderEo.OrderID);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error(ex, "三方代付成功，更新订单异常！orderid:{0},我方订单状态:{1},对方返回值：{2}", orderEo.OrderID,orderEo.Status,SerializerUtil.SerializeJsonNet(resp));
            }
        }

        /// <summary>
        /// 三方代付失败
        /// </summary>
        /// <param name="orderEo"></param>
        /// <param name="resp"></param>
        /// <returns></returns>
        public async Task CashFail(Sb_bank_orderEO orderEo,object resp)
        {
            var tm = new TransactionManager(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                switch (orderEo.Status)
                {
                    case (int)BankOrderStatusEnum.Fail:
                        await _orderService.UpdateSettlStatus(orderEo, SettlStatusEnum.Consistent, orderEo.SettlStatus, resp, tm);
                        tm.Commit();
                        break;
                    case (int)BankOrderStatusEnum.Processing:
                    case (int)BankOrderStatusEnum.Initial:
                        orderEo.SettlStatus = (int)SettlStatusEnum.Consistent;
                        await _orderService.UpdateCashFail(orderEo, resp, tm);
                        tm.Commit();
                        await _messageService.SendUserCashMsg(orderEo, false);
                        break;
                    case (int)BankOrderStatusEnum.Success:
                        await _orderService.UpdateSettlStatus(orderEo, SettlStatusEnum.OwnSuccessOtherFail, orderEo.SettlStatus, resp, tm);
                        tm.Commit();
                        break;
                    //case (int)BankOrderStatusEnum.Exception:
                    //    orderEo.SettlStatus = (int)SettlStatusEnum.OwnFailOtherSuccess;
                    //    await _orderService.UpdateCashSuccess(orderEo, tm);
                    //    tm.Commit();
                    //    break;
                    //case (int)BankOrderStatusEnum.ExceptionHandled:
                    //case (int)BankOrderStatusEnum.Rollback:
                    //    tm.Rollback();
                    //    break;
                    default:
                        tm.Rollback();
                        break;
                }
            }
            catch (DuplicateUpdateOrderException ex)
            {
                tm.Rollback();
                LogUtil.Info(ex, "并发更新订单异常！orderid:{0}", orderEo.OrderID);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error(ex, "三方代付失败，更新订单异常！orderid:{0},我方订单状态：{1},对方返回值：{2}", orderEo.OrderID, orderEo.Status, SerializerUtil.SerializeJsonNet(resp));
            }
        }
    }
}
