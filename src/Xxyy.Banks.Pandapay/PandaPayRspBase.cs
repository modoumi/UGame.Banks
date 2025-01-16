namespace Xxyy.Banks.Pandapay
{
    public class PandaPayRspBase<T>
    {
        public string code { get; set; }
        public string message { get; set; }
        public string businessCode { get; set; }
        public T data { get; set; }
    }
}
