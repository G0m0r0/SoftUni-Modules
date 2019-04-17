using System;

namespace recursive_fibunacci
{
    class Program
    {
        static int FibunacciRecursion(int n)
        {
            if (n == 1) return 1;
            else if (n == 2) return 1;
            else if (n == 3) return 2;
            return FibunacciRecursion(n - 1) + FibunacciRecursion(n - 2);
        }
        static void Main(string[] args)
        {
            int fibunacciNum = int.Parse(Console.ReadLine());
            Console.WriteLine(FibunacciRecursion(fibunacciNum));
        }
    }
}
