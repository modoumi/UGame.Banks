using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_bank_orderPO
    {
        #region tinyfx
        public static implicit operator Sb_bank_orderEO(Sb_bank_orderPO value)
        {
            if (value==null) return null;
            return new Sb_bank_orderEO
            {
		        OrderID = value.OrderID,
		        ProviderID = value.ProviderID,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        UserID = value.UserID,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        DomainID = value.DomainID,
		        UserKind = value.UserKind,
		        RegistDate = value.RegistDate,
		        OrderType = value.OrderType,
		        BankID = value.BankID,
		        PaytypeID = value.PaytypeID,
		        PaytypeChannel = value.PaytypeChannel,
		        CurrencyID = value.CurrencyID,
		        RecDate = value.RecDate,
		        PlanAmount = value.PlanAmount,
		        AppRequestUUID = value.AppRequestUUID,
		        AppOrderId = value.AppOrderId,
		        AppReqComment = value.AppReqComment,
		        AppRequestTime = value.AppRequestTime,
		        AccName = value.AccName,
		        AccNumber = value.AccNumber,
		        BankCode = value.BankCode,
		        IsFirstCashOfDay = value.IsFirstCashOfDay,
		        Meta = value.Meta,
		        Status = value.Status,
		        UserIP = value.UserIP,
		        OwnOrderId = value.OwnOrderId,
		        TransMoney = value.TransMoney,
		        OrderMoney = value.OrderMoney,
		        BankResponseTime = value.BankResponseTime,
		        BankOrderId = value.BankOrderId,
		        BankCallbackTime = value.BankCallbackTime,
		        BankTime = value.BankTime,
		        BrCode = value.BrCode,
		        QrCode = value.QrCode,
		        Amount = value.Amount,
		        OwnFee = value.OwnFee,
		        UserFee = value.UserFee,
		        UserMoney = value.UserMoney,
		        EndBalance = value.EndBalance,
		        AmountBonus = value.AmountBonus,
		        EndBonus = value.EndBonus,
		        SettlTable = value.SettlTable,
		        SettlId = value.SettlId,
		        SettlAmount = value.SettlAmount,
		        SettlStatus = value.SettlStatus,
		        CompleteFlag = value.CompleteFlag,
		        ActivityIds = value.ActivityIds,
		        IsAddBalance = value.IsAddBalance,
		        IsAuditOrder = value.IsAuditOrder,
		        CountryID = value.CountryID,
		        UserFeeAmount = value.UserFeeAmount,
            };
        }
        public static implicit operator Sb_bank_orderPO(Sb_bank_orderEO value)
        {
            if (value==null) return null;
            return new Sb_bank_orderPO
            {
		        OrderID = value.OrderID,
		        ProviderID = value.ProviderID,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        UserID = value.UserID,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        DomainID = value.DomainID,
		        UserKind = value.UserKind,
		        RegistDate = value.RegistDate,
		        OrderType = value.OrderType,
		        BankID = value.BankID,
		        PaytypeID = value.PaytypeID,
		        PaytypeChannel = value.PaytypeChannel,
		        CurrencyID = value.CurrencyID,
		        RecDate = value.RecDate,
		        PlanAmount = value.PlanAmount,
		        AppRequestUUID = value.AppRequestUUID,
		        AppOrderId = value.AppOrderId,
		        AppReqComment = value.AppReqComment,
		        AppRequestTime = value.AppRequestTime,
		        AccName = value.AccName,
		        AccNumber = value.AccNumber,
		        BankCode = value.BankCode,
		        IsFirstCashOfDay = value.IsFirstCashOfDay,
		        Meta = value.Meta,
		        Status = value.Status,
		        UserIP = value.UserIP,
		        OwnOrderId = value.OwnOrderId,
		        TransMoney = value.TransMoney,
		        OrderMoney = value.OrderMoney,
		        BankResponseTime = value.BankResponseTime,
		        BankOrderId = value.BankOrderId,
		        BankCallbackTime = value.BankCallbackTime,
		        BankTime = value.BankTime,
		        BrCode = value.BrCode,
		        QrCode = value.QrCode,
		        Amount = value.Amount,
		        OwnFee = value.OwnFee,
		        UserFee = value.UserFee,
		        UserMoney = value.UserMoney,
		        EndBalance = value.EndBalance,
		        AmountBonus = value.AmountBonus,
		        EndBonus = value.EndBonus,
		        SettlTable = value.SettlTable,
		        SettlId = value.SettlId,
		        SettlAmount = value.SettlAmount,
		        SettlStatus = value.SettlStatus,
		        CompleteFlag = value.CompleteFlag,
		        ActivityIds = value.ActivityIds,
		        IsAddBalance = value.IsAddBalance,
		        IsAuditOrder = value.IsAuditOrder,
		        CountryID = value.CountryID,
		        UserFeeAmount = value.UserFeeAmount,
            };
        }
        #endregion
    }
}