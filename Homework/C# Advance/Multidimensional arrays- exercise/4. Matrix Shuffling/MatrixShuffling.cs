using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class MatrixShuffling
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string[,] matrix = new string[size[0], size[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string[] rowInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                }
            }

            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (tokens.Length!=5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                    int x1 = int.Parse(tokens[1]);
                    int y1 = int.Parse(tokens[2]);
                    int x2 = int.Parse(tokens[3]);
                    int y2 = int.Parse(tokens[4]);
                

                if(ValidCoordinates(x1, y1, x2, y2,matrix))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                switch (tokens[0])
                {
                    case "swap":
                        Swap(x1, y1, x2, y2, matrix);
                        Print(matrix);
                        break;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }

            }
        }

        private static void Print(string[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]+" ");
                }
                Console.WriteLine();
            }
        }

        private static void Swap(int x1, int y1, int x2, int y2, string[,] matrix)
        {
            string swap = matrix[x1, y1];
            matrix[x1, y1] = matrix[x2, y2];
            matrix[x2,y2]=swap;
        }

        private static bool ValidCoordinates(int x1, int y1, int x2, int y2,string[,] matrix)
        {
            if(x1<0||y1<0||x2<0||y2<0)
            {
                return true;
            }
            if (x1 > matrix.GetLength(0) - 1 || y1 > matrix.GetLength(1) - 1 || x2 > matrix.GetLength(0) - 1 || y2 > matrix.GetLength(1)-1)
            {
                return true;
            }
            return false;
        }
    }
}
