using System;

namespace Simple_Calculator
{
    class Program
    {
        static int SmallestNum(int[] array)
        {
            int smallestNUm = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < smallestNUm)
                    smallestNUm = array[i];
            }
            return smallestNUm;
        }
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int[] array = { a, b, c };
            Console.WriteLine(SmallestNum(array));

        }
    }
}
