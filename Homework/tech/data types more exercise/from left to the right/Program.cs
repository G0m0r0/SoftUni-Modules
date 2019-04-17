using System;
using System.Numerics;

namespace from_left_to_the_right
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                BigInteger sum = 0;
                string nums = Console.ReadLine();
                string[] splitNums = nums.Split(' ');
                BigInteger[] numsToBigInteger = new BigInteger[2];
                numsToBigInteger[0] = BigInteger.Parse(splitNums[0]);
                numsToBigInteger[1] = BigInteger.Parse(splitNums[1]);
                if (numsToBigInteger[1] >= numsToBigInteger[0])
                    while (BigInteger.Abs(numsToBigInteger[1]) > 0)
                    {
                        sum += (BigInteger.Abs(numsToBigInteger[1] % 10));
                        numsToBigInteger[1] /= 10;
                    }
                else
                    while (BigInteger.Abs(numsToBigInteger[0]) > 0)
                    {
                        sum += (BigInteger.Abs(numsToBigInteger[0] % 10));
                        numsToBigInteger[0] /= 10;
                    }
                Console.WriteLine(sum);
            }
        }
    }
}
