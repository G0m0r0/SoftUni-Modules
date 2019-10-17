using System;
using System.Collections.Generic;

namespace Create_custom_Select_method
{
    static class CustomSelectMethod
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split().MySelectMethod(int.Parse);
        }
        static List<T2> MySelectMethod<T,T2>(this IEnumerable<T> input,Func<T,T2> projection)
        {
            var newList= new List<T2>();
            foreach (var element in input)
            {
                newList.Add(projection(element));
            }
            return newList;
        }
    }
}
