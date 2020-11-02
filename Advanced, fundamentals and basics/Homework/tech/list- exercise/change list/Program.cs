using System;
using System.Collections.Generic;
using System.Linq;

namespace change_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integerList = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string choice = Console.ReadLine();
            while (choice!="end")
            {
                string[] token = choice.Split(" ").ToArray();
                switch (token[0])
                {
                    case "Delete":
                        integerList.RemoveAll(x => x == int.Parse(token[1]));
                        break;
                    case "Insert":
                        integerList.Insert(int.Parse(token[2]), int.Parse(token[1]));
                        break;
                    default:
                        break;
                }
                choice = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",integerList));
        }
    }
}
