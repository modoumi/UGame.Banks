using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Service
{
    public enum OrderTypeEnum
    {
        Init=0,
        /// <summary>
        /// 充值
        /// </summary>
        Charge=1,
        /// <summary>
        /// 返现
        /// </summary>
        Draw=2
    }
}
