using System;

namespace factorial_division
{
    class Program
    {
        static double Recursion(double num)
        {
            if (num == 0) return 0;
            else if (num == 1) return 1;
            return num*Recursion(num-1);

        }
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = 0;
            if (Recursion(b)!=0)
            c = Recursion(a) / Recursion(b);
            Console.WriteLine($"{(c):f2}");
        }
    }
}
