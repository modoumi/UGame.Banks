using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TinyFx.Reflection;
using TinyFx.Security;

namespace Xxyy.Banks.Mongopay
{
    internal class SignHelper
    {
        public static string GetSign<T>(T request)
        {
            var excludeNames = new string[] {"Sign","PlatSign","Order","Balance", "BankTransLog", "OwnMoney" };
            var properties = request.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance).Where(x=>!excludeNames.Contains(x.Name)).ToList();
            properties.Sort(new PropertyComparer());
            var ret = string.Join("", properties.Select(p => ReflectionUtil.GetPropertyValue<string>(request, p.Name)));
            return ret;
        }
      
    }
    internal class PropertyComparer : IComparer<PropertyInfo>
    {
        public int Compare(PropertyInfo x, PropertyInfo y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
