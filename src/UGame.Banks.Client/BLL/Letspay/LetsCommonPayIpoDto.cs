using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Letspay
{
    internal class LetsCommonPayIpo:BaseIpo
    {
        public string email { get; set; }
        public string name { get; set; }
        public string phone { get; set; }

        /// <summary>
        /// 墨西哥：CLABE,OXXO,PAYCASH
        /// 巴西：忽略该参数，内部已经处理
        /// </summary>
        public string BankCode { get; set; }
    }



    public class LetsCommonPayDto : BaseDto
    {
        public string code { get; set; }

        public string payUrl { get; set; }
    }
}
