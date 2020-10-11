using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Parallelism
{
    class Program
    {
        static void Main(string[] args)
        {
            //USE TASKS performance ! its better if different tasks dont use share same resource

            var sw = Stopwatch.StartNew();

            Task.Factory.StartNew(MethodOne);
            Task.Factory.StartNew(MethodTwo);

            Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}  Input data:");
            Console.ReadLine();
        }
        private static void MethodOne()
        {
            Task.Delay(3000);
            Console.WriteLine("Download file 1");
        }

        private static void MethodTwo()
        {
            Task.Delay(3000);
            Console.WriteLine("Download file 2");
        }

    }
}
