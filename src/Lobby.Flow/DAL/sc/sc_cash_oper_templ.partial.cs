using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_oper_templPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_oper_templEO(Sc_cash_oper_templPO value)
        {
            if (value==null) return null;
            return new Sc_cash_oper_templEO
            {
		        OperTempID = value.OperTempID,
		        OperatorID = value.OperatorID,
		        TempNum = value.TempNum,
		        PayCashRatioStart = value.PayCashRatioStart,
		        PayCashRatioEnd = value.PayCashRatioEnd,
		        RecDate = value.RecDate,
            };
        }
        public static implicit operator Sc_cash_oper_templPO(Sc_cash_oper_templEO value)
        {
            if (value==null) return null;
            return new Sc_cash_oper_templPO
            {
		        OperTempID = value.OperTempID,
		        OperatorID = value.OperatorID,
		        TempNum = value.TempNum,
		        PayCashRatioStart = value.PayCashRatioStart,
		        PayCashRatioEnd = value.PayCashRatioEnd,
		        RecDate = value.RecDate,
            };
        }
        #endregion
    }
}