using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_mongopay_bankcodePO
    {
        #region tinyfx
        public static implicit operator Sb_mongopay_bankcodeEO(Sb_mongopay_bankcodePO value)
        {
            if (value==null) return null;
            return new Sb_mongopay_bankcodeEO
            {
		        BankCode = value.BankCode,
		        BankName = value.BankName,
            };
        }
        public static implicit operator Sb_mongopay_bankcodePO(Sb_mongopay_bankcodeEO value)
        {
            if (value==null) return null;
            return new Sb_mongopay_bankcodePO
            {
		        BankCode = value.BankCode,
		        BankName = value.BankName,
            };
        }
        #endregion
    }
}