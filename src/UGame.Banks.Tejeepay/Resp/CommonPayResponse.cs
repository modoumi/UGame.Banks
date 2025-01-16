namespace UGame.Banks.Tejeepay.Resp
{
    public class CommonPayResponse
    {
        public CommonPayRespHead head { get; set; }
        public CommonPayRespBody body { get; set; }

        public string sign { get; set; }
    }

    public class CommonPayRespHead
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }
    }

    public class CommonPayRespBody
    {
        public string mchtId { get; set; }
        public string orderId { get; set; }

        public string payUrl { get; set; }

        public string tradeId { get; set; }
    }
}
