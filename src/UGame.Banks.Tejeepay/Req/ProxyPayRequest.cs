using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace UGame.Banks.Tejeepay.Req
{
    public class ProxyPayRequest
    {
        public ProxyPayHeader head { get; set; }
        public object body { get; set; }  
    }
    public class ProxyPayHeader
    {
        public string mchtId { get; set; }// = "2020724000586621";
        /// <summary>
        /// pix代付
        /// </summary>
        public string biz { get; set; } //= "df104";
        public int version { get; set; } //= 20;
    }
    public class ProxyPayDetail
    {
        public string seq { get; set; } //": "0",
        public long amount { get; set; } //": "100",
        public int accType { get; set; } //": "0",
        public int certType { get; set; } //":"0",
        public string certId { get; set; }//": "23423423424242",
        public string bankCardNo { get; set; }//": "23423423424242",
        public string bankCardName { get; set; }//":"Asse Drrt"


        /// <summary>
        /// 银行编码（银行卡代付时必传）
        /// </summary>
        public string bankCode { get; set; }

        /// <summary>
        /// 1借记卡 2信用卡
        /// </summary>
        public string bankCardType { get; set; }
        /// <summary>
        /// 银行卡类型为2信用卡时必传 信用卡有效期,MMyy
        /// </summary>
        public string creditValid { get; set; }
        /// <summary>
        /// 银行卡类型为2信用卡时必传 卡背面后3位数字
        /// </summary>
        public string creditCvv { get; set; }

        /// <summary>
        /// 收款人手机号(墨西哥代付下单必填)
        /// </summary>
        public string? mobile { get; set; }

        /// <summary>
        /// 收款人邮箱(墨西哥代付下单必填)
        /// </summary>
        public string? email { get; set; }

        /// <summary>
        /// 银行名称
        /// </summary>
        public string? bankName { get; set; }

    }
    public class ProxyPayBody
    {
        public string batchOrderNo { get; set; }
        public int totalNum {
            get {
                return this.detail.Count;
            }
            //set; 
        }//是    //商户代付笔数，与detail代付明细集合数一致
        public long totalAmount { 
            get
            {
                long total = 0;
                foreach(var item in detail)
                {
                    total+= item.amount;
                }
                return total;
            }
            
            //set; 
        }//是 string //商户代付总金额，单位：分，为detail代付明细集合中金额总和
        public string notifyUrl { get; set; }//否 string //异步通知地址
        public List<ProxyPayDetail> detail { get; set; }   //是   jsonarray //代付订单明细，Json数组格式，详情参照【detail参数说明】
        public string appId { get; set; }//否   string //产品Id
        public string currencyType { get; set; }



    }
}
