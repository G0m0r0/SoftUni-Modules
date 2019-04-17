using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            string nums = Console.ReadLine();
            string[] splitNums = nums.Split(' ');
            long[] numsToLong = new long[1];
            numsToLong[0] = long.Parse(splitNums[0]);
            numsToLong[1] = long.Parse(splitNums[1]);
            Console.WriteLine(numsToLong[0]);
            Console.WriteLine(numsToLong[1]);
        }
    }
}
