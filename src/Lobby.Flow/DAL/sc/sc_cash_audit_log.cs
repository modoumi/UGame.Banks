using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sc_cash_audit_log")]
    public partial class Sc_cash_audit_logPO
    {
           public Sc_cash_audit_logPO(){

            this.Action =0;
            this.RecDate =DateTime.Now;
            this.TransType =0;
            this.RequestTime =DateTime.Now;
            this.Status =0;

           }
           /// <summary>
           /// Desc:GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string AuditLogID {get;set;}

           /// <summary>
           /// Desc:主键guid
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CashAuditID {get;set;}

           /// <summary>
           /// Desc:操作0-提交申请1-审批通过2-审批拒绝
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Action {get;set;}

           /// <summary>
           /// Desc:操作人ID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorId {get;set;}

           /// <summary>
           /// Desc:操作人
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OperatorName {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:通讯类型(0-我方发起1-对方发起)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TransType {get;set;}

           /// <summary>
           /// Desc:通讯标记（接口标识）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TransMark {get;set;}

           /// <summary>
           /// Desc:请求消息（我方请求或对方push）json
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? RequestBody {get;set;}

           /// <summary>
           /// Desc:请求时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RequestTime {get;set;}

           /// <summary>
           /// Desc:返回时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ResponseTime {get;set;}

           /// <summary>
           /// Desc:响应消息（对方响应或我方响应）json
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ResponseBody {get;set;}

           /// <summary>
           /// Desc:异常消息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Exception {get;set;}

           /// <summary>
           /// Desc:消息状态
			///              0-初始
			///              1-调用成功
			///              2-返回错误或调用异常，无需处理
			///              3-出现异常，需处理
			///              4-异常已处理
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

    }
}
