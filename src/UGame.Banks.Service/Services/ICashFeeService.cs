using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.DbCaching;
using UGame.Banks.Service.Services.Cash;

namespace UGame.Banks.Service.Services
{
    /// <summary>
    /// 计算手续费服务
    /// </summary>
    public interface ICashFeeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ipo"></param>
        /// <returns></returns>
        decimal Fee(CalcCashFeeIpo ipo);
    }
}
