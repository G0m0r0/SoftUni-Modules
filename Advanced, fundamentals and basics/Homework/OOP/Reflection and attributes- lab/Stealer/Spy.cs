using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameClass, params string[] requstedFields)
        {
            Type classType = Type.GetType(nameClass);

            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance |
                BindingFlags.Static |
                BindingFlags.NonPublic |
                BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            Object classInstanc = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {classType}");

            foreach (FieldInfo field in classFields.Where(f => requstedFields.Contains(f.Name)))
            {
                //get field value
                sb.AppendLine($"{field.Name}={field.GetValue(classInstanc)}");
            }

            return sb.ToString().Trim();
        }
    }
}
