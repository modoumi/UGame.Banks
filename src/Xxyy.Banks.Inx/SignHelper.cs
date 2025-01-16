using System.Security.Cryptography;
using System.Text;

namespace Xxyy.Banks.Inx
{
    internal class SignHelper
    {
        public static string GetSign(SortedDictionary<string, string> paramList)
        {
            string appId = paramList["AppId"];
            paramList.Remove("_Sign");
            paramList.Remove("Sign");
            //StringBuilder sb = new StringBuilder(appId);
            StringBuilder sb = new StringBuilder();
            foreach (var p in paramList)
                sb.Append(p.Key).Append(p.Value);
            //sb.Append(appId);
            return GetMD5(sb.ToString());
        }
        public static string GetSign(RequestBase request, string appSecret)
        {
            var param = new SortedDictionary<string, string>(new AsciiComparer());
            var properties = request.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (var property in properties)
            {
                string pn = property.Name;
                if (pn == "Sign")
                {
                    continue;
                }
                param.Add(pn, property.GetValue(request)?.ToString());
            }
            param.Add("AppSecret", appSecret);
            return SignHelper.GetSign(param);
        }
        public static string GetMD5(string str)
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

        public static string GetSHA(string input)
        {
            using (var sha = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }

        }
    }
}
