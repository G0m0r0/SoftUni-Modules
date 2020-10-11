using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Examples
{
    class Program
    {
        static void Main(string[] args)
        {
            //just one thread !!! non blocking concurrency
            var sw = Stopwatch.StartNew();
            MethodOne();

            MethodTwo();

            Console.WriteLine($"{sw.Elapsed.TotalMilliseconds}  Input data:");
            Console.ReadLine();
        }

        private static async void MethodTwo()
        {
            await Task.Delay(3000);
            Console.WriteLine("Download file 2");
        }

        private static async void MethodOne()
        {
            await Task.Delay(3000);
            Console.WriteLine("Download file 1");
        }
    }
}
