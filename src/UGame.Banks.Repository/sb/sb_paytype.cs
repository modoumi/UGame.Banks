using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///支付方式：visa，电子钱包，spei等
    ///</summary>
    [SugarTable("sb_paytype")]
    public partial class Sb_paytypePO
    {
           public Sb_paytypePO(){


           }
           /// <summary>
           /// Desc:支付类型编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int PaytypeID {get;set;}

           /// <summary>
           /// Desc:支付类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Name {get;set;}

    }
}
