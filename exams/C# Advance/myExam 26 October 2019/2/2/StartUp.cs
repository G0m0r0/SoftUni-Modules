using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2
{
    class StartUp
    {
        static char[,] matrix;
        static void Main(string[] args)
        {
            List<char> myString = Console.ReadLine().ToCharArray().ToList();
            int size = int.Parse(Console.ReadLine());
            matrix = new char[size, size];

            int xPlayer = 0;
            int yPlayer = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                    if (matrix[i, j] == 'P')
                    {
                        xPlayer = i;
                        yPlayer = j;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                matrix[xPlayer, yPlayer] = '-';
                switch (command)
                {
                    case "down":
                        xPlayer++;
                        break;
                    case "up":
                        xPlayer--;
                        break;
                    case "right":
                        yPlayer++;
                        break;
                    case "left":
                        yPlayer--;
                        break;
                }

                if (!InsideTheField(ref xPlayer, ref yPlayer))
                {
                    if (myString.Count > 0)
                        myString.RemoveAt(myString.Count - 1);
                    matrix[xPlayer, yPlayer] = 'P';
                    continue;
                }

                if (matrix[xPlayer, yPlayer] != '-')
                {
                    myString.Add(matrix[xPlayer, yPlayer]);
                    matrix[xPlayer, yPlayer] = 'P';
                }
            }
            Console.WriteLine(string.Join("",myString));
            Print();
        }

        private static void Print()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        private static bool InsideTheField(ref int xPlayer, ref int yPlayer)
        {
            if (xPlayer < 0)
            {
                xPlayer++;
                return false;
            }
            else if (xPlayer > matrix.GetLength(0) - 1)
            {
                xPlayer--;
                return false;
            }
            else if (yPlayer < 0)
            {
                yPlayer++;
                return false;
            }
            else if (yPlayer > matrix.GetLength(1) - 1)
            {
                yPlayer--;
                return false;
            }
            return true;
        }
    }
}
