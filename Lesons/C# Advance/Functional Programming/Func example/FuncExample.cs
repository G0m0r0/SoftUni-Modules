using System;

namespace Functional_Programming
{
    class FunctionalPrograming
    {
        static void Main(string[] args)
        {
            int a = 0;
            string x = "asasdda";

            PrintResult(5, Square);
            PrintResult(5, Facoriel);
        }

        static void PrintResult(int x,Func<int,long> func)
        {
            var result = func(x);
            Console.WriteLine("=============");
            Console.WriteLine("=============");
            Console.WriteLine($"         Result {result}");
            Console.WriteLine("=============");

        }

        static long Square(int number)
        {
            return number * number;
        }

        static long Facoriel(int number)
        {
            long result = 1;
            for (int i = 2; i <= number; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}
