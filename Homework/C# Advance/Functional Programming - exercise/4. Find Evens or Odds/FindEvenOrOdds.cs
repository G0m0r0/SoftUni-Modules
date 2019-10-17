using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class FindEvenOrOdds
    {
        static void Main(string[] args)
        {
            Predicate<int> isEvenPredicate = num => num % 2 == 0;
            Action<List<int>> PrintNumbers = nums => Console.WriteLine(string.Join(" ",nums));

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();
            int startNum = input[0];
            int endNum = input[1];

            for (int i = startNum; i <= endNum; i++)
            {
                numbers.Add(i);
            }

            string numberType = Console.ReadLine();

            List<int> result = new List<int>();
            if (numberType == "even")
            {
               result= numbers.FindAll(isEvenPredicate);
            }
            else
            {
                result=numbers.FindAll(x=>!isEvenPredicate(x));
            }

            PrintNumbers(result);
        }
    }
}
