using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL
{
    public class XxyyGetOrderIpo
    {
        public string OrderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        public string AppId { get; set; }
        public string CurrencyId { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }
        public string ReqComment { get; set; }

        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }
    }
}
