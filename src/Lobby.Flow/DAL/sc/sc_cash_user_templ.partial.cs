using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_user_templPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_user_templEO(Sc_cash_user_templPO value)
        {
            if (value==null) return null;
            return new Sc_cash_user_templEO
            {
		        UserTempID = value.UserTempID,
		        OperTempID = value.OperTempID,
		        OperatorID = value.OperatorID,
		        TempNum = value.TempNum,
		        PayMinusCashStart = value.PayMinusCashStart,
		        PayMinusCashEnd = value.PayMinusCashEnd,
		        PayCashRatioStart = value.PayCashRatioStart,
		        PayCashRatioEnd = value.PayCashRatioEnd,
		        PassRate = value.PassRate,
		        RecDate = value.RecDate,
            };
        }
        public static implicit operator Sc_cash_user_templPO(Sc_cash_user_templEO value)
        {
            if (value==null) return null;
            return new Sc_cash_user_templPO
            {
		        UserTempID = value.UserTempID,
		        OperTempID = value.OperTempID,
		        OperatorID = value.OperatorID,
		        TempNum = value.TempNum,
		        PayMinusCashStart = value.PayMinusCashStart,
		        PayMinusCashEnd = value.PayMinusCashEnd,
		        PayCashRatioStart = value.PayCashRatioStart,
		        PayCashRatioEnd = value.PayCashRatioEnd,
		        PassRate = value.PassRate,
		        RecDate = value.RecDate,
            };
        }
        #endregion
    }
}