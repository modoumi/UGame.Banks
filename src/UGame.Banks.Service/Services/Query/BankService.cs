using EasyNetQ;
using Microsoft.AspNetCore.Http.Metadata;
using Org.BouncyCastle.Ocsp;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.Configuration;
using TinyFx.Extensions.AutoMapper;
using TinyFx.Logging;
using UGame.Banks.Service.Caching;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Service.Services.SyncOrders;
using UGame.Banks.Service.Common;
using UGame.Banks.Repository;
using Xxyy.Common;

using Xxyy.DAL;

namespace UGame.Banks.Service.Services.Query
{
    /// <summary>
    /// 
    /// </summary>
    public class BankService
    {
        private Sb_bank_orderMO _bankOrderMo = new();
        private const int PAGESIZE = 500;
        /// <summary>
        /// 根据订单号获取订单
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async Task<GetOrderDto> GetOrder(GetOrderIpo ipo)
        {
            var ret = new GetOrderDto
            {
                OrderID = ipo.OrderId,
                UserID = ipo.UserId,
                AppID = ipo.AppId,
                Status = PartnerCodes.RS_OK
            };
            try
            {
                if (string.IsNullOrWhiteSpace(ipo.OrderId))
                    throw new CustomException(PartnerCodes.RS_WRONG_SYNTAX, $"GetOrder时OrderId不能为空！");

                await BankUtil.CheckAndSetIpo(ipo);
                //redis
                var orderPayCache = new OrderPayDCache(ipo.OrderId);
                var orderStatus = await orderPayCache.GetOrLoadAsync(expire: TimeSpan.FromMinutes(30));
                if (!orderStatus.HasValue || orderStatus.Value.UserID != ipo.UserId)
                {
                    throw new CustomException(PartnerCodes.RS_ORDER_NOT_EXISTS, $"订单不存在。orderid:{ipo.OrderId}");
                }
                //var orderEo = orderStatus.Value;
                ret = orderStatus.Value.Map<GetOrderDto>();
                ret.Status = PartnerCodes.RS_OK;
            }
            catch (Exception ex)
            {
                var exc = ExceptionUtil.GetException<CustomException>(ex);
                ret.Status = (exc != null) ? exc.Code : PartnerCodes.RS_UNKNOWN;
                ret.Message = (exc != null) ? exc.Message : ex.Message;
            }
            return ret;
        }

        /// <summary>
        /// 同步三方订单状态
        /// </summary>
        /// <returns></returns>
        public async Task VerifyOrders(VerifyOrderIpo ipo)
        {
            IVerifyOrder verifyOrderSvc= DIUtil.GetService<Func<string, IVerifyOrder>>()("hubtel");
            try
            {
                await verifyOrderSvc.VerifyOrder(ipo);
            }
            catch (Exception ex)
            {
                LogUtil.GetContextLogger()
                    .SetLevel(Microsoft.Extensions.Logging.LogLevel.Error)
                    .AddException(ex)
                    .AddMessage($"验证hubtel订单异常！")
                    .Save() ;
            }

            //if(ipo.VerifyTime==DateTime.MinValue)
            //    ipo.VerifyTime = DateTime.UtcNow;
            //var pageSize = ConfigUtil.AppSettings.GetOrDefault<int>("VerifyOrderPageSize",PAGESIZE);
            //var pageCount = await _bankOrderMo.GetPageCountAsync(PAGESIZE, $" BankID=@BankID and SettlStatus=@SettlStatus and status=@status and DATE_SUB(@now, INTERVAL 30 MINUTE)", "orderid",values: new object[] { "hubtel",(int)SettlStatusEnum.Init, (int)BankOrderStatusEnum.Processing,ipo.VerifyTime });
            //if (pageCount == 0)
            //    return;

            //IVerifyOrder verifyOrderSvc = DIUtil.GetService<Func<string, IVerifyOrder>>()("hubtel");
            //for (var page = 1; page <= pageCount; page++)
            //{
            //    var bankOrders = await _bankOrderMo.GetPagerListAsync(PAGESIZE, page, "BankID=@BankID and SettlStatus=@SettlStatus and status=@status and DATE_SUB(@now, INTERVAL 30 MINUTE)", "orderid",values:new object[] { "hubtel", (int)SettlStatusEnum.Init,(int)BankOrderStatusEnum.Processing,ipo.VerifyTime });
            //    if (null == bankOrders || !bankOrders.Any())
            //        continue;
            //    foreach (var orderEo in bankOrders)
            //    {
            //        try
            //        {
            //            await verifyOrderSvc.VerifyOrder(orderEo);
            //        }
            //        catch (Exception ex)
            //        {
            //            LogUtil.Error(ex, $"验证订单过程异常！orderid:{orderEo.OrderID}");
            //        }
            //    }
            //}
        }

        /// <summary>
        /// 获取银行列表
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public List<Sb_bankcodePO> GetBankList(GetBankListIpo ipo)
        {
            var bankList = DbBankCacheUtil.GetBankList(ipo.BankId, ipo.CountryId);
            return bankList?.OrderBy(x=>x.BankName)?.ToList();
        }
    }
}
