using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CodingAttribute
{
    public class CodeTracker
    {
        public void PrintMethodByAuthor(string author)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var type in types)
            {
                var methods = type.GetMethods(
                    BindingFlags.Public | BindingFlags.Instance |
                    BindingFlags.NonPublic | BindingFlags.Static);

                foreach (var method in methods)
                {
                   // method.CustomAttributes.Where(x => x.AttributeType == typeof(AuthorAttribute));
                   //or
                    var attributes = method.GetCustomAttributes<AuthorAttribute>();
                    if(attributes.Any(x=>x.Name==author))
                    {
                        Console.WriteLine(method);
                    }
                }
            }
        }
    }
}
