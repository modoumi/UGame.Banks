using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_bank_spei_codePO
    {
        #region tinyfx
        public static implicit operator Sb_bank_spei_codeEO(Sb_bank_spei_codePO value)
        {
            if (value==null) return null;
            return new Sb_bank_spei_codeEO
            {
		        SpeiCode = value.SpeiCode,
		        IsUsed = value.IsUsed,
		        UseDate = value.UseDate,
		        UserID = value.UserID,
            };
        }
        public static implicit operator Sb_bank_spei_codePO(Sb_bank_spei_codeEO value)
        {
            if (value==null) return null;
            return new Sb_bank_spei_codePO
            {
		        SpeiCode = value.SpeiCode,
		        IsUsed = value.IsUsed,
		        UseDate = value.UseDate,
		        UserID = value.UserID,
            };
        }
        #endregion
    }
}