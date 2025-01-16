using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_configPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_configEO(Sc_cash_configPO value)
        {
            if (value==null) return null;
            return new Sc_cash_configEO
            {
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        AuditStartAmount = value.AuditStartAmount,
		        FirstCashMinAmount = value.FirstCashMinAmount,
		        CashMinAmount = value.CashMinAmount,
		        CashMaxAmount = value.CashMaxAmount,
		        CashPayAmount = value.CashPayAmount,
		        DayCashMaxLimitAmount = value.DayCashMaxLimitAmount,
		        DayCashNumLimit = value.DayCashNumLimit,
		        GlobalFirstCashAuditLimit = value.GlobalFirstCashAuditLimit,
		        CashComparePayMultiple = value.CashComparePayMultiple,
		        HistoryCashComparePayMultiple = value.HistoryCashComparePayMultiple,
		        IsAudit = value.IsAudit,
		        IsVerifyMobile = value.IsVerifyMobile,
		        CurrCashMaxLimit = value.CurrCashMaxLimit,
		        RecDate = value.RecDate,
            };
        }
        public static implicit operator Sc_cash_configPO(Sc_cash_configEO value)
        {
            if (value==null) return null;
            return new Sc_cash_configPO
            {
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        AuditStartAmount = value.AuditStartAmount,
		        FirstCashMinAmount = value.FirstCashMinAmount,
		        CashMinAmount = value.CashMinAmount,
		        CashMaxAmount = value.CashMaxAmount,
		        CashPayAmount = value.CashPayAmount,
		        DayCashMaxLimitAmount = value.DayCashMaxLimitAmount,
		        DayCashNumLimit = value.DayCashNumLimit,
		        GlobalFirstCashAuditLimit = value.GlobalFirstCashAuditLimit,
		        CashComparePayMultiple = value.CashComparePayMultiple,
		        HistoryCashComparePayMultiple = value.HistoryCashComparePayMultiple,
		        IsAudit = value.IsAudit,
		        IsVerifyMobile = value.IsVerifyMobile,
		        CurrCashMaxLimit = value.CurrCashMaxLimit,
		        RecDate = value.RecDate,
            };
        }
        #endregion
    }
}