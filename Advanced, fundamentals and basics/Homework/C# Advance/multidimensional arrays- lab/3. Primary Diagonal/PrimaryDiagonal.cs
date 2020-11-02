using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class PrimaryDiagonal
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            int sumDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (i == j)
                        sumDiagonal += matrix[i, j];
                }
            }

            Console.WriteLine(sumDiagonal);
        }
    }
}
