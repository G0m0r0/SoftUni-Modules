using System;
using System.Linq;

namespace _2._1_Sum_matrix_columns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            int[] sumColoumns = new int[size[1]];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                    sumColoumns[j] += rowInput[j];
                }
            }

            for (int i = 0; i < sumColoumns.Length; i++)
            {
                Console.WriteLine(sumColoumns[i]);
            }
        }
    }
}
