using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());

            double[][] jaggedArray = new double[numberOfRows][];

            for (int i = 0; i < jaggedArray.Length; i++)
            {
                // int[] rowSequence = Console.ReadLine()
                //     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                //     .Select(int.Parse)
                //     .ToArray();
                // jaggedArray[i] = new double[rowSequence.Length];
                //
                // for (int j = 0; j < jaggedArray[i].Length; j++)
                // {
                //     jaggedArray[i][j] = rowSequence[j];
                // }
                //or
                jaggedArray[i] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(double.Parse)
                    .ToArray();
            }

            for (int i = 0; i < jaggedArray.Length - 1; i++)
            {
                if (jaggedArray[i].Length == jaggedArray[i + 1].Length)
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] *= 2;
                        jaggedArray[i + 1][j] *= 2;
                    }
                }
                else
                {
                    for (int j = 0; j < jaggedArray[i].Length; j++)
                    {
                        jaggedArray[i][j] /= 2;
                    }
                    for (int k = 0; k < jaggedArray[i + 1].Length; k++)
                    {
                        jaggedArray[i + 1][k] /= 2;
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] token = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = token[0];
                int x = int.Parse(token[1]);
                int y = int.Parse(token[2]);
                int value = int.Parse(token[3]);

                if (x < 0 || y < 0 ||jaggedArray.Length-1<x||jaggedArray[x].Length-1<y)
                {
                    continue;
                }

                if (action == "Add")
                {
                    jaggedArray[x][y] += value;
                }
                else if (action == "Subtract")
                {
                    jaggedArray[x][y] -= value;
                }
            }

            foreach (var row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
    }
}
