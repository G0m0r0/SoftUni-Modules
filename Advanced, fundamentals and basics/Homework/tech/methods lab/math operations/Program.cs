using System;

namespace math_operations
{
    class Program
    {
        static double Calculator(int a,int b,string c)
        {
            switch (c)
            {
                case "*": return a * b;
                case "+": return a + b;
                case "/": return a / b;
                case "-": return a - b;
                default: return 0;
            }
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string c = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine(Calculator(a, b, c));         }
    }
}
