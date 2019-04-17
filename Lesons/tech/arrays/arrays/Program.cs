using System;
using System.Linq;

namespace arrays
{
    class Program
    {
       static void Main()
        {
            string values = Console.ReadLine();
           // int[] valuesAsString = values.Split().Select(int.Parse).ToArray();
           //we have to use using System.Linq
            string[] valuesString = values.Split();
            int[] numbers= new int[valuesString.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] =int.Parse(valuesString[i]);
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]+" ");
            }
            Console.WriteLine();
            
        }
    }
}