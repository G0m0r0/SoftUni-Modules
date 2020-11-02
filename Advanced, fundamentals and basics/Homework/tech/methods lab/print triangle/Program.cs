using System;

namespace print_triangle
{
    class Program
    {
        static void PrintTriangle(int num)
        {
            for (int i = 1; i <= num; i++)
            {
                for (int j = 1; j <= i; j++)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine();
            }
        }
        static void ReverseTriangle(int num)
        {
            for (int i = num-1; i >=0 ; i--)
            {
                for (int j = 1; j <=i ; j++)
                {
                    Console.Write(j+" ");
                }
                Console.WriteLine();
            }
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintTriangle(number);
            ReverseTriangle(number);
        }
    }
}
