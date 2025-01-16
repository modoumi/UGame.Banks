using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Tejeepay
{
    public class SighHelper
    {
        public static string GetSign(object obj, String signKey = "")
        {
            SortedDictionary<string, object> paramList = null;
            if (!(obj is SortedDictionary<string, object>))
            {
                paramList = ToSortedDictionary(obj);
            }
            else
            {
                paramList = obj as SortedDictionary<string, object>;
            }
            if (signKey != null && paramList.ContainsKey(signKey))
            {
                paramList.Remove(signKey);
            }

            StringBuilder sb = new StringBuilder();
            foreach (var p in paramList)
            {
                if (string.IsNullOrEmpty(p.Value?.ToString()))
                {
                    continue;
                }
                sb.Append(p.Key).Append("=").Append(p.Value).Append("&");
            }
            sb.Append("key=" + signKey);
            return GetMD5(sb.ToString());
        }
        private static Dictionary<string, object> ToDictionary(object obj)
        {
            Dictionary<string, object> ret = new Dictionary<string, object>();

            foreach (PropertyInfo prop in obj.GetType().GetProperties())
            {
                string propName = prop.Name;
                var val = prop.GetValue(obj, null);
                if (val != null)
                {
                    ret.Add(propName, val);
                }
                else
                {
                    ret.Add(propName, null);
                }
            }

            return ret;
        }
        private static SortedDictionary<string, object> ToSortedDictionary(object obj)
        {
            SortedDictionary<string, object> ret = new SortedDictionary<string, object>();
            var type = obj.GetType();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                string propName = prop.Name;
                var val = prop.GetValue(obj, null);
                if (val != null)
                {
                    ret.Add(propName, val);
                }
                else
                {
                    ret.Add(propName, null);
                }
            }
            return ret;
        }

        private static string GetMD5(string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            var sb = new StringBuilder(32);
            var md5 = System.Security.Cryptography.MD5.Create();
            var output = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < output.Length; i++)
                sb.Append(output[i].ToString("X").PadLeft(2, '0'));
            return sb.ToString();
        }
    }
}
