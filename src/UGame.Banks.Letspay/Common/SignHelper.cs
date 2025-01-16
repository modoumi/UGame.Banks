using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UGame.Banks.Letspay.Common
{
    public class SignHelper
    {
        public static string GetSign(object obj, string key)
        {
            var dict = ObjectToMap(obj);
            StringBuilder sb = new StringBuilder();
            var ps = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in dict)
            {
                string name = p.Key;
                if (name == "sign")
                    continue;
                string o = p.Value;
                sb.Append(name + "=" + o + "&");
            }
            sb.Append("key=" + key);
            return Md5(sb.ToString());
        }

        public static string Md5(string str)
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

        private static SortedDictionary<string, string> ObjectToMap(object obj)
        {
            SortedDictionary<string, string> map = new SortedDictionary<string, string>();
            PropertyInfo[] pi = obj.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo p in pi)
            {
                var v = p.GetValue(obj, null) ?? "";
                map.Add(p.Name, v.ToString());
            }
            return map;
        }
    }
}
