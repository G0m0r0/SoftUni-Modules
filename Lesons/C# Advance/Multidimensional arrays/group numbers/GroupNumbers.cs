using System;
using System.Linq;

namespace group_numbers
{
    class GroupNumbers
    {
        static void Main(string[] args)
        {
            int[][] jaghedArray = new int[3][];

            int[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            jaghedArray[0] = input
                .Where(x => Math.Abs(x) % 3 == 0)
                .ToArray();

            jaghedArray[1] = input
                .Where(x => Math.Abs(x) % 3 == 1)
                .ToArray();

            jaghedArray[2] = input
                .Where(x => Math.Abs(x) % 3 == 2)
                .ToArray();

            foreach (int[] row in jaghedArray)
            {
                Console.WriteLine(string.Join(' ',row));
            }
        }
    }
}
