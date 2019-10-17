using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, int> addFunc = num => num += 1;
            Func<int, int> mulFunc = num => num *= 2;
            Func<int, int> substractFunc = num => num -= 1;
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end")
            {
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(addFunc).ToArray();
                        break;
                    case "subtract":
                       numbers= numbers.Select(substractFunc).ToArray();
                        break;
                    case "print":
                        print(numbers);
                        break;
                    case "multiply":
                       numbers= numbers.Select(mulFunc).ToArray();
                        break;
                }
            }
        }
    }
}
