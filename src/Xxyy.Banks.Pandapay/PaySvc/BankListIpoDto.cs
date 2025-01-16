using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TinyFx.Extensions.AutoMapper;
using Xxyy.Banks.BLL.Services.Pay;
using Xxyy.Banks.DAL;

namespace Xxyy.Banks.Pandapay.PaySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class BankListIpo : BankIpoBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public override Type DtoType => typeof(GetBankListDto);
    }

    /// <summary>
    /// 
    /// </summary>
    public class BankListItemDto
    {

        /// <summary>
        /// 银行代码 如：（90613）
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行名称 如：（MULTIVA CBOLSA）
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Abbreviation Bank Name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// TED Bank code
        /// </summary>
        public string StrCode { get; set; }


    }

    /// <summary>
    /// 
    /// </summary>
    public class GetBankListDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<BankListItemDto> BankList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
