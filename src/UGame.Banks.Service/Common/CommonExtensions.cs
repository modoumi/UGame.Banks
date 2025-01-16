using Newtonsoft.Json.Linq;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyFx;

namespace UGame.Banks.Service.Common
{
    /// <summary>
    /// 
    /// </summary>
    public static class CommonExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static T ToSafeDeserialize<T>(this string str,T defaultVal=default(T))
        {
            try
            {
                return SerializerUtil.DeserializeJsonNet<T>(str);
            }
            catch
            {
                return defaultVal;
            }
        }
    }
}
