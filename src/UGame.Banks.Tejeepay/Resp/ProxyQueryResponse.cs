using System.Collections.Generic;

namespace UGame.Banks.Tejeepay.Resp
{
    public class ProxyQueryResponse
    {
        public ProxyQueryRespHeader head { get; set; }
        public object body { get; set; }
    }
    public class ProxyQueryRespHeader
    {
        public string respCode { get; set; }// = "2020724000586621";
        public string respMsg { get; set; } //= "qj301";
        
    }

    public class ProxyQueryRespBody
    {
        public string batchOrderNo { get; set; }
        public string tradeId { get; set; }
        public string totalNum { get; set; }
        public string totalAmount { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public List<ProxyQueryDetail> detail { get; set; }

    }
    public class ProxyQueryDetail
    {
        public string detailId { get; set; }
        public string amount { get; set; }
        public string status { get; set; }
        public string desc { get; set; }
        public string seq { get; set; }
        /// <summary>
        /// 代付完成时间
        /// </summary>
        public string finishTime { get; set; }
    }
}

