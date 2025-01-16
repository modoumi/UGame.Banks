//using Org.BouncyCastle.Asn1.Ocsp;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using TinyFx;
//using Xxyy.Banks.BLL.Caching;
//using Xxyy.Banks.BLL.Common;
//using Xxyy.Banks.BLL;
//using Xxyy.Banks.DAL;
//using TinyFx.Data;
//using Microsoft.AspNetCore.Http;
//using Xxyy.DAL;
//using TinyFx.AspNet;
//using Xxyy.Banks.BLL.Services.Pay;
//using TinyFx.Logging;
//using TinyFx.ShortId;
//using Xxyy.Common.Caching;
//using Xxyy.Common;
//

//namespace Xxyy.Banks.Inx
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    public class InxPayService
//    {
//        private static readonly S_userMO _userMo = new();
//        private static readonly Sb_bank_orderMO _bankOrderMo = new();
//        private static readonly Sb_order_trans_logMO _orderTransLog = new();
//        private const int AMOUNT = 100000;
//        //private const string HEADER_NAME = "X-ING-Signature";
//        private const string BANKID = "inx";
//        private const int TryCount = 3;
//        private static ShortIdOptions _shortIdOptions = new ShortIdOptions
//        {
//            CustomAlphabet = ",.;:?!/@#$%^&()=+*{}[]<>|~"
//        };
//        private HttpRequest _request;
//        //private static readonly PayService _payService = new();

//        /// <summary>
//        /// 
//        /// </summary>
//        public InxPayService()
//        {
//            _request = DIUtil.GetRequiredService<IHttpContextAccessor>().HttpContext.Request;
//        }

//        /// <summary>
//        /// visa支付回调
//        /// </summary>
//        /// <param name="ipo"></param>
//        /// <returns></returns>
//        public async Task<bool> VisaCallback(VisaPayCallbackIpo ipo)
//        {
//            bool ret = false;
//            var tm = new TransactionManager();
//            bool isOrderHandled = await CheckOrderHandled(ipo); //0.是否处理过
//            if (isOrderHandled)
//            {
//                ret = true;
//                return ret;
//            }
//            //A,D,R,T---A即成功，其他不成功
//            if (ipo.Result != "A")
//            {
//                try
//                {
//                    ret = true;
//                    //更新订单状态为失败
//                    await UpdateBankOrder(ipo, BankOrderStatusEnum.Fail,tm);
//                    await AddBankTransLog(ipo,true,1,null,tm);
//                    tm.Commit();
//                }
//                catch (Exception ex)
//                {
//                    ret = false;
//                    tm.Rollback();
//                    //更新订单状态为失败
//                    await UpdateBankOrder(ipo, BankOrderStatusEnum.Fail, null);
//                    await AddBankTransLog(ipo, true, 2, null, null);
//                    LogUtil.Error(ex,"visa支付回调处理异常");
//                }
//                return ret;
//            }
//            try
//            {
//                if (ipo.Order.Status == (int)BankOrderStatusEnum.Fail)
//                {
//                    //1.更新订单
//                    await UpdateBankOrder(ipo, BankOrderStatusEnum.Exception, tm);
//                    //2.添加银行通讯日志
//                    await AddBankTransLog(ipo, true, 1, null, tm);
//                }
//                else
//                {
//                    //1.更新用户账户
//                    await UpdateUserCash(ipo.Order.UserID, ipo, tm);
//                    //2.更新订单
//                    await UpdateBankOrder(ipo, BankOrderStatusEnum.Success, tm);
//                    //3.添加银行通讯日志
//                    await AddBankTransLog(ipo, true, 1, null, tm);
//                    //4.redis
//                    var orderPayCache = new OrderPayDCache(ipo.Order.OrderID);
//                    orderPayCache.SetOrderAndExpire((int)BankOrderStatusEnum.Success);
//                }
//                ret = true;
//                tm.Commit();
//            }
//            catch (Exception ex)
//            {
//                ret = false;
//                tm.Rollback();
//                //更新订单状态
//                await UpdateBankOrder(ipo, BankOrderStatusEnum.Exception, null);
//                //银行日志
//                await AddBankTransLog(ipo,false,2,ex,null);
//            }
//            return ret;
//        }



//        /// <summary>
//        /// 更新用户账户余额
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="ipo"></param>
//        /// <param name="tm"></param>
//        private async Task UpdateUserCash(string userId, CallbackIpoBase ipo, TransactionManager tm)
//        {
//            //支付成功，更新用户账户余额
//            var amount = (long)(ipo.Amount * AMOUNT);
//            await _userMo.PutAsync("Cash=Cash+@Amount", "UserID=@UserID and 0<=Cash+@Amount2", tm, amount, userId,  amount);
//            ipo.Balance = await _userMo.GetCashByPKAsync(userId,tm);
//        }

        


//        private async Task UpdateBankOrder(VisaPayCallbackIpo ipo, BankOrderStatusEnum status,TransactionManager tm)
//        {
//            var eo = ipo.Order;
//            eo.Status = (int)status;
//            eo.BankCallbackTime= DateTime.Now;
//            eo.BankOrderId = ipo.OrderId;
//            eo.Amount = (long)(ipo.Amount * AMOUNT);
//            eo.EndBalance = ipo.Balance;
//            await _bankOrderMo.PutAsync(eo, tm);
//        }
//        //private async Task UpdateBankOrder(PayIpoBase ipo, BankOrderStatusEnum status, TransactionManager tm)
//        //{
//        //    var eo = ipo.Order;
//        //    eo.Status = (int)status;
//        //    eo.BankResponseTime = DateTime.Now;
//        //    eo.OwnOrderId = ipo.OwnOrderId;
//        //    //eo.BankOrderId = dto.BankOrderId;
//        //    await _bankOrderMo.PutAsync(eo, tm);
//        //}

//        private async Task AddBankTransLog(CallbackIpoBase ipo, bool dto, int status, Exception ex, TransactionManager tm)
//        {
//            var bankTransLogEo = new Sb_order_trans_logEO
//            {
//                TransLogID = Guid.NewGuid().ToString(),
//                OrderID = ipo.Order.OrderID,
//                BankID = ipo.Order.BankID,
//                TransType = 0,
//                TransMark = _request.Path.Value,
//                RequestBody = SerializerUtil.SerializeJson(ipo),
//                RequestTime = DateTime.Now,
//                Status = status,
//                ResponseTime = DateTime.Now,
//                ResponseBody = SerializerUtil.SerializeJson(dto),
//                Exception = SerializerUtil.SerializeJson(ex)
//            };
//            await _orderTransLog.AddAsync(bankTransLogEo, tm);
//        }

      



//        /// <summary>
//        /// 检查是否处理过
//        /// </summary>
//        /// <param name="ipo"></param>
//        /// <returns></returns>
//        /// <exception cref="Exception"></exception>
//        private async Task<bool> CheckOrderHandled(VisaPayCallbackIpo ipo)
//        {
//            //var transactionId = ipo.OrderId;
//            var orderEos = await _bankOrderMo.GetAsync("BankID=@BankID and OwnOrderId=@OwnOrderId",BANKID, ipo.OrderId);
//            if (orderEos == null || orderEos.Count == 0)
//                throw new Exception($"订单不存在,orderid：{ipo.OrderId}");
//            if (orderEos.Count != 1)
//                throw new Exception("sb_bank_order存在两条相同OwnOrderId的完成数据");
//            ipo.Order = orderEos[0];
//            //初始、待处理、成功
//            var orderStatusArr = new[] {(int)BankOrderStatusEnum.Initial, (int)BankOrderStatusEnum.Processing, (int)BankOrderStatusEnum.Success,(int)BankOrderStatusEnum.Fail };
//            //不是以上3种状态抛异常
//            if (!orderStatusArr.Contains(orderEos[0].Status))
//            {
//                throw new Exception($"订单状态异常.status={orderEos[0].Status}");
//            }//成功返回已处理
//            if (orderEos[0].Status == (int)BankOrderStatusEnum.Success)
//            {
//               // dto.Status = BankStatusCodes.RS_OK;
//                return true;
//            }
//            return false;
//        }



//        #region pay逻辑
//        /// <summary>
//        /// visa银行支付
//        /// </summary>
//        /// <param name="ipo"></param>
//        /// <returns></returns>
//        public async Task<VisaDto> VisaPay(VisaIpo ipo)
//        {
//            var ret = BankUtil.CreateDto<VisaDto>(ipo);

//            try
//            {
//                if (ipo.Amount <= 0)
//                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值金额Amount必须大于0");
//                if (string.IsNullOrWhiteSpace(ipo.BankId))
//                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"充值时BankId不能为空");

//                var func = async (TransactionManager tm) =>
//                {
//                    var proxy = new BankProxy(ipo.BankId);
//                    //获取交易流水号
//                    string ownOrderId = await GetOwnOrderId(ipo.BankId);
//                    ipo.OwnOrderId = ownOrderId;
//                    await proxy.Pay(ipo, ret);
//                };
//                //await _payService.Execute(ipo, ret, OrderTypeEnum.Charge,PayTypeEnum.Visa,func);
//                await BankUtil.Execute(ipo, ret, OrderTypeEnum.Charge, PayTypeEnum.Visa,this._request.Path.Value,0, func);
//            }
//            catch (Exception ex)
//            {
//                var exc = ExceptionUtil.GetException<CustomException>(ex);
//                ret.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
//            }
//            return ret;

//        }
//        /// <summary>
//        /// 生成交易流水号--也就是对方的orderid(商户下唯一)
//        /// </summary>
//        /// <param name="bankId"></param>
//        /// <returns></returns>
//        private async Task<string> GetOwnOrderId(string bankId)
//        {
//            string bankTransactionId = ShortIdUtil.Generate(_shortIdOptions, 15);
//            List<Sb_bank_orderEO> bankOrders = null;
//            int tryCount = 0;
//            while (tryCount < TryCount)
//            {
//                tryCount++;
//                bankOrders = await _bankOrderMo.GetTopAsync("BankID=@BankID and OwnOrderId=@OwnOrderId", 1, bankId, bankTransactionId);
//                if (null == bankOrders || bankOrders.Count == 0)
//                {
//                    return bankTransactionId;
//                }
//                bankTransactionId = ShortIdUtil.Generate(_shortIdOptions, 15);
//            }
//            throw new Exception("无法生成交易流水号：OwnOrderId");
//        }
//        #endregion

//    }
//}
