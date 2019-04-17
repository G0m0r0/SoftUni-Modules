using System;

namespace multiply_evens_by_odds
{
    class Program
    {
        static int GetMultipleOfEvenAndOdds(int num)
        {
            return GetSumEvenDigits(num) * GetSumOfOddDigits(num);
        }
        static int GetSumEvenDigits(int num)
        {
            int sum = 0;
            while(num>0)
            {
                int parse = num % 10;
                if (parse % 2 == 0)
                    sum += parse;
                num /= 10;
            }
            return sum;
        }
        static int GetSumOfOddDigits(int num)
        {
            int sum = 0;
            while(num>0)
            {
                int parse = num % 10;
                if (parse % 2 != 0)
                    sum += parse;
                num /= 10;
            }
            return sum;
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMultipleOfEvenAndOdds(Math.Abs(number))); 
        }
    }
}
