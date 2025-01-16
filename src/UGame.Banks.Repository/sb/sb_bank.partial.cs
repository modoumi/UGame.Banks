using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_bankPO
    {
        #region tinyfx
        public static implicit operator Sb_bankEO(Sb_bankPO value)
        {
            if (value==null) return null;
            return new Sb_bankEO
            {
		        BankID = value.BankID,
		        BankName = value.BankName,
		        BankType = value.BankType,
		        TrdPublicKey = value.TrdPublicKey,
		        OwnPublicKey = value.OwnPublicKey,
		        OwnPrivateKey = value.OwnPrivateKey,
		        PayFee = value.PayFee,
		        CashFee = value.CashFee,
		        Note = value.Note,
		        Status = value.Status,
		        VerifyDelay = value.VerifyDelay,
		        RecDate = value.RecDate,
		        BankConfig = value.BankConfig,
            };
        }
        public static implicit operator Sb_bankPO(Sb_bankEO value)
        {
            if (value==null) return null;
            return new Sb_bankPO
            {
		        BankID = value.BankID,
		        BankName = value.BankName,
		        BankType = value.BankType,
		        TrdPublicKey = value.TrdPublicKey,
		        OwnPublicKey = value.OwnPublicKey,
		        OwnPrivateKey = value.OwnPrivateKey,
		        PayFee = value.PayFee,
		        CashFee = value.CashFee,
		        Note = value.Note,
		        Status = value.Status,
		        VerifyDelay = value.VerifyDelay,
		        RecDate = value.RecDate,
		        BankConfig = value.BankConfig,
            };
        }
        #endregion
    }
}