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
            int[] newArray = array.Where(x=>x>5).ToArray();



            foreach (var item in newArray)
            {
                Console.WriteLine(string.Join(" ", newArray));
            }
        }
    }

}

