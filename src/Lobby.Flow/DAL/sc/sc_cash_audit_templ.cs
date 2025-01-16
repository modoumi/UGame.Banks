using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///运营商的提现审批策略表
    ///</summary>
    [SugarTable("sc_cash_audit_templ")]
    public partial class Sc_cash_audit_templPO
    {
           public Sc_cash_audit_templPO(){

            this.Status =false;
            this.RecDate =DateTime.Now;
            this.ModifiedDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:状态0-无效1-有效
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:更新时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime ModifiedDate {get;set;}

    }
}
