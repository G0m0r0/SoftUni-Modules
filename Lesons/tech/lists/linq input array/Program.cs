using System;
using System.Collections.Generic;
using System.Linq;

namespace linq_input_array
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = Console.ReadLine();
            List<int> newList= value.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries).Select(Convert).Where(x=>x>0).ToList();
            //we can add insted of convert int.parse(originalValue) or only int.parse

            //where returns all the values of its condition opposite of removeAll
            //.Where(x=>x>0)

            //.Skip(2) skip 2 elements
            //.Take(2) take 2 elements
            //.Sum


            foreach (var item in newList)
            {
                Console.WriteLine(item*item);
                //finds powder of 2 of elements
            }

            //select(convert) method in method


        }
        //we dont need in we can add directly int.parse
        static int Convert(string originalValue)
        {
            int newValue = int.Parse(originalValue);
            return newValue;
        }
    }
}
