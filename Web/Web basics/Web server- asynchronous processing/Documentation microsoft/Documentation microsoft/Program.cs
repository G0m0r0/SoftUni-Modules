using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Documentation_microsoft
{
    class Program
    {
        public static async Task Main()
        {
            var sw = Stopwatch.StartNew();

             await Task.Run(() => {
                 // Just loop.
                 int ctr = 0;
                 for (ctr = 0; ctr <= 1000000; ctr++)
                 { }
                 Console.WriteLine("Finished {0} loop iterations",
                                   ctr);
             });
           // int i = 0;
           // for (i = 0; i <= 1000000; i++)
           // { }
           // Console.WriteLine($"Finished {i} loop iterations");

            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
