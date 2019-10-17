using System;
using System.Linq;

namespace LambdaExpressions
{
    class LambdaExpressions
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsEvenNumber(5)); //false
            Console.WriteLine(IsEvenNumber(10)); //true


            Func<int, bool> predicat = IsEvenNumber;
            //or
            Func<int, bool> predicatAnonymusMethod = (int a) => a % 2 == 0;
            //or
            Func<int, bool> predicatwithoutType = a => a % 2 == 0;

            var result=new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Where(predicat);
            Console.WriteLine(string.Join(' ',result));
        }
        // static bool IsEvenNumber(int a)
        // {
        //     return a%2==0;
        // }
        //or
        static bool IsEvenNumber(int a) => a % 2 == 0;
    }
}
