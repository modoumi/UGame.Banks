using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_bankcodePO
    {
        #region tinyfx
        public static implicit operator Sb_bankcodeEO(Sb_bankcodePO value)
        {
            if (value==null) return null;
            return new Sb_bankcodeEO
            {
		        BankID = value.BankID,
		        CountryID = value.CountryID,
		        BankCode = value.BankCode,
		        BankName = value.BankName,
            };
        }
        public static implicit operator Sb_bankcodePO(Sb_bankcodeEO value)
        {
            if (value==null) return null;
            return new Sb_bankcodePO
            {
		        BankID = value.BankID,
		        CountryID = value.CountryID,
		        BankCode = value.BankCode,
		        BankName = value.BankName,
            };
        }
        #endregion
    }
}