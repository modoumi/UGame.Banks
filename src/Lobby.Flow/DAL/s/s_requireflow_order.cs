using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///流水需求订单
    ///</summary>
    [SugarTable("s_requireflow_order")]
    public partial class S_requireflow_orderPO
    {
           public S_requireflow_orderPO(){

            this.UserKind =0;
            this.FromMode =0;
            this.CurrencyType =0;
            this.BonusSourceType =1;
            this.IsBonus =false;
            this.OrderAmount =0;
            this.FlowMultip =0f;
            this.RequireFlow =0;
            this.EndBalance =0;
            this.EndBonus =0;
            this.Status =0;
            this.RecDate =DateTime.Now;
            this.UpdateTime =Convert.ToDateTime("2000-01-01 00:00:00");
            this.OrderRemain =0;
            this.InheritOrder =0;
            this.CompletedFlow =0;
            this.InheritFlow =0;

           }
           /// <summary>
           /// Desc:充值及赠金时生成订单GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string OrderID {get;set;}

           /// <summary>
           /// Desc:应用提供商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ProviderID {get;set;}

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
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserID {get;set;}

           /// <summary>
           /// Desc:用户类型0-未知1-普通用户2-开发用户3-线上测试用户（调用第三方扣减）4-线上测试用户（不调用第三方扣减）5-仿真用户6-接口联调用户9-管理员
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

           /// <summary>
           /// Desc:新用户来源方式
			///              0-获得运营商的新用户(s_operator)
			///              1-推广员获得的新用户（userid）
			///              2-推广渠道通过url获得的新用户（s_channel_url)
			///              3-推广渠道通过code获得的新用户（s_channel_code)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int FromMode {get;set;}

           /// <summary>
           /// Desc:对应的编码（根据FromMode变化）
			///              FromMode=
			///              0-运营商的新用户(s_operator)==> OperatorID
			///              1-推广员获得的新用户（userid） ==> 邀请人的UserID
			///              2-推广渠道通过url获得的新用户（s_channel_url) ==> CUrlID
			///              3-推广渠道通过code获得的新用户（s_channel_code) ==> CCodeID
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? FromId {get;set;}

           /// <summary>
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型（货币缩写RMB,USD）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:货币类型 1-COIN 2--GOLD 3-POINT 4-SWB 8-虚拟货币 9-CASH
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CurrencyType {get;set;}

           /// <summary>
           /// Desc:变化原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BonusReason {get;set;}

           /// <summary>
           /// Desc:0-未知1xxx-运营活动4xxx充值
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public int BonusSourceType {get;set;}

           /// <summary>
           /// Desc:源表名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SourceTable {get;set;}

           /// <summary>
           /// Desc:源表编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? SourceId {get;set;}

           /// <summary>
           /// Desc:是否赠金
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsBonus {get;set;}

           /// <summary>
           /// Desc:当前订单充值或获赠的金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long OrderAmount {get;set;}

           /// <summary>
           /// Desc:要求的流水系数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public float FlowMultip {get;set;}

           /// <summary>
           /// Desc:提现所要达到的流水
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long RequireFlow {get;set;}

           /// <summary>
           /// Desc:处理后余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndBalance {get;set;}

           /// <summary>
           /// Desc:处理后的bonus余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long EndBonus {get;set;}

           /// <summary>
           /// Desc:状态0-未完成1-正常打码完成流水2-流水被新订单继承3-余额小于5时取消流水4-打码完成,已提取
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:订单修改时间
           /// Default:2000-01-01 00:00:00
           /// Nullable:False
           /// </summary>           
           public DateTime UpdateTime {get;set;}

           /// <summary>
           /// Desc:当前订单剩余金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long OrderRemain {get;set;}

           /// <summary>
           /// Desc:被继承的余额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long InheritOrder {get;set;}

           /// <summary>
           /// Desc:当前已完成的流水
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long CompletedFlow {get;set;}

           /// <summary>
           /// Desc:被继承的流水
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long InheritFlow {get;set;}

           /// <summary>
           /// Desc:完成流水后bonus余额列表，|分割
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? EndBonusList {get;set;}

    }
}
