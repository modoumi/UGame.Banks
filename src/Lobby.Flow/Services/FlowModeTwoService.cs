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
using Xxyy.MQ.Bank;
using Xxyy.MQ.Xxyy;
using Xxyy.DAL;
using TinyFx.Data;
using Lobby.Flow.Services;

namespace Lobby.Flow
{
    /// <summary>
    /// 累计流水，并继承已完成流水的订单余额--对应operator.flowmode=2
    /// </summary>
    public class FlowModeTwoService : FlowCommonService, IFlowService
    {
        string _roundId;
        string _appId;
        //private readonly RequireFlowService _requireFlowService = new RequireFlowService();
        public FlowModeTwoService(string userId, string appId, string operatorId) : base(userId, appId, operatorId)
        {
            _appId = appId;
        }


        protected override async Task UserBetExecute(UserBetMsg message, TransactionManager tm)
        {
            var toUpdateOrderList = new List<S_requireflow_orderEO>();
            tm = tm == null ? new TransactionManager() : tm;
            _roundId = message.RoundId;

            var currBonus = await _userSvc.GetBonus();//当前账户的Bonus总额
            var _remainCashFlow = 0L;//已完成的真金订单溢出的流水
            var _remainCash = 0L;//已完成的真金订单的余额
            var _remainBonusFlow = 0L;//已完成的Bonus订单溢出的流水
            var _remainBonus = 0L;//已完成的Bonus订单的余额

            if (message.BetBonus == 0)
            {
                //只扣真金
                var cashOrderList = await _requireFlowMo.GetSortAsync($"UserID='{message.UserId}' and IsBonus=0 and Status=0", "RecDate asc", tm);
                if (cashOrderList != null && cashOrderList.Count > 0)
                {
                    var tmpDeductRes = await DeductCash(cashOrderList, message.BetAmount, currBonus, message.WinAmount, toUpdateOrderList);
                    _remainCashFlow += tmpDeductRes.remainCashFlow;
                    _remainCash += tmpDeductRes.remainCash;
                }
            }
            else if (message.BetBonus > 0)
            {
                var bonusOrderList = await _requireFlowMo.GetSortAsync($"UserID='{message.UserId}' and IsBonus=1 and Status=0", "RecDate asc", tm);
                var cashOrderList = await _requireFlowMo.GetSortAsync($"UserID='{message.UserId}' and IsBonus=0 and Status=0", "RecDate asc", tm);

                if (message.BetBonus < message.BetAmount)
                {
                    //bonus和真金都扣
                    if (bonusOrderList != null && bonusOrderList.Count > 0)
                    {
                        var tmpDeductRes = await DeductBonus(bonusOrderList, message.BetBonus, currBonus, message.WinBonus, toUpdateOrderList);
                        _remainBonusFlow += tmpDeductRes.remainBonusFlow;
                        _remainBonus += tmpDeductRes.remainBonus;
                    }

                    if (cashOrderList != null && cashOrderList.Count > 0)
                    {
                        var tmpDeductRes = await DeductCash(cashOrderList, message.BetAmount - message.BetBonus, currBonus, message.WinAmount - message.WinBonus, toUpdateOrderList);
                        _remainCashFlow += tmpDeductRes.remainCashFlow;
                        _remainCash += tmpDeductRes.remainCash;
                    }
                }
                else
                {
                    //只扣bonus
                    if (bonusOrderList != null && bonusOrderList.Count > 0)
                    {
                        var tmpDeductRes = await DeductBonus(bonusOrderList, message.BetAmount, currBonus, message.WinAmount, toUpdateOrderList);
                        _remainBonusFlow += tmpDeductRes.remainBonusFlow;
                        _remainBonus += tmpDeductRes.remainBonus;
                    }
                    else
                    {
                        //bonus订单都已完成时，流水直接给真金订单
                        if (cashOrderList != null && cashOrderList.Count > 0)
                        {
                            #region 原先不直接加流水，而走扣真金的逻辑
                            //var currCash = await userSvc.GetBalance(message.CurrencyId, null, false);
                            //var _betAmount = message.BetAmount;
                            //var _winAmount = message.WinAmount;
                            //if (currCash < message.BetAmount)
                            //{
                            //    _betAmount = currCash;
                            //    var _betProportion = (double)currCash / message.BetAmount;
                            //    _winAmount = (long)(message.WinAmount * _betProportion);
                            //}
                            //_remainCashFlow += await DeductCash(cashOrderList, _betAmount, currBonus, _winAmount, toUpdateOrderList);
                            #endregion

                            var _totalFlow = message.BetAmount;//本次下注的总流水[下注额算流水]
                            if (_operatorInfo != null && _operatorInfo.FlowMode != 1)
                                _totalFlow = Math.Abs(message.BetAmount - message.WinAmount);//本次下注的总流水[绝对值算流水]
                            await DirectAccumulateCashFlow(cashOrderList, currBonus, toUpdateOrderList, _totalFlow, 0);
                        }
                    }
                }
            }

            if (toUpdateOrderList.Count > 0 && await _requireFlowMo.PutAsync(toUpdateOrderList, tm) < 1)
                throw new Exception("Bet、Win后扣减流水订单中的bonus和真金失败");


            #region 已完成订单有溢出流水及余额时

            var toTwiceUpdateOrderList = new List<S_requireflow_orderEO>();

            if (_remainBonusFlow > 0 || _remainBonus > 0)
            {
                var bonusOrderList = await _requireFlowMo.GetSortAsync($"UserID='{message.UserId}' and IsBonus=1 and Status=0", "RecDate asc", tm);
                if (bonusOrderList != null && bonusOrderList.Any())
                    _remainBonusFlow = await DirectAccumulateBonusFlow(bonusOrderList, currBonus, toTwiceUpdateOrderList, _remainBonusFlow, _remainBonus);

            }

            if (_remainBonusFlow > 0 || _remainCashFlow > 0 || _remainCash > 0)
            {
                var cashOrderList = await _requireFlowMo.GetSortAsync($"UserID='{message.UserId}' and IsBonus=0 and Status=0", "RecDate asc", tm);
                if (cashOrderList != null && cashOrderList.Any())
                    await DirectAccumulateCashFlow(cashOrderList, currBonus, toTwiceUpdateOrderList, _remainCashFlow + _remainBonusFlow, _remainCash);
            }

            if (toTwiceUpdateOrderList.Count > 0 && await _requireFlowMo.PutAsync(toTwiceUpdateOrderList, tm) < 1)
                throw new Exception("扣减完流水订单中的额度后且有溢出流水，直接给订单加流水时失败");

            #endregion
        }

        /// <summary>
        /// 用户充值时处理流水
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task DealUserPayMsg(UserPayMsg message)
        {
            var balanceInfo = await _userSvc.GetBalanceInfo();
            var cashFlowMultip = _operatorInfo.PayFlowMultip;

            var accumulativeCash = 0L;//可以累计的余额
            var hisRequireFlowOrders = await _requireFlowMo.GetAsync("UserID=@userId and IsBonus=0 and Status=0", message.UserId);
            if (hisRequireFlowOrders == null || !hisRequireFlowOrders.Any())
            {
                accumulativeCash = await _userSvc.GetBalance(message.CurrencyId, useBonus: false);
            }

            var requireFlowEo = new S_requireflow_orderEO
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
                OrderRemain = message.PayAmount + accumulativeCash,
                RequireFlow = (long)(message.PayAmount * (decimal)cashFlowMultip),
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
            await _requireFlowMo.AddAsync(requireFlowEo);
        }

        ///// <summary>
        ///// 用户货币变化时流水处理
        ///// </summary>
        ///// <param name="req"></param>
        ///// <returns></returns>
        //public async Task DealCurrencyChangeMsg(CurrencyChangeMsg message)
        //{
        //    await _requireFlowService.AddRequireFlowOrder(message);
        //}


        #region 流水相关私有方法【Bonus和真金分开记流水时，且有余额继承】

        /// <summary>
        /// 消耗bonus金
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="betAmount"></param>
        /// <param name="currBonus"></param>
        /// <param name="winAmount"></param>
        /// <param name="toUpdateList"></param>
        /// <returns>bonus订单都完成后剩余的流水</returns>
        private async Task<(long remainBonusFlow, long remainBonus)> DeductBonus(List<S_requireflow_orderEO> orderList, long betAmount, long currBonus, long winAmount, List<S_requireflow_orderEO> toUpdateList)
        {
            var _betRemain = betAmount;//剩余下注金额
            var _currBonus = currBonus;//当前bonus金额
            var _totalFlow = betAmount;//本次下注的总流水[下注额算流水]
            if (_operatorInfo != null && _operatorInfo.FlowMode != 1)
                _totalFlow = Math.Abs(betAmount - winAmount);//本次下注的总流水[绝对值算流水]

            var _remainFlow = _totalFlow;//剩余的流水，累加到后面未完成订单的流水上
            var _remainBonus = 0L;//流水打够的订单的余额

            foreach (var _bonusOrder in orderList)
            {
                _bonusOrder.UpdateTime = DateTime.UtcNow;
                _bonusOrder.EndBonus = _currBonus;
                var _logInfo = $"【游戏{_appId}回合增加流水】用户Id：{_bonusOrder.UserID},Bonus流水订单号：{_bonusOrder.OrderID},所需完成的流水:{_bonusOrder.RequireFlow},本回合ID:{_roundId},本回合总下注Bonus：{betAmount},本回合总返奖Bonus:{winAmount},本回合之前已完成的流水:{_bonusOrder.CompletedFlow}";//本次流水计算日志
                if (_betRemain > 0)
                {
                    _betRemain = _betRemain - _bonusOrder.OrderRemain;

                    if (_betRemain < 0)//当前订单bonus金额大于剩余下注金额
                    {
                        var betProportion = (double)(_bonusOrder.OrderRemain + _betRemain) / betAmount;
                        var _bonusWinAmount = (long)(winAmount * betProportion);//当前订单可以拿到的返奖金额
                        var _curFlow = (long)(_totalFlow * betProportion);//当前订单可以拿到的流水
                        if (_bonusOrder.OrderRemain + _betRemain > 0)//规避-0的现象
                            _bonusOrder.EndBonusList = _bonusOrder.EndBonusList + $"|-{_bonusOrder.OrderRemain + _betRemain}";

                        var planCompleteFlow = _bonusOrder.CompletedFlow + _curFlow;//暂时存放当前订单可以拿到的流水，如果有剩余流水加到其他未完成订单上
                        _remainFlow -= _curFlow;
                        if (winAmount > 0)
                        {
                            _bonusOrder.EndBonusList = _bonusOrder.EndBonusList + $"|+{_bonusWinAmount}";
                        }

                        _bonusOrder.OrderRemain = Math.Abs(_betRemain) + _bonusWinAmount;
                        if (planCompleteFlow <= _bonusOrder.RequireFlow)
                        {
                            _logInfo += $",本回合增加流水:{_curFlow}";
                            _bonusOrder.CompletedFlow = planCompleteFlow;
                            if (planCompleteFlow == _bonusOrder.RequireFlow)
                            {
                                _bonusOrder.Status = 1;
                                _logInfo += ",流水完成";
                                _remainBonus += _bonusOrder.OrderRemain;
                            }
                            toUpdateList.Add(_bonusOrder);
                            LogUtil.Debug(_logInfo);
                            break;
                        }
                        else
                        {
                            _logInfo += $",本回合增加流水:{_bonusOrder.RequireFlow - _bonusOrder.CompletedFlow},流水完成";
                            _bonusOrder.CompletedFlow = _bonusOrder.RequireFlow;
                            _bonusOrder.Status = 1;
                            _remainFlow += planCompleteFlow - _bonusOrder.RequireFlow;
                            _remainBonus += _bonusOrder.OrderRemain;
                            _betRemain = 0;//剩余下注金额置为0
                            toUpdateList.Add(_bonusOrder);
                        }
                    }
                    else
                    {
                        var betProportion = (double)_bonusOrder.OrderRemain / betAmount;
                        var _bonusWinAmount = (long)(winAmount * betProportion);//当前订单可以拿到的返奖金额
                        var _curFlow = (long)(_totalFlow * betProportion);//当前订单可以拿到的流水

                        _bonusOrder.EndBonusList = _bonusOrder.EndBonusList + $"|-{_bonusOrder.OrderRemain}";
                        _bonusOrder.Status = 1;


                        var planCompleteFlow = _bonusOrder.CompletedFlow + _curFlow;//暂时存放当前订单可以拿到的流水，如果有剩余流水加到其他未完成订单上
                        _remainFlow -= _curFlow;
                        if (planCompleteFlow <= _bonusOrder.RequireFlow)
                        {
                            _bonusOrder.CompletedFlow = planCompleteFlow;
                            if (winAmount > 0 && planCompleteFlow < _bonusOrder.RequireFlow)
                            {
                                _logInfo += $",本回合增加流水:{_curFlow}";
                                _bonusOrder.Status = 0;//有返奖时，需要置为未完成，OrderRemain会被赋为返奖值
                            }
                            else
                            {
                                _logInfo += $",本回合增加流水:{_curFlow},流水完成";
                                _remainBonus += _bonusWinAmount;
                            }
                        }
                        else
                        {
                            _logInfo += $",本回合增加流水:{_curFlow},流水完成";
                            _bonusOrder.CompletedFlow = _bonusOrder.RequireFlow;
                            _remainFlow += planCompleteFlow - _bonusOrder.RequireFlow;
                            _remainBonus += _bonusWinAmount;
                        }

                        _bonusOrder.OrderRemain = _bonusWinAmount;

                        toUpdateList.Add(_bonusOrder);
                    }
                }

                LogUtil.Debug(_logInfo);
            }
            return (_remainFlow, _remainBonus);
        }

        /// <summary>
        /// 剩余bonus流水直接累加到bonus订单上,余额累加到未完成的订单上
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="currBonus"></param>
        /// <param name="toUpdateList"></param>
        /// <param name="remainFlow"></param>
        /// <param name="remainBonus"></param>
        /// <returns></returns>
        private async Task<long> DirectAccumulateBonusFlow(List<S_requireflow_orderEO> orderList, long currBonus, List<S_requireflow_orderEO> toUpdateList, long remainFlow, long remainBonus)
        {
            var _currBonus = currBonus;//当前bonus金额
            var _remainFlow = remainFlow;//剩余的流水，累加到后面未完成订单的流水上
            var _remainBonus = remainBonus;//剩余的金额，累加到后面未完成订单的余额上
            //if (_remainFlow <= 0) return 0L;
            foreach (var _bonusOrder in orderList)
            {
                _bonusOrder.UpdateTime = DateTime.UtcNow;
                _bonusOrder.EndBonus = _currBonus;
                var _logInfo = $"【流水溢出时增加流水】用户Id：{_bonusOrder.UserID},Bonus流水订单号：{_bonusOrder.OrderID},所需完成的流水:{_bonusOrder.RequireFlow},溢出流水的回合ID:{_roundId},之前已完成的流水:{_bonusOrder.CompletedFlow}";//本次流水计算日志

                if (_remainFlow > 0 || _remainBonus > 0)
                {
                    _remainFlow = _remainFlow <= 0 ? 0 : _remainFlow;
                    var planCompleteFlow = _bonusOrder.CompletedFlow + _remainFlow;
                    if (planCompleteFlow <= _bonusOrder.RequireFlow)
                    {
                        _logInfo += $",本次增加流水:{_remainFlow}";
                        _bonusOrder.CompletedFlow = planCompleteFlow;
                        if (planCompleteFlow == _bonusOrder.RequireFlow)
                        {
                            _bonusOrder.Status = 1;
                            _logInfo += ",流水完成";
                            _remainBonus += _bonusOrder.OrderRemain;//正好完成流水，_remainBonus余额继续累加
                        }
                        else
                        {
                            _bonusOrder.OrderRemain += _remainBonus;//未完成流水时，把原来完成的订单的余额加到这个未完成的订单上
                            _remainBonus = 0;
                        }
                        toUpdateList.Add(_bonusOrder);
                        _remainFlow = 0;
                        LogUtil.Debug(_logInfo);
                        break;
                    }
                    else
                    {
                        _logInfo += $",本次增加流水:{_bonusOrder.RequireFlow - _bonusOrder.CompletedFlow},流水完成";
                        _bonusOrder.CompletedFlow = _bonusOrder.RequireFlow;
                        _bonusOrder.Status = 1;
                        _remainFlow = planCompleteFlow - _bonusOrder.RequireFlow;//仍然有溢出流水
                        _remainBonus += _bonusOrder.OrderRemain;//完成流水，_remainBonus余额继续累加
                        toUpdateList.Add(_bonusOrder);
                    }
                }

                LogUtil.Debug(_logInfo);
            }
            return _remainFlow;
        }

        /// <summary>
        /// 消耗真金
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="betAmount"></param>
        /// <param name="currBonus"></param>
        /// <param name="winAmount"></param>
        /// <param name="toUpdateList"></param>
        /// <returns></returns>
        private async Task<(long remainCashFlow, long remainCash)> DeductCash(List<S_requireflow_orderEO> orderList, long betAmount, long currBonus, long winAmount, List<S_requireflow_orderEO> toUpdateList)
        {
            var _betRemain = betAmount;//剩余下注金额
            var _totalFlow = betAmount;//本次下注的总流水[下注额算流水]
            if (_operatorInfo != null && _operatorInfo.FlowMode != 1)
                _totalFlow = Math.Abs(betAmount - winAmount);//本次下注的总流水[绝对值算流水]

            var _remainFlow = _totalFlow;//剩余的流水，累加到后面未完成订单的流水上
            var _remainCash = 0L;//流水打够的订单的余额
            foreach (var _cashOrder in orderList)
            {
                _cashOrder.EndBonus = currBonus;
                _cashOrder.UpdateTime = DateTime.UtcNow;
                var _logInfo = $"【游戏{_appId}回合增加流水】用户Id：{_cashOrder.UserID},真金流水订单号：{_cashOrder.OrderID},所需完成的流水:{_cashOrder.RequireFlow},本回合ID:{_roundId},本回合总下注真金：{betAmount},本回合总返奖真金:{winAmount},本回合之前已完成的流水:{_cashOrder.CompletedFlow}";//本次流水计算日志
                if (_betRemain > 0)
                {
                    _betRemain = _betRemain - _cashOrder.OrderRemain;
                    if (_betRemain < 0)//当前订单金额大于剩余下注金额
                    {
                        var betProportion = (double)(_cashOrder.OrderRemain + _betRemain) / betAmount;
                        var _cashWinAmount = (long)(winAmount * betProportion);//当前订单可以拿到的返奖金额
                        var _curFlow = (long)(_totalFlow * betProportion);//当前订单可以拿到的流水
                        var planCompleteFlow = _cashOrder.CompletedFlow + _curFlow;//暂时存放当前订单可以拿到的流水，如果有剩余流水加到其他未完成订单上

                        _cashOrder.OrderRemain = Math.Abs(_betRemain) + _cashWinAmount;
                        _remainFlow -= _curFlow;
                        if (planCompleteFlow <= _cashOrder.RequireFlow)
                        {
                            _logInfo += $",本回合增加流水:{_curFlow}";
                            _cashOrder.CompletedFlow = planCompleteFlow;
                            if (planCompleteFlow == _cashOrder.RequireFlow)
                            {
                                _cashOrder.Status = 1;
                                _logInfo += ",流水完成";
                                _remainCash += _cashOrder.OrderRemain;
                            }
                            toUpdateList.Add(_cashOrder);
                            LogUtil.Debug(_logInfo);
                            break;
                        }
                        else
                        {
                            _logInfo += $",本回合增加流水:{_cashOrder.RequireFlow - _cashOrder.CompletedFlow},流水完成";
                            _cashOrder.CompletedFlow = _cashOrder.RequireFlow;
                            _cashOrder.Status = 1;
                            _remainFlow += planCompleteFlow - _cashOrder.RequireFlow;
                            _remainCash += _cashOrder.OrderRemain;
                            _betRemain = 0;//剩余下注金额置为0
                            toUpdateList.Add(_cashOrder);
                        }
                    }
                    else
                    {
                        var betProportion = (double)_cashOrder.OrderRemain / betAmount;
                        var _cashWinAmount = (long)(winAmount * betProportion);//当前订单可以拿到的返奖金额
                        var _curFlow = (long)(_totalFlow * betProportion);//当前订单可以拿到的流水
                        _cashOrder.Status = 1;

                        var planCompleteFlow = _cashOrder.CompletedFlow + _curFlow;//暂时存放当前订单可以拿到的流水，如果有剩余流水加到其他未完成订单上
                        _remainFlow -= _curFlow;
                        if (planCompleteFlow <= _cashOrder.RequireFlow)
                        {
                            _cashOrder.CompletedFlow = planCompleteFlow;
                            if (winAmount > 0 && planCompleteFlow < _cashOrder.RequireFlow)
                            {
                                _cashOrder.Status = 0;
                                _logInfo += $",本回合增加流水:{_curFlow}";
                            }
                            else
                            {
                                _remainCash += _cashWinAmount;
                                _logInfo += $",本回合增加流水:{_curFlow},流水完成";
                            }
                        }
                        else
                        {
                            _logInfo += $",本回合增加流水:{_curFlow},流水已完成";
                            _cashOrder.CompletedFlow = _cashOrder.RequireFlow;
                            _remainFlow += planCompleteFlow - _cashOrder.RequireFlow;
                            _remainCash += _cashWinAmount;
                        }

                        _cashOrder.OrderRemain = _cashWinAmount;
                        toUpdateList.Add(_cashOrder);
                    }
                }

                LogUtil.Debug(_logInfo);
            }
            return (_remainFlow, _remainCash);
        }

        /// <summary>
        /// 剩余流水直接累加到真金订单上,余额累加到未完成的订单上
        /// </summary>
        /// <param name="orderList"></param>
        /// <param name="currBonus"></param>
        /// <param name="toUpdateList"></param>
        /// <param name="remainFlow"></param>
        /// <param name="remainCash"></param>
        /// <returns></returns>
        private async Task DirectAccumulateCashFlow(List<S_requireflow_orderEO> orderList, long currBonus, List<S_requireflow_orderEO> toUpdateList, long remainFlow, long remainCash)
        {
            var _currBonus = currBonus;//当前bonus金额
            var _remainFlow = remainFlow;//剩余的流水，累加到后面未完成订单的流水上
            var _remainCash = remainCash;//剩余的金额，累加到后面未完成订单的余额上
            //if (_remainFlow <= 0) return;
            foreach (var _cashOrder in orderList)
            {
                _cashOrder.UpdateTime = DateTime.UtcNow;
                _cashOrder.EndBonus = _currBonus;
                var _logInfo = $"【流水溢出时增加流水】用户Id：{_cashOrder.UserID}，真金流水订单号：{_cashOrder.OrderID},所需完成的流水:{_cashOrder.RequireFlow},溢出流水的回合ID:{_roundId},之前已完成的流水:{_cashOrder.CompletedFlow}";//本次流水计算日志

                if (_remainFlow > 0 || _remainCash > 0)
                {
                    _remainFlow = _remainFlow <= 0 ? 0 : _remainFlow;
                    var planCompleteFlow = _cashOrder.CompletedFlow + _remainFlow;
                    if (planCompleteFlow <= _cashOrder.RequireFlow)
                    {
                        _logInfo += $",本次增加流水:{_remainFlow}";
                        _cashOrder.CompletedFlow = planCompleteFlow;
                        if (planCompleteFlow == _cashOrder.RequireFlow)
                        {
                            _cashOrder.Status = 1;
                            _logInfo += ",流水完成";
                            _remainCash += _cashOrder.OrderRemain;//正好完成流水，_remainCash余额继续累加
                        }
                        else
                        {
                            _cashOrder.OrderRemain += _remainCash;//未完成流水时，把原来完成的订单的余额加到这个未完成的订单上
                            _remainCash = 0;
                        }
                        toUpdateList.Add(_cashOrder);
                        _remainFlow = 0;
                        LogUtil.Debug(_logInfo);
                        break;
                    }
                    else
                    {
                        _logInfo += $",本次增加流水:{_cashOrder.RequireFlow - _cashOrder.CompletedFlow},流水完成";
                        _cashOrder.CompletedFlow = _cashOrder.RequireFlow;
                        _cashOrder.Status = 1;
                        _remainFlow = planCompleteFlow - _cashOrder.RequireFlow;
                        _remainCash += _cashOrder.OrderRemain;//完成流水，_remainCash余额继续累加
                        toUpdateList.Add(_cashOrder);
                    }
                }

                LogUtil.Debug(_logInfo);
            }
        }

       

        #endregion


    }
}
