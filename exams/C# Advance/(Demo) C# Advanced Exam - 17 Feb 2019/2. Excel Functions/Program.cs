using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Excel_Functions
{
    class Program
    {
        static string[][] table;
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            table = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                table[i] = Console.ReadLine()
                    .Split(", ")
                    .ToArray();
            }

            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            switch (command[0])
            {
                case "hide":
                    PrintTable(command[1]);
                    break;
                case "sort":
                    SortByHeader(command[1]);
                    break;
                case "filter":
                    FilterByHeaderAndValue(command[1], command[2]);
                    break;
            }
        }

        private static void FilterByHeaderAndValue(string header, string value)
        {
            int headerToFilter = 0;
            for (int i = 0; i < table[0].Length; i++)
            {
                if (table[0][i] == header)
                {
                    headerToFilter = i;
                    break;
                }
            }

            Console.WriteLine(string.Join(" | ",table[0]));
            for (int i = 0; i < table.Length; i++)
            {
                if(table[i][headerToFilter]==value)
                {
                    Console.WriteLine(string.Join(" | ",table[i]));
                    break;
                }
            }
        }

        private static void SortByHeader(string header)
        {
            int headerToSort=0;
            for (int i = 0; i < table[0].Length; i++)
            {
                if (table[0][i] == header)
                {
                    headerToSort = i;
                    break;
                }
            }

            List<string> elements = new List<string>();
            for (int i = 1; i < table.Length; i++)
            {
                elements.Add(table[i][headerToSort]);
            }
            elements.Sort();
            List<int> indexes = new List<int>();
            for (int i = 0; i < elements.Count; i++)
            {
                for (int j = 1; j < table.Length; j++)
                {
                    if(table[j][headerToSort]==elements[i])
                    {
                        indexes.Add(j);
                    }
                }
            }

            Console.WriteLine(string.Join(" | ",table[0]));
            for (int i = 0; i < indexes.Count; i++)
            {
                int indexToPrint = indexes[i];
                Console.WriteLine(string.Join(" | ",table[indexToPrint]));
            }
        }

        private static void PrintTable(string header)
        {
            int rowToRemove = 0;
            for (int i = 0; i < table[0].Length; i++)
            {
                if (table[0][i] == header)
                {
                    rowToRemove = i;
                }
            }

            for (int i = 0; i < table.Length; i++)
            {
                for (int j = 0; j < table[i].Length; j++)
                {
                    if (j != rowToRemove)
                    {
                        if (j == table[i].Length - 1)
                            Console.Write(table[i][j]+" ");
                        else
                            Console.Write(table[i][j] + " | ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
