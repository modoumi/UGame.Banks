using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///bankid代付时所支持的不同国家的银行列表
    ///</summary>
    [SugarTable("sb_bankcode")]
    public partial class Sb_bankcodePO
    {
           public Sb_bankcodePO(){


           }
           /// <summary>
           /// Desc:银行编码(ing)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BankID {get;set;}

           /// <summary>
           /// Desc:国家代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CountryID {get;set;}

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
