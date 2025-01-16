using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace UGame.Banks.Repository
{
    ///<summary>
    ///spei支付个人可用序号
    ///</summary>
    [SugarTable("sb_bank_spei_code")]
    public partial class Sb_bank_spei_codePO
    {
           public Sb_bank_spei_codePO(){

            this.IsUsed =false;

           }
           /// <summary>
           /// Desc:Spei支付用户标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public string SpeiCode {get;set;}

           /// <summary>
           /// Desc:是否使用
           /// Default:0
           /// Nullable:False
           /// </summary>           
           public bool IsUsed {get;set;}

           /// <summary>
           /// Desc:使用时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UseDate {get;set;}

           /// <summary>
           /// Desc:用户编码(GUID)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string? UserID {get;set;}

    }
}
