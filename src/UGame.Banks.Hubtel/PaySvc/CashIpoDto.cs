using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Service.Common;
using UGame.Banks.Service.Services.Pay;
using System.Text.Json.Serialization;

namespace UGame.Banks.Hubtel.PaySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class CashIpo : PayIpoBase
    {
        /// <summary>
        /// 出款时的用户钱包
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// hubtel支持的channel
        /// </summary>
        public string Channel { get; set; }

        [JsonIgnore,Newtonsoft.Json.JsonIgnore]
        public decimal CashFee { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override BankAction Action => BankAction.None;

        ///// <summary>
        ///// 
        ///// </summary>
        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(CashDto);
    }

    /// <summary>
    /// 
    /// </summary>
    public class CashDto : PayDtoBase
    {

    }
}
