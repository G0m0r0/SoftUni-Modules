using System;
using System.Diagnostics;

namespace class_debug
{
    class Program
    {
        static void Main()
        {
            int a = 10;
           // int b = 30;

            Debug.WriteLine("14 a+b");
            Debug.WriteLineIf(a == 10, "Its equal");

            Debug.Assert(10 == 110);

            Console.WriteLine("HAHA");
        }
    }
}
