using Newtonsoft.Json;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Services.Pay
{
    /// <summary>
    /// 
    /// </summary>
    public class CallbackIpoCommonBase
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore,System.Text.Json.Serialization.JsonIgnore]
        public long Balance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore, System.Text.Json.Serialization.JsonIgnore]
        public long Bonus { get; set; }

    

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore, System.Text.Json.Serialization.JsonIgnore]
        public Sb_bank_orderEO Order { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonIgnore, System.Text.Json.Serialization.JsonIgnore]
        public Sb_order_trans_logEO BankTransLog { get; set; }
    }
}
