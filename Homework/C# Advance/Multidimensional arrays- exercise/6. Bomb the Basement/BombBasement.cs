using System;
using System.Linq;

namespace _6._Bomb_the_Basement
{
    class BombBasement
    {
        //not finished
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[,] basementMatrix = new int[size[0], size[1]];
            int[] bombParameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int x = bombParameters[0];
            int y = bombParameters[1];
            int radius = bombParameters[2];

            for (int i = 0; i < basementMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < basementMatrix.GetLength(1); j++)
                {

                }
            }

            Print(basementMatrix);
        }

        private static void Print(int[,] matrix)
        {
            for (int i = 0; i <matrix.GetLength(0) ; i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
