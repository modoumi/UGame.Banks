using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Ipo
{
    public class TejeeCallbackDto
    {
        public string status { get; set; } = "fail"; //= "SUCCESS";
        public string msg { get; set; }
    }
}
