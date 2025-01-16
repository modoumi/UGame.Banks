using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Serialization;
using UGame.Banks.Service.Services.Pay;
using UGame.Banks.Service.Common;

namespace UGame.Banks.Service.Services.Cash
{
    /// <summary>
    /// 获取提现手续费Ipo
    /// </summary>
    public class CalcCashFeeIpo : PayIpoBase
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //public override Type DtoType => typeof(CalcCashFeeDto);

        ///// <summary>
        ///// 
        ///// </summary>
        //public override BankAction Action => BankAction.CalcCashFee;
        public string AdditionalParameters { get; set; }
    }

    /// <summary>
    /// 返回提现手续费dto
    /// </summary>
    public class CalcCashFeeDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Fee { get; set; }
    

    }
}
