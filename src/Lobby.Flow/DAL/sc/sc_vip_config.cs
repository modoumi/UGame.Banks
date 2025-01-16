using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///用户vip等级配置表
    ///</summary>
    [SugarTable("sc_vip_config")]
    public partial class Sc_vip_configPO
    {
           public Sc_vip_configPO(){

            this.PayStartAmount =0;
            this.PayEndAmount =0;
            this.GradeFlowMultip =1.00f;
            this.WeekFlowMultip =1.00f;
            this.CashRate =0.00f;
            this.DayCashNumLimit =0;
            this.DayCashAmountLimit =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:主键
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true,IsIdentity=true)]
           public int VipID {get;set;}

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
           /// Desc:货币编码（现金）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:vip等级
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int VipGrade {get;set;}

           /// <summary>
           /// Desc:需要达到的最小下注额度
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long BetMinAmount {get;set;}

           /// <summary>
           /// Desc:需要达到的最大下注额度
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long BetMaxAmount {get;set;}

           /// <summary>
           /// Desc:当前vip升级需要的充值金额起始值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PayStartAmount {get;set;}

           /// <summary>
           /// Desc:当前vip升级需要的充值金额截止值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long PayEndAmount {get;set;}

           /// <summary>
           /// Desc:升级奖励
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long GradeReward {get;set;}

           /// <summary>
           /// Desc:升级奖励提现要求的流水倍数
           /// Default:1.00
           /// Nullable:False
           /// </summary>           
           public float GradeFlowMultip {get;set;}

           /// <summary>
           /// Desc:每周可享收益
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long WeekReward {get;set;}

           /// <summary>
           /// Desc:每周收益提现要求的流水倍数
           /// Default:1.00
           /// Nullable:False
           /// </summary>           
           public float WeekFlowMultip {get;set;}

           /// <summary>
           /// Desc:提现手续费
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float CashRate {get;set;}

           /// <summary>
           /// Desc:每日提现次数上线
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int DayCashNumLimit {get;set;}

           /// <summary>
           /// Desc:每日提现金额上限
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long DayCashAmountLimit {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
