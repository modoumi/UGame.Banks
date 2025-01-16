using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_panda_user_barcodePO
    {
        #region tinyfx
        public static implicit operator Sb_panda_user_barcodeEO(Sb_panda_user_barcodePO value)
        {
            if (value==null) return null;
            return new Sb_panda_user_barcodeEO
            {
		        UserID = value.UserID,
		        BarCode = value.BarCode,
		        OwnOrderId = value.OwnOrderId,
		        PlatOrderNum = value.PlatOrderNum,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        CurrencyID = value.CurrencyID,
		        RecDate = value.RecDate,
            };
        }
        public static implicit operator Sb_panda_user_barcodePO(Sb_panda_user_barcodeEO value)
        {
            if (value==null) return null;
            return new Sb_panda_user_barcodePO
            {
		        UserID = value.UserID,
		        BarCode = value.BarCode,
		        OwnOrderId = value.OwnOrderId,
		        PlatOrderNum = value.PlatOrderNum,
		        AppID = value.AppID,
		        OperatorID = value.OperatorID,
		        CurrencyID = value.CurrencyID,
		        RecDate = value.RecDate,
            };
        }
        #endregion
    }
}