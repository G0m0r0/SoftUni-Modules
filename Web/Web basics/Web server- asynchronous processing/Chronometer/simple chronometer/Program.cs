using System;
using System.Diagnostics;
using System.Threading;

namespace simple_chronometer
{
    class Program
    {
        static void Main()
        {
            var sw = new Stopwatch();

            sw.Start();

            Console.ReadLine();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
