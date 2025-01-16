using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Req
{
    public class QueryPayHeader
    {
        public string mchtId { get; set; }// = "2020724000586621";
        public string biz { get; set; }// = "qj301";
        public int version { get; set; }//= 20;
    }
    public class QueryPayBody
    {
        public string orderTime { get; set; } //= "20190722135508";
        public string orderId { get; set; } //= "YWS190722071052802";
        public string currencyType { get; set; } //= "BRL";
    }
    public class QueryPayRequest
    {
        public QueryPayHeader head { get; set; }
        public QueryPayBody body { get; set; }
        public string sign { get; set; }

    }
}
