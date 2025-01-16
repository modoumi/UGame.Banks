using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Inx
{
    /// <summary>
    /// 
    /// </summary>
    public enum InxResponseCodeEnum
    {
        /// <summary>
        /// 成功
        /// </summary>
        Success = 200,
        /// <summary>
        /// 参数有误，如通过参数中 某个值查找数据，数据为空
        /// </summary>
        ValueError = 300,
        /// <summary>
        /// 参数有误，如参数需要验证，但验证失败了
        /// </summary>
        ParamNULL = 400,
        /// <summary>
        /// 服务器错误
        /// </summary>
        Exception = 500
    }
}
