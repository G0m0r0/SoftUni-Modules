using System;
using System.Collections.Generic;

namespace list_contains__bool_true_or_false
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(Contains(list,0));

        }
        //template void
        static bool Contains<T>(List<T> list, T element)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(element))
                    return true;
            }
            return false;
        }
    }
}
