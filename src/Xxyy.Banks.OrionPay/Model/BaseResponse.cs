using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xxyy.Banks.Orionpay.Model
{
    public class BaseResponse<T>
    {
        public string code { get; set; }
        public string message { get; set; }
        public string businessCode { get; set; }
        public T data { get; set; }
    }
    public class BaseResponse
    {
        public string code { get; set; }
        public string message { get; set; }
        public string businessCode { get; set; }
        public object data { get; set; }
    }
}
