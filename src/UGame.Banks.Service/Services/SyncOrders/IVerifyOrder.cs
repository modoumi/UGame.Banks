using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UGame.Banks.Repository;

namespace UGame.Banks.Service.Services.SyncOrders
{
    /// <summary>
    /// 同步三方订单接口
    /// </summary>
    public interface IVerifyOrder
    {
        ///// <summary>
        ///// 同步订单
        ///// </summary>
        ///// <param name="orderEo"></param>
        ///// <returns></returns>
        //Task VerifyOrder(Sb_bank_orderEO orderEo);
        Task VerifyOrder(VerifyOrderIpo ipo);
    }
}
