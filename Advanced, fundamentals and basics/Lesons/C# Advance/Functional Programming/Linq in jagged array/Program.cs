using System;
using System.Linq;

namespace Linq_in_jagged_array
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = new int[3][]{
                new[] {1,2,3,4},
                new[] {4,5,6,7,8,9 },
                new[] { 0 }
            };

            //takes jagged arrays that lenght is greater than 2
            var resultArrays = input.Where(x => x.Length > 2);
            //or
            //numbers greater than 2 we will take only the arrays with numbers greater than 2
            var resultArraysWithNumbersGreaterThanFive = input.Where(x => x.Any(y => y > 5));
            foreach (var array in resultArraysWithNumbersGreaterThanFive)
            {
                Console.WriteLine(string.Join(' ',array));
            }
        }
    }
}
