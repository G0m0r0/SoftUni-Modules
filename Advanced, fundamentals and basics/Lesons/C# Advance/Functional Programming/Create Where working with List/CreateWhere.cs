using System;
using System.Collections.Generic;

namespace Create_Where_working_with_List
{
    static class CreateWhere
    {
        static void Main(string[] args)
        {
            var input =new[] { 1.0M, 2.5M, 3M, 4M, 5M, 6M, 7.86543M, 8M, 9M };
            var result = MyWhere(input, x => x > 5);
            Console.WriteLine(string.Join(' ', result));
            //or
            var shorterResult = input.MyWhere(x => x % 2 == 0);
            //by using this means we can use it over input
            Console.WriteLine(string.Join(' ',shorterResult));
        }
        //abstract working with tuple
        static List<T> MyWhere<T>(this IEnumerable<T> input,Func<T,bool> filter)
        {
            var newList = new List<T>();
            foreach (var num in input)
            {
                if(filter(num))
                {
                    newList.Add(num);
                }
            }
            return newList;
        }
    }
}
