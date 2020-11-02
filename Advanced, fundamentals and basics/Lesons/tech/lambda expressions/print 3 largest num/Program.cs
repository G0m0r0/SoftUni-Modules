using System;
using System.Linq;

namespace print_3_largest_num
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .Take(3);

            Console.WriteLine(string.Join(" ",numbers));
        }
    }
}
