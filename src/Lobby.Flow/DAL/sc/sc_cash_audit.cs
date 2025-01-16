using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///提款审核
    ///</summary>
    [SugarTable("sc_cash_audit")]
    public partial class Sc_cash_auditPO
    {
           public Sc_cash_auditPO(){

            this.UserKind =1;
            this.FromMode =0;
            this.Amount =0;
            this.CashRate =0.00f;
            this.Channels =0;
            this.Status =0;
            this.ApplyTime =DateTime.Now;
            this.Paytype =0;
            this.Channel =0;
            this.IsAudit =true;
            this.AmountBalance =0;
            this.AmountBonus =0;

           }
           /// <summary>
           /// Desc:主键guid
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string CashAuditID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string UserID {get;set;}

           /// <summary>
           /// Desc:用户类型
           /// Default:1
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
           /// Desc:AppId
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
           /// Desc:国家编码ISO 3166-1三位字母
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CountryID {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Mobile {get;set;}

           /// <summary>
           /// Desc:提款金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long Amount {get;set;}

           /// <summary>
           /// Desc:提现手续费率
           /// Default:0.00
           /// Nullable:False
           /// </summary>           
           public float CashRate {get;set;}

           /// <summary>
           /// Desc:银行代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankCode {get;set;}

           /// <summary>
           /// Desc:银行名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankName {get;set;}

           /// <summary>
           /// Desc:用户账户名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? AccName {get;set;}

           /// <summary>
           /// Desc:用户账号（银行卡号等）
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string AccNumber {get;set;}

           /// <summary>
           /// Desc:提款渠道0-银行卡
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Channels {get;set;}

           /// <summary>
           /// Desc:提款审核状态0-处理中1-通过2-拒绝
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:申请时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime ApplyTime {get;set;}

           /// <summary>
           /// Desc:审批时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? AuditTime {get;set;}

           /// <summary>
           /// Desc:审批人
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorUser {get;set;}

           /// <summary>
           /// Desc:BankId
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankID {get;set;}

           /// <summary>
           /// Desc:paytype(1.visa,2.spei3.mongopay4.pandapay)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Paytype {get;set;}

           /// <summary>
           /// Desc:bankid对应支持的渠道编码
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Channel {get;set;}

           /// <summary>
           /// Desc:请求参数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? RequestParam {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Remark {get;set;}

           /// <summary>
           /// Desc:是否需要审核
           /// Default:1
           /// Nullable:False
           /// </summary>           
           public bool IsAudit {get;set;}

           /// <summary>
           /// Desc:balance变化额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long AmountBalance {get;set;}

           /// <summary>
           /// Desc:bonus变化额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long AmountBonus {get;set;}

           /// <summary>
           /// Desc:sb_bank_order表中Orderid
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankOrderId {get;set;}

           /// <summary>
           /// Desc:返回时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RequestTime {get;set;}

           /// <summary>
           /// Desc:返回时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ResponseTime {get;set;}

           /// <summary>
           /// Desc:回调时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CallbackTime {get;set;}

           /// <summary>
           /// Desc:原因
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Reason {get;set;}

           /// <summary>
           /// Desc:l_bra_user_bank(UserBankID)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserBankID {get;set;}

    }
}
