using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Net;
using TinyFx;
using Xxyy.Common.Caching;
using Xxyy.DAL;
using TinyFx.Data;
using Xxyy.Common;
using UGame.Banks.Service.Common;
using Microsoft.Net.Http.Headers;
using TinyFx.AspNet;
using Org.BouncyCastle.Asn1.Ocsp;
using TinyFx.Extensions.AutoMapper;
using TinyFx.Text;
using UGame.Banks.Repository;
using System.Security.Cryptography;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Service
{
    /// <summary>
    /// 
    /// </summary>
    public static class BankUtil
    {
        private static readonly Sb_bank_orderMO _bankOrderMo = new();
        private static readonly Sb_order_trans_logMO _orderTransLogMo = new();
        private static readonly Sb_bank_currencyMO _bankCurrencyMo = new();
        private static readonly Sb_user_vanumberMO _userVanumberMo = new();
       // private static readonly S_userMO _userMo = new();
        
        private const string HEADER_NAME = "X-ING-Signature";

        
        #region BankCacheUtil
        /// <summary>
        /// 
        /// </summary>
        /// <param name="orderCache"></param>
        /// <param name="amount"></param>
        /// <param name="order"></param>
        /// <param name="status"></param>
        public static async Task SetOrderCacheAsync(OrderPayDCache orderCache,long amount,Sb_bank_orderEO order,int status)
        {
            var orderViewDto = order.Map<GetOrderViewDto>();
            orderViewDto.Amount = amount;
            orderViewDto.Status = status;
            await orderCache.SetOrderAndExpire(orderViewDto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="paytypeId"></param>
        /// <param name="paytypeChannel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetChannelName(string bankId,int paytypeId,int paytypeChannel)
        {
            var bankPaytypeChannelEo =DbBankCacheUtil.GetBankPaytypeChannel(bankId,paytypeId, paytypeChannel,false);
            return bankPaytypeChannelEo?.ChannelName;
        }

        #endregion

        #region Check
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public static async Task CheckBankCurrency(PayIpoBase ipo)
        {
            var bankCurrencyEo = await _bankCurrencyMo.GetByPKAsync(ipo.BankId,ipo.CurrencyId);
            if (bankCurrencyEo == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"不支持的银行和货币BankId:{ipo.BankId},currencyId：{ipo.CurrencyId}");
        }

        /// <summary>
        /// 检查相关设置
        /// </summary>
        /// <param name="ipo"></param>
        /// <exception cref="Exception"></exception>
        /// <exception cref="CustomException"></exception>
        public static async Task CheckAndSetIpo(BankIpoBase ipo)
        {
            if (string.IsNullOrWhiteSpace(ipo.RequestUUID) || string.IsNullOrWhiteSpace(ipo.UserId) || string.IsNullOrWhiteSpace(ipo.AppId) || string.IsNullOrWhiteSpace(ipo.CurrencyId))
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"PayIpoBase中的参数不能为空");

            //ipo.OrderId = ipo.RequestUUID;
            // appId
            ipo.App = DbCacheUtil.GetApp(ipo.AppId, false);
            if (ipo.App == null)
                throw new CustomException(PartnerCodes.RS_INVALID_APP, $"未知App。 appId:{ipo.AppId}");

            // provider
            ipo.Provider = DbCacheUtil.GetProvider(ipo.App.ProviderID, false);
            if (ipo.Provider == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"未知Provider。 providerId:{ipo.App.ProviderID}");
            if (ipo.Provider.Status == 0)
                throw new CustomException(PartnerCodes.RS_INVALID_PROVIDER, $"提供商被禁用。 providerId:{ipo.Provider.ProviderID}");

            // sign
            await CheckSign(ipo.Provider.OwnPublicKey, $"s_provider没有定义TrdPublicKey。providerId:{ipo.Provider.ProviderID}");

            //// token
            //ipo.LoginTokenDo = await CheckToken(ipo);

            // user status
            var userDCache = await GlobalUserDCache.Create(ipo.UserId);
            if (!await userDCache.KeyExistsAsync())
            {
                var user = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId);
                if (user == null)
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"用户不存在。userId:{ipo.UserId}");
                await userDCache.SetBaseValues(user);
            }
            if (await userDCache.GetUserStatusAsync() != UserStatus.Normal)
                throw new CustomException(PartnerCodes.RS_USER_DISABLED, $"用户被禁用/锁定并且无法充值。 userId:{ipo.UserId}");
            if(await userDCache.GetUserModeAsync()!= UserMode.Register)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX,$"非注册用户无法充值。 userId:{ipo.UserId}");

            // currencyId
            var currencyType = DbCacheUtil.GetCurrencyType(ipo.CurrencyId);
            if (currencyType != CurrencyType.Cash)
                throw new CustomException(PartnerCodes.RS_WRONG_CURRENCY, $"不支持的交易货币。CurrencyId:{ipo.CurrencyId}");
            if (await userDCache.GetCurrencyIdAsync() != ipo.CurrencyId)
                throw new CustomException(PartnerCodes.RS_WRONG_CURRENCY, $"交易货币不同于用户的钱包货币。user:{await userDCache.GetCurrencyIdAsync()} ipo:{ipo.CurrencyId}");

            // operator status
            var operatorId = await userDCache.GetOperatorIdAsync();
            ipo.Operator = DbCacheUtil.GetOperator(operatorId, false);
            if (ipo.Operator == null)
                throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"未知Operator。 operatorId:{operatorId}");
            if (ipo.Operator.Status == 0)
                throw new CustomException(PartnerCodes.RS_INVALID_OPERATOR, $"运营商商被禁用。 operatorId:{operatorId}");
            //ipo.OperatorApp = DbCacheUtil.GetOperatorApp(operatorId, ipo.AppId);
        }

        

        public static async Task CheckSign(string trdPublicKey, string exceptionMsg)
        {
            if (string.IsNullOrEmpty(trdPublicKey))
                throw new Exception(exceptionMsg);
            
            //if (!await AspNetUtil.VerifyRequestHeaderSign(HEADER_NAME, trdPublicKey))
            if(!await new RequestBodySignValidator(trdPublicKey).VerifyByHeader(HEADER_NAME, HttpContextEx.Current))
                throw new CustomException(PartnerCodes.RS_INVALID_SIGNATURE, "验证签名错误");
        }

       

        /// <summary>
        /// 重复验证
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static async Task<bool> CheckRepeatRequestAppOrder(PayIpoBase ipo, PayDtoBase dto)
        {
            var transactionId = ipo.AppOrderId;
            var orderEos = await _bankOrderMo.GetAsync("BankID=@BankID and AppOrderId=@AppOrderId", ipo.BankId, transactionId);
            if (orderEos == null || orderEos.Count == 0)
                return false;
            throw new CustomException(PartnerCodes.RS_DUPLICATE_TRANSACTION, $"发送了具有相同 AppOrderId 的交易");
        }
        #endregion




        #region 添加订单修改订单


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="orderType"></param>
        /// <param name="payType"></param>
        /// <param name="channel"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public static async Task AddBankOrder(PayIpoBase ipo,PayDtoBase dto, OrderTypeEnum orderType, PayTypeEnum payType,int channel, TransactionManager tm)
        {
            var userDCache =await GlobalUserDCache.Create(ipo.UserId);
            var operatorId = await userDCache.GetOperatorIdAsync();
            var orderEo = new Sb_bank_orderEO
            {
                OrderID = ipo.OrderId,
                BankID = ipo.BankId,
                ProviderID = ipo.Provider.ProviderID,
                AppID = ipo.AppId,
                OperatorID = operatorId,
                UserID = ipo.UserId,
                FromMode=await userDCache.GetFromModeAsync(),
                FromId=await userDCache.GetFromIdAsync(),
                UserKind= (int)await userDCache.GetUserKindAsync(), //userEo.UserKind,
                OrderType =(int)orderType,
                PaytypeID = (int)payType,
                PaytypeChannel=channel,
                CurrencyID = ipo.CurrencyId,
                PlanAmount = (orderType== OrderTypeEnum.Charge? ipo.Amount:-ipo.Amount),
                RecDate=DateTime.UtcNow,
                AppRequestUUID = ipo.RequestUUID,
                AppOrderId = ipo.AppOrderId,
                AppReqComment = ipo.ReqComment,
                AppRequestTime = DateTime.UtcNow,
                Meta = SerializerUtil.SerializeJson(new { AppMeta = ipo.Meta }),
                Status = (int)BankOrderStatusEnum.Initial,
                Amount= (orderType == OrderTypeEnum.Charge ? ipo.Amount : -ipo.Amount),
                UserIP=ipo.UserIp
            };
            ipo.Order = orderEo;
            await _bankOrderMo.AddAsync(orderEo, tm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="status"></param>
        /// <param name="dto"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public static async Task UpdateBankOrder(PayIpoBase ipo, BankOrderStatusEnum status, PayDtoBase dto, TransactionManager tm)
        {
            var eo = ipo.Order;
            eo.EndBalance = dto.EndBalance;
            eo.EndBonus = dto.EndBonus;
            eo.Status = (int)status;
            eo.BankResponseTime = DateTime.UtcNow;
            eo.OwnOrderId = ipo.OwnOrderId;
            eo.BankOrderId = dto.BankOrderId;
            eo.IsFirstCashOfDay = dto.IsFirstCashOfDay;
            eo.TransMoney= dto.TransMoney;
            eo.OrderMoney = dto.OrderMoney;
            if (eo.OrderType == (int)OrderTypeEnum.Draw)
            {
                eo.UserFee = dto.Fee;
            }
            //else
            //{
            //    eo.OwnFee = dto.Fee;
            //}
            await _bankOrderMo.PutAsync(eo, tm);
        }
        #endregion

        #region 添加日志
      
        /// <summary>
        /// 添加app日志
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="status"></param>
        /// <param name="ex"></param>
        /// <param name="transMark"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public static async Task AddAppTransLog(PayIpoBase ipo, PayDtoBase dto, int status, Exception ex, string transMark, TransactionManager tm)
        {
            var appTransLogEo = new Sb_order_trans_logEO
            {
                TransLogID = ipo.OrderId,
                OrderID = ipo.OrderId,
                AppID = ipo.AppId,
                TransType = 1,
                TransMark = transMark,
                RequestBody = SerializerUtil.SerializeJsonNet(ipo),
                RequestTime = DateTime.UtcNow,
                Status = status,
                ResponseBody = SerializerUtil.SerializeJsonNet(dto),
                ResponseTime = DateTime.UtcNow,
                Exception = SerializerUtil.SerializeJsonNet(ex)
            };
            await _orderTransLogMo.AddAsync(appTransLogEo, tm);
        }

        /// <summary>
        /// 添加银行日志
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="dto"></param>
        /// <param name="status"></param>
        /// <param name="ex"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public static async Task AddBankTransLog(PayIpoBase ipo, PayDtoBase dto, int status, Exception ex, TransactionManager tm)
        {
            var bankTransLogEo = new Sb_order_trans_logEO
            {
                TransLogID = ObjectId.NewId(),
                OrderID = ipo.OrderId,
                BankID = ipo.BankId,
                TransType = 0,
                TransMark = HttpContextEx.Request.Path.Value,
                RequestBody = SerializerUtil.SerializeJsonNet(ipo),
                RequestTime = DateTime.UtcNow,
                Status = status,
                ResponseTime = DateTime.UtcNow,
                ResponseBody = SerializerUtil.SerializeJsonNet(dto),
                Exception = SerializerUtil.SerializeJsonNet(ex),
                ReceiveBonus=ipo.ReceiveBonus
            };
            await _orderTransLogMo.AddAsync(bankTransLogEo, tm);
        }
        #endregion

        #region 更新用户账户余额

        /// <summary>
        /// 更新用户账户余额
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="amount"></param>
        /// <param name="tm"></param>
        public static async Task<(long,long)> UpdateUserCash(string userId, long amount, TransactionManager tm)
        {
            //支付成功，更新用户账户余额
            //var amount = money * AMOUNT;
            var rows = await DbSink.BuildUserMo(userId).PutAsync("Cash=Cash+@Amount", "UserID=@UserID and 0<=Cash+@Amount2", tm, amount, userId, amount);
            if (rows <= 0)
            {
                throw new Exception($"更新用户账户余额异常,userId:{userId},money:{amount}");
            }
            var userEo = await DbSink.BuildUserMo(userId).GetByPKAsync(userId, tm);
            if (null == userEo)
                throw new Exception("用户不存在");
            //var balance = await DbSink.BuildUserMo(userId).GetCashByPKAsync(userId, tm);
            return (userEo.Cash,userEo.Bonus);
        }

        #endregion

      



        #region CreateDto
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TDto"></typeparam>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public static TDto CreateDto<TDto>(PayIpoBase ipo)
           where TDto : PayDtoBase, new()
        {
            var ret = new TDto();
            ret.RequestUUID = ipo.RequestUUID;
            ret.UserId = ipo.UserId;
            ret.OrderId = ipo.OrderId;
            ret.CurrencyId = ipo.CurrencyId;
            ret.Status = PartnerCodes.RS_OK;
            ret.Amount= ipo.Amount;
            ret.Meta = ipo.Meta;
            return ret;
        }
        #endregion

    }
}
