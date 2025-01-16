using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay.Common
{
    public class NetUtils
    {
        public static string getIp(HttpContext httpContext, bool flag = true) //_httpContextAccessor 
        {
            //"123.119.226.251:43430, 123.119.226.251"
            var userHostAddress = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(userHostAddress))
            {
                userHostAddress = httpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
                userHostAddress = IPAddress.Parse(userHostAddress).MapToIPv4().ToString();
            }
            if (!string.IsNullOrEmpty(userHostAddress))
            {
                var ips = userHostAddress.Contains(",") ? userHostAddress.Split(",")[0] : userHostAddress;
                //如果包含ip+端口，只取ip
                return flag ? (ips.Contains(":") ? ips.Split(":")[0] : ips) : ips;
            }

            return "127.0.0.1";
        }
    }
}
