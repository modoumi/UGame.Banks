using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///银行表
    ///</summary>
    [SugarTable("sb_bank")]
    public partial class Sb_bankPO
    {
           public Sb_bankPO(){

            this.BankType =0;
            this.PayFee =0.000000m;
            this.CashFee =0.000000m;
            this.Status =0;
            this.VerifyDelay =100;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:银行编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BankID {get;set;}

           /// <summary>
           /// Desc:银行名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankName {get;set;}

           /// <summary>
           /// Desc:银行类型
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int BankType {get;set;}

           /// <summary>
           /// Desc:第三方公钥
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TrdPublicKey {get;set;}

           /// <summary>
           /// Desc:我方的公钥
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OwnPublicKey {get;set;}

           /// <summary>
           /// Desc:我方的私钥
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OwnPrivateKey {get;set;}

           /// <summary>
           /// Desc:充值费率
			/// 0 - 无费率
			/// -1  不通过该方式计算费率
			/// 0.03等
           /// Default:0.000000
           /// Nullable:False
           /// </summary>           
           public decimal PayFee {get;set;}

           /// <summary>
           /// Desc:提现费率
			/// 0 - 无费率
			/// -1  不通过该方式计算费率
			/// 0.03等
           /// Default:0.000000
           /// Nullable:False
           /// </summary>           
           public decimal CashFee {get;set;}

           /// <summary>
           /// Desc:备注信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? Note {get;set;}

           /// <summary>
           /// Desc:状态(0-无效1-有效)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Status {get;set;}

           /// <summary>
           /// Desc:验证三方订单调用延时（单位毫秒）
           /// Default:100
           /// Nullable:False
           /// </summary>           
           public int VerifyDelay {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

           /// <summary>
           /// Desc:bank配置参数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BankConfig {get;set;}

    }
}
