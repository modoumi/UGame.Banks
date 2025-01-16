using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Pandapay
{
    /// <summary>
    /// 
    /// </summary>
    public class PandaBankListItemDto
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
    public class PandaBankListDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PandaBankListItemDto> BankList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
