using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///用户推广渠道（仅拉新用户，无产品定制需求）
    ///</summary>
    [SugarTable("s_channel")]
    public partial class S_channelPO
    {
           public S_channelPO(){

            this.CType =0;
            this.IsStats =false;
            this.Status =0;
            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:推广渠道编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string ChannelID {get;set;}

           /// <summary>
           /// Desc:运营商编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OperatorID {get;set;}

           /// <summary>
           /// Desc:渠道名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CName {get;set;}

           /// <summary>
           /// Desc:渠道类型（0-公司1-个人）
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public int CType {get;set;}

           /// <summary>
           /// Desc:branch关键字
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BranchKey {get;set;}

           /// <summary>
           /// Desc:facebook pixelid
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? FBPixelId {get;set;}

           /// <summary>
           /// Desc:Facebook AccessToken
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? FBAccessToken {get;set;}

           /// <summary>
           /// Desc:快手打点配置
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? KwaiConfig {get;set;}

           /// <summary>
           /// Desc:GA关键字
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? GAKey {get;set;}

           /// <summary>
           /// Desc:埋点配置信息
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? TrackConfigs {get;set;}

           /// <summary>
           /// Desc:是否统计
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsStats {get;set;}

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
           /// Desc:记录时间
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
