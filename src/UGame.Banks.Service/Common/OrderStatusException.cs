using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Service.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderStatusException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public OrderStatusException() : base()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        public OrderStatusException(string msg):base(msg)  
        {

        }
    }
}
