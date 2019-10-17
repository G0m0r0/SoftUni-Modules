using System;

namespace Functional_Programming
{
    class FunctionalPrograming
    {
        static void Main(string[] args)
        {
            int a = 0;
            string x = "asasdda";

            //what if we want to use Factoriel insted of Square method
            Func<int, long> operation = Facoriel;
            //proxy our program is working through Func operation

            Console.WriteLine(Square(5));

            Console.WriteLine(operation(5));
            Console.WriteLine(operation(5));
            Console.WriteLine(operation(5));
            Console.WriteLine(operation(5));
            Console.WriteLine(operation(5));
        }

        //read only imutable
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
