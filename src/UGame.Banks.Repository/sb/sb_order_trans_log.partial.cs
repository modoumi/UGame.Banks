using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_order_trans_logPO
    {
        #region tinyfx
        public static implicit operator Sb_order_trans_logEO(Sb_order_trans_logPO value)
        {
            if (value==null) return null;
            return new Sb_order_trans_logEO
            {
		        TransLogID = value.TransLogID,
		        OrderID = value.OrderID,
		        AppID = value.AppID,
		        BankID = value.BankID,
		        TransType = value.TransType,
		        TransMark = value.TransMark,
		        RequestBody = value.RequestBody,
		        RequestTime = value.RequestTime,
		        ResponseTime = value.ResponseTime,
		        ResponseBody = value.ResponseBody,
		        Exception = value.Exception,
		        Status = value.Status,
		        ClientIP = value.ClientIP,
		        ReceiveBonus = value.ReceiveBonus,
            };
        }
        public static implicit operator Sb_order_trans_logPO(Sb_order_trans_logEO value)
        {
            if (value==null) return null;
            return new Sb_order_trans_logPO
            {
		        TransLogID = value.TransLogID,
		        OrderID = value.OrderID,
		        AppID = value.AppID,
		        BankID = value.BankID,
		        TransType = value.TransType,
		        TransMark = value.TransMark,
		        RequestBody = value.RequestBody,
		        RequestTime = value.RequestTime,
		        ResponseTime = value.ResponseTime,
		        ResponseBody = value.ResponseBody,
		        Exception = value.Exception,
		        Status = value.Status,
		        ClientIP = value.ClientIP,
		        ReceiveBonus = value.ReceiveBonus,
            };
        }
        #endregion
    }
}