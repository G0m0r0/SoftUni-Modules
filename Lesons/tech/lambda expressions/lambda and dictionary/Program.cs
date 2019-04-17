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
            var newArray= array.Where(LarggerThanFive)
                .ToDictionary(MyGetKey);
            //if we add after myGetKey fun LarggerThanFive it will show us
            //all keys that are true (largger than five)

            foreach (var item in newArray)
            {
                Console.WriteLine(item.Key+" -> "+item.Value);
            }
        }
        static string MyGetKey(int a)
        {
            //create key
            return (-a * 5).ToString()+'K';
        }
        static bool LarggerThanFive(int a)
        {
            return a > 5;
        }
    }

}
