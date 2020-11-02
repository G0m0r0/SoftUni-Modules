using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _3._Custom_min_function
{
     class MinFunction
    {
        void Main(string[] args)
        {
            int number = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .MyMinValue();

          // Func<int[], int> printMinValue = x =>
          // {
          //     int minValue = int.MaxValue;
          //     foreach (var num in x)
          //     {
          //         if (num < minValue)
          //         {
          //             minValue = num;
          //         }
          //     }
          //     return minValue;
          // };

            //Console.WriteLine(printMinValue(setOfIntegers));  
        }
    }
}
