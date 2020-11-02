using System;
using System.Linq;

namespace jagged_array_modification
{
    class JaggedModification
    {
        static void Main(string[] args)
        {
            int rowCount = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                int[] currentRow = Console.ReadLine()
                     .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                     .Select(int.Parse)
                     .ToArray();

                //there is no need to write jaggedArray[i]=new int[currentRow.Lenght];
                jaggedArray[i] = currentRow;
            }

            string[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (input[0]?.ToLower() != "end")
            {
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (row < 0 ||
                    row > jaggedArray.Length - 1 ||
                    col < 0 ||
                    col > jaggedArray[int.Parse(input[1])].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates!");
                    input = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }

                switch (input[0]?.ToLower())
                {
                    case "add":
                        jaggedArray[row][col] += value;
                        break;
                    case "subtract":
                        jaggedArray[row][col] -= value;
                        break;
                    default:
                        //Console.WriteLine("Invalid command");
                        break;
                }
                input = Console.ReadLine()
                            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }

            foreach (var item in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', item));
            }
        }
    }
}
