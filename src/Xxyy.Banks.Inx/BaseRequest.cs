namespace Xxyy.Banks.Inx
{
    public class RequestBase
    {
        public long Timestamp { get; set; }
        public string Sign { get; set; }
        public string AppId { get; set; }
    }
}
