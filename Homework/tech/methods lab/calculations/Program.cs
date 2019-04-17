using System;

namespace calculations
{
    class Program
    {
        static int subtraction(int a, int b)
        {
            return a - b;
        }
        static int addition(int a, int b)
        {
            return a + b;
        }
        static int multiplication(int a, int b)
        {
            return a * b;
        }
        static double division(int a, int b)
        {
            return (double)a / b;
        }

        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            double result = 0;
            switch (operation)
            {
                case "subtract": result = subtraction(a, b); break;
                case "divide": result = division(a, b); break;
                case "multiply": result = multiplication(a, b); break;
                case "add": result = addition(a, b); break;
            }
            Console.WriteLine(result);
        }
    }
}
