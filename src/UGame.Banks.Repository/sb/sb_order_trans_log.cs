using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///与app或bank调用方通讯日志(http)
    ///</summary>
    [SugarTable("sb_order_trans_log")]
    public partial class Sb_order_trans_logPO
    {
           public Sb_order_trans_logPO(){

            this.TransType =0;
            this.RequestTime =DateTime.Now;
            this.Status =0;
            this.ReceiveBonus =0;

           }
           /// <summary>
           /// Desc:请求应答日志编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string TransLogID {get;set;}

           /// <summary>
           /// Desc:请求ID GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OrderID {get;set;}

           /// <summary>
           /// Desc:应用编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AppID {get;set;}

           /// <summary>
           /// Desc:银行编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankID {get;set;}

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

           /// <summary>
           /// Desc:客户端ip地址
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ClientIP {get;set;}

           /// <summary>
           /// Desc:充值参与领取bonus状态，0不参与，1参与
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ReceiveBonus {get;set;}

    }
}
