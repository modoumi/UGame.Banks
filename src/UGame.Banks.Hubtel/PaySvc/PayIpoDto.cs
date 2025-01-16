using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Hubtel.PaySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class PayIpo : PayIpoBase
    {
        /// <summary>
        /// 还款（充值）时的用户钱包
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 还款（充值）时的用channel
        /// </summary>
        public string Channel { get; set; }

        [JsonIgnore,Newtonsoft.Json.JsonIgnore]
        public decimal PayFee { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.HubtelPay;

        ///// <summary>
        ///// 
        ///// </summary>
        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(PayIpo);
    }

    /// <summary>
    /// 
    /// </summary>
    public class PayDto : PayDtoBase
    {
    }
}
