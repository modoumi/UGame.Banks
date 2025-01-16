using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///提现配置
    ///</summary>
    [SugarTable("sc_cash_config")]
    public partial class Sc_cash_configPO
    {
           public Sc_cash_configPO(){

            this.AuditStartAmount =0;
            this.FirstCashMinAmount =0;
            this.CashMinAmount =0;
            this.CashMaxAmount =0;
            this.CashPayAmount =0;
            this.DayCashMaxLimitAmount =0;
            this.DayCashNumLimit =0;
            this.GlobalFirstCashAuditLimit =0;
            this.CashComparePayMultiple =0;
            this.HistoryCashComparePayMultiple =0.00f;
            this.IsAudit =false;
            this.IsVerifyMobile =false;
            this.CurrCashMaxLimit =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:审核起始金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long AuditStartAmount {get;set;}

           /// <summary>
           /// Desc:首次提现最小金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long FirstCashMinAmount {get;set;}

           /// <summary>
           /// Desc:最低提现金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CashMinAmount {get;set;}

           /// <summary>
           /// Desc:最大提现金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CashMaxAmount {get;set;}

           /// <summary>
           /// Desc:提现时,需要满足的充值金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CashPayAmount {get;set;}

           /// <summary>
           /// Desc:当天累计提款上限
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long DayCashMaxLimitAmount {get;set;}

           /// <summary>
           /// Desc:当天累计提款次数上限
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int DayCashNumLimit {get;set;}

           /// <summary>
           /// Desc:全局首次提款审批限制
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long GlobalFirstCashAuditLimit {get;set;}

           /// <summary>
           /// Desc:提现对比充值倍数（超过此倍数，不允许提现）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CashComparePayMultiple {get;set;}

           /// <summary>
           /// Desc:(历史提现+本次提现)/历史充值>5则必定审批,判断审批第二顺位
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float HistoryCashComparePayMultiple {get;set;}

           /// <summary>
           /// Desc:满足可提现条件后,当前值=1,则必定进入审批,判断审批第一顺位
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsAudit {get;set;}

           /// <summary>
           /// Desc:
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsVerifyMobile {get;set;}

           /// <summary>
           /// Desc:单次提款上限
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CurrCashMaxLimit {get;set;}

           /// <summary>
           /// Desc:创建时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
