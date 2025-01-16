using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Resp
{
    public class TBase
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }

    public class TBase<T>
    {
        public bool success { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
