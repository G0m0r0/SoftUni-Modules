using System;

namespace Sub_matrix
{
    class SubMatrix
    {
        static void Main(string[] args)
        {
            int[,] matrix =
            {
                {7,1,3,3,2,1 },
                {1,3,9,8,5,6 },
                {4,6,7,9,1,0 }
            };

            int maxSum = int.MinValue;
            int rowIndex = 0;
            int colIndex = 0;

            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1]
                        + matrix[i + 1, j] + matrix[i + 1, j + 1];

                    if(sum>maxSum)
                    {
                        maxSum = sum;
                        rowIndex = i;
                        colIndex = j;
                    }

                }
            }
            Console.WriteLine(maxSum);
            for (int i = rowIndex; i < rowIndex+2; i++)
            {
                for (int j = colIndex; j < colIndex+2; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
