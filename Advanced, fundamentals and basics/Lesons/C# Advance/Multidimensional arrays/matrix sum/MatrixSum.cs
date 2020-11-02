using System;
using System.Linq;
//linq language integrated query

namespace matrix_sum
{
    class MatrixSum
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] columElements = Console.ReadLine()
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = columElements[j];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));

            int sum = 0;
            foreach (var item in matrix)
            {
                sum += item;
            }

            //sum by colums then rows
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int sum1 = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sum1 += matrix[j, i];
                }
                Console.WriteLine(sum1);
            }
        }

    }
}
