using System;
using System.Collections.Generic;

namespace list_count_capacity
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            Console.WriteLine($"count {list.Count} cappacity{list.Capacity}");

            for (int i = 0; i < 129; i++)
            {
                list.Add(i);
            }
            Console.WriteLine($"count {list.Count} cappacity{list.Capacity}");

        }
    }
}
