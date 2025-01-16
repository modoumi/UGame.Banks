using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class S_requireflow_orderPO
    {
        #region tinyfx
        public static implicit operator S_requireflow_orderEO(S_requireflow_orderPO value)
        {
            if (value==null) return null;
            return new S_requireflow_orderEO
            {
		        OrderID = value.OrderID,
		        ProviderID = value.ProviderID,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        UserID = value.UserID,
		        UserKind = value.UserKind,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        CurrencyType = value.CurrencyType,
		        BonusReason = value.BonusReason,
		        BonusSourceType = value.BonusSourceType,
		        SourceTable = value.SourceTable,
		        SourceId = value.SourceId,
		        IsBonus = value.IsBonus,
		        OrderAmount = value.OrderAmount,
		        FlowMultip = value.FlowMultip,
		        RequireFlow = value.RequireFlow,
		        EndBalance = value.EndBalance,
		        EndBonus = value.EndBonus,
		        Status = value.Status,
		        RecDate = value.RecDate,
		        UpdateTime = value.UpdateTime,
		        OrderRemain = value.OrderRemain,
		        InheritOrder = value.InheritOrder,
		        CompletedFlow = value.CompletedFlow,
		        InheritFlow = value.InheritFlow,
		        EndBonusList = value.EndBonusList,
            };
        }
        public static implicit operator S_requireflow_orderPO(S_requireflow_orderEO value)
        {
            if (value==null) return null;
            return new S_requireflow_orderPO
            {
		        OrderID = value.OrderID,
		        ProviderID = value.ProviderID,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        UserID = value.UserID,
		        UserKind = value.UserKind,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        CurrencyType = value.CurrencyType,
		        BonusReason = value.BonusReason,
		        BonusSourceType = value.BonusSourceType,
		        SourceTable = value.SourceTable,
		        SourceId = value.SourceId,
		        IsBonus = value.IsBonus,
		        OrderAmount = value.OrderAmount,
		        FlowMultip = value.FlowMultip,
		        RequireFlow = value.RequireFlow,
		        EndBalance = value.EndBalance,
		        EndBonus = value.EndBonus,
		        Status = value.Status,
		        RecDate = value.RecDate,
		        UpdateTime = value.UpdateTime,
		        OrderRemain = value.OrderRemain,
		        InheritOrder = value.InheritOrder,
		        CompletedFlow = value.CompletedFlow,
		        InheritFlow = value.InheritFlow,
		        EndBonusList = value.EndBonusList,
            };
        }
        #endregion
    }
}