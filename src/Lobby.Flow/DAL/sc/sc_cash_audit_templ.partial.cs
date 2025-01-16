using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_audit_templPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_audit_templEO(Sc_cash_audit_templPO value)
        {
            if (value==null) return null;
            return new Sc_cash_audit_templEO
            {
		        OperatorID = value.OperatorID,
		        Status = value.Status,
		        RecDate = value.RecDate,
		        ModifiedDate = value.ModifiedDate,
            };
        }
        public static implicit operator Sc_cash_audit_templPO(Sc_cash_audit_templEO value)
        {
            if (value==null) return null;
            return new Sc_cash_audit_templPO
            {
		        OperatorID = value.OperatorID,
		        Status = value.Status,
		        RecDate = value.RecDate,
		        ModifiedDate = value.ModifiedDate,
            };
        }
        #endregion
    }
}