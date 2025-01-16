using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///体现条件配置
    ///</summary>
    [SugarTable("sc_cash_condition_config")]
    public partial class Sc_cash_condition_configPO
    {
           public Sc_cash_condition_configPO(){

            this.ConditionType =0;
            this.FirstPayAmountStart =0;
            this.FirstPayAmountEnd =0;
            this.CashCompareTotalPayAmount =0.00f;
            this.TotalPayCountStart =0;
            this.TotalPayCountEnd =0;
            this.TotalPayAmountStartLimit =0;
            this.TotalPayAmountMaxLimit =0;
            this.BalanceStartAmount =0;
            this.BalanceEndAmount =0;
            this.TotalPayAmount =0;
            this.HistoryTotalPayAmountMultiple =0.00f;
            this.HistoryTotalPayAmountMultiple1 =0.00f;
            this.CashMultipLimit =0.00f;
            this.CashAmountLimit =0;
            this.BalanceLimit =0;
            this.OrderNum =0;

           }
           /// <summary>
           /// Desc:配置ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int ConfigID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorID {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:条件类型
			/// 0-预留
			/// 1-判断是否审批，FirstPayAmountStart、FirstPayAmountEnd、CashCompareTotalPayAmount
			/// 2-判断是否审批，TotalPayCountStart、TotalPayCountEnd、CashCompareTotalPayAmount
			/// 3-判断是否审批，TotalPayAmountStartLimit、TotalPayAmountMaxLimit
			/// 4-判断是否可提现，BalanceStartAmount、BalanceEndAmount、TotalPayAmount
			/// 5-判断是否审批，HistoryTotalPayAmountMultiple、HistoryTotalPayAmountMultiple1
			/// 6-判断是否审批，TotalPayAmountStartLimit、TotalPayAmountMaxLimit、CashMultipLimit、CashAmountLimit、BalanceLimit
			/// 7-判断是否审批，HistoryTotalPayAmountMultiple
			/// 8-判断是否审批，HistoryTotalPayAmountMultiple、HistoryTotalPayAmountMultiple1
			/// 9-判断是否审批，HistoryTotalPayAmountMultiple + 提现审批是否有退回、挂起记录
			/// 10-判断是否审批，TotalPayAmountStartLimit、TotalPayAmountMaxLimit、CashMultipLimit、CashAmountLimit、BalanceLimit
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ConditionType {get;set;}

           /// <summary>
           /// Desc:首次充值金额起始值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long FirstPayAmountStart {get;set;}

           /// <summary>
           /// Desc:首次充值金额截止值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long FirstPayAmountEnd {get;set;}

           /// <summary>
           /// Desc:本次提现金额对比累计充值金额
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float CashCompareTotalPayAmount {get;set;}

           /// <summary>
           /// Desc:累计充值次数起始值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalPayCountStart {get;set;}

           /// <summary>
           /// Desc:累计充值次数截止值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalPayCountEnd {get;set;}

           /// <summary>
           /// Desc:累计充值起始金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalPayAmountStartLimit {get;set;}

           /// <summary>
           /// Desc:累计充值金额截止值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalPayAmountMaxLimit {get;set;}

           /// <summary>
           /// Desc:余额起始区间
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BalanceStartAmount {get;set;}

           /// <summary>
           /// Desc:余额截止区间
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BalanceEndAmount {get;set;}

           /// <summary>
           /// Desc:充值总金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalPayAmount {get;set;}

           /// <summary>
           /// Desc:历史总充值金额倍数
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float HistoryTotalPayAmountMultiple {get;set;}

           /// <summary>
           /// Desc:历史总充值金额倍数1
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float HistoryTotalPayAmountMultiple1 {get;set;}

           /// <summary>
           /// Desc:提现倍数
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float CashMultipLimit {get;set;}

           /// <summary>
           /// Desc:提现金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CashAmountLimit {get;set;}

           /// <summary>
           /// Desc:余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BalanceLimit {get;set;}

           /// <summary>
           /// Desc:排序字段
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int OrderNum {get;set;}

    }
}
