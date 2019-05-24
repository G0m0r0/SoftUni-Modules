using System;

namespace _7._Pascal_Triangle
{
    class PaskalTriangle
    {
        static void Main(string[] args)
        {
            int levelsOfTriangle = int.Parse(Console.ReadLine());
            long[][] jaggedArray = new long[levelsOfTriangle][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                jaggedArray[i] = new long[i + 1];
                jaggedArray[i][0] = 1;
                jaggedArray[i][i] = 1;
            }

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                if (jaggedArray[i].Length > 2)
                    for (int j = 1; j < jaggedArray[i].Length-1; j++)
                    {
                        jaggedArray[i][j] = jaggedArray[i - 1][j] + jaggedArray[i - 1][j - 1];
                    }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(" ",row));
            }
        }
    }
}
