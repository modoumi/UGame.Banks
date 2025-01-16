using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service;

namespace UGame.Banks.Letspay
{
    public class LetsPayConfig//: BankConfigBase
    {
        public string host { get; set; }
        public string mchId { get; set; }
        public string key { get; set; }


        public string payNotify { get; set; }
        public string cashNotify { get; set; }

        public string queryHost { get; set; }

        /// <summary>
        /// 每笔订单的手续费 如：
        /// 墨西哥代收代付 3+1%
        /// </summary>
        public decimal perFee { get; set; }
    }
}
