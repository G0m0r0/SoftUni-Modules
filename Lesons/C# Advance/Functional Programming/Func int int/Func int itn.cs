using System;

namespace Func_int_int
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 5;
            int b = Operation(a, number => number * 5); //25
            int c = Operation(a, number => number - 3); //2

            Console.WriteLine(b);
            Console.WriteLine(c);
        }
        static int Operation(int number,Func<int,int> operation)
        {
            return operation(number);
        }
    }
}
