using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Hubtel
{
    internal class HubtelCashIpo:BaseIpo
    {
        /// <summary>
        /// 出款时的用户钱包
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// hubtel支持的channel
        /// </summary>
        public string Channel { get; set; }
        public string CashAuditId { get; set; }
    }

    public class HubtelCashDto:BaseDto
    {

    }
}
