using System;
using System.Collections.Generic;

namespace Generics
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var list1 = new List<string>();
            AddValues(list1, 100, "Niki4");

            var list2 = new List<int>();
            var x = AddValues<int>(list2, 100, 5); //its optional to put <int>
        }
        static T AddValues<T>(List<T> list, int num, T x)
        {
            for (int i = 0; i < num; i++)
            {
                list.Add(x);
            }

            return x;
        }
        //template 
        // static TResult AddValues<T,TResult>(List<T> list, int num, T x)
        // {
        //     for (int i = 0; i < num; i++)
        //     {
        //         list.Add(x);
        //     }
        //
        //     return TResult;
        // }
    }
}
