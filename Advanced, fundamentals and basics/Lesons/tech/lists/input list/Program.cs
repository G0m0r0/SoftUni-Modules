using System;
using System.Collections.Generic;
using System.Linq;

namespace input_list
{
    class Program
    {
        static void Main(string[] args)
        {
            string values = Console.ReadLine();

            //we need using system linq
            List<string> items = values.Split(' ').ToList();

            List<int> nums = new List<int>();

            for (int i = 0; i < items.Count; i++)
            {
                nums.Add(int.Parse(items[i]));
            }
            Console.WriteLine(string.Join(" ",items));
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
