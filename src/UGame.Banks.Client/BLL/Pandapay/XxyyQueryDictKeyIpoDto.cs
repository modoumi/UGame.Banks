using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Pandapay
{
    public class XxyyQueryDictKeyIpo
    {
        public string QueryKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 货币编码
        /// </summary>
        public string CurrencyId { get; set; }
        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }
    }
}
