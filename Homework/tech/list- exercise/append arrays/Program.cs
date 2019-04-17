using System;
using System.Collections.Generic;
using System.Linq;

namespace append_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrays = Console.ReadLine()
                .Trim()
                .Split("|")
                .ToArray();

            List<int> listInt = new List<int>();

            for (int i = arrays.Length - 1; i >= 0; i--)
            {
                int[] arrayInt = arrays[i]
                    .Trim()
                    .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < arrayInt.Length; j++)
                {
                    listInt.Add(arrayInt[j]);
                }
            }
            Console.WriteLine(string.Join(" ",listInt));
        }
    }
}
