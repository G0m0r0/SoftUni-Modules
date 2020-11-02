using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        static char[,] matrix;
        static int xPlayer;
        static int yPlayer;
        static void Main(string[] args)
        {
            int[] NandM = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int n = NandM[0];
            int m = NandM[1];

            matrix = new char[n, m];

            InitializeMatrix();

            char[] path = Console.ReadLine().ToCharArray();

            for (int i = 0; i < path.Length; i++)
            {           
                switch (path[i])
                {
                    case 'U':
                        Move(-1,0);
                        break;
                    case 'D':
                        Move(1,0);
                        break;
                    case 'R':
                        Move(0,1);
                        break;
                    case 'L':
                        Move(0,-1);
                        break;
                }
                MutationOfBunnies();
            }

        }

        private static void Move(int x,int y)
        {
            if(!ValidCell(xPlayer+x,yPlayer+y))
            {
                PrintMatrix();
                Console.WriteLine($"won: {xPlayer} {yPlayer}");

                Environment.Exit(0);
            }

            if(matrix[xPlayer+x,yPlayer+y]=='B')
            {
                PrintMatrix();
                Console.WriteLine($"dead: {xPlayer+x} {yPlayer+y}");

                Environment.Exit(0);
            }

            matrix[xPlayer, yPlayer] = '.';

            xPlayer += x;
            yPlayer += y;

            matrix[xPlayer, yPlayer] = 'P';
        }

        private static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]}");
                }
                Console.WriteLine();
            }
        }

        private static void MutationOfBunnies()
        {
            //mutation
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'B')
                    {
                        if (ValidCell(i + 1, j))
                        {
                            matrix[i + 1, j] = 'M';
                        }
                        if (ValidCell(i - 1, j))
                        {
                            matrix[i - 1, j] = 'M';
                        }
                        if (ValidCell(i, j - 1))
                        {
                            matrix[i, j - 1] = 'M';
                        }
                        if (ValidCell(i, j + 1))
                        {
                            matrix[i, j + 1] = 'M';
                        }
                    }
                }
            }

            //mutant bunny
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if(matrix[i,j]=='M')
                    {
                        matrix[i, j] = 'B';
                    }
                }
            }

            //if bunny reach player
            if(matrix[xPlayer,yPlayer]=='B')
            {
                PrintMatrix();
                Console.WriteLine($"dead: {xPlayer} {yPlayer}");
                Environment.Exit(0);
            }
        }

        private static bool ValidCell(int x, int y)
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

        private static void InitializeMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] rowInput = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rowInput[j];
                    if (rowInput[j] == 'P')
                    {
                        xPlayer = i;
                        yPlayer = j;
                    }
                }
            }
        }
    }
}
