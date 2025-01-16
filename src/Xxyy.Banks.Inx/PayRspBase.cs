namespace Xxyy.Banks.Inx
{
    public class PayRspBase
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Obj { get; set; }
        /// <summary>
        /// 200.成功 300.参数有误，如通过参数中 某个值查找数据，数据为空 400.参数有误，如参数需要验证，但验证失败了 500. 服务器错误
        /// </summary>
        public int Code { get; set; }
    }
}
