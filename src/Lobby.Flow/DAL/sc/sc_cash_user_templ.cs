using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///用户提现模板配置表
    ///</summary>
    [SugarTable("sc_cash_user_templ")]
    public partial class Sc_cash_user_templPO
    {
           public Sc_cash_user_templPO(){

            this.TempNum =0;
            this.PayMinusCashStart =0.00m;
            this.PayMinusCashEnd =0.00m;
            this.PassRate =0.00m;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserTempID {get;set;}

           /// <summary>
           /// Desc:运营商提现区间配置表外键(sc_cash_oper_templ)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperTempID {get;set;}

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
           /// Desc:充值减提现下限
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public decimal PayMinusCashStart {get;set;}

           /// <summary>
           /// Desc:充值减提现上限
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public decimal PayMinusCashEnd {get;set;}

           /// <summary>
           /// Desc:充提比下限
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal PayCashRatioStart {get;set;}

           /// <summary>
           /// Desc:充提比上限
           /// Default:
           /// Nullable:False
           /// </summary>           
           public decimal PayCashRatioEnd {get;set;}

           /// <summary>
           /// Desc:通过率
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public decimal PassRate {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
