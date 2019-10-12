using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            string[] moveCommands = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            char[,] matrixMine = new char[fieldSize, fieldSize];

            int x = -1;
            int y = -1;
            int coals = 0;
            for (int i = 0; i < matrixMine.GetLength(0); i++)
            {
                char[] rowInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for (int j = 0; j < matrixMine.GetLength(1); j++)
                {
                    matrixMine[i, j] = rowInput[j];
                    if (rowInput[j] == 's')
                    {
                        x = i;
                        y = j;
                    }
                    if (rowInput[j] == 'c')
                    {
                        coals++;
                    }
                }
            }

            int collectCoals = 0;
            for (int i = 0; i < moveCommands.Length; i++)
            {
                switch (moveCommands[i])
                {
                    case "left":
                        if (Validate(matrixMine, x, --y))
                        {
                            if (Movement(matrixMine[x, y], ref collectCoals, x, y, coals, matrixMine))
                            {
                                return;
                            }
                        }
                        else
                        {
                            y++;
                        }
                        break;
                    case "right":
                        if (Validate(matrixMine, x, ++y))
                        {
                            if (Movement(matrixMine[x, y], ref collectCoals, x, y, coals, matrixMine))
                            {
                                return;
                            }
                        }
                        else
                        {
                            y--;
                        }
                        break;
                    case "down":
                        if (Validate(matrixMine, ++x, y))
                        {
                            if (Movement(matrixMine[x, y], ref collectCoals, x, y, coals, matrixMine))
                            {
                                return;
                            }
                        }
                        else
                        {
                            x--;
                        }
                        break;
                    case "up":
                        if (Validate(matrixMine, --x, y))
                        {
                            if (Movement(matrixMine[x, y], ref collectCoals, x, y, coals, matrixMine))
                            {
                                return;
                            }
                        }
                        else
                        {
                            x++;
                        }
                        break;
                }
            }
            Console.WriteLine($"{coals - collectCoals} coals left. ({x}, {y})");
        }

        private static bool Validate(char[,] matrixMine, int x, int y)
        {
            if(x<0||y<0)
            {
                return false;
            }
            if(matrixMine.GetLength(0)-1<x||matrixMine.GetLength(1)-1<y)
            {
                return false;
            }
            return true;
        }

        private static bool Movement(char element, ref int collectCoals, int x, int y, int coals, char[,] matrix)
        {
            switch (element)
            {
                case '*':
                    return false;
                case 'e':
                    Console.WriteLine($"Game over! ({x}, {y})");
                    return true;
                case 'c':
                    collectCoals++;
                    matrix[x, y] = '*';
                    if (coals == collectCoals)
                    {
                        Console.WriteLine($"You collected all coals! ({x}, {y})");
                        return true;
                    }
                    return false;
                default:
                    return false;
            }

        }
    }
}
