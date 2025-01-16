using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Lobby.Flow.IpoDto
{
    public class FlowProgressDto
    {
        /// <summary>
        /// 可提现金额
        /// </summary>
        public decimal CashMoney { get; set; } = 0;

        /// <summary>
        /// 第一条未完成的流水订单信息
        /// </summary>
        public ProgressRequireFlowOrder FlowOrder { get; set; }
        public class ProgressRequireFlowOrder
        {
            /// <summary>
            /// 提现需要完成的流水
            /// </summary>
            public decimal RequireFlow { get; set; } = 0;
            /// <summary>
            /// 提现已完成的流水
            /// </summary>
            public decimal CompletedFlow { get; set; } = 0;

            /// <summary>
            /// 第一条未完成流水订单日期
            /// </summary>
            public DateTime OrderDate { get; set; }

            /// <summary>
            /// 第一条未完成流水订单金额
            /// </summary>
            public decimal OrderAmount { get; set; }

            /// <summary>
            /// 第一条未完成订单的要求流水的倍数
            /// </summary>
            public float FlowMultip { get; set; }
        }
    }

    internal class SumRequireFlow
    {
        public long? RequireFlow { get; set; } = 0;

        public long? CompletedFlow { get; set; } = 0;

        /// <summary>
        /// 第一条未完成流水订单日期
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// 第一条未完成流水订单金额
        /// </summary>
        public long OrderAmount { get; set; }

        /// <summary>
        /// 第一条未完成订单的要求流水的倍数
        /// </summary>
        public float FlowMultip { get; set; }
    }
}
