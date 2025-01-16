namespace UGame.Banks.Tejeepay.Resp
{
    public class QueryPayResponse
    {
        public QueryPayRespHead head { get; set; }
        public QueryPayRespBody body { get; set; }
        public string sign { get; set; }

    }
    public class QueryPayRespHead
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }
    }
    public class QueryPayRespBody
    {
        public string amount { get; set; }//":"5000",
        public string biz { get; set; }//":"",
        public string chargeTime { get; set; }//":"",
        public string mchtId { get; set; }//":"2000724000586621",
        public string orderId { get; set; }//":"YWS190722071052802",
        public string seq { get; set; }//":"ba215ef6338c4cfdb83b920cdd418d11",
        public string status { get; set; }//":"SUCCESS",
        public string tradeId { get; set; }//":"P1907221355093250590"
    }
}
