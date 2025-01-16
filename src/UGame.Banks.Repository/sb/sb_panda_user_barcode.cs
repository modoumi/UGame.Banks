using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///panda支付表-用户barcode
    ///</summary>
    [SugarTable("sb_panda_user_barcode")]
    public partial class Sb_panda_user_barcodePO
    {
           public Sb_panda_user_barcodePO(){

            this.RecDate =DateTime.Now;

           }
           /// <summary>
           /// Desc:用户编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string UserID {get;set;}

           /// <summary>
           /// Desc:还款码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? BarCode {get;set;}

           /// <summary>
           /// Desc:我方向对方请求的订单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? OwnOrderId {get;set;}

           /// <summary>
           /// Desc:对方订单号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? PlatOrderNum {get;set;}

           /// <summary>
           /// Desc:app编码
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
           /// Desc:货币编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? CurrencyID {get;set;}

           /// <summary>
           /// Desc:时间记录
           /// Default:CURRENT_TIMESTAMP
           /// Nullable:False
           /// </summary>           
           public DateTime RecDate {get;set;}

    }
}
