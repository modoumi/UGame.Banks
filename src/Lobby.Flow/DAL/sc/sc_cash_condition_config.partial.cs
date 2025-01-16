using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_condition_configPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_condition_configEO(Sc_cash_condition_configPO value)
        {
            if (value==null) return null;
            return new Sc_cash_condition_configEO
            {
		        ConfigID = value.ConfigID,
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        ConditionType = value.ConditionType,
		        FirstPayAmountStart = value.FirstPayAmountStart,
		        FirstPayAmountEnd = value.FirstPayAmountEnd,
		        CashCompareTotalPayAmount = value.CashCompareTotalPayAmount,
		        TotalPayCountStart = value.TotalPayCountStart,
		        TotalPayCountEnd = value.TotalPayCountEnd,
		        TotalPayAmountStartLimit = value.TotalPayAmountStartLimit,
		        TotalPayAmountMaxLimit = value.TotalPayAmountMaxLimit,
		        BalanceStartAmount = value.BalanceStartAmount,
		        BalanceEndAmount = value.BalanceEndAmount,
		        TotalPayAmount = value.TotalPayAmount,
		        HistoryTotalPayAmountMultiple = value.HistoryTotalPayAmountMultiple,
		        HistoryTotalPayAmountMultiple1 = value.HistoryTotalPayAmountMultiple1,
		        CashMultipLimit = value.CashMultipLimit,
		        CashAmountLimit = value.CashAmountLimit,
		        BalanceLimit = value.BalanceLimit,
		        OrderNum = value.OrderNum,
            };
        }
        public static implicit operator Sc_cash_condition_configPO(Sc_cash_condition_configEO value)
        {
            if (value==null) return null;
            return new Sc_cash_condition_configPO
            {
		        ConfigID = value.ConfigID,
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        ConditionType = value.ConditionType,
		        FirstPayAmountStart = value.FirstPayAmountStart,
		        FirstPayAmountEnd = value.FirstPayAmountEnd,
		        CashCompareTotalPayAmount = value.CashCompareTotalPayAmount,
		        TotalPayCountStart = value.TotalPayCountStart,
		        TotalPayCountEnd = value.TotalPayCountEnd,
		        TotalPayAmountStartLimit = value.TotalPayAmountStartLimit,
		        TotalPayAmountMaxLimit = value.TotalPayAmountMaxLimit,
		        BalanceStartAmount = value.BalanceStartAmount,
		        BalanceEndAmount = value.BalanceEndAmount,
		        TotalPayAmount = value.TotalPayAmount,
		        HistoryTotalPayAmountMultiple = value.HistoryTotalPayAmountMultiple,
		        HistoryTotalPayAmountMultiple1 = value.HistoryTotalPayAmountMultiple1,
		        CashMultipLimit = value.CashMultipLimit,
		        CashAmountLimit = value.CashAmountLimit,
		        BalanceLimit = value.BalanceLimit,
		        OrderNum = value.OrderNum,
            };
        }
        #endregion
    }
}