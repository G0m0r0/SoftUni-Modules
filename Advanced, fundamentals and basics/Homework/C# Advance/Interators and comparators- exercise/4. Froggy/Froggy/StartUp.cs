using System;
using System.Linq;

namespace Froggy
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] stonesInput = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Lake lake = new Lake(stonesInput);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
