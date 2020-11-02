using System;
using System.Linq;

namespace hold_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Trim()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int middleStartIndex = (array.Length / 2)/2;
            int middleEndIndex = middleStartIndex + array.Length / 2;

            int sumIndex = middleStartIndex - 1;

            for (int i = middleStartIndex; i <middleEndIndex ; i++)
            {
                int sum = array[i] + array[sumIndex];
                Console.Write($"{sum} ");
                sumIndex--;
                if(sumIndex<0)
                {
                    sumIndex = array.Length - 1;
                }
            }
        }
    }
}
