using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject2.Utils
{
    internal static class ReflectionUtils
    {


        public static string ToStringExtension(this object obj)
        {
            StringBuilder sb = new StringBuilder();
            foreach (System.Reflection.PropertyInfo property in obj.GetType().GetProperties())
            {

                sb.Append(property.Name);
                sb.Append(": ");
                if (property.GetIndexParameters().Length > 0)
                {
                    sb.Append("Indexed Property cannot be used");
                }
                else
                {
                    sb.Append(property.GetValue(obj, null));
                }

                sb.Append(System.Environment.NewLine);
            }

            return sb.ToString();
        }

        public static Type GetTypeByName(string name)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Reverse())
            {
                var tt = assembly.GetType(name);
                if (tt != null)
                {
                    return tt;
                }
            }

            return null;
        }

    }
}
