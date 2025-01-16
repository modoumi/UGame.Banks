using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///mongopay所支持的银行列表
    ///</summary>
    [SugarTable("sb_mongopay_bankcode")]
    public partial class Sb_mongopay_bankcodePO
    {
           public Sb_mongopay_bankcodePO(){


           }
           /// <summary>
           /// Desc:银行代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BankCode {get;set;}

           /// <summary>
           /// Desc:银行名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankName {get;set;}

    }
}
