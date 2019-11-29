using System;
using System.Reflection;

[assembly: AssemblyVersion("2.1.3.4")]

namespace Global_attributes
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Assembly.GetExecutingAssembly());
        }
    }
}
