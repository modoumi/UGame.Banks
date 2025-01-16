namespace UGame.Banks.Tejeepay.Resp
{
    public class ProxyBalanceResponse
    {
        public ProxyBalanceRespHeader head { get; set; }
        public object body { get; set; }
    }

    public class ProxyBalanceRespHeader
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }

    }
    public class ProxyBalanceRespBody
    {
        public string payoutBalance { get; set; }
        public string balance { get; set; }
        public string mchtId { get; set; }
    }
}
