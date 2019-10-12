using System;
using System.Linq;

namespace _7._Group_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] jaggednumarray = new int[3][];

            jaggednumarray[0] = numbers.Where(x => x % 3 == 0).ToArray();
            jaggednumarray[1] = numbers.Where(x => x % 3 == 1).ToArray();
            jaggednumarray[2] = numbers.Where(x => x % 3 == 2).ToArray();


            foreach (var item in jaggednumarray)
            {
                Console.WriteLine(string.Join(' ',item));
            }
        }
    }
}
