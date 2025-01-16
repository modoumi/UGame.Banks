using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class S_user_dayPO
    {
        #region tinyfx
        public static implicit operator S_user_dayEO(S_user_dayPO value)
        {
            if (value==null) return null;
            return new S_user_dayEO
            {
		        DayID = value.DayID,
		        UserID = value.UserID,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        UserKind = value.UserKind,
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        IsNew = value.IsNew,
		        IsLogin = value.IsLogin,
		        LoginDays = value.LoginDays,
		        LastLoginTime = value.LastLoginTime,
		        IsRegister = value.IsRegister,
		        RegistDate = value.RegistDate,
		        IsNewBet = value.IsNewBet,
		        HasBet = value.HasBet,
		        IsNewPay = value.IsNewPay,
		        HasPay = value.HasPay,
		        IsNewCash = value.IsNewCash,
		        HasCash = value.HasCash,
		        TotalBonus = value.TotalBonus,
		        TotalBonusCount = value.TotalBonusCount,
		        TotalBetBonus = value.TotalBetBonus,
		        TotalWinBonus = value.TotalWinBonus,
		        TotalChangeAmount = value.TotalChangeAmount,
		        TotalChangeCount = value.TotalChangeCount,
		        TotalBetAmount = value.TotalBetAmount,
		        TotalBetCount = value.TotalBetCount,
		        TotalWinAmount = value.TotalWinAmount,
		        TotalWinCount = value.TotalWinCount,
		        TotalPayAmount = value.TotalPayAmount,
		        TotalPayCount = value.TotalPayCount,
		        TotalCashAmount = value.TotalCashAmount,
		        TotalCashCount = value.TotalCashCount,
		        UserIp = value.UserIp,
		        RecDate = value.RecDate,
            };
        }
        public static implicit operator S_user_dayPO(S_user_dayEO value)
        {
            if (value==null) return null;
            return new S_user_dayPO
            {
		        DayID = value.DayID,
		        UserID = value.UserID,
		        FromMode = value.FromMode,
		        FromId = value.FromId,
		        UserKind = value.UserKind,
		        OperatorID = value.OperatorID,
		        CountryID = value.CountryID,
		        CurrencyID = value.CurrencyID,
		        IsNew = value.IsNew,
		        IsLogin = value.IsLogin,
		        LoginDays = value.LoginDays,
		        LastLoginTime = value.LastLoginTime,
		        IsRegister = value.IsRegister,
		        RegistDate = value.RegistDate,
		        IsNewBet = value.IsNewBet,
		        HasBet = value.HasBet,
		        IsNewPay = value.IsNewPay,
		        HasPay = value.HasPay,
		        IsNewCash = value.IsNewCash,
		        HasCash = value.HasCash,
		        TotalBonus = value.TotalBonus,
		        TotalBonusCount = value.TotalBonusCount,
		        TotalBetBonus = value.TotalBetBonus,
		        TotalWinBonus = value.TotalWinBonus,
		        TotalChangeAmount = value.TotalChangeAmount,
		        TotalChangeCount = value.TotalChangeCount,
		        TotalBetAmount = value.TotalBetAmount,
		        TotalBetCount = value.TotalBetCount,
		        TotalWinAmount = value.TotalWinAmount,
		        TotalWinCount = value.TotalWinCount,
		        TotalPayAmount = value.TotalPayAmount,
		        TotalPayCount = value.TotalPayCount,
		        TotalCashAmount = value.TotalCashAmount,
		        TotalCashCount = value.TotalCashCount,
		        UserIp = value.UserIp,
		        RecDate = value.RecDate,
            };
        }
        #endregion
    }
}