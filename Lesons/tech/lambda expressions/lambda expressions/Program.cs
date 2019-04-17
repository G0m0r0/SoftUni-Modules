using System;
using System.Linq;

namespace lambda_expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //lambda works with functions
            int[] array=new int[] {1,2,3,4,10,-100 };
            int[] newArray=array.Where(LarggerThanFive).ToArray();
            foreach (var item in newArray)
            {
                Console.WriteLine(string.Join(" ",newArray));
            }
        }
        static bool LarggerThanFive(int a)
        {
            return a > 5;
        }
    }
    
}
