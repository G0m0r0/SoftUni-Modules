using System;

namespace pyramid
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            PrintTriangle(number);
            PrintReverseTriangle(number - 1);
        }

        private static void PrintReverseTriangle(int maxNumber)
        {
            for (int i = maxNumber; i >= 1; i--)
            {
                PrintNumOnRows(i);
            }
        }

        private static void PrintTriangle(int maxNumber)
        {
            for (int i = 1; i <= maxNumber; i++)
            {
                PrintNumOnRows(i);
            }
        }

        private static void PrintNumOnRows(int i)
        {
            for (int j = 1; j <= i; j++)
            {
                Console.Write(j + " ");
            }
            Console.WriteLine();
        }
    }
}
