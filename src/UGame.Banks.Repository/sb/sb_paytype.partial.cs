using System;
using System.Linq;
using System.Text;
using SqlSugar;
using TinyFx.Data.SqlSugar;

namespace UGame.Banks.Repository
{
    public partial class Sb_paytypePO
    {
        #region tinyfx
        public static implicit operator Sb_paytypeEO(Sb_paytypePO value)
        {
            if (value==null) return null;
            return new Sb_paytypeEO
            {
		        PaytypeID = value.PaytypeID,
		        Name = value.Name,
            };
        }
        public static implicit operator Sb_paytypePO(Sb_paytypeEO value)
        {
            if (value==null) return null;
            return new Sb_paytypePO
            {
		        PaytypeID = value.PaytypeID,
		        Name = value.Name,
            };
        }
        #endregion
    }
}