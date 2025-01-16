using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("sb_bank_paytype_channel")]
    public partial class Sb_bank_paytype_channelPO
    {
           public Sb_bank_paytype_channelPO(){

            this.PaytypeID =0;
            this.PaytypeChannel =0;

           }
           /// <summary>
           /// Desc:银行编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string BankID {get;set;}

           /// <summary>
           /// Desc:支付方式0-综合1-visa2-spei
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int PaytypeID {get;set;}

           /// <summary>
           /// Desc:支付方式下的渠道
           /// Default:0
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public int PaytypeChannel {get;set;}

           /// <summary>
           /// Desc:渠道名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? ChannelName {get;set;}

    }
}
