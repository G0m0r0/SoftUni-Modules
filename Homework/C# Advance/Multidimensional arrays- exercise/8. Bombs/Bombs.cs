using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            matrix = new int[dimentions, dimentions];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            char[] spliters = { ' ', ',' };
            int[] bombInput = Console.ReadLine().Split(spliters, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            List<int> coorinatesBomb = new List<int>(bombInput);

            while (coorinatesBomb.Count > 0)
            {
                int x = coorinatesBomb.First();
                coorinatesBomb.RemoveAt(0);
                int y = coorinatesBomb.First();
                coorinatesBomb.RemoveAt(0);                
                int value = matrix[x, y];
                if(value<0)
                {
                    value = 0;
                }
                //matrix[x, y] = 0;

                for (int i = x - 1; i <= x + 1; i++)
                {
                    for (int j = y - 1; j <= y + 1; j++)
                    {
                        if (Valid(i, j))
                        {
                            if (matrix[i,j]>0)
                                matrix[i, j] -= value;
                            //&&NotABomb(coorinatesBomb,i,j)
                        }
                    }
                }
            }
            Console.WriteLine($"Alive cells: {AliveCells(0)}");
            Console.WriteLine($"Sum: {SumAliveCells(0)}");
            PrintMatrix();
        }

        private static bool NotABomb(List<int> coorinatesBomb,int x,int y)
        {
            for (int i = 0; i < coorinatesBomb.Count; i += 2)
            {
                if(coorinatesBomb[i]==x&&coorinatesBomb[i+1]==y)
                {
                    return false;
                }
            }
            return true;
        }

        private static object SumAliveCells(int sum)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum;
        }

        private static int AliveCells(int count)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }

        private static bool Valid(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return false;
            }
            if (x > matrix.GetLength(0) - 1 || y > matrix.GetLength(1) - 1)
            {
                return false;
            }
            return true;
        }
    }
}
