using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.AspNet;

namespace UGame.Banks.Client.BLL.Orionpay
{
    public class XxyyOrionCommonPayIpo
    {
        /// <summary>
        /// CPF or CNPJ
        /// </summary>
        [RequiredEx("", "type cannot be empty")]
        public string type { get; set; }

        [RequiredEx("", "number cannot be empty")]
        public string number { get; set; }

        public string zipCode { get; set; }

        public string phone { get; set; }

        public string name { get; set; }
        public string email { get; set; }


        /// <summary>
        /// 充值参与领取bonus状态，2不参与，1参与
        /// </summary>
        public int ReceiveBonus { get; set; }

        /// <summary>
        /// 用户ip
        /// </summary>
        public string UserIp { get; set; }

        /// <summary>
        /// 充值或提现的金额
        /// </summary>
        public long Amount { get; set; }

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
        /// 请求备注
        /// </summary>
        public string ReqComment { get; set; }


        /// <summary>
        /// 扩展数据
        /// </summary>
        public object Meta { get; set; }
    }

}
