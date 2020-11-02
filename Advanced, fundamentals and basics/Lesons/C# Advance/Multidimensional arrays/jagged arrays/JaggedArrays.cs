using System;
using System.Linq;

namespace jagged_arrays
{
    class JaggedArrays
    {
        static void Main(string[] args)
        {
            //only initialize firs [3] because the rest will be with different lenght
            int[][] jagged = new int[3][];
            jagged[0] = new int[3];
            jagged[1] = new int[2];
            jagged[2] = new int[5];

            for (int i = 0; i < jagged.Length; i++)
            {
                int[] inputNumbers = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                jagged[i] = new int[inputNumbers.Length];

                for (int j = 0; j < jagged[i].Length; j++)
                {
                   // jagged[i][j] = int.Parse(inputNumbers[j]);
                }
            }

            //print
            for (int i = 0; i < jagged.Length; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j]+" ");
                }
                Console.WriteLine();
            }
            //print with foreach
            foreach (int[] row in jagged)
            {
                Console.WriteLine(string.Join(" ",row));
            }                        
        }
    }
}
