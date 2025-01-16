using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Model
{ 
    //0000	成功
    public enum ErrorCodeEnum
    {
        /// <summary>
        /// 版本错误
        /// </summary>
        E1001 = 1,   //
        /// <summary>
        /// 商户错误
        /// </summary>
        E1002 = 2,  //
        /// <summary>
        /// 参数错误
        /// </summary>
        E1003 = 3,  //
        /// <summary>
        /// 订单号重复
        /// </summary>
        E1004 = 4, //
        /// <summary>
        /// 金额错误
        /// </summary>
        E1005 = 5, //
        /// <summary>
        /// 商品名称错误
        /// </summary>
        E1006 = 6, //
        /// <summary>
        /// 商品描述错误
        /// </summary>
        E1007 = 7, //
        /// <summary>
        /// 操作员编号错误
        /// </summary>
        E1008 = 8,//
        /// <summary>
        /// 验签失败
        /// </summary>
        E1009 = 9,//
        /// <summary>
        /// 解密数据错误
        /// </summary>
        E1010 = 10//
    }
}
