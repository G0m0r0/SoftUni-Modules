using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace synchronously
{
    class Program
    {
        static void Main()
        {
            var sw = Stopwatch.StartNew();
            MethodOne();

            MethodTwo();

            Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}  Input data:");
            Console.ReadLine();
        }

        private static void MethodOne()
        {
            Task.Delay(3000).Wait();
            Console.WriteLine("Download file 1");
        }

        private static void MethodTwo()
        {
            Task.Delay(3000).Wait();
            Console.WriteLine("Download file 2");
        }
    }
}
