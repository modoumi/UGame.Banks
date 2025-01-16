using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_bank_currencyPO
    {
        #region tinyfx
        public static implicit operator Sb_bank_currencyEO(Sb_bank_currencyPO value)
        {
            if (value==null) return null;
            return new Sb_bank_currencyEO
            {
		        BankID = value.BankID,
		        CurrencyID = value.CurrencyID,
            };
        }
        public static implicit operator Sb_bank_currencyPO(Sb_bank_currencyEO value)
        {
            if (value==null) return null;
            return new Sb_bank_currencyPO
            {
		        BankID = value.BankID,
		        CurrencyID = value.CurrencyID,
            };
        }
        #endregion
    }
}