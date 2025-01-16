using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.Json;
using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Tejeepay.Resp
{
    public class ProxyPayAsyncResponse : CallbackIpoCommonBase
    {
        /// <summary>
        /// 手续费，固定费率0.01M
        /// </summary>
        public decimal fee
        {
            get; set;

        }
        public string body { get; set; }
        public ProxyPayAsynRespHead head { get; set; }

        public override string ToString()
        {
            return string.Format("{{ \"fee\":\"{0}\",\"body\":\"{1}\",\"head\":{2} }} ", fee, body, JsonConvert.SerializeObject(head));
        }
    }

    public class ProxyPayAsynRespHead
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }
    }

    public class ProxyPayAsynBody
    {
        public string batchOrderNo { get; set; }//":"5000",
        public string tradeId { get; set; } //":"",
        public string totalNum { get; set; }//":"",
        public string totalAmount { get; set; }//":"2000724000586621",
        public string status { get; set; }//":"YWS190722071052802",
        public string desc { get; set; }//":"ba215ef6338c4cfdb83b920cdd418d11",
        public List<ProxyPayRespDetail> detail { get; set; }//":"SUCCESS",
        
    }

    public class ProxyPayRespDetail
    {
        public string seq { get; set; }
        public string detailId { get; set; }
     
        public string amount { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string finishTime { get; set; }

        public override string ToString()
        {
            return string.Format("seq:{0},detailId:{1},amount:{2},status:{3},desc:{4}", seq, detailId, amount, status, desc);
        }
    }
}
