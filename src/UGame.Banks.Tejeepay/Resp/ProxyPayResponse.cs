namespace UGame.Banks.Tejeepay.Resp
{
    public class ProxyPayResponse
    {
       public  ProxyPayRespHeader head { get; set; }
        public object body { get; set; }
    }

    public class ProxyPayRespHeader
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }

    }
    public class ProxyPayRespBody
    {
        public string status { get; set; }
        public string tradeId { get; set; }
        public string batchOrderNo { get; set; }
        public string mchtId { get; set; }
        public string desc { get; set; }
    }

}
