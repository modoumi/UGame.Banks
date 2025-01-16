using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobby.Flow.Common
{
    public class CashAuditActionData
    {
        public DateTime RequestTime { get; set; }
        public int TransType { get; set; }
        public int Action { get; set; }
        public string OperatorId { get; set; }
        public object Ipo { get; set; }
        public object Dto { get; set; }
    }
}
