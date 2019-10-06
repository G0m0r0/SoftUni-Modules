using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] jaggedArray = new int[5][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new int[i];
            }

            Console.WriteLine(jaggedArray.GetLength(0));
            Console.WriteLine(jaggedArray.GetLength(1));
        }
    }
}
