using System;
using System.Linq;
using System.Text;

namespace _5._Snake_Moves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            char[] snake = Console.ReadLine().ToCharArray();
            char[,] snakeMatrix = new char[size[0], size[1]];

            int num = 0;
            for (int i = 0; i < snakeMatrix.GetLength(0); i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < snakeMatrix.GetLength(1); j++)
                    {
                        if (num == snake.Length)
                        {
                            num = 0;
                        }
                        snakeMatrix[i, j] = snake[num++ ];
                    }
                }
                else
                {
                    for (int j = snakeMatrix.GetLength(1) - 1; j >= 0; j--)
                    {
                        if (num > snake.Length - 1)
                        {
                            num = 0;
                        }
                        snakeMatrix[i, j] = snake[num++];
                    }
                }
            }

            for (int i = 0; i < snakeMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < snakeMatrix.GetLength(1); j++)
                {
                    Console.Write(snakeMatrix[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
