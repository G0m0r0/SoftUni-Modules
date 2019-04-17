using System;

namespace add_and_substract
{
    class Program
    {
        static int SumTwoIntegers(int a,int b)
        {
            return a + b;
        }
        static int SubstractThirdInteger(int ab,int c)
        {
            return ab - c;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(SubstractThirdInteger(SumTwoIntegers(a, b), c));
        }
    }
}
