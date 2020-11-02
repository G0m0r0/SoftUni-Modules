using System;

namespace Pascal_Triangle
{
    class Program
    {
        static void CreatePascalTriangle(long n, long[][] jaggedArray)
        {
            for (long i = 0; i < n; i++)
            {
                jaggedArray[i] = new long[i + 1];
            }

            jaggedArray[0][0] = 1;
            jaggedArray[1][0] = 1;
            jaggedArray[1][1] = 1;
            for (long i = 2; i < jaggedArray.Length; i++)
            {
                for (long j = 1; j < i; j++)
                {
                    jaggedArray[i][0] = 1;
                    jaggedArray[i][i] = 1;
                    jaggedArray[i][j] = jaggedArray[i - 1][j - 1] + jaggedArray[i - 1][j];
                }
            }
        }
        static void PrlongPascalTriangle(long[][] jagged)
        {
            for (long i = 0; i < jagged.Length; i++)
            {
                long[] innerArray = jagged[i];
                Console.WriteLine(string.Join(" ", innerArray));
            }
        }
        static void Main(string[] args)
        {
            long numOfRows = long.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[numOfRows][];
            if (numOfRows == 1)
                Console.WriteLine("1");
            else if (numOfRows == 2)
            {
                Console.WriteLine("1");
                Console.WriteLine("1 1");
            }
            else if (numOfRows == 0) return;
            else if (numOfRows == 0) return;
            else
            {
                CreatePascalTriangle(numOfRows, jaggedArray);
                PrlongPascalTriangle(jaggedArray);
            }
        }
    }
}
