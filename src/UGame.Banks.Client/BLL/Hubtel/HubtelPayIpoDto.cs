using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Hubtel
{
    internal class HubtelPayIpo : BaseIpo
    {
        /// <summary>
        /// 还款（充值）时的用户钱包
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 还款（充值）时的用channel
        /// </summary>
        public string Channel { get; set; }
    }

    
}
