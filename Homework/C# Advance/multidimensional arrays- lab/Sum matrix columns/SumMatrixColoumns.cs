using System;
using System.Linq;

namespace Sum_matrix_columns
{
    class SumMatrixColoumns
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            int sumColoumn = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    sumColoumn += matrix[j, i];
                }
                Console.WriteLine(sumColoumn);
                sumColoumn = 0;
            }
        }
    }
}
