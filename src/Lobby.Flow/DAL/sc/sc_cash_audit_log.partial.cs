using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace Lobby.Flow.DAL
{
    public partial class Sc_cash_audit_logPO
    {
        #region tinyfx
        public static implicit operator Sc_cash_audit_logEO(Sc_cash_audit_logPO value)
        {
            if (value==null) return null;
            return new Sc_cash_audit_logEO
            {
		        AuditLogID = value.AuditLogID,
		        CashAuditID = value.CashAuditID,
		        Action = value.Action,
		        OperatorId = value.OperatorId,
		        OperatorName = value.OperatorName,
		        RecDate = value.RecDate,
		        TransType = value.TransType,
		        TransMark = value.TransMark,
		        RequestBody = value.RequestBody,
		        RequestTime = value.RequestTime,
		        ResponseTime = value.ResponseTime,
		        ResponseBody = value.ResponseBody,
		        Exception = value.Exception,
		        Status = value.Status,
            };
        }
        public static implicit operator Sc_cash_audit_logPO(Sc_cash_audit_logEO value)
        {
            if (value==null) return null;
            return new Sc_cash_audit_logPO
            {
		        AuditLogID = value.AuditLogID,
		        CashAuditID = value.CashAuditID,
		        Action = value.Action,
		        OperatorId = value.OperatorId,
		        OperatorName = value.OperatorName,
		        RecDate = value.RecDate,
		        TransType = value.TransType,
		        TransMark = value.TransMark,
		        RequestBody = value.RequestBody,
		        RequestTime = value.RequestTime,
		        ResponseTime = value.ResponseTime,
		        ResponseBody = value.ResponseBody,
		        Exception = value.Exception,
		        Status = value.Status,
            };
        }
        #endregion
    }
}