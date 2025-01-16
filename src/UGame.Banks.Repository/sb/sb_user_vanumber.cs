using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///用户与虚拟账号对应关系
    ///</summary>
    [SugarTable("sb_user_vanumber")]
    public partial class Sb_user_vanumberPO
    {
           public Sb_user_vanumberPO(){


           }
           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:虚拟账号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? VaNumber {get;set;}

           /// <summary>
           /// Desc:我方订单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OrderID {get;set;}

           /// <summary>
           /// Desc:对方订单号（平台订单号）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? PlatOrderNum {get;set;}

           /// <summary>
           /// Desc:应用编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AppID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

    }
}
