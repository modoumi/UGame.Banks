using static StackExchange.Redis.Role;
using static UGame.Banks.BFpay.Proxy.CashReq;

namespace UGame.Banks.BFpay.IpoDto
{
    /// <summary>
    /// 代付回调通知类
    /// </summary>
    public class CashNotifyIpo
    {
        public class Head
        {
            public string RespCode { get; set; }

            public string RespMsg { get; set; }
        }

        public class Body
        {
            /// <summary>
            ///  商户代付批次号，值唯一
            /// </summary>
            public string BatchOrderNo { get; set; }

            /// <summary>
            /// 商户代付笔数，与detail代付明细集合数一致
            /// </summary>
            public int TotalNum { get; set; }

            /// <summary>
            /// 商户代付总金额，单位：分，为detail代付明细集合中金额总和
            /// </summary>
            public string TotalAmount { get; set; }

            /// <summary>
            /// 平台批次号
            /// </summary>
            public string TradeId { get; set; }

            /// <summary>
            ///  状态 
            ///              AUDIT_DOING 审核中
            //AUDIT_SUCCESS审核通过
            //AUDIT_FAIL审核未通过
            //DONE代付结束
            //DOING代付处理中
            //NONE 订单不存在
            /// </summary>
            public string Status { get; set; }

            /// <summary>
            /// 结果描述

            /// </summary>
            public string Desc { get; set; }

            public Detail[] Detail { get; set; }
        }
        public class Detail
        {
            /// <summary>
            /// 平台明细号
            /// </summary>
            public string DetailId { get; set; }

            /// <summary>
            /// 序号，商户自定义
            /// </summary>
            public string Seq { get; set; }

            /// <summary>
            /// 金额 单位：分
            /// </summary>
            public string Amount { get; set; }

            /// <summary>
            /// 状态
            ///             AUDIT_DOING 审核中
            ///AUDIT_SUCCESS审核通过
            ///AUDIT_FAIL审核未通过
            ///COMMITTED已提交
            ///COMMITTED_SUCCESS提交成功
            ///COMMITED_FAIL提交失败
            ///DOING代付处理中
            ///SUCCESS 代付成功
            ///FAIL 代付失败
            ///UNKNOWN 未知
            /// </summary>
            public string Status { get; set; }

            public string Desc { get; set; }

            public string FinishTime { get; set; }

        }

        public Head head { get; set; }

        public string body { get; set; }
    }
}
