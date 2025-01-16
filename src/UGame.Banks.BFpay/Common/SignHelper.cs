using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Security;

namespace UGame.Banks.BFpay.Common
{
    public static class SignHelper
    {
        public static string GetSign(object req, string key)
        {
            var keyValuesStr = GetPropValuesWithoutSign(req);
            var signstr = string.Join("&", keyValuesStr) +"&key="+key;
            return SecurityUtil.MD5Hash(signstr,CipherEncode.Bit32Lower);
        }

        public static IEnumerable<string> GetPropValues(object req)
        {
            return from prop in GetAllPropValues(req)
                   let propValue = prop.GetValue(req)
                   where propValue != null && !string.IsNullOrWhiteSpace(propValue.ToString())
                   orderby prop.Name
                   select $"{prop.Name}={propValue}";
        }

        private static IEnumerable<string> GetPropValuesWithoutSign(object req)
        {
            return from prop in GetAllPropValues(req)
                   let propValue = prop.GetValue(req)
                   where prop.Name != "sign" && propValue != null && !string.IsNullOrWhiteSpace(propValue.ToString())
                   orderby prop.Name
                   select $"{prop.Name.ToCamelCase()}={propValue}";
        }

        private static IEnumerable<PropertyInfo> GetAllPropValues(object req) => req.GetType().GetProperties();

        public static string ToCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input) || char.IsLower(input[0]))
            {
                return input;
            }

            return char.ToLowerInvariant(input[0]) + input.Substring(1);
        }

        public static T ToCamelCase<T>(this T input) where T : class
        {
            Type type = input.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                string propertyName = property.Name.ToCamelCase();
                PropertyInfo camelCaseProperty = type.GetProperty(propertyName);

                if (camelCaseProperty != null && camelCaseProperty.CanWrite)
                {
                    object value = property.GetValue(input);
                    camelCaseProperty.SetValue(input, value);
                }
            }

            return input;
        }

    }
}
