using System;
using System.Linq;

namespace lambda_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //lambda works with functions
            int[] array = new int[] { 1, 2, 3, 4, 10, -100 };
            var newArray= array.Where(x => x > 5)
                .ToDictionary(x => "_"+x+"_", x => x);


            //or
            //var newArray = array
             //   .ToDictionary(x => "_" + x + "_", x > 5);
             //output all number bigger than 5 with key _num_

            foreach (var item in newArray)
            {
                Console.WriteLine(string.Join(" ", newArray));
            }
        }
    }

}

