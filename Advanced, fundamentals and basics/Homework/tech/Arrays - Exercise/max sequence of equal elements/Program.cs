using System;
using System.Linq;

namespace max_sequence_of_equal_elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int maxCount = 0;
            int maxElement = 0;
            int counter = 1;
            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] == array[i + 1])
                    counter++;       
                else counter = 1;
                if (counter > maxCount)
                {
                    maxCount = counter;
                    maxElement = array[i];
                }
            }
            for (int i=0;i<maxCount;i++)
            Console.Write(maxElement+" ");
        }
    }
}
