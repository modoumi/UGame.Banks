using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Hubtel.PaySvc
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelsIpo : BankIpoBase
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public string UserId { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //public string AppId { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[System.Text.Json.Serialization.JsonIgnore, Newtonsoft.Json.JsonIgnore]
        //public override Type DtoType => typeof(ChannelsDto);
    }

    /// <summary>
    /// 
    /// </summary>
    public class ChannelsDto
    {
        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<string> Channels { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }
    }
}
