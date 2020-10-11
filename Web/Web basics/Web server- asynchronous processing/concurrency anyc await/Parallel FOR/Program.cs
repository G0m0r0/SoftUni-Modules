namespace Parallel_FOR
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    class Program
    {
        //DONT FORGET TO LOCK SHARED FILES !!!

        static object lockObj = new object();
        private static int Count = 0;
        static void Main()
        {
            var sw = Stopwatch.StartNew();
            PrimeNumberCounter(1,10_000_000);
            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);

            //664580
            //00:00:11.1111191
            //vs
            //664580
            //00:00:02.9768593
        }

        private static void PrimeNumberCounter(int min,int max)
        {
            //for (int i = min; i <= max; i++)
            Parallel.For(min, max + 1, i =>
                {
                    bool isPrime = true;
                    for (int j = 2; j <= Math.Sqrt(i); j++)
                    {
                        if (i % j == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }

                    if (isPrime)
                    {
                        lock (lockObj)
                        {
                            Count++; //lock because its shared resourse between the threads
                        }
                    }
                });
        }
    }
}
