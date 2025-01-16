using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Ipo
{
    public class LetsCallbackDto
    {
        public string status { get; set; } = "fail";// "success";
        public string msg { get; set; }
    }
}
