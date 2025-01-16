using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Extensions.RabbitMQ;

namespace UGame.Banks.Service.MQMsg
{
    public class OrderProcessingMsg
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string BankId { get; set; }
        public string OwnOrderId { get; set; }
        public string BankOrderId { get; set; }
        public OrderTypeEnum OrderType { get; set; }
        public int Paytype { get; set; }
        public int Channel { get; set; }
        public decimal Money { get; set; }
        public DateTime Recdate { get; set; }
        public object MQMeta { get; set; }
    }
}
