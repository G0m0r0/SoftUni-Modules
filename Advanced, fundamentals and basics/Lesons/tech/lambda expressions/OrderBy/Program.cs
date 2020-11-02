using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderBy
{
    class Program
    {

        static void Main(string[] args)
        {
            //sort int list
            List<int> nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToList();

            //we can sort string by its lengh
            //we can orderby string by alphabet
            //its same as the list.order
            Console.WriteLine(string.Join(" ",nums));
        }
    }
}
