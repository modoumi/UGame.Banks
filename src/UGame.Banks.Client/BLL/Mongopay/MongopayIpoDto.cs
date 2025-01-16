using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Client.BLL.Mongopay
{

    public class MongopayDto : BaseDto
    {
        /// <summary>
        /// 创建的虚拟账号
        /// </summary>
        public string VaNumber { get; set; }
    }
}
