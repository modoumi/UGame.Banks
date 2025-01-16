using Lobby.Flow.DAL;
using Lobby.Flow.IpoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;
using TinyFx.AspNet;
using TinyFx.Data;
using TinyFx.DbCaching;
using TinyFx.Logging;
using TinyFx.Text;
using Xxyy.Common;
using Xxyy.Common.Caching;

namespace Lobby.Flow.Common
{
    public static class FlowUtil
    {
        private static Sc_cash_audit_logMO _cashAuditLogMo = new();

        public static async Task AddCashAuditLog(string cashAuditId, TransactionManager tm, bool success, CashAuditActionData data, Exception ex)
        {
            try
            {
                var utcNow = DateTime.UtcNow;
                var logEo = new Sc_cash_audit_logEO
                {
                    AuditLogID = ObjectId.NewId(),
                    CashAuditID = cashAuditId,
                    TransType = data.TransType,
                    TransMark = HttpContextEx.Request?.Path.Value,
                    RequestTime = data.RequestTime,
                    RequestBody = SerializerUtil.SerializeJsonNet(data.Ipo),
                    Status = success ? 1 : 2,
                    RecDate = utcNow,
                    ResponseTime = utcNow,
                    Action = data.Action,
                    OperatorId = data.OperatorId,
                    OperatorName = data.OperatorId
                };
                if (success)
                    logEo.ResponseBody = SerializerUtil.SerializeJsonNet(data.Dto);
                else
                    logEo.Exception = SerializerUtil.SerializeJsonNet(ex);
                await _cashAuditLogMo.AddAsync(logEo, tm);
            }
            catch (Exception e)
            {
                LogUtil.Error(e,$"FlowUtil.AddCashAuditLog记录日志异常！");
            }
        }

        /// <summary>
        /// 查询当前运营商编码查询当天数据区间
        /// </summary>
        /// <param name="operatorId"></param>
        /// <returns></returns>
        public static (DateTime startTime, DateTime endTime) GetDBTimeInterval(string operatorId)
        {
            var utcTime = DateTime.UtcNow;
            (DateTime startTime, DateTime endTime) ret = new(utcTime, utcTime);

            var countryEo = DbCacheUtil.GetCountryByOperatorId(operatorId);
            var localTime = utcTime.AddHours(countryEo.TimeZone);
            var timeZoneAbs = Math.Abs(countryEo.TimeZone);

            ret.startTime = new DateTime(localTime.Year, localTime.Month, localTime.Day, timeZoneAbs, 0, 0);
            ret.endTime = ret.startTime.AddDays(1);

            return ret;
        }

        /// <summary>
        /// 获取提现配置
        /// </summary>
        /// <param name="operatorId">运营商编码</param>
        /// <param name="currencyId">货币编码</param>
        /// <returns>提现审批起始金额、最小提现金额</returns>
        public static async Task<Lobby.Flow.DAL.Sc_cash_configEO> GetCashConfig(string operatorId, string currencyId)
        {
            if (string.IsNullOrWhiteSpace(operatorId) || string.IsNullOrWhiteSpace(currencyId))
            {
                throw new CustomException("operatorId or currencyId is not empty.");
            }

            //var field = Caching.CashConfigDCache.GetField(operatorId, currencyId);

            //var cashConfig = await new Caching.CashConfigDCache().GetOrLoadAsync(field);

            //if (!cashConfig.HasValue)
            //{
            //    throw new CustomException("Withdraw Configuration not found");
            //}
            var cashConfig = DbCachingUtil.GetSingle<Sc_cash_configPO>(it => new {it.OperatorID,it.CurrencyID }, new {
                OperatorID=operatorId,
                CurrencyID=currencyId
            });
            return cashConfig;
            //return cashConfig.Value;
        }

        /// <summary>
        /// 获取充值、提现渠道
        /// </summary>
        /// <param name="operatorId"></param>
        /// <param name="currencyId"></param>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public static async Task<BraPayChannelEnum> GetPayChannel(string operatorId, string currencyId, string countryId)
        {
            //默认渠道tejeepay
            var ret = BraPayChannelEnum.letspay;
            switch (countryId)
            {
                case "MEX":
                    ret = BraPayChannelEnum.letspay;
                    break;
                default:
                    break;
            }
            //bank记录的所有支付记录成功or失败次数记录
            var bankErrorDic = await Common.FlowUtil.GetAllBankChannel();
            //var payConfigEoList = await new Caching.PayConfigDCache().GetAsync(operatorId, currencyId);
            var payConfigEoList = DbCachingUtil.GetList(()=>new L_pay_configPO{
              OperatorID=operatorId,
              CurrencyID=currencyId
            });
            
            //bank缓存没有数据
            if (bankErrorDic == null || bankErrorDic.Count == 0 || bankErrorDic.Keys.Count == 0)
            {
                if (!payConfigEoList.Any())
                    return ret;

                //默认取第一条主渠道
                var payConfigEo = payConfigEoList.Where(d => d.IsMainChannel)?.FirstOrDefault();
                //如果没有设置主渠道，则直接获取最新的支付渠道
                if (payConfigEo == null)
                {
                    payConfigEo = payConfigEoList.OrderByDescending(d => d.Channels).FirstOrDefault();
                }

                var payConfigEoChannel = payConfigEo.ChannelsDesc.ToEnumN<BraPayChannelEnum>();
                if (!payConfigEoChannel.HasValue)
                    return ret;
                return payConfigEoChannel.Value;
            }
            //bank缓存有数据
            else
            {
                //如果大厅缺少支付渠道配置，则从缓存拿成功率最高的支付渠道
                if (!payConfigEoList.Any())
                {
                    //值越小成功率越高
                    var bankError = bankErrorDic.OrderBy(d => d.Value).First();
                    var bankErrorEnum = bankError.Key.ToEnumN<BraPayChannelEnum>();
                    if (!bankErrorEnum.HasValue)
                        return ret;
                    return bankErrorEnum.Value;
                }
                else
                {
                    var payConfigChannel = payConfigEoList.Select(d => d.ChannelsDesc).Distinct().ToList();
                    var existsChannel = false;
                    foreach (var item in bankErrorDic.OrderBy(d => d.Value))
                    {
                        var channel = item.Key.ToEnumN<BraPayChannelEnum>();
                        if (!channel.HasValue)
                            continue;

                        if (payConfigChannel.Contains(item.Key))
                        {
                            ret = item.Key.ToEnum<BraPayChannelEnum>();
                            existsChannel = true;
                            break;
                        }
                    }
                    if (!existsChannel)
                        return ret;
                }
            }

            return ret;
        }

        /// <summary>
        /// 获取bank成功率最高的支付渠道
        /// </summary>
        /// <returns></returns>
        public static async Task<Dictionary<string, long>> GetAllBankChannel()
        {
            var ret = new Dictionary<string, long>();

            try
            {
                //bank端支付渠道成功率权重
                return await new Caching.BankErrorDCache().GetAllAsync();
            }
            catch (Exception ex)
            {
                LogUtil.GetContextLogger().AddException(ex).AddMessage($"LobbyUtil.GetAllBankChannel.从缓存获取BankError异常");
                return ret;
            }
        }

        /// <summary>
        /// 获取用户提现需要完成的流水、已完成的流水（只计算正常打码完成的、未完成的订单）
        /// </summary>
        /// <param name="userId"></param>
        /// <param name=""></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        internal static async Task<SumRequireFlow> GetRequireFlows(string userId, TransactionManager tm = null)
        {
            var selectSql = $@"select  
	                                SUM(RequireFlow) as requireFlow,
                                    SUM(CompletedFlow) as completedFlow
                                from s_requireflow_order 
                                where UserID = @UserID
                                and Status in (0,1)";

            var ret = await DbSink.MainDb.ExecSqlSingleAsync<SumRequireFlow>(selectSql, tm, userId);
            return ret;
        }
    }
}
