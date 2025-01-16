using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///用户每天统计
    ///</summary>
    [SugarTable("s_user_day")]
    public partial class S_user_dayPO
    {
           public S_user_dayPO(){

            this.FromMode =0;
            this.UserKind =0;
            this.IsNew =false;
            this.IsLogin =false;
            this.IsRegister =false;
            this.IsNewBet =false;
            this.HasBet =false;
            this.IsNewPay =false;
            this.HasPay =false;
            this.IsNewCash =false;
            this.HasCash =false;
            this.TotalBonus =0;
            this.TotalBonusCount =0;
            this.TotalBetBonus =0;
            this.TotalWinBonus =0;
            this.TotalChangeAmount =0;
            this.TotalChangeCount =0;
            this.TotalBetAmount =0;
            this.TotalBetCount =0;
            this.TotalWinAmount =0;
            this.TotalWinCount =0;
            this.TotalPayAmount =0;
            this.TotalPayCount =0;
            this.TotalCashAmount =0;
            this.TotalCashCount =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:统计日
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public DateTime DayID {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

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
           /// Desc:用户类型
			///              0-未知
			///              1-普通用户
			///              2-开发用户
			///              3-线上测试用户（调用第三方扣减）
			///              4-线上测试用户（不调用第三方扣减）
			///              5-仿真用户
			///              6-接口联调用户
			///              9-管理员
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int UserKind {get;set;}

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
           /// Desc:是否新用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNew {get;set;}

           /// <summary>
           /// Desc:当天是否登录
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsLogin {get;set;}

           /// <summary>
           /// Desc:连续登录天数
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int LoginDays {get;set;}

           /// <summary>
           /// Desc:上次登录时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? LastLoginTime {get;set;}

           /// <summary>
           /// Desc:当天是否进行了注册
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsRegister {get;set;}

           /// <summary>
           /// Desc:注册时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RegistDate {get;set;}

           /// <summary>
           /// Desc:是否是第一次下注用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNewBet {get;set;}

           /// <summary>
           /// Desc:当天是否下注
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HasBet {get;set;}

           /// <summary>
           /// Desc:是否是第一次充值用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNewPay {get;set;}

           /// <summary>
           /// Desc:当天是否充值
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HasPay {get;set;}

           /// <summary>
           /// Desc:是否第一次体现用户
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsNewCash {get;set;}

           /// <summary>
           /// Desc:当天是否有提现行为
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool HasCash {get;set;}

           /// <summary>
           /// Desc:赠金总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalBonus {get;set;}

           /// <summary>
           /// Desc:赠金次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalBonusCount {get;set;}

           /// <summary>
           /// Desc:下注时扣除的bonus总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalBetBonus {get;set;}

           /// <summary>
           /// Desc:返奖时增加的bonus总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalWinBonus {get;set;}

           /// <summary>
           /// Desc:变化总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalChangeAmount {get;set;}

           /// <summary>
           /// Desc:变化次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalChangeCount {get;set;}

           /// <summary>
           /// Desc:下注总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalBetAmount {get;set;}

           /// <summary>
           /// Desc:下注次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalBetCount {get;set;}

           /// <summary>
           /// Desc:返奖总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalWinAmount {get;set;}

           /// <summary>
           /// Desc:返奖次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalWinCount {get;set;}

           /// <summary>
           /// Desc:充值总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalPayAmount {get;set;}

           /// <summary>
           /// Desc:充值次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalPayCount {get;set;}

           /// <summary>
           /// Desc:提现总额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TotalCashAmount {get;set;}

           /// <summary>
           /// Desc:提现次数
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int TotalCashCount {get;set;}

           /// <summary>
           /// Desc:用户IP
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserIp {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
