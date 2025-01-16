using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace Lobby.Flow.DAL
{
    ///<summary>
    ///充值配置
    ///</summary>
    [SugarTable("l_pay_config")]
    public partial class L_pay_configPO
    {
           public L_pay_configPO(){

            this.Channels =0;
            this.IsEnable =false;
            this.IsMainChannel =false;
            this.ChannelsGroup =0;
            this.MinAmount =0;
            this.MaxAmount =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:主键GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ConfigID {get;set;}

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
           public string CountryId {get;set;}

           /// <summary>
           /// Desc:货币类型
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CurrencyID {get;set;}

           /// <summary>
           /// Desc:充值渠道4-pandapay5-tejeepay
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int Channels {get;set;}

           /// <summary>
           /// Desc:充值渠道描述,对应channels
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ChannelsDesc {get;set;}

           /// <summary>
           /// Desc:是否启用，同一个operatorId只能启用一条
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsEnable {get;set;}

           /// <summary>
           /// Desc:1-主渠道2-备用渠道
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsMainChannel {get;set;}

           /// <summary>
           /// Desc:充值渠道组
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int ChannelsGroup {get;set;}

           /// <summary>
           /// Desc:最小充值金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MinAmount {get;set;}

           /// <summary>
           /// Desc:最大充值金额
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public long MaxAmount {get;set;}

           /// <summary>
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
