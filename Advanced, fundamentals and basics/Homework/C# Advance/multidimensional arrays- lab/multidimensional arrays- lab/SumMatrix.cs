using System;
using System.Linq;

namespace multidimensional_arrays__lab
{
    class SumMatrix
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            int sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowNumbers[j];
                    sum += rowNumbers[j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}
