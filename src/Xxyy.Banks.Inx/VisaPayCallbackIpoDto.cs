using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xxyy.Banks.BLL.Services.Pay;

namespace Xxyy.Banks.Inx
{
    /// <summary>
    /// visa支付回调
    /// </summary>
    public class VisaPayCallbackIpo : CallbackIpoBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore]
        public string BankId { get; set; }
    }

    /// <summary>
    /// visa支付回调dto
    /// </summary>
    public class VisaPayCallbackDto : CallbackDtoBase
    {

    }
}
