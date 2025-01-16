namespace UGame.Banks.Tejeepay.Req
{
    public class ProxyQueryHeader
    {
        public string mchtId { get; set; }// = "2020724000586621";
        public string biz { get; set; }// = "qj301";
        public int version { get; set; }//= 20;
    }
    public class ProxyQueryBody
    {
        public string orderTime { get; set; } //= "20190722135508";
        public string batchOrderNo { get; set; } //= "YWS190722071052802";
        public string currencyType { get; set; } //= "BRL";
        public string tradeId { get; set; } //= "BRL";
    }
    public class ProxyQueryRequest
    {
        public ProxyQueryHeader head { get; set; }
        public object body { get; set; }

    }
}
