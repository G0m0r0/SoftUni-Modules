using System;
using System.Collections.Generic;
using System.Linq;

namespace grades_of_persons_with_dictionary_and_list
{
    class Program
    {
        static void Main(string[] args)
        {
            var grades = new Dictionary<string, List<int>>();
            int numOfPeopl = int.Parse(Console.ReadLine());
            for (int i = 0; i <numOfPeopl ; i++)
            {
                string nameKey = Console.ReadLine();
                //initialize list 
                grades.Add(nameKey, new List<int>());
            }
            //input into list
            grades["niki"].Add(3);
            grades["niki"].Add(6);
            grades["niki"].Add(4);

            //average part of System.Linq
            Console.WriteLine(grades["niki"].Average());
        }
    }
}
