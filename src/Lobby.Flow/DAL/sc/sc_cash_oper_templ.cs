using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///运营商的提现策略区间配置表
    ///</summary>
    [SugarTable("sc_cash_oper_templ")]
    public partial class Sc_cash_oper_templPO
    {
           public Sc_cash_oper_templPO(){

            this.TempNum =0;
            this.PayCashRatioStart =0.00m;
            this.PayCashRatioEnd =0.00m;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperTempID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:模板编号
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TempNum {get;set;}

           /// <summary>
           /// Desc:充提比下限
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public decimal PayCashRatioStart {get;set;}

           /// <summary>
           /// Desc:充提比上限
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public decimal PayCashRatioEnd {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
