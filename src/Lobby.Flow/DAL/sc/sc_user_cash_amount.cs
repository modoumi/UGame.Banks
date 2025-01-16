using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sc_user_cash_amount")]
    public partial class Sc_user_cash_amountPO
    {
           public Sc_user_cash_amountPO(){

            this.BetCashAmount =0;
            this.WinCashAmount =0;
            this.BalanceCashAmount =0;
            this.TempWithdrawAmount =0;
            this.WithdrawAmount =0;

           }
           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

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
           /// Desc:真金下注总额(计算可提现金额,会重置)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BetCashAmount {get;set;}

           /// <summary>
           /// Desc:真金返奖总额(计算可提现金额,会重置)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long WinCashAmount {get;set;}

           /// <summary>
           /// Desc:真金余额(计算可提现金额)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long BalanceCashAmount {get;set;}

           /// <summary>
           /// Desc:充值后的临时可提现真金金额(计算可提现金额)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long TempWithdrawAmount {get;set;}

           /// <summary>
           /// Desc:可提现真金金额(计算可提现金额)
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long WithdrawAmount {get;set;}

    }
}
