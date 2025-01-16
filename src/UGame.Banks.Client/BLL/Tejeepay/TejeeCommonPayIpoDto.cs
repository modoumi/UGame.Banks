using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Tejeepay
{
    internal class TejeeCommonPayIpo:BaseIpo
    {
        public int BizEnum { get; set; } = 1;
        public string ClientIp { get; set; }

        /// <summary>
        /// 币种是BRL,USDT,THB,PHP，此参数可不传
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// 币种是BRL,USDT,THB,PHP，此参数可不传
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 币种是BRL,USDT,THB,PHP，此参数可不传
        /// </summary>
        public string? Email { get; set; }

    }

    public class TejeeCommonPayDto:BaseDto
    {
        public string mchtId { get; set; }
        public string payUrl { get; set; }
        public string tradeId { get; set; }
    }
}
