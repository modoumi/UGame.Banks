using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_auditPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_auditEO(Sc_cash_auditPO value)
        {
            if (value==null) return null;
            return new Sc_cash_auditEO
            {
		        CashAuditID = value.CashAuditID,
		        UserID = value.UserID,
		        UserKind = value.UserKind,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        Mobile = value.Mobile,
		        Amount = value.Amount,
		        CashRate = value.CashRate,
		        BankCode = value.BankCode,
		        BankName = value.BankName,
		        AccName = value.AccName,
		        AccNumber = value.AccNumber,
		        Channels = value.Channels,
		        Status = value.Status,
		        ApplyTime = value.ApplyTime,
		        AuditTime = value.AuditTime,
		        OperatorUser = value.OperatorUser,
		        BankID = value.BankID,
		        Paytype = value.Paytype,
		        Channel = value.Channel,
		        RequestParam = value.RequestParam,
		        Remark = value.Remark,
		        IsAudit = value.IsAudit,
		        AmountBalance = value.AmountBalance,
		        AmountBonus = value.AmountBonus,
		        BankOrderId = value.BankOrderId,
		        RequestTime = value.RequestTime,
		        ResponseTime = value.ResponseTime,
		        CallbackTime = value.CallbackTime,
		        Reason = value.Reason,
		        UserBankID = value.UserBankID,
            };
        }
        public static implicit operator Sc_cash_auditPO(Sc_cash_auditEO value)
        {
            if (value==null) return null;
            return new Sc_cash_auditPO
            {
		        CashAuditID = value.CashAuditID,
		        UserID = value.UserID,
		        UserKind = value.UserKind,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        Mobile = value.Mobile,
		        Amount = value.Amount,
		        CashRate = value.CashRate,
		        BankCode = value.BankCode,
		        BankName = value.BankName,
		        AccName = value.AccName,
		        AccNumber = value.AccNumber,
		        Channels = value.Channels,
		        Status = value.Status,
		        ApplyTime = value.ApplyTime,
		        AuditTime = value.AuditTime,
		        OperatorUser = value.OperatorUser,
		        BankID = value.BankID,
		        Paytype = value.Paytype,
		        Channel = value.Channel,
		        RequestParam = value.RequestParam,
		        Remark = value.Remark,
		        IsAudit = value.IsAudit,
		        AmountBalance = value.AmountBalance,
		        AmountBonus = value.AmountBonus,
		        BankOrderId = value.BankOrderId,
		        RequestTime = value.RequestTime,
		        ResponseTime = value.ResponseTime,
		        CallbackTime = value.CallbackTime,
		        Reason = value.Reason,
		        UserBankID = value.UserBankID,
            };
        }
        #endregion
    }
}