using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Text;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.Common;
using Xxyy.DAL;
using Xxyy.MQ.Xxyy;
using TinyFx.Data;
using Xxyy.MQ.Bank;
using Lobby.Flow.Common;
using Lobby.Flow.DAL;
using TinyFx.Logging;
using Lobby.Flow.Services.CashServices;
using TinyFx;
using Lobby.Flow.IpoDto;
using Newtonsoft.Json;
using TinyFx.Extensions.RabbitMQ;
using TinyFx.AspNet;
using TinyFx.Net;
using Xxyy.MQ.Lobby.Notify;
using TinyFx.Extensions.AutoMapper;
using UGame.Banks.Client.BLL.Letspay;
using UGame.Banks.Client.BLL.Mlpay;
using UGame.Banks.Client.BLL;
using Lobby.Flow.Services;
using Microsoft.AspNetCore.Mvc;
using TinyFx.Data.SqlSugar;
using Amazon.EC2.Model;
using UGame.Banks.Client.BLL.Bfpay;
using UGame.Banks.Client.BLL.Hubtel;
using Microsoft.AspNetCore.Server.IIS.Core;
using Xxyy.MQ.Lobby;
using MySqlX.XDevAPI.Relational;
using TinyFx.Configuration;

namespace Lobby.Flow
{
    public class FlowCommonService
    {
        protected readonly S_provider_orderMO _provOrderMo = new();
        protected readonly Xxyy.DAL.S_requireflow_orderMO _requireFlowMo;
        protected readonly S_appEO _sappEo;
        protected readonly UserService _userSvc;
        protected readonly V_s_operatorEO _operatorInfo;
        protected readonly GlobalUserDCache _userDCache;
        protected readonly Sc_cash_auditMO _cashAuditMo = new();
        internal readonly FlowCashAuditService _flowCashAuditService = new();
        
        public FlowCommonService(string userId, string appId, string operatorId)
        {
            _userSvc = new UserService(userId);
            _requireFlowMo = _userSvc.GetRequireflowOrderMo();
            _userDCache = new GlobalUserDCache(userId);
            _sappEo = DbCacheUtil.GetApp(appId);
            _operatorInfo = DbCacheUtil.GetOperator(operatorId);
        }
        protected virtual Task UserBetExecute(UserBetMsg message, TransactionManager tm)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 用户货币变化时流水处理
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public virtual async Task DealCurrencyChangeMsg(CurrencyChangeMsg message)
        {
            var currencyType = DbCacheUtil.GetCurrencyType(message.CurrencyId);

            if (!(currencyType == CurrencyType.Cash && message.Amount > 0 && message.FlowMultip > 0))
                return;
            await new RequireFlowService().AddRequireFlowOrder(message);
        }

        public virtual async Task DealUserBetMsg(UserBetMsg message)
        {
            if (message.CurrencyType != CurrencyType.Cash || (message.BetType == 1) || (message.BetType == 4 && message.ReferOrderIds.Count < 1))
                return;

            var tm = new TransactionManager();
            try
            {
                //s_requireflow_order
                //UserService userSvc = new(message.UserId);
                //var requireFlowMo = DbSink.BuildRequireFlowOrderMo(message.UserId);
                var currBonus = await _userSvc.GetBonus();//当前账户的Bonus总额


                //rollBack
                if (message.BetType == 4 && (message.WinAmount < 0 || message.BetAmount < 0))
                {
                    await HandleRollBack(message, _requireFlowMo, currBonus, tm);
                }
                else
                {
                    #region 重新计算bet和win
                    if (!string.IsNullOrEmpty(message.RoundId) && !message.RoundClosed) { return; }
                    var referProviderOrders = new List<S_provider_orderEO>();
                    if (!string.IsNullOrEmpty(message.RoundId))
                    {
                        referProviderOrders = await _provOrderMo.GetAsync("UserID=@userId and AppID=@appId and ProviderID=@providerId and RoundId=@roundId",
                            message.UserId, message.AppId, message.ProviderId, message.RoundId);
                        if (referProviderOrders == null || !referProviderOrders.Any()) return;
                    }
                    else
                    {
                        if (message.BetType == 2 && (message.ReferOrderIds == null || !message.ReferOrderIds.Any())) { return; }
                        if (message.ReferOrderIds != null && message.ReferOrderIds.Any())
                        {
                            foreach (var _referOrderId in message.ReferOrderIds)
                            {
                                var _curProvOrder = await _provOrderMo.GetByPKAsync(_referOrderId);
                                if (_curProvOrder != null)
                                {
                                    referProviderOrders.Add(_curProvOrder);
                                }
                            }
                        }
                    }

                    if (referProviderOrders.Any())
                    {
                        message.BetAmount = referProviderOrders.Sum(p => p.PlanBet);
                        message.BetBonus = referProviderOrders.Sum(p => p.BetBonus);
                        message.WinAmount = referProviderOrders.Sum(p => p.PlanWin);
                        message.WinBonus = referProviderOrders.Sum(p => p.WinBonus);
                    }

                    #endregion

                    if (message.BetAmount <= 0 || message.BetBonus > message.BetAmount) return;//下注金额不合法，直接返回

                    await UserBetExecute(message, tm);
                }

                tm.Commit();
            }
            catch (Exception)
            {
                tm.Rollback();
                throw;
            }
        }

        /// <summary>
        /// 请求提现
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<FlowCashDto> RequestCash(FlowCashIpo flowIpo)
        {
            var ipo = new Services.CashServices.BraWithDrawIpo
            {
                UserId = flowIpo.UserId,
                Channels = flowIpo.Channels,
                Amount = flowIpo.Amount,
                UserBankId = flowIpo.UserBankId,
                AppId = flowIpo.AppId,
                OperatorId = flowIpo.OperatorId,
                LangId = flowIpo.LangId,
                CountryId = flowIpo.CountryId,
                CurrencyId = flowIpo.CurrencyId,
                CashType= flowIpo.CashType,
                TaxId = flowIpo.TaxId,
                AccountNo = flowIpo.AccountNo,
                AdditionalParameters=flowIpo.AdditionalParameters
            };
            var ret = new FlowCashDto();

            ipo.BraPayChannel =await GetPayChannel(ipo); //await Common.FlowUtil.GetPayChannel(ipo.OperatorId, ipo.CurrencyId, ipo.CountryId);

            switch (ipo.BraPayChannel)
            {
                case BraPayChannelEnum.pandapay:
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "cash channel error.");
                case BraPayChannelEnum.tejeepay:
                case BraPayChannelEnum.letspay:
                case BraPayChannelEnum.bfpay:
                case BraPayChannelEnum.mlpay:
                case BraPayChannelEnum.hubtel:
                    ret = await WithDraw(ipo);
                    break;
                default:
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "cash channel error.");
            }
            return ret;
        }

        protected virtual async Task<BraPayChannelEnum> GetPayChannel(BraWithDrawIpo ipo)=> await Common.FlowUtil.GetPayChannel(ipo.OperatorId, ipo.CurrencyId, ipo.CountryId);

        /// <summary>
        /// 巴西提现（tejeePay）
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        private async Task<FlowCashDto> WithDraw(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();

            //初始化ipo，并验证用户基本信息
            await BuildBraWithDrawIpo(ipo);

            //墨西哥充值金额只能是正整数
            if (ipo.CountryId.Equals("MEX") && !StringUtil.IsPositiveInteger(ipo.Amount.ToString()))
            {
                throw new CustomException(FlowResponseCodes.RS_PARAMETER_ERROR, "withdraw.param error.The recharge amount must be a positive integer");
            }

            //var cashService = Services.CashServices.CashServiceFactory<Services.CashServices.BraWithDrawIpo>.CreateCashService(ipo.OperatorId, ipo.CurrencyId);

            ////校验是否满足提现条件
            //await cashService.CheckCashCondition(ipo);
            var cashService = CashValidateServiceFactory.Create(ipo.OperatorId);

            //是否需要审批
            (bool? isAudit, AutoAuditResultEnum autoAuditResult) = await cashService.ValidateCash(ipo);
            var isNeedAudit = (isAudit != null && isAudit.Value) || autoAuditResult == AutoAuditResultEnum.AutoAuditRefused;
            //全局提现开关，默认
            var isGlobalCashAudit = await new Lobby.Flow.Caching.GlobalCashAuditDCache().GetOrDefaultAsync(false);
            if (isGlobalCashAudit)
            {
                isNeedAudit = true;
            }
            if (isNeedAudit)
            {
                return await AuditWithdraw(ipo,autoAuditResult);
            }
            else
            {
                return await DirectWithdraw(ipo);
            }
        }

        private async Task<FlowCashDto> AuditWithdraw(BraWithDrawIpo ipo, AutoAuditResultEnum autoAuditResult)
        {
            var ret = new FlowCashDto{IsAudit = true};
            ipo.Amount = ipo.Amount.MToA(ipo.CurrencyId);
            //1.添加sc_cash_audit订单
            var cashAuditEo = await BuildCashAuditEo(ipo,true);
            var addCashAuditRet = await _cashAuditMo.AddAsync(cashAuditEo, null);
            if (addCashAuditRet <= 0) throw new CustomException("cash failed.");
            var actionData = new CashAuditActionData
            {
                Ipo = ipo,
                Action = 0,
                Dto = ret,
                OperatorId = ipo.UserId,
                TransType = 0,
                RequestTime = DateTime.UtcNow
            };
            TransactionManager tm = new TransactionManager();
            try
            {
                var currencyChangeMsg = await ChangeAmount(ipo,tm);
                if (null == currencyChangeMsg)
                {
                    LogUtil.GetContextLogger().SetLevel( Microsoft.Extensions.Logging.LogLevel.Error).AddMessage($"用户ID：{ipo.UserId}，用户提现审核预扣账户时失败。CashAuditId:{ipo.CashAuditId}");
                    throw new CustomException("cash failed.");
                }
                //update sc_cash_audit
                var cashAuditStatus = (int)CashAuditStatusEnum.Auditing;
                if (autoAuditResult== AutoAuditResultEnum.AutoAuditRefused)
                {
                    cashAuditStatus = (int)CashAuditStatusEnum.AutoReturn;
                }
                cashAuditEo.IsAudit = true;
                cashAuditEo.Status = cashAuditStatus; //(int)CashAuditStatusEnum.Auditing;
                cashAuditEo.AmountBalance = currencyChangeMsg.Amount;
                cashAuditEo.AmountBonus = currencyChangeMsg.Bonus;
                var rows = await _cashAuditMo.PutAsync(cashAuditEo, tm);
                if (rows <= 0)
                    throw new CustomException("cash failed.");
                actionData.Dto = ret;
                await Common.FlowUtil.AddCashAuditLog(cashAuditEo.CashAuditID, null, true, actionData, null);
                ret.Success = true;
                tm.Commit();
                if (null != currencyChangeMsg)
                    await MQUtil.PublishAsync(currencyChangeMsg);
                //发送自动回退处理消息
                if(autoAuditResult== AutoAuditResultEnum.AutoAuditRefused)
                    await MQUtil.FuturePublishAsync(new AutoAuditMsg {
                     Amount= currencyChangeMsg.Amount,
                     Bonus= currencyChangeMsg.Bonus,
                     AppId= currencyChangeMsg.AppId,
                     ChangeTime= currencyChangeMsg.ChangeTime,
                     Coin= currencyChangeMsg.Coin,
                     CountryId= currencyChangeMsg.CountryId,
                     CurrencyId= currencyChangeMsg.CurrencyId,
                     CurrencyType= currencyChangeMsg.CurrencyType,
                     DomainId= currencyChangeMsg.DomainId,
                     EndBalance= currencyChangeMsg.EndBalance,
                     EndBonus= currencyChangeMsg.EndBonus,
                     EndCoin= currencyChangeMsg.EndCoin,
                     FlowMultip = currencyChangeMsg.FlowMultip,
                     FromId= currencyChangeMsg.FromId,
                     FromMode= currencyChangeMsg.FromMode,
                     OperatorId= currencyChangeMsg.OperatorId,
                     Reason= currencyChangeMsg.Reason,
                     SourceId= currencyChangeMsg.SourceId,
                     SourceTable= currencyChangeMsg.SourceTable,
                     SourceType= currencyChangeMsg.SourceType,
                     UserId= currencyChangeMsg.UserId,
                     UserKind=currencyChangeMsg.UserKind
                    }, ConfigUtil.Environment.IsProduction ? TimeSpan.FromHours(24):TimeSpan.FromMinutes(2));
            }
            catch (Exception ex)
            {
                tm.Rollback();
                ret.Success = false;
                ret.Message = ex.Message;
                //
                cashAuditEo.Status = (int)CashAuditStatusEnum.Fail;
                await _cashAuditMo.PutAsync(cashAuditEo, null);
                await Common.FlowUtil.AddCashAuditLog(cashAuditEo.CashAuditID, null, false, actionData, ex);

                if (ex is CustomException)
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, ex.Message);
                else
                    LogUtil.Error($"braWithdraw.提交提款审批失败，ipo:{Newtonsoft.Json.JsonConvert.SerializeObject(ipo)},errorMsg:{ex.Message}");
            }
            return ret;
        }

        private async Task<FlowCashDto> DirectWithdraw(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();
            ipo.Amount = ipo.Amount.MToA(ipo.CurrencyId);
            //0.添加sc_cash_audit订单
            var cashAuditEo = await BuildCashAuditEo(ipo,false);
            var addCashAuditRet = await _cashAuditMo.AddAsync(cashAuditEo, null);
            if (addCashAuditRet <= 0) throw new CustomException("cash failed.");
            var actionData = new CashAuditActionData
            {
                Ipo = ipo,
                Action = 0,
                Dto = ret,
                OperatorId = ipo.UserId,
                TransType = 0,
                RequestTime = DateTime.UtcNow
            };
            var tm = new TransactionManager();

            try
            {
                var currencyChangeMsg = await ChangeAmount(ipo, tm);
                if (null == currencyChangeMsg)
                {
                    LogUtil.GetContextLogger().SetLevel(Microsoft.Extensions.Logging.LogLevel.Error).AddMessage($"用户ID：{ipo.UserId}，用户提现预扣账户时失败。CashAuditId:{ipo.CashAuditId}");
                    throw new CustomException("cash failed.");
                }
                cashAuditEo.IsAudit = false;
                cashAuditEo.RequestTime = DateTime.UtcNow;

                if (ipo.BraPayChannel == Common.BraPayChannelEnum.tejeepay)
                    ret = await TejeeCash(ipo);
                else if (ipo.BraPayChannel == Common.BraPayChannelEnum.letspay)
                    ret = await LetspayCash(ipo);
                else if (ipo.BraPayChannel == Common.BraPayChannelEnum.mlpay)
                    ret = await MlpayCash(ipo);
                else if (ipo.BraPayChannel == Common.BraPayChannelEnum.bfpay)
                    ret = await BfpayCash(ipo);
                else if (ipo.BraPayChannel == BraPayChannelEnum.hubtel)
                    ret = await HubtelCash(ipo);
                else
                    throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, $"Channels error.channel:{ipo.BraPayChannel.ToString()}");
                cashAuditEo.Status = (int)CashAuditStatusEnum.Confirmation;
                cashAuditEo.BankOrderId = ret.OrderId;
                cashAuditEo.AmountBonus = currencyChangeMsg.Bonus;
                cashAuditEo.AmountBalance = currencyChangeMsg.Amount;
                cashAuditEo.ResponseTime = DateTime.UtcNow;
                var rows = await _cashAuditMo.PutAsync(cashAuditEo, tm);
                if (rows <= 0)
                    throw new CustomException("cash failed.");
                actionData.Dto = ret;
                tm.Commit();
                if (null != currencyChangeMsg)
                    await MQUtil.PublishAsync(currencyChangeMsg);
                //await UpdateBraUserBankStatus(ipo.BraUserBankEo);
                await Common.FlowUtil.AddCashAuditLog(cashAuditEo.CashAuditID, null, true, actionData, null);
            }
            catch (Exception ex)
            {
                tm.Rollback();
                cashAuditEo.Status = (int)CashAuditStatusEnum.Fail;
                await _cashAuditMo.PutAsync(cashAuditEo, null);
                await Common.FlowUtil.AddCashAuditLog(cashAuditEo.CashAuditID, null, false, actionData, ex);
                LogUtil.Error(ex, "直接提现处理失败！Ipo:{0},dto:{1}", SerializerUtil.SerializeJsonNet(ipo), SerializerUtil.SerializeJsonNet(ret));
                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, $"direct cash error:{ex.Message}");
            }
            return ret;
        }

        private async Task<FlowCashDto> HubtelCash(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();
            var hubtelChannel = ipo.AdditionalParameters?.GetValueOrDefault("hubtelChannel","").ToString();
            if (string.IsNullOrWhiteSpace(hubtelChannel))
                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, "hubtelchannel can not empty.");
            var request = new UGame.Banks.Client.BLL.Hubtel.XxyyHubtelCashIpo()
            {
                Mobile=null,//233552378058
                Channel =hubtelChannel,//mtn-gh
                AppOrderId = ipo.CashAuditId,
                CountryId = ipo.CountryId,
                UserIp = ipo.UserIp,
                UserId = ipo.UserId,
                Amount = (long)ipo.Amount,
                AppId = ipo.AppId,
                CurrencyId = ipo.CurrencyId,
                CashRate = (decimal)ipo.CashRate
            };
            if (string.IsNullOrWhiteSpace(request.UserIp))
                request.UserIp = AspNetUtil.GetRemoteIpString();

            var globalUserDCache = ipo.GlobalUserDCache ?? await GlobalUserDCache.Create(ipo.UserId);
            var phone = await globalUserDCache.GetMobileAsync();
            var countryId = ipo.CountryId ?? await globalUserDCache.GetCountryIdAsync();
            var callingCode = DbCacheUtil.GetCountry(countryId).CallingCode;
            if (!phone.StartsWith(callingCode) || phone.Length < 12)
            {
                phone = $"{callingCode}{phone}";
            }
            request.Mobile = phone;
            var response = await new UGame.Banks.Client.BLL.Hubtel.HubtelClient().Cash(request);

            var logger = LogUtil.GetContextLogger()
                .SetLevel(Microsoft.Extensions.Logging.LogLevel.Information)
                .AddMessage($"{request.Mobile}通过hubtel,{hubtelChannel}提现，amount:{request.Amount.AToM(ipo.CurrencyId)}")
                .AddField("lobby.req",SerializerUtil.SerializeJsonNet(request))
                .AddField("lobby.rsp",SerializerUtil.SerializeJsonNet(response));
            //LogUtil.Info($"bra提现bfpay.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

            if (response == null
                || response.Status != 200
                || !response.Result.Status.Equals(UGame.Banks.Client.ResponseCodes.RS_OK))
            {
                //LogUtil.Error($"bra提现（bra提现bfpay）.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");
                logger.SetLevel(Microsoft.Extensions.Logging.LogLevel.Error);
                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, response.Result.Message);
            }
            ret = new FlowCashDto
            {
                Amount = response.Result.Amount.AToM(ipo.CurrencyId),
                Balance = response.Result.Balance,
                CurrencyId = response.Result.CurrencyId,
                Message = response.Result.Message,
                Meta = response.Result.Meta,
                OrderId = response.Result.OrderId,
                Status = response.Result.Status,
                UserId = response.Result.UserId
            };
            ret.Success = true;
            return ret;
        }

        /// <summary>
        /// 预扣账户（旧的方式，新的方式通过子类重写）
        /// </summary>
        /// <param name="ipo"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        protected virtual async Task<CurrencyChangeMsg> ChangeAmount(BraWithDrawIpo ipo, TransactionManager tm = null) {
            //写入S_currency_change用户奖励变化表
            var changeMsg = await ipo.CurrencyChangeServices.Add(new CurrencyChangeReq()
            {
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                OperatorId = ipo.OperatorId,
                CurrencyId = ipo.CurrencyId,
                Reason = "提现审核预扣除",
                Amount = (long)(ipo.Amount * -1),
                SourceType = 2,
                SourceTable = "sc_cash_audit",
                SourceId = ipo.CashAuditId,
                ChangeTime = DateTime.UtcNow,
                TM = tm,
                ChangeBalance = CurrencyChangeBalance.FirstBonus
            });
            return changeMsg;
        }


        #region cash辅助方法
        ///// <summary>
        ///// 新版需要重写该方法以更新卡的验证状态
        ///// </summary>
        ///// <param name="userBankIpo"></param>
        ///// <returns></returns>
        //protected virtual async Task UpdateBraUserBankStatus(L_bra_user_bankPO userBankIpo)
        //{
            
        //}

        /// <summary>
        /// 创建Sc_cash_auditEO
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        private async Task<Sc_cash_auditEO> BuildCashAuditEo(BraWithDrawIpo ipo,bool isAudit)
        {
            object requestParam = null;
            if (ipo.BraPayChannel == BraPayChannelEnum.letspay)
            {
                requestParam = new XxyyLetsProxyPayIpo()
                {
                    cashAuditId =isAudit?ipo.CashAuditId:"",
                    accountName = ipo.BraUserBankEo.Name,
                    accountNo = ipo.BraUserBankEo.AccountNumber,
                    bankCode = ipo.CountryId.Equals("MEX") ? ipo.BraUserBankEo.BankCode : ipo.BraUserBankEo.AccountType,
                    email = string.IsNullOrWhiteSpace(ipo.UserEo.Email) ? "test@lucro777.com" : ipo.UserEo.Email,
                    phone = string.IsNullOrWhiteSpace(ipo.UserEo.Mobile) ? "12345678901" : ipo.UserEo.Mobile,
                    cpf = ipo.BraUserBankEo.AccountNumber,
                    Amount = (long)ipo.Amount,
                    UserId = ipo.UserId,
                    AppId = ipo.AppId,
                    CurrencyId = ipo.CurrencyId,
                    UserIp = ipo.UserIp,
                    //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
                    CashRate = (decimal)ipo.CashRate,
                    CountryId = ipo.CountryId,
                    taxId = ipo.BraUserBankEo.TaxId,
                    mode = "bank",
                    AppOrderId=ipo.CashAuditId
                };
            }
            else if (ipo.BraPayChannel == BraPayChannelEnum.mlpay)
            {
                requestParam = new XxyyMlpayCashIpo()
                {
                    CashAuditId =isAudit?ipo.CashAuditId:"",
                    AccountName = ipo.BraUserBankEo.Name,
                    AccountNo = ipo.BraUserBankEo.AccountNumber,
                    BankCode = ipo.CountryId.Equals("MEX") ? ipo.BraUserBankEo.BankCode : ipo.BraUserBankEo.AccountType,
                    Email = string.IsNullOrWhiteSpace(ipo.UserEo.Email) ? "test@lucro777.com" : ipo.UserEo.Email,
                    Phone = string.IsNullOrWhiteSpace(ipo.UserEo.Mobile) ? "12345678901" : ipo.UserEo.Mobile,
                    Amount = (long)ipo.Amount,
                    UserId = ipo.UserId,
                    AppId = ipo.AppId,
                    CurrencyId = ipo.CurrencyId,
                    UserIp = ipo.UserIp,
                    //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
                    CashRate = (decimal)ipo.CashRate,
                    CountryId = ipo.CountryId,
                    TaxId = ipo.BraUserBankEo.TaxId,
                    AppOrderId=ipo.CashAuditId
                };
            }
            else if (ipo.BraPayChannel == BraPayChannelEnum.bfpay)
            {
                requestParam = new XxyyBfpayCashIpo()
                {
                    CashAuditId = isAudit ? ipo.CashAuditId : "",
                    AccountName = ipo.BraUserBankEo.Name,
                    AccountNo = ipo.BraUserBankEo.AccountNumber,
                    //BankCode = ipo.CountryId.Equals("MEX") ? ipo.BraUserBankEo.BankCode : ipo.BraUserBankEo.AccountType,
                    Email = string.IsNullOrWhiteSpace(ipo.UserEo.Email) ? "test@lucro777.com" : ipo.UserEo.Email,
                    Phone = string.IsNullOrWhiteSpace(ipo.UserEo.Mobile) ? "12345678901" : ipo.UserEo.Mobile,
                    Amount = (long)ipo.Amount,
                    UserId = ipo.UserId,
                    AppId = ipo.AppId,
                    CurrencyId = ipo.CurrencyId,
                    UserIp = ipo.UserIp,
                    //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
                    CashRate = (decimal)ipo.CashRate,
                    CountryId = ipo.CountryId,
                    TaxId = ipo.BraUserBankEo.TaxId,
                    AppOrderId = ipo.CashAuditId,
                    CertType = (int)ipo.BraUserBankEo.AccountType.ToEnumN<TejeePayMethodEnum>(),
                    CertId = ipo.BraUserBankEo.AccountNumber,
                    BankCardNo = ipo.BraUserBankEo.AccountNumber,
                    BankCardName = ipo.BraUserBankEo.Name,
                    BankCode = ipo.BraUserBankEo.BankCode,
                
                };
            }
            else if(ipo.BraPayChannel== BraPayChannelEnum.hubtel)
            {
                var hubtelChannel = ipo.AdditionalParameters?.GetValueOrDefault("hubtelChannel", "").ToString();
                if (string.IsNullOrWhiteSpace(hubtelChannel))
                    throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, "hubtelchannel can not empty.");
                var request = new XxyyHubtelCashIpo()
                {
                    Mobile=null,
                    Channel=hubtelChannel,
                    AppOrderId = ipo.CashAuditId,
                    CountryId = ipo.CountryId,
                    UserIp = ipo.UserIp,
                    UserId = ipo.UserId,
                    Amount = (long)ipo.Amount,
                    AppId = ipo.AppId,
                    CurrencyId = ipo.CurrencyId,
                    //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
                    CashRate = (decimal)ipo.CashRate,
                    CashAuditId = isAudit ? ipo.CashAuditId : ""
                };
                if (string.IsNullOrWhiteSpace(request.UserIp))
                    request.UserIp = AspNetUtil.GetRemoteIpString();
                var globalUserDCache = ipo.GlobalUserDCache ?? await GlobalUserDCache.Create(ipo.UserId);
                var phone = await globalUserDCache.GetMobileAsync();
                var countryId = ipo.CountryId ?? await globalUserDCache.GetCountryIdAsync();
                var callingCode = DbCacheUtil.GetCountry(countryId).CallingCode;
                if (!phone.StartsWith(callingCode) || phone.Length < 12)
                {
                    phone = $"{callingCode}{phone}";
                }
                request.Mobile = phone;
                requestParam = request;
            }
            else
            {


                switch (ipo.CountryId)
                {
                    case "BRA":
                        requestParam = new UGame.Banks.Client.BLL.Tejeepay.XxyyTejeeProxyPayIpo()
                        {
                            UserId = ipo.UserId,
                            AppId = ipo.AppId,
                            CurrencyId = ipo.CurrencyId,
                            Amount = (long)ipo.Amount,
                            UserIp = AspNetUtil.GetRemoteIpString(),
                            Mobile = await ipo.GlobalUserDCache.GetMobileAsync(),
                            Email = await ipo.GlobalUserDCache.GetEmailAsync(),
                            CashRate = (decimal)ipo.CashRate,
                            BankCardNo = ipo.BraUserBankEo.AccountNumber,
                            BankCardName = ipo.BraUserBankEo.Name,
                            BankCode = ipo.BraUserBankEo.BankCode,
                            BizEnum = 0,
                            CertType = (int)ipo.BraUserBankEo.AccountType.ToEnumN<TejeePayMethodEnum>(),
                            CertId = ipo.BraUserBankEo.AccountNumber,
                            CashAuditId =isAudit?ipo.CashAuditId:"",
                            CountryId = ipo.CountryId,
                            AppOrderId=ipo.CashAuditId
                        };
                        break;
                    case "MEX":
                        requestParam = new UGame.Banks.Client.BLL.Tejeepay.XxyyTejeeProxyPayIpo()
                        {
                            UserId = ipo.UserId,
                            AppId = ipo.AppId,
                            CurrencyId = ipo.CurrencyId,
                            Amount = (long)ipo.Amount,
                            UserIp = AspNetUtil.GetRemoteIpString(),
                            Mobile = await ipo.GlobalUserDCache.GetMobileAsync(),
                            Email = await ipo.GlobalUserDCache.GetEmailAsync(),
                            CashRate = (decimal)ipo.CashRate,
                            BankCardNo = ipo.BraUserBankEo.AccountNumber,
                            BankCardName = ipo.BraUserBankEo.Name,
                            BankCode = ipo.BraUserBankEo.BankCode,
                            BizEnum = 1,
                            CashAuditId =isAudit? ipo.CashAuditId:"",
                            CountryId = ipo.CountryId,
                            AppOrderId = ipo.CashAuditId
                        };
                        break;
                    default:
                        break;
                }
            }
            
            var cashAudit= new Sc_cash_auditEO()
            {
                CashAuditID = ipo.CashAuditId,
                UserID = ipo.UserId,
                OperatorID = ipo.OperatorId,
                CountryID = ipo.CountryId,
                CurrencyID = ipo.CurrencyId,
                AppID = ipo.AppId,
                Mobile = ipo.UserEo.Mobile,
                Amount = (long)ipo.Amount,
                BankCode = ipo?.BraUserBankEo?.BankCode,
                BankName = ipo?.BraUserBankEo?.BankName,
                AccName = ipo?.BraUserBankEo?.Name,
                AccNumber = ipo?.BraUserBankEo?.AccountNumber,
                Status = (int)CashAuditStatusEnum.Init,
                Paytype = (int)ipo.BraPayChannel,
                BankID = ipo.BraPayChannel.ToString(),
                RequestParam = JsonConvert.SerializeObject(requestParam),
                ApplyTime = DateTime.UtcNow,
                FromMode = ipo.UserEo.FromMode,
                FromId = ipo.UserEo.FromId,
                //如果是长线版本，是需要扣除手续费的，根据当前的vip等级捞取对应的手续费配置
                CashRate = ipo.CashRate,
                UserBankID=ipo?.BraUserBankEo?.UserBankID
            };
            if(ipo.CountryId=="GHA"&&string.IsNullOrWhiteSpace(cashAudit.AccNumber))
                cashAudit.AccNumber = cashAudit.Mobile;
            return cashAudit;
        }

        private async Task<BraWithDrawIpo> BuildBraWithDrawIpo(BraWithDrawIpo ipo)
        {
            ipo.GlobalUserDCache = await GlobalUserDCache.Create(ipo.UserId);
            ipo.OperatorId = await ipo.GlobalUserDCache.GetOperatorIdAsync();
            ipo.CurrencyId = await ipo.GlobalUserDCache.GetCurrencyIdAsync();
            ipo.CountryId = await ipo.GlobalUserDCache.GetCountryIdAsync();

            //校验用户税号、户名是否存在
            //await CheckBraUser(ipo);

            //校验银行卡
            await CheckBraUserBank(ipo);

            //校验s_user_ex是否存在用户数据
            await CheckUserEx(ipo);

            ipo.CommonUserServices = _userSvc; //new Xxyy.Common.Services.UserService(ipo.UserId);
            ipo.CurrencyChangeServices = new CurrencyChangeService(ipo.UserId);
            ipo.UserEo = await DbSink.BuildUserMo(ipo.UserId).GetByPKAsync(ipo.UserId);

            ipo.UserIp = AspNetUtil.GetRemoteIpString();

            ipo.CashAuditId = ObjectId.NewId();

            ipo.CashConditionConfigEoList = Caching.DbCacheUtil.GetAllCashConditionConfig(ipo.OperatorId, ipo.CurrencyId);

            ipo.SOperatorEO = DbCacheUtil.GetOperator(ipo.OperatorId);

            return ipo;
        }

        /// <summary>
        /// 校验银行卡
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        protected virtual async  Task CheckBraUserBank(BraWithDrawIpo ipo)
        {
            if (ipo.CountryId == "GHA")
                return;
            var braUserBankDCache = new Caching.BraUserBankDCache(ipo.OperatorId, ipo.UserId);
            var braUserBank = await braUserBankDCache.GetOrLoadAsync();

            if (!braUserBank.HasValue)
                throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "No bank card added.");

            if (!braUserBank.Value.Any(d => d.UserBankID.Equals(ipo.UserBankId)))
                throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "Bank card not found.");

            ipo.BraUserBankEoList = braUserBank.Value;
            ipo.BraUserBankEo = braUserBank.Value.Where(d => d.UserBankID.Equals(ipo.UserBankId)).FirstOrDefault();

            //if (!ipo.BraUserBankEo.BankChannel.Equals(ipo.BraPayChannel.ToString()))
            //    throw new CustomException(ResponseCodes.RS_UNKNOWN, "BankId and Channels do not match.");
        }

        private async Task CheckUserEx(BraWithDrawIpo ipo)
        {

            var userExMo = DbSink.BuildUserExMo(ipo.UserId);

            var userExEo = await userExMo.GetSingleAsync("UserID = @UserID", ipo.UserId);

            if (userExEo == null)
                throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "Data does not exist.");

            ipo.UserExEo = userExEo;
        }

        /// <summary>
        /// tejee直接提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task<FlowCashDto> TejeeCash(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();

            var globalUserDCache = await GlobalUserDCache.Create(ipo.UserId);

            var request = new UGame.Banks.Client.BLL.Tejeepay.XxyyTejeeProxyPayIpo()
            {
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                AppOrderId=ipo.CashAuditId,
                CurrencyId = ipo.CurrencyId,
                Amount = (long)ipo.Amount,
                UserIp = AspNetUtil.GetRemoteIpString(),
                Mobile = await globalUserDCache.GetMobileAsync(),
                Email = await globalUserDCache.GetEmailAsync(),
                CashRate = (decimal)ipo.CashRate,
                BankCardNo = ipo.BraUserBankEo.AccountNumber,
                BankCardName = ipo.BraUserBankEo.Name,
                BankCode = ipo.BraUserBankEo.BankCode,
                CountryId = ipo.CountryId
            };

            switch (ipo.CountryId)
            {
                case "BRA":
                    request.BizEnum = 0;
                    request.CertType = (int)ipo.BraUserBankEo.AccountType.ToEnumN<TejeePayMethodEnum>();
                    request.CertId = ipo.BraUserBankEo.AccountNumber;
                    break;
                case "MEX":
                    request.BizEnum = 1;
                    break;
                default:
                    break;
            }

            var xxyyBankClient = new UGame.Banks.Client.BLL.Tejeepay.TejeepayClient();

            var response = await xxyyBankClient.TejeeCash(request);

            LogUtil.Info($"tejeePay提现.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

            if (response.Status != 200 || !response.Result.Status.Equals("SUCCESS"))
            {
                LogUtil.Error($"tejeePay提现.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, response.Message);
            }
            ret = new FlowCashDto
            {
                Amount = response.Result.Amount.AToM(ipo.CurrencyId),
                Balance = response.Result.Balance,
                CurrencyId = response.Result.CurrencyId,
                Message = response.Result.Message,
                Meta = response.Result.Meta,
                OrderId = response.Result.OrderId,
                Status = response.Result.Status,
                UserId = response.Result.UserId
            };
            //ret = response.Result.Map<FlowCashDto>();
            ret.Success = true;
            return ret;
        }

        /// <summary>
        /// letspay直接提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task<FlowCashDto> LetspayCash(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();
            var request = new UGame.Banks.Client.BLL.Letspay.XxyyLetsProxyPayIpo()
            {
                accountName = ipo.BraUserBankEo.Name,
                accountNo = ipo.BraUserBankEo.AccountNumber,
                bankCode = ipo.BraUserBankEo.AccountType,
                email = string.IsNullOrWhiteSpace(ipo.UserEo.Email) ? "test@lucro777.com" : ipo.UserEo.Email,
                phone = string.IsNullOrWhiteSpace(ipo.UserEo.Mobile) ? "12345678901" : ipo.UserEo.Mobile,
                cpf = ipo.BraUserBankEo.AccountNumber,
                Amount = (long)ipo.Amount,
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                AppOrderId=ipo.CashAuditId,
                CurrencyId = ipo.CurrencyId,
                UserIp = AspNetUtil.GetRemoteIpString(),
                CashRate = (decimal)ipo.CashRate,
                CountryId = ipo.CountryId,
                taxId = ipo.BraUserBankEo.TaxId,
                mode = "bank"
            };

            ApiResult<UGame.Banks.Client.BLL.BaseDto> response = null;

            switch (ipo.CountryId)
            {
                case "MEX":
                    response = await new UGame.Banks.Client.BLL.Letspay.LetspayClient().LetsCashMex(request);
                    break;
                case "BRA":
                    response = await new UGame.Banks.Client.BLL.Letspay.LetspayClient().LetsCash(request);
                    break;
                default:
                    LogUtil.Info($"bra提现（bra提现letspay）,request:{JsonConvert.SerializeObject(request)},用户国家编码异常:{ipo.CountryId}");
                    throw new CustomException("Abnormal country code");
            }

            LogUtil.Info($"bra提现letspay.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

            if (response == null
                || response.Status != 200
                || !response.Result.Status.Equals(UGame.Banks.Client.ResponseCodes.RS_OK))
            {
                LogUtil.Error($"bra提现（bra提现letspay）.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, response.Result.Message);
            }

            //ret = response.Result.Map<FlowCashDto>();
            ret = new FlowCashDto
            {
                Amount = response.Result.Amount.AToM(ipo.CurrencyId),
                Balance = response.Result.Balance,
                CurrencyId = response.Result.CurrencyId,
                Message = response.Result.Message,
                Meta = response.Result.Meta,
                OrderId = response.Result.OrderId,
                Status = response.Result.Status,
                UserId = response.Result.UserId
            };
            ret.Success = true;
            return ret;
        }

        /// <summary>
        /// mlpay直接提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task<FlowCashDto> MlpayCash(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();
            var request = new UGame.Banks.Client.BLL.Mlpay.XxyyMlpayCashIpo()
            {
                AccountName = ipo.BraUserBankEo.Name,
                AccountNo = ipo.BraUserBankEo.AccountNumber,
                BankCode = ipo.BraUserBankEo.AccountType,
                Email = string.IsNullOrWhiteSpace(ipo.UserEo.Email) ? "test@lucro777.com" : ipo.UserEo.Email,
                Phone = string.IsNullOrWhiteSpace(ipo.UserEo.Mobile) ? "12345678901" : ipo.UserEo.Mobile,
                //Cpf = ipo.BraUserBankEo.AccountNumber,
                Amount = (long)ipo.Amount,
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                AppOrderId=ipo.CashAuditId,
                CurrencyId = ipo.CurrencyId,
                UserIp = AspNetUtil.GetRemoteIpString(),
                CashRate = (decimal)ipo.CashRate,
                CountryId = ipo.CountryId,
                TaxId = ipo.BraUserBankEo.TaxId
            };

            var response = await new UGame.Banks.Client.BLL.Mlpay.MlpayClient().MlpayCash(request);

            LogUtil.Info($"bra提现mlpay.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

            if (response == null
                || response.Status != 200
                || !response.Result.Status.Equals(UGame.Banks.Client.ResponseCodes.RS_OK))
            {
                LogUtil.Error($"bra提现（bra提现mlpay）.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, response.Result.Message);
            }
            ret = new FlowCashDto
            {
                Amount = response.Result.Amount.AToM(ipo.CurrencyId),
                Balance = response.Result.Balance,
                CurrencyId = response.Result.CurrencyId,
                Message = response.Result.Message,
                Meta = response.Result.Meta,
                OrderId = response.Result.OrderId,
                Status = response.Result.Status,
                UserId = response.Result.UserId
            };
            //ret = response.Result.Map<FlowCashDto>();
            ret.Success = true;
            return ret;
        }

        /// <summary>
        /// mlpay直接提现
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        /// <exception cref="CustomException"></exception>
        private async Task<FlowCashDto> BfpayCash(BraWithDrawIpo ipo)
        {
            var ret = new FlowCashDto();
            var request = new UGame.Banks.Client.BLL.Bfpay.XxyyBfpayCashIpo()
            {
                AccountName = ipo.BraUserBankEo.Name,
                AccountNo = ipo.BraUserBankEo.AccountNumber,
                BankCode = ipo.BraUserBankEo.AccountType,
                Email = string.IsNullOrWhiteSpace(ipo.UserEo.Email) ? "test@lucro777.com" : ipo.UserEo.Email,
                Phone = string.IsNullOrWhiteSpace(ipo.UserEo.Mobile) ? "12345678901" : ipo.UserEo.Mobile,
                //Cpf = ipo.BraUserBankEo.AccountNumber,
                Amount = (long)ipo.Amount,
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                AppOrderId = ipo.CashAuditId,
                CurrencyId = ipo.CurrencyId,
                UserIp = AspNetUtil.GetRemoteIpString(),
                CashRate = (decimal)ipo.CashRate,
                CountryId = ipo.CountryId,
                TaxId = ipo.BraUserBankEo.TaxId,
                BankCardNo = ipo.BraUserBankEo.AccountNumber,
                BankCardName = ipo.BraUserBankEo.Name,
          
            };
            switch (ipo.CountryId)
            {
                case "BRA":
                    request.CertType = (int)ipo.BraUserBankEo.AccountType.ToEnumN<TejeePayMethodEnum>();
                    request.CertId = ipo.BraUserBankEo.AccountNumber;
                    break;
                //case "MEX":
                //    request.BizEnum = 1;
                //    break;
                default:
                    break;
            }

            var response = await new UGame.Banks.Client.BLL.Bfpay.BfpayClient().BfpayCash(request);

            LogUtil.Info($"bra提现bfpay.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

            if (response == null
                || response.Status != 200
                || !response.Result.Status.Equals(UGame.Banks.Client.ResponseCodes.RS_OK))
            {
                LogUtil.Error($"bra提现（bra提现bfpay）.request:{JsonConvert.SerializeObject(ipo)},response:{JsonConvert.SerializeObject(response)}");

                throw new CustomException(FlowResponseCodes.RS_CASH_ERROR, response.Result.Message);
            }
            ret = new FlowCashDto
            {
                Amount = response.Result.Amount.AToM(ipo.CurrencyId),
                Balance = response.Result.Balance,
                CurrencyId = response.Result.CurrencyId,
                Message = response.Result.Message,
                Meta = response.Result.Meta,
                OrderId = response.Result.OrderId,
                Status = response.Result.Status,
                UserId = response.Result.UserId
            };
            //ret = response.Result.Map<FlowCashDto>();
            ret.Success = true;
            return ret;
        }
        #endregion



        /// <summary>
        /// 处理提现消息
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task DealUserCashMsg(UserCashMsg message)
        {
            var actionData = new CashAuditActionData
            {
                Action = (int)CashAuditStatusEnum.Success,
                Ipo = message,
                Dto = true,
                OperatorId = message.UserId,
                RequestTime = DateTime.UtcNow,
                TransType = 1
            };
            int rows = 0;
            var tm = new TransactionManager();
            try
            {
                if (message.Status == 0)
                {
                    //1
                    rows = await _cashAuditMo.PutAsync("Status=@status,AuditTime=@AuditTime,BankOrderId=@BankOrderId,CallbackTime=@CallbackTime", "CashAuditID=@CashAuditID and status<=@oldstatus", tm, (int)CashAuditStatusEnum.Success, actionData.RequestTime,message.OrderID,actionData.RequestTime, message.AppOrderId,(int)CashAuditStatusEnum.Confirmation);
                    if (rows <= 0)
                        throw new Exception($"提现成功更新sc_cash_audit状态失败！CashAuditID:{message.AppOrderId}");
                    //2
                    await FlowUtil.AddCashAuditLog(message.AppOrderId, null, true, actionData, null);
                }
                else
                {
                    var cashAuditEo = await _cashAuditMo.GetByPKAsync(message.AppOrderId, tm);
                    if (null == cashAuditEo||cashAuditEo.Status>(int)CashAuditStatusEnum.Confirmation)
                        throw new Exception($"没有找到该提现订单或该订单状态异常！CashAuditId:{message.AppOrderId}，status:{cashAuditEo?.Status}");

                    var changeAmount = Math.Abs(cashAuditEo.AmountBalance);
                    var bonusAmount = Math.Abs(cashAuditEo.AmountBonus);
                    var ret = await _userSvc.UpdateBalance(message.CurrencyId, changeAmount, tm, bonusAmount);
                    if (!ret)
                        throw new Exception($"提现失败,更新s_user账户失败！CashAuditId:{message.AppOrderId}");
                    //s_currency_change
                    var balanceInfo = await _userSvc.GetBalanceInfo(tm, true);
                    var appEo = DbCacheUtil.GetApp(cashAuditEo.AppID);
                    var eo = new S_currency_changeEO
                    {
                        ChangeID = ObjectId.NewId(),
                        ProviderID = appEo.ProviderID,
                        AppID = message.AppId,
                        OperatorID = message.OperatorId,
                        UserID = message.UserId,
                        FromMode = await _userDCache.GetFromModeAsync(),
                        FromId = await _userDCache.GetFromIdAsync(),
                        DomainID = await _userDCache.GetDomainIdAsync(),
                        UserKind = message.UserKind,
                        CountryID = message.CountryId,
                        CurrencyID = message.CurrencyId,
                        CurrencyType = (int)DbCacheUtil.GetCurrencyType(message.CurrencyId),
                        IsBonus = false, //TODO 已失效
                        FlowMultip = 0,
                        Reason = "提现失败,回退账户余额",
                        PlanAmount = changeAmount,
                        Meta = null,
                        SourceType = 300009,
                        SourceTable = "sc_cash_audit",
                        SourceId = cashAuditEo.CashAuditID,
                        UserIp = "",
                        Status = (int)OrderStatus.Success,
                        RecDate = actionData.RequestTime,
                        DealTime = actionData.RequestTime,
                        Amount = changeAmount,
                        EndBalance = balanceInfo.Balance,
                        AmountBonus = bonusAmount,
                        EndBonus = balanceInfo.Bonus,
                    };
                    if (await new S_currency_changeMO().AddAsync(eo, tm) != 1)
                        throw new Exception($"CurrencyChangeService：{eo.Reason}，提现失败写入流水表s_currency_change出错");

                    rows = await _cashAuditMo.PutAsync("Status=@status,AuditTime=@AuditTime,BankOrderId=@BankOrderId,CallbackTime=@CallbackTime", "CashAuditID=@CashAuditID and Status=@oldstatus", tm, (int)CashAuditStatusEnum.Fail,actionData.RequestTime,message.OrderID,actionData.RequestTime, cashAuditEo.CashAuditID, cashAuditEo.Status);
                    if (rows <= 0)
                        throw new Exception($"收到用户提现失败消息，回滚处理失败！CashAuditId:{message.AppOrderId}");

                    actionData.Action = (int)CashAuditStatusEnum.Fail;
                    await FlowUtil.AddCashAuditLog(message.AppOrderId, null, false, actionData, null);
                }
                tm.Commit();
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error(ex, "InheritingCommonFlowService.usercash处理异常！");
                throw;
            }
        }

        /// <summary>
        /// 获取可体现额
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currencyId"></param>
        /// <param name="operatorId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public virtual async Task<decimal> GetAllowCashMoney(string userId, string currencyId, TransactionManager tm = null)
        {
            long ret = 0;
            var requireFlowOrder = await _requireFlowMo.GetSingleAsync("UserID = @UserID and Status = 0", tm, userId);
            if (requireFlowOrder == null)
                ret = await _userSvc.GetBalance(currencyId, tm, true);

            return ret.AToM(currencyId);
        }

        internal virtual async Task<SumRequireFlow> GetRequireFlows()=> await FlowUtil.GetRequireFlows(_userSvc.UserId);

        /// <summary>
        /// 获取流水打码进度
        /// </summary>
        /// <returns></returns>
        public virtual async Task<FlowProgressDto> GetFlowProgress()
        {
            var ret=new FlowProgressDto() { 
             FlowOrder=new FlowProgressDto.ProgressRequireFlowOrder()
            };
            ret.CashMoney = await this.GetAllowCashMoney(_userSvc.UserId, _operatorInfo.CurrencyID);
            var flow =await GetRequireFlows();
            ret.FlowOrder.RequireFlow = (flow?.RequireFlow ?? 0).AToM(_operatorInfo.CurrencyID);
            ret.FlowOrder.CompletedFlow = (flow?.CompletedFlow ?? 0).AToM(_operatorInfo.CurrencyID);
            if (ret.CashMoney > 0)
                ret.FlowOrder.CompletedFlow = ret.FlowOrder.RequireFlow;
            return ret;
        }

        /// <summary>
        /// 提现后台审核
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        public async virtual Task<bool> CashAudit(FlowCashAuditIpo ipo)
        {
            var ret = await _flowCashAuditService.CashAudit(ipo,_cashAuditMo,_operatorInfo);
            return ret;
        }

        

        #region 内部方法
        /// <summary>
        /// 回滚消息处理
        /// </summary>
        /// <returns></returns>
        private async Task HandleRollBack(UserBetMsg message, Xxyy.DAL.S_requireflow_orderMO requireFlowMo, long currBonus, TransactionManager tm)
        {
            if (message.BetType != 4) return;
            var rollBackedOrder = await _provOrderMo.GetByPKAsync(message.ReferOrderIds[0]);//被回滚的订单
            if (rollBackedOrder == null) { return; }
            var userDCache = new GlobalUserDCache(message.UserId);
            if (message.BetBonus < 0 && Math.Abs(message.WinBonus) - Math.Abs(message.BetBonus) < 0)
            {
                var rollbackBonus = Math.Abs(Math.Abs(message.WinBonus) - Math.Abs(message.BetBonus));
                var requireFlowOrder = await requireFlowMo.GetTopSortAsync($"UserID='{message.UserId}' and IsBonus=1 ", 1, "UpdateTime desc");
                if (requireFlowOrder == null || requireFlowOrder.Count < 1) return;
                var orderEo = new Xxyy.DAL.S_requireflow_orderEO
                {
                    OrderID = ObjectId.NewId(),
                    ProviderID = rollBackedOrder.ProviderID,
                    AppID = rollBackedOrder.AppID,
                    OperatorID = message.OperatorId,
                    UserID = message.UserId,
                    UserKind = (int)await userDCache.GetUserKindAsync(),
                    CountryID = await userDCache.GetCountryIdAsync(),
                    CurrencyID = message.CurrencyId,
                    CurrencyType = (int)DbCacheUtil.GetCurrencyType(message.CurrencyId),
                    IsBonus = true,
                    FlowMultip = requireFlowOrder[0].FlowMultip,
                    OrderAmount = rollbackBonus,
                    OrderRemain = rollbackBonus,
                    RequireFlow = (long)(Math.Abs(message.BetBonus) * requireFlowOrder[0].FlowMultip),
                    EndBonus = currBonus + Math.Abs(message.BetBonus),
                    Status = requireFlowOrder[0].FlowMultip > 0 ? 0 : 1,
                    RecDate = DateTime.UtcNow,
                    EndBonusList = $"+{Math.Abs(message.BetBonus)}",
                    UpdateTime = DateTime.UtcNow,
                    BonusReason = "回滚",
                    BonusSourceType = requireFlowOrder[0].BonusSourceType
                };
                if (await requireFlowMo.AddAsync(orderEo, tm) < 1)
                    throw new Exception("RollBack后添加新的bonus流水订单失败");
            }
            if (Math.Abs(message.WinAmount) - Math.Abs(message.BetAmount) < 0)
            {
                var rollbackCash = Math.Abs(Math.Abs(message.WinAmount) - Math.Abs(message.BetAmount));

                if (Math.Abs(message.BetBonus) < Math.Abs(message.BetAmount))
                {
                    var _rollbackBonus = Math.Abs(Math.Abs(message.WinBonus) - Math.Abs(message.BetBonus));
                    rollbackCash = rollbackCash - _rollbackBonus;//去掉回滚金额中的bonus额度
                }
                var requireFlowOrder = await requireFlowMo.GetTopSortAsync($"UserID='{message.UserId}' and IsBonus=0 ", 1, "UpdateTime desc");
                if (requireFlowOrder == null || requireFlowOrder.Count < 1) return;
                var orderEo = new Xxyy.DAL.S_requireflow_orderEO
                {
                    OrderID = ObjectId.NewId(),
                    ProviderID = rollBackedOrder.ProviderID,
                    AppID = rollBackedOrder.AppID,
                    OperatorID = message.OperatorId,
                    UserID = message.UserId,
                    UserKind = (int)await userDCache.GetUserKindAsync(),
                    CountryID = await userDCache.GetCountryIdAsync(),
                    CurrencyID = message.CurrencyId,
                    CurrencyType = (int)DbCacheUtil.GetCurrencyType(message.CurrencyId),
                    IsBonus = false,
                    FlowMultip = requireFlowOrder[0].FlowMultip,
                    OrderAmount = rollbackCash,
                    OrderRemain = rollbackCash,
                    RequireFlow = (long)(rollbackCash * requireFlowOrder[0].FlowMultip),
                    EndBonus = currBonus + Math.Abs(message.BetBonus),
                    Status = requireFlowOrder[0].FlowMultip > 0 ? 0 : 1,
                    BonusReason = "回滚",
                    RecDate = DateTime.UtcNow,
                    UpdateTime = DateTime.UtcNow
                };
                if (await requireFlowMo.AddAsync(orderEo, tm) < 1)
                    throw new Exception("RollBack后添加新的真金流水订单失败");
            }
        }

        #endregion

        public async virtual Task AutoReturnAfter24Hours(AutoAuditMsg ipo)
        {
            var userBalanceSvc = new UserBalanceService();
            Func<S_currency_changeEO, CurrencyType, Task> sendMsgFunc = async (currencyChangeEo, currencyType) => {
                //记录bonus流水订单
                if (currencyChangeEo.AmountBonus > 0)
                {
                    var currencyChangeMsg = BuildCurrencyChangeMsg(currencyChangeEo, currencyType, true, 30);
                    await MQUtil.PublishAsync(currencyChangeMsg);
                }
                //记录真金流水订单
                if ((currencyChangeEo.Amount-currencyChangeEo.AmountBonus) > 0)
                {
                    var currencyChangeMsg = BuildCurrencyChangeMsg(currencyChangeEo, currencyType, false, 15);
                    await MQUtil.PublishAsync(currencyChangeMsg);
                }
            };
            await userBalanceSvc.ReturnBalance(ipo.SourceId,_cashAuditMo,_userSvc,sendMsgFunc);
        }

        private CurrencyChangeMsg BuildCurrencyChangeMsg(S_currency_changeEO currencyChangeEo,CurrencyType currencyType,bool isBonus,float flowMultip)
        {
            var currencyChangeMsg = new CurrencyChangeMsg
            {
                UserId = currencyChangeEo.UserID,
                UserKind = currencyChangeEo.UserKind.ToEnum<UserKind>(),
                AppId = currencyChangeEo.AppID,
                OperatorId = currencyChangeEo.OperatorID,
                CountryId = currencyChangeEo.CountryID,
                CurrencyId = currencyChangeEo.CurrencyID,
                FlowMultip = flowMultip,
                CurrencyType = currencyType,
                ChangeTime = currencyChangeEo.RecDate,
                SourceType = currencyChangeEo.SourceType,
                SourceId = currencyChangeEo.SourceId,
                SourceTable = currencyChangeEo.SourceTable,
                Reason = currencyChangeEo.Reason,
                Amount = isBonus ? currencyChangeEo.AmountBonus : (currencyChangeEo.Amount - currencyChangeEo.AmountBonus),
                FromMode = currencyChangeEo.FromMode,
                FromId = currencyChangeEo.FromId,
                Bonus = isBonus?currencyChangeEo.AmountBonus:0,
                EndBalance = currencyChangeEo.EndBalance,
                EndBonus = currencyChangeEo.EndBonus
            };
            return currencyChangeMsg;
        }
    }
}
