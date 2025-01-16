using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_user_vanumberPO
    {
        #region tinyfx
        public static implicit operator Sb_user_vanumberEO(Sb_user_vanumberPO value)
        {
            if (value==null) return null;
            return new Sb_user_vanumberEO
            {
		        UserID = value.UserID,
		        VaNumber = value.VaNumber,
		        OrderID = value.OrderID,
		        PlatOrderNum = value.PlatOrderNum,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        CurrencyID = value.CurrencyID,
            };
        }
        public static implicit operator Sb_user_vanumberPO(Sb_user_vanumberEO value)
        {
            if (value==null) return null;
            return new Sb_user_vanumberPO
            {
		        UserID = value.UserID,
		        VaNumber = value.VaNumber,
		        OrderID = value.OrderID,
		        PlatOrderNum = value.PlatOrderNum,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        CurrencyID = value.CurrencyID,
            };
        }
        #endregion
    }
}