using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sb_bank_currency")]
    public partial class Sb_bank_currencyPO
    {
           public Sb_bank_currencyPO(){


           }
           /// <summary>
           /// Desc:银行编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BankID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CurrencyID {get;set;}

    }
}
