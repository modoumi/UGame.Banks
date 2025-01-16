using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.RabbitMQ;

namespace UGame.Banks.Service.MQMsg
{

    public class BankErrorMsg
    {
        public string BankId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public PayTypeEnum Paytype { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public int Channel { get; set; }
        public decimal Money { get; set; }

        public string CurrencyId { get; set; }

        /// <summary>
        /// utc时间
        /// </summary>
        public DateTime RecDate { get; set; }
        public string ErrorMsg { get; set; }
        public object Remark { get; set; }
        public object MQMeta { get; set; }
    }
}
