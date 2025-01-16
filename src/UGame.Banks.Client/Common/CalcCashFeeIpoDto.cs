using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Serialization;

namespace UGame.Banks.Client.BLL
{
    internal class CalcCashFeeIpo : BaseIpo
    {
        public JsonMeta AdditionalParameters { get; set; }
    }

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
