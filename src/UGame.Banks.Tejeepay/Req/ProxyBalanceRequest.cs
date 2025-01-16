namespace UGame.Banks.Tejeepay.Req
{
    public class ProxyBalanceHeader
    {
        public string mchtId { get; set; }// = "2020724000586621";
        public string biz { get; set; }// = "qj301";
        public int version { get; set; }//= 20;
    }
    public class ProxyBalanceBody
    {
        public string mchtId { get; set; } //= "YWS190722071052802";
        public string currencyType { get; set; } //= "BRL";
 
    }
    public class ProxyBalanceRequest
    {
        public ProxyBalanceHeader head { get; set; }
        public object body { get; set; }

    }
}
