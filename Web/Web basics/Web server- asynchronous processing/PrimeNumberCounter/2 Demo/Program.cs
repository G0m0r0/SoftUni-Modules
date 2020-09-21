namespace _2_Demo
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    class Program
    {
        private static Stopwatch sw = Stopwatch.StartNew();
        private static int Count = 0;
        static object lockObj = new object(); //different locks are named 
                                             //with objects bcs its only an address and its ref

        static void Main()
        {
            //WE SEE THAT THERE IS AN ERROR IN THE OUTPUT 
            //IF WE DONT USE LOCK BCS ALL THREADS SOMETIMES ARE TAKING THE SAME COUNT AND OVERIDE IT WITH OLD NUM!!!

            //Task.Run(PrintPrimeCount);
            Thread thread1 = new Thread(()=>PrintPrimeCount(1,2_500_000));
            thread1.Start();
            Thread thread2 = new Thread(()=>PrintPrimeCount(2_500_001,5_000_00));
            thread2.Start();
            Thread thread3 = new Thread(()=>PrintPrimeCount(5_000_001,7_500_000));
            thread3.Start();
            Thread thread4 = new Thread(()=>PrintPrimeCount(7_500_001,10_000_000));
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();


            Console.WriteLine(Count);
            Console.WriteLine(sw.Elapsed);
            while (true)
            {
                var input = Console.ReadLine();
                Console.WriteLine(input.ToUpper());
            }
        }

        private static void PrintPrimeCount(int min,int max)
        {
            for (int i = min; i <= max; i++)
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
                    lock(lockObj)
                    {
                        Count++;
                    }
                }
            }
        }
    }
}
