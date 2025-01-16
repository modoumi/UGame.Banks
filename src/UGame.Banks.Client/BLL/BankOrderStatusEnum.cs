using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL
{
    /// <summary>
    ///  状态0-初始1-处理中2-成功3-失败4-已回滚5-异常且需处理6-异常已处理
    /// </summary>
    public enum BankOrderStatusEnum
    {
        /// <summary>
        /// 初始
        /// </summary>
        Initial = 0,
        /// <summary>
        /// 处理中
        /// </summary>
        Processing = 1,
        /// <summary>
        /// 成功
        /// </summary>
        Success = 2,
        /// <summary>
        /// 失败
        /// </summary>
        Fail = 3,
        /// <summary>
        /// 已回滚
        /// </summary>
        Rollback = 4,
        /// <summary>
        /// 异常且需处理
        /// </summary>
        Exception = 5,
        /// <summary>
        /// 异常已处理
        /// </summary>
        ExceptionHandled = 6
    }
}
