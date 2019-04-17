using System;
using System.Linq;

namespace equal_sums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int index = -1;
            for (int i = 0; i <array.Length ; i++)
            {
                int sumRight = 0;
                for (int j = i+1; j < array.Length; j++)
                {
                    sumRight += array[j];
                }
                int sumLeft = 0;
                for (int j = i - 1; j >= 0; j--)
                {
                    sumLeft += array[j];
                }
                if (sumLeft == sumRight)
                {
                    index = i;
                }
            }
            if (index != -1) Console.WriteLine(index);
            else Console.WriteLine("no");
        }
    }
}
