using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Mongopay
{

    public class MongoBankListItemDto
    {
        /// <summary>
        /// 银行代码 如：（90613）
        /// </summary>
        public string BankCode { get; set; }

        /// <summary>
        /// 银行名称 如：（MULTIVA CBOLSA）
        /// </summary>
        public string BankName { get; set; }
    }

    public class MongoBankListDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<MongoBankListItemDto> BankList { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
