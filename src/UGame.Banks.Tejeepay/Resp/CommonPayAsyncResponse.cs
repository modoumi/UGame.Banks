using UGame.Banks.Service.Services.Pay;

namespace UGame.Banks.Tejeepay.Resp
{
    public class CommonPayAsyncResponse : CallbackIpoCommonBase
    {
        /// <summary>
        /// 手续费，固定费率0.03M;
        /// </summary>
        public decimal fee
        {
            get; 
            set;
            //{
            // return long.Parse(body.amount) * 0.03M;
            //}
        }
     


        public CommonPayAsynBody body { get; set; }
        public CommonPayAsynHead head { get; set; }
    }

    public class CommonPayAsynHead
    {
        public string respCode { get; set; }
        public string respMsg { get; set; }
    }

    public class CommonPayAsynBody
    {
        public string amount { get; set; }//":"5000",
        public string biz { get; set; } //":"",
        public string chargeTime { get; set; }//":"",
        public string mchtId { get; set; }//":"2000724000586621",
        public string orderId { get; set; }//":"YWS190722071052802",
        public string seq { get; set; }//":"ba215ef6338c4cfdb83b920cdd418d11",
        public string status { get; set; }//":"SUCCESS",
        public string tradeId { get; set; }//":"P1907221355093250590",
        public string payType { get; set; }//":"bq101"
    }
}
