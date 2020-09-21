namespace PrimeNumberCounter
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    class Program
    {
        static void Main()
        {
            //Task.Run(PrintPrimeCount);
            Thread thread = new Thread(PrintPrimeCount);
            thread.Start();
            thread.Join(); //we use join threat has to finish in order for the program to finish

            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        private static void PrintPrimeCount()
        {
            Stopwatch sw = Stopwatch.StartNew();
            int n = 10000000;
            int count = 0;

            for (int i = 1; i <= n; i++)
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
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(sw.Elapsed);
        }
    }
}
