using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TinyFx.Extensions.AutoMapper;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Mongopay.QuerySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class BankNameListIpo : BankIpoBase
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public string UserId { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string BankId { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string AppId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override Type DtoType => typeof(BankNameListDto);
    }

    /// <summary>
    /// 
    /// </summary>
    public class BankNameListDto : IMapFrom<Sb_mongopay_bankcodeEO>
    {

        /// <summary>
        /// 银行代码 如：（90613）
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行名称 如：（MULTIVA CBOLSA）
        /// </summary>
        public string BankName { get; set; }


        public void MapFrom(Sb_mongopay_bankcodeEO source)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBankNameListDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<BankNameListDto> BankList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
