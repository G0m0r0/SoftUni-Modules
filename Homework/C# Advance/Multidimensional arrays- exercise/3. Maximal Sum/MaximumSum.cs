using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class MaximumSum
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            int maxSum = int.MinValue;
            int index1 = 0;
            int index2 = 0;
            for (int i = 0; i < matrix.GetLength(0) - 2; i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 2; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                        + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];
                    if (maxSum < sum)
                    {
                        maxSum = sum;
                        index1 = i; 
                        index2 = j;
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            for (int i = index1; i < index1+3; i++)
            {
                for (int j = index2; j < index2+3; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
