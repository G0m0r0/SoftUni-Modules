using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] matrix = new int[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            int sumSubSquare = int.MinValue;
            int index1 = 0, index2 = 0;
            //if we need higher than 2
            int size1 = 2;
            int size2 = 2;
            //initialize from console
            for (int i = 0; i < matrix.GetLength(0)-1; i++)
            {
                for (int j = 0; j < matrix.GetLength(1)-1; j++)
                {
                    int sum = matrix[i, j] + matrix[i, j + 1] + matrix[i + 1, j] + matrix[i + 1, j + 1];
                    //or
                    /*
                    for (int subRow = 0; subrow <size1 ; subrow++)
                    {
                        for (int subCol = 0; subcol < size2; subcol++)
                        {
                            sumSubSquare+=matrix[i+subRow,j+subCol];
                        }
                    }
                    its like:
                    int sum=
                       matrix[row+0,col+0]+matrix[row+0,col+1]+
                       matrix[row+1,col+0]+matrix[row+1,col+1];
                       and we have to substract -size1+1 and -size2+1 not only -1
                    */

                    if(sumSubSquare<sum)
                    {
                        sumSubSquare = sum;
                        index1 = i;
                        index2 = j;
                    }
                }
            }

            for (int i = index1; i < index1+2; i++)
            {
                for (int j = index2; j < index2+2; j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(sumSubSquare);
        }
    }
}
