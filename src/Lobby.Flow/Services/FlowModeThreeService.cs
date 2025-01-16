using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Logging;
using TinyFx.Text;
using Xxyy.Common.Caching;
using Xxyy.Common.Services;
using Xxyy.Common;
using Xxyy.DAL;
using Xxyy.MQ.Bank;
using Xxyy.MQ.Xxyy;
using TinyFx.Data;
using Lobby.Flow.DAL;
using Lobby.Flow.Common;
using TinyFx;
using Newtonsoft.Json;
using TinyFx.AspNet;
using Lobby.Flow.Services;
using Elasticsearch.Net;
using Lobby.Flow.IpoDto;
using Lobby.Flow.Services.CashServices;
using TinyFx.Data.SqlSugar;
using TinyFx.Security;
using TinyFx.Extensions.RabbitMQ;
using Org.BouncyCastle.Ocsp;
using Xxyy.MQ.Lobby;

namespace Lobby.Flow
{
    /// <summary>
    /// 新的打码规则--对应operator.flowmode=3
    /// </summary>
    public class FlowModeThreeService : FlowCommonService, IFlowService
    {
        //private readonly RequireFlowService _requireFlowService = new RequireFlowService();
        private readonly S_currency_changeMO _changeMo = new();
        public FlowModeThreeService(string userId, string appId, string operatorId) : base(userId, appId, operatorId)
        {
        }
        //public async Task DealCurrencyChangeMsg(CurrencyChangeMsg message)
        //{
        //    await _requireFlowService.AddRequireFlowOrder(message);
        //}

        public override async Task DealCurrencyChangeMsg(CurrencyChangeMsg message)
        {
            //1.记录bonus订单
            await base.DealCurrencyChangeMsg(message);
            switch(message.SourceType)
            {

                case 2://2.处理提现消息
                    await DealWithdrawUserAmountWhenUserCash(message);
                    break;
                default://活动赠送或者后台审核拒绝
                    await DealWithdrawUserAmountWhenActivity(message);
                    break;
            }
        }

        public override async Task DealUserBetMsg(UserBetMsg message)
        {
            if (message.CurrencyType != CurrencyType.Cash)
                return;
            CurrencyChangeMsg changeMsg = null;
            TransactionManager tm = new TransactionManager();
            try
            {
                //rollBack
                if (message.BetType == 4)
                {
                    await HandleRollBack(message, _requireFlowMo, tm);
                }
                else
                {
                    //计算可提现额
                    await DealWithdrawUserAmountWhenUserBet(message,tm);

                    //计算bonus流水
                    if (message.BetBonus <= 0) {
                        tm.Commit();
                        return; 
                    }
                    var toUpdateOrderList = new List<Xxyy.DAL.S_requireflow_orderEO>();
                    tm = tm == null ? new TransactionManager() : tm;
                    //s_requireflow_order
                    var currBonus = await _userSvc.GetBonus(tm);//当前账户的Bonus总额
                    var _totalFlow = (long)(message.BetBonus * (decimal)_sappEo.FlowRatio);
                    var orderList = await _requireFlowMo.GetSortAsync($"UserID='{message.UserId}' and Status=0", "RecDate asc", tm);
                    if (orderList != null && orderList.Any())
                    {
                        await AccumulateFlow(orderList, _totalFlow, currBonus, toUpdateOrderList);
                    }

                    if (toUpdateOrderList.Count > 0 && await _requireFlowMo.PutAsync(toUpdateOrderList, tm) < 1)
                        throw new Exception("Bet、Win后扣减流水订单中的bonus和真金失败");
                    if (toUpdateOrderList.Any(o => o.Status == 4))
                    {
                        var drawAmount = Math.Min(currBonus, toUpdateOrderList.Where(o => o.Status == 4).Sum(o => o.OrderAmount));
                        var success = await _userSvc.UpdateUserBonus(message.CurrencyId, -drawAmount, tm);
                        if (!success)
                            throw new Exception($"流水完成更新用户真金账户余额失败");
                        var balanceInfo = await _userSvc.GetBalanceInfo(tm, true);
                        // s_currency_change
                        var utcNow = DateTime.UtcNow;
                        var sourceId = toUpdateOrderList.Count(o => o.Status == 4) > 1 ? "" : toUpdateOrderList.First(o => o.Status == 4).OrderID;
                        var fromMode = await _userDCache.GetFromModeAsync();
                        var fromId = await _userDCache.GetFromIdAsync();
                        changeMsg = new CurrencyChangeMsg
                        {
                            UserId = message.UserId,
                            UserKind = message.UserKind.ToEnum<UserKind>(),
                            AppId = message.AppId,
                            OperatorId = message.OperatorId,
                            CountryId = message.CountryId,
                            CurrencyId = message.CurrencyId,
                            FlowMultip = 0,
                            CurrencyType = message.CurrencyType,
                            ChangeTime = utcNow,
                            SourceType = 300008,
                            SourceId = sourceId,
                            SourceTable = "s_requireflow_order",
                            Reason = "打满bonus流水转为真金",
                            Amount = drawAmount,
                            FromMode = fromMode,
                            FromId = fromId,
                            Bonus = 0,
                            EndBalance = balanceInfo.Balance,
                            EndBonus = balanceInfo.Bonus
                        };
                        var eo = new S_currency_changeEO
                        {
                            ChangeID = ObjectId.NewId(),
                            ProviderID = message.ProviderId,
                            AppID = message.AppId,
                            OperatorID = message.OperatorId,
                            UserID = message.UserId,
                            FromMode = fromMode,
                            FromId = fromId,
                            DomainID = await _userDCache.GetDomainIdAsync(),
                            UserKind = message.UserKind,
                            CountryID = message.CountryId,
                            CurrencyID = message.CurrencyId,
                            CurrencyType = (int)message.CurrencyType,
                            IsBonus = false, //TODO 已失效
                            FlowMultip = 0,
                            Reason = "打满bonus流水转为真金",
                            PlanAmount = drawAmount,
                            Meta = SerializerUtil.SerializeJsonNet(message),
                            SourceType = 300008,
                            SourceTable = "s_requireflow_order",
                            SourceId = sourceId,
                            UserIp = "",
                            Status = (int)OrderStatus.Success,
                            RecDate =utcNow,
                            DealTime = utcNow,
                            Amount = drawAmount,
                            EndBalance = balanceInfo.Balance,
                            AmountBonus = 0,
                            EndBonus = balanceInfo.Bonus,
                        };
                        if (await _changeMo.AddAsync(eo, tm) != 1)
                            throw new Exception($"CurrencyChangeService：{eo.Reason}，写入流水表s_currency_change出错");
                        await DealWithdrawUserAmountWhenBonusToCash(changeMsg,balanceInfo,tm);
                    }
                }

                tm.Commit();
                //if (changeMsg != null) await MQUtil.PublishAsync(changeMsg);
            }
            catch (Exception)
            {
                tm.Rollback();
                throw;
            }
        }
        /// <summary>
        /// 下注时计算可提现额
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task DealWithdrawUserAmountWhenUserBet(UserBetMsg message,TransactionManager tm)
        {
            try
            {
                var dto = new WithdrawUserServiceDto
                {
                    TM = tm,
                    AppEo = _sappEo,
                    CurrencyId = message.CurrencyId,
                    OperatorEo = _operatorInfo,
                    UserSvc = _userSvc
                };
                await new WithdrawUserOneService(dto).DealUserBet(message,tm);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "消费userbetmsg处理可提现额异常！");
            }
        }

        /// <summary>
        /// 充值时计算可提现额
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task DealWithdrawUserAmountWhenUserPay(UserPayMsg message)
        {
            try
            {
                var dto = new WithdrawUserServiceDto
                {
                    TM = null,
                    AppEo = _sappEo,
                    CurrencyId = message.CurrencyId,
                    OperatorEo = _operatorInfo,
                    UserSvc = _userSvc
                };
                await new WithdrawUserOneService(dto).DealUserPay(message);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "消费userpaymsg处理可提现额异常！");
            }
        }

        /// <summary>
        /// 活动或者后台审核拒绝时计算可提现额
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task DealWithdrawUserAmountWhenActivity(CurrencyChangeMsg message)
        {
            try
            {
                var dto = new WithdrawUserServiceDto
                {
                    TM = null,
                    AppEo = _sappEo,
                    CurrencyId = message.CurrencyId,
                    OperatorEo = _operatorInfo,
                    UserSvc = _userSvc
                };
                await new WithdrawUserOneService(dto).DealCurrencyChange(message,null);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "消费userpaymsg处理可提现额异常！");
            }
        }

        /// <summary>
        /// 提现时计算可提现额
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task DealWithdrawUserAmountWhenUserCash(CurrencyChangeMsg message)
        {
            try
            {
                var dto = new WithdrawUserServiceDto
                {
                    TM = null,
                    AppEo = _sappEo,
                    CurrencyId = message.CurrencyId,
                    OperatorEo = _operatorInfo,
                    UserSvc = _userSvc
                };
                await new WithdrawUserOneService(dto).DealUserCash(message);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "消费userpaymsg处理可提现额异常！");
            }
        }



        /// <summary>
        /// bonus转真金
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private async Task DealWithdrawUserAmountWhenBonusToCash(CurrencyChangeMsg message,BalanceInfo balanceInfo,TransactionManager tm)
        {
            try
            {
                var dto = new WithdrawUserServiceDto
                {
                    TM = tm,
                    AppEo = _sappEo,
                    CurrencyId = message.CurrencyId,
                    OperatorEo = _operatorInfo,
                    UserSvc = _userSvc,
                    BalanceInfo= balanceInfo
                };
                await new WithdrawUserOneService(dto).DealCurrencyChange(message,tm);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "消费userbetmsg，bonus转真金处理时计算可提现额异常！");
            }
        }

        #region 流水相关私有方法【不区分Bonus和真金时，继承流水】

        /// <summary>
        /// 累计流水
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="flowAmount"></param>
        /// <param name="currBonus"></param>
        /// <param name="toUpdateList"></param>
        /// <returns></returns>
        private async Task<long> AccumulateFlow(List<Xxyy.DAL.S_requireflow_orderEO> orderList, long flowAmount, long currBonus, List<Xxyy.DAL.S_requireflow_orderEO> toUpdateList)
        {
            var _remainFlow = flowAmount;
            foreach (var _order in orderList)
            {
                _order.UpdateTime = DateTime.UtcNow;
                _order.EndBonus = currBonus;
                var _logInfo = $"【增加流水】用户Id：{_order.UserID},流水订单号：{_order.OrderID},所需完成的流水:{_order.RequireFlow},之前已完成的流水:{_order.CompletedFlow}";//本次流水计算日志

                if (_remainFlow > 0)
                {
                    var planCompleteFlow = _order.CompletedFlow + _remainFlow;
                    if (planCompleteFlow <= _order.RequireFlow)
                    {
                        _logInfo += $",本次增加流水:{_remainFlow}";
                        _order.CompletedFlow = planCompleteFlow;
                        if (planCompleteFlow == _order.RequireFlow)
                        {
                            _order.Status = 4;
                            _logInfo += ",流水完成";
                        }
                        toUpdateList.Add(_order);
                        _remainFlow = 0;
                        LogUtil.Debug(_logInfo);
                        break;
                    }
                    else
                    {
                        _logInfo += $",本次增加流水:{_order.RequireFlow - _order.CompletedFlow},流水完成";
                        _order.CompletedFlow = _order.RequireFlow;
                        _order.Status = 4;
                        _remainFlow = planCompleteFlow - _order.RequireFlow;//仍然有溢出流水
                        toUpdateList.Add(_order);
                    }
                }
                LogUtil.Debug(_logInfo);
            }
            return _remainFlow;
        }

        #endregion

        public async Task DealUserPayMsg(UserPayMsg message)
        {
            await DealWithdrawUserAmountWhenUserPay(message);
            try
            {
                var cashFlowMultip = message.IsFirst
                    ? _operatorInfo.FirstPayFlowMultip
                    : _operatorInfo.PayFlowMultip;//充值的流水倍数
                if (cashFlowMultip <= 0) return;

                var balanceInfo = await _userSvc.GetBalanceInfo();
                var requireFlowEo = new Xxyy.DAL.S_requireflow_orderEO
                {
                    OrderID = ObjectId.NewId(),
                    ProviderID = null,
                    AppID = null,
                    OperatorID = message.OperatorId,
                    UserID = message.UserId,
                    UserKind = (int)await _userDCache.GetUserKindAsync(),
                    CountryID = await _userDCache.GetCountryIdAsync(),
                    CurrencyID = message.CurrencyId,
                    CurrencyType = (int)DbCacheUtil.GetCurrencyType(message.CurrencyId),
                    IsBonus = false,
                    FlowMultip = cashFlowMultip,
                    OrderAmount = message.PayAmount,
                    OrderRemain = message.PayAmount,
                    RequireFlow = message.PayAmount * cashFlowMultip,
                    EndBonus = balanceInfo.Bonus,
                    EndBalance = balanceInfo.Balance,
                    Status = 0,
                    RecDate = message.PayTime,
                    UpdateTime = message.PayTime,
                    SourceId = message.OrderID,
                    SourceTable = "sb_bank_order",
                    BonusSourceType = 400001,
                    BonusReason = "用户充值",
                    FromId = await _userDCache.GetFromIdAsync(),
                    FromMode = await _userDCache.GetFromModeAsync()
                };
                if (await _requireFlowMo.AddAsync(requireFlowEo) < 1)
                    throw new Exception("FlowNoInheritingNoCompletedService充值消费端，新增流水订单时出错");
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex, "FlowNoInheritingNoCompletedService充值消费端，计算流水订单时出错");
            }
        }

        protected override async Task<CurrencyChangeMsg> ChangeAmount(BraWithDrawIpo ipo, TransactionManager tm = null)
        {
            (long changeAmount, long changeBonus) = await GetChangeAmount(ipo, tm);
            //写入S_currency_change用户奖励变化表
            var changeMsg = await ipo.CurrencyChangeServices.Change(new CurrencyChangeReq()
            {
                UserId = ipo.UserId,
                AppId = ipo.AppId,
                OperatorId = ipo.OperatorId,
                CurrencyId = ipo.CurrencyId,
                Reason = "提现审核预扣除",
                Amount = -changeAmount,
                SourceType = 2,
                SourceTable = "sc_cash_audit",
                SourceId = ipo.CashAuditId,
                ChangeTime = DateTime.UtcNow,
                TM = tm,
                ChangeBalance = CurrencyChangeBalance.FirstCash,
                BonusAmount = -changeBonus
            });
            return changeMsg;
        }

        private async Task<(long changeAmount, long changeBonus)> GetChangeAmount(BraWithDrawIpo ipo, TransactionManager tm = null)
        {
            var balanceInfo = await _userSvc.GetBalanceInfo(tm);
            long changeAmount = 0L, changeBonus = 0L;
            var drawAmount = (long)ipo.Amount;
            if (drawAmount > (balanceInfo.Balance - balanceInfo.Bonus))
                changeAmount = balanceInfo.Balance;
            else
                changeAmount = drawAmount + balanceInfo.Bonus;
            changeBonus = balanceInfo.Bonus;
            return (changeAmount, changeBonus);
        }

        //protected override Task<BraPayChannelEnum> GetPayChannel(BraWithDrawIpo ipo) => Task.FromResult(ipo.Channels.ToEnum<BraPayChannelEnum>());

        #region 内部方法
        /// <summary>
        /// 回滚消息处理
        /// </summary>
        /// <returns></returns>
        private async Task HandleRollBack(UserBetMsg message, Xxyy.DAL.S_requireflow_orderMO requireFlowMo, TransactionManager tm)
        {
            if (message.BetType != 4) return;
            if (message.BetBonus < 0)
            {
                var rollbackBonus = (long)(message.BetBonus * _sappEo.FlowRatio);
                if (rollbackBonus == 0) return;
                var requireFlowOrders = await requireFlowMo.GetTopSortAsync($"UserID='{message.UserId}' and Status=0", 1, "UpdateTime desc", tm);
                if (requireFlowOrders == null || requireFlowOrders.Count < 1) return;
                if (await requireFlowMo.PutAsync("CompletedFlow+=@rollbackBonus", "OrderID=@OrderID", tm, rollbackBonus, requireFlowOrders[0].OrderID) < 1)
                    throw new Exception("RollBack后更新最近一条未完成的bonus流水订单失败");
            }
        }
        #endregion


        public override async Task DealUserCashMsg(UserCashMsg message)
        {
            var utcNow = DateTime.UtcNow;
            var actionData = new CashAuditActionData
            {
                Action = (int)CashAuditStatusEnum.Success,
                Ipo = message,
                Dto = true,
                OperatorId = message.UserId,
                RequestTime = utcNow,
                TransType = 1
            };
            var tm = new TransactionManager();
            try
            {
                int rows = 0;
                if (message.Status == 0)
                {
                    //1.
                    rows = await _cashAuditMo.PutAsync("Status=@status,AuditTime=@AuditTime,BankOrderId=@BankOrderId,CallbackTime=@CallbackTime", "CashAuditID=@CashAuditID and Status<=@oldstatus", tm, (int)CashAuditStatusEnum.Success, utcNow,message.OrderID, utcNow, message.AppOrderId, (int)CashAuditStatusEnum.Confirmation);
                    if (rows <= 0)
                        throw new Exception($"提现成功更新sc_cash_audit状态失败！CashAuditID:{message.AppOrderId},oldstatus:{(int)CashAuditStatusEnum.Confirmation},status:{(int)CashAuditStatusEnum.Success}");
                    //2.
                    rows = await _requireFlowMo.PutAsync("Status=4", $"UserID=@UserID and Status !=4", tm, message.UserId);
                    //if (rows <= 0)
                    //    throw new Exception($"提现成功更新requireFlowOrder表失败！CashAuditID:{message.AppOrderId}");
                    //3.0更新银行卡可用状态
                    var cashAuditEo = await _cashAuditMo.GetByPKAsync(message.AppOrderId,null);
                    if(null!=cashAuditEo)
                        await UpdateBraUserBankStatus(cashAuditEo.UserBankID);
                    //3.log
                    await FlowUtil.AddCashAuditLog(message.AppOrderId, null, true, actionData, null);
                }
                else
                {
                    var cashAuditEo = await _cashAuditMo.GetByPKAsync(message.AppOrderId, tm);
                    if (null == cashAuditEo || cashAuditEo.Status > (int)CashAuditStatusEnum.Confirmation)
                        throw new Exception($"提现失败时没有找到该提现订单或该订单不是等待银行确认状态！CashAuditId:{message.AppOrderId},status:{cashAuditEo?.Status}");

                    //var userSvc = new UserService(message.UserId);
                    var changeAmount = Math.Abs(cashAuditEo.AmountBalance);
                    var bonusAmount = Math.Abs(cashAuditEo.AmountBonus);
                    var ret = await _userSvc.UpdateBalance(message.CurrencyId, changeAmount, tm, bonusAmount);
                    if (!ret)
                        throw new Exception($"提现失败时,更新s_user账户失败！CashAuditId:{message.AppOrderId}");

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
                        EndBonus = balanceInfo.Bonus
                    };
                    if (await new S_currency_changeMO().AddAsync(eo, tm) != 1)
                        throw new Exception($"CurrencyChangeService：{eo.Reason}，提现失败写入流水表s_currency_change出错");

                    rows = await _cashAuditMo.PutAsync("Status=@status,AuditTime=@AuditTime,BankOrderId=@BankOrderId,CallbackTime=@CallbackTime", "CashAuditID=@CashAuditID and Status=@oldstatus", tm, (int)CashAuditStatusEnum.Fail, utcNow,message.OrderID,utcNow, cashAuditEo.CashAuditID, cashAuditEo.Status);
                    if (rows <= 0)
                        throw new Exception($"提现失败时，更新sc_cashaudit失败！CashAuditId:{message.AppOrderId}");

                    actionData.Action = (int)CashAuditStatusEnum.Fail;
                    await FlowUtil.AddCashAuditLog(message.AppOrderId, null, false, actionData, null);
                }
                tm.Commit();
            }
            catch (Exception ex)
            {
                tm.Rollback();
                LogUtil.Error(ex, "FlowNoInheritingNoCompletedService处理用户提现消息异常！");
                throw;
            }
        }

        /// <summary>
        /// 获取可提现额
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="currencyId"></param>
        /// <param name="tm"></param>
        /// <returns></returns>
        public override async Task<decimal> GetAllowCashMoney(string userId, string currencyId, TransactionManager tm = null)
        {
            //var balanceInfo = await _userSvc.GetBalanceInfo(tm, false);
            //return balanceInfo.ValidAmount;
            var dto = new WithdrawUserServiceDto
            {
                TM = tm,
                AppEo = _sappEo,
                CurrencyId = currencyId,
                OperatorEo = _operatorInfo,
                UserSvc = _userSvc
            };
            var withdrawAmountService = WithdrawUserServiceFactory.Create(dto);
            return await withdrawAmountService.GetWithdrawMoney(dto);
        }

        internal override async Task<SumRequireFlow> GetRequireFlows()
        {
            var requireFlowOrderEos = await _requireFlowMo.GetTopSortAsync("UserId = @UserId and Status=0", 1, "RecDate asc", null, _userSvc.UserId);
            var requireFlowOrder = requireFlowOrderEos.FirstOrDefault();
            if (null == requireFlowOrder) return null;
            return new SumRequireFlow
            {
                RequireFlow = requireFlowOrder.RequireFlow,
                CompletedFlow = requireFlowOrder.CompletedFlow,
                OrderDate = requireFlowOrder.RecDate,
                FlowMultip = requireFlowOrder.FlowMultip,
                OrderAmount = requireFlowOrder.OrderAmount,
            };
        }

        /// <summary>
        /// 获取流水打码进度
        /// </summary>
        /// <returns></returns>
        public async override Task<FlowProgressDto> GetFlowProgress()
        {
            var ret = new FlowProgressDto();
            ret.CashMoney = await this.GetAllowCashMoney(_userSvc.UserId, _operatorInfo.CurrencyID);
            var flow = await GetRequireFlows();
            if (null != flow)
            {
                ret.FlowOrder = new FlowProgressDto.ProgressRequireFlowOrder { 
                     RequireFlow= flow.RequireFlow.Value.AToM(_operatorInfo.CurrencyID),
                     CompletedFlow=flow.CompletedFlow.Value.AToM(_operatorInfo.CurrencyID),
                     OrderDate = flow.OrderDate,
                     FlowMultip = flow.FlowMultip,
                     OrderAmount = flow.OrderAmount.AToM(_operatorInfo.CurrencyID)
                };
            }
            return ret;
        }

        /// <summary>
        /// 检查用户支付信息
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        protected override async Task CheckBraUserBank(BraWithDrawIpo ipo)
        {
            if (ipo.CountryId == "GHA")
                return;
            if(string.IsNullOrWhiteSpace(ipo.UserBankId)&&(string.IsNullOrWhiteSpace(ipo.TaxId)||string.IsNullOrWhiteSpace(ipo.AccountNo)||!Enum.IsDefined<TejeePayMethodEnum>(ipo.CashType)))
                throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "cpf not found ");
            if (!string.IsNullOrWhiteSpace(ipo.UserBankId))
            {
                //if (string.IsNullOrWhiteSpace(ipo.UserBankId))
                //{
                //    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "No bank card selected");
                //}
                var braUserBankDCache = new Caching.BraUserBankDCache(ipo.OperatorId, ipo.UserId);
                var braUserBank = await braUserBankDCache.GetOrLoadAsync();

                if (!braUserBank.HasValue)
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "No bank card added.");
                var braUserBankEo = ipo.BraUserBankEo = braUserBank.Value.FirstOrDefault(d => d.UserBankID.Equals(ipo.UserBankId));

                if (null == braUserBankEo)
                    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "Bank card not found.");

                return;
            }
            //ipo.TaxId = braUserBankEo.TaxId;
            //ipo.AccountNo = braUserBankEo.KeyCode;
            //if (string.IsNullOrWhiteSpace(ipo.TaxId))
            //    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "CPF not empty.");
            //if (string.IsNullOrWhiteSpace(ipo.AccountNo))
            //    throw new CustomException(FlowResponseCodes.RS_UNKNOWN, "AccountNo can not empty.");
            
            
            var cardInfoHash = SecurityUtil.MD5Hash(SerializerUtil.SerializeJson(new { ipo.CashType, ipo.TaxId, ipo.AccountNo }), CipherEncode.Bit32Lower);
            
            var userBankRepo = DbUtil.GetRepository<L_bra_user_bankPO>();
            var cardInfo =await userBankRepo.GetFirstAsync(b => b.UserID == ipo.UserId && b.CardInfoHash == cardInfoHash);
            if(null!=cardInfo)
            {
                ipo.BraUserBankEo = cardInfo;
            }
            else
            {
                var globalUserDCache = await GlobalUserDCache.Create(ipo.UserId);
                //var braPayChannel = await FlowUtil.GetPayChannel(ipo.OperatorId, ipo.CurrencyId, ipo.CountryId);
                var userName =await globalUserDCache.GetUsernameAsync();
                var eo = new L_bra_user_bankPO()
                {
                    UserBankID = ObjectId.NewId(),
                    BankChannel =ipo.BraPayChannel.ToString(),//braPayChannel.ToString(),
                    UserID = ipo.UserId,
                    UserKind = (int)await globalUserDCache.GetUserKindAsync(),
                    OperatorID = ipo.OperatorId,
                    CountryID = ipo.CountryId,
                    CurrencyID = ipo.CurrencyId,
                    TaxId = ipo.TaxId,
                    KeyCode = ipo.AccountNo,
                    AccountType = ipo.CashType.ToString(),
                    Name =string.IsNullOrWhiteSpace(userName)?"test":userName,
                    OwnerType = string.Empty,
                    BankName = string.Empty,
                    BankCode = string.Empty,
                    BranchCode = string.Empty,
                    AccountNumber = ipo.AccountNo,
                    AccountStatus = string.Empty,
                    CardInfoHash = cardInfoHash,
                    CardStatus = 0,
                    RecDate = DateTime.UtcNow
                };
                ipo.BraUserBankEo = eo;
                var hasSuccess=await userBankRepo.InsertAsync(eo);
                if (hasSuccess)
                   await new Caching.BraUserBankDCache(this._operatorInfo.OperatorID,this._userSvc.UserId).KeyDeleteAsync();
            }
            //var ret = await userBankRepo.IsAnyAsync(b => b.UserID == ipo.UserId && b.CardInfoHash == cardInfoHash);
            //if (!ret)
            //    await userBankRepo.InsertAsync(eo);
            //ipo.BraUserBankEo = eo;
        }

        private async Task UpdateBraUserBankStatus(string userBankId)
        {
            try
            {
                var userBankRepo = DbUtil.GetRepository<L_bra_user_bankPO>();
                await userBankRepo.UpdateSetColumnsTrueAsync(x => new L_bra_user_bankPO { CardStatus = 1 }, w => w.UserBankID == userBankId && w.CardStatus == 0);
            }
            catch (Exception ex)
            {
                LogUtil.Error(ex,"更新用户支付卡验证状态异常！");
            }
        }

        public override async Task AutoReturnAfter24Hours(AutoAuditMsg ipo)
        {
            var userBalanceSvc = new UserBalanceService();
            await userBalanceSvc.ReturnBalance(ipo.SourceId, _cashAuditMo, _userSvc, null);
        }
    }
}
