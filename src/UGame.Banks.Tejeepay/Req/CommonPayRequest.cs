using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Req
{
    public class CommonPayHeader
    {
        public string mchtId { get; set; }// = "2000724000586621";
        public string biz { get; set; } //= "qj301";
        public int version { get; set; }// = 20;
    }
    public class CommonPayBody
    {
        public long amount { get; set; } //= 5000;
        public string desc { get; set; } //= "A16WX2019072213000500026502-YWS190722070956320";
        public string goods { get; set; } //= "A16WX2019072213000500026502-YWS190722070956320";
        public string orderTime { get; set; } //= "20190722130005";
        public string notifyUrl { get; set; } //= "http://epay.marketfree.top/PayRec?idx=3002";
        public string currencyType { get; set; } //= "20190722130005";
        public string orderId { get; set; }// = "YWS190722070956320";
        public string ip { get; set; } //= "127.0.0.1";
        public string callBackUrl { get; set; } //= "http://epay.marketfree.top/PayRec?idx=3002";
        public string phone { get; set; } //= "+0055 31385342424";
        public string email { get; set; } //= "test@inxtech.cn";
        public string name { get; set; } //= "test";
    }
    public class CommonPayRequest
    {
        public CommonPayHeader head { get; set; }
        public CommonPayBody body { get; set; }

        public string sign { get; set; }

    }
}
