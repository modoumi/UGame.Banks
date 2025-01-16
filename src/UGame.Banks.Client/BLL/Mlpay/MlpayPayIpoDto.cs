using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Mlpay
{
    internal class MlpayPayIpo : BaseIpo
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string BankCode { get; set; }
        /// <summary>
        /// 巴西：税号，其他国家忽略
        /// </summary>
        public string TaxId { get; set; }
    }
    public class MlpayPayDto : BaseDto
    {
        public string code { get; set; }
        public string payUrl { get; set; }
    }
}
