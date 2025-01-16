using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Configuration;
using UGame.Banks.Service;
using Xxyy.Common;

namespace UGame.Banks.Hubtel
{
    public class HubtelConfig //: BankConfigBase//, ICustomConfig
    {
        //public override string SignHeaderName => "Authorization";

        //public const string ApiID = "92rRk7B";
        //public const string ApiKey = "ce206133d88246848b123ea3873ad4d7";

        public string ApiID { get; set; }
        public string ApiKey { get; set; }
        public string PosId { get; set; }
        public string PrepaId { get; set; }
        public string Channels { get; set; }
        public string CashCallbackUrl { get; set; }
        public string PayCallbackUrl { get; set; }
        public string PayBaseAddress { get; set; }
        public string VerifyCustomerBaseAddress { get; set; }
        public string CashBaseAddress { get; set; }
        public string VerifyPayOrderBaseAddress { get; set; }
        public string VerifyCashOrderBaseAddress { get; set; }
        public string QueryPosSalesAccountBaseAddress { get; set; }
        public string TransferCallbackUrl { get; set; }
        /// <summary>
        /// 测试环境是否跳过true--false
        /// </summary>
        public bool IsTesting { get; set; }

        public Dictionary<string,List<HubtelChannelFeeItem>> CashFeeRule { get; set; }
        public Dictionary<string,List<HubtelChannelFeeItem>> PayFeeRule { get; set; }
        public class HubtelChannelFeeItem
        {
            public decimal Start { get; set; }
            public decimal End { get; set; }
            public decimal FixedValue { get; set; }
            public decimal VariableValue { get; set; }
        }
    }
}
