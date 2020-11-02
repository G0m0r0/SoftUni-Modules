using System;
using System.Linq;

namespace condense_array_to_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] strArray = new int[array.Length - 1];
            for(int j=0;j<array.Length-1;j++)
            for (int i = 0; i < array.Length-1; i++)
            {
                array[i] = array[i] + array[i + 1];
            }
            Console.WriteLine(array[0]);
           // Console.WriteLine(string.Join(' ',array));
        }
    }
}
