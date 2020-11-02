using System;
using System.Linq;

namespace Multidimensional_arrays__exercise
{
    class AbsDiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            int sumMainDiagonal = 0;
            int sumSecondDiagonal = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                    if(i==j)
                    {
                        sumMainDiagonal += matrix[i, j];
                    }
                    if(i+j==matrix.GetLength(0)-1)
                    {
                        sumSecondDiagonal += matrix[i, j];
                    }
                }
            }

            int absoluteDifference = Math.Abs(sumSecondDiagonal - sumMainDiagonal);
            Console.WriteLine(absoluteDifference);
        }
    }
}
