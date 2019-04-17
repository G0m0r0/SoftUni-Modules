using System;
using System.Collections.Generic;
using System.Linq;

namespace List_manipulation_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listIntegers = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            string command = Console.ReadLine();
            while(command!="end")
            {
                string[] commandAction = command.Split(" ").ToArray();
                switch (commandAction[0])
                {
                    case "Add":
                        listIntegers.Add(int.Parse(commandAction[1]));
                        break;
                    case "Remove":
                        listIntegers.Remove(int.Parse(commandAction[1]));
                        break;
                    case "RemoveAt":
                        listIntegers.RemoveAt(int.Parse(commandAction[1]));
                        break;
                    case "Insert":
                        listIntegers.Insert(int.Parse(commandAction[2]), int.Parse(commandAction[1]));
                        break;                    
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",listIntegers));
        }
    }
}
