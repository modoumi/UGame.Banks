using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Letspay.Resp
{
    public class PayOutAsyncResponse : CallbackIpoCommonBase
    {

        public string mchId { get; set; }
        public string mchTransNo { get; set; }
        public string amount { get; set; }
        /// <summary>
        /// 1 处理中,2 成功,3 失败
        /// </summary>
        public string status { get; set; }
        public string transSuccTime { get; set; }
        public string sign { get; set; }
        public string msg { get; set; }

        public decimal fee { get; set; }
    }
}
