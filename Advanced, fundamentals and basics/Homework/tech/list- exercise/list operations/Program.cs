using System;
using System.Collections.Generic;
using System.Linq;

namespace list_operations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numberList = Console.ReadLine()
                .Split(" ")            
                .Select(int.Parse)
                .ToList();

            string choice = Console.ReadLine();
            while (choice != "End")
            {
                string[] token = choice.Split(" ").ToArray();
                switch (token[0])
                {
                    case "Add":
                        numberList.Add(int.Parse(token[1]));
                        break;
                    case "Remove":
                        if (int.Parse(token[1]) > numberList.Count-1||int.Parse(token[1])<0)
                            Console.WriteLine("Invalid index");
                        else
                        numberList.RemoveAt(int.Parse(token[1]));
                        break;
                    case "Insert":
                        if (int.Parse(token[2]) > numberList.Count-1||int.Parse(token[2])<0)
                            Console.WriteLine("Invalid index");
                        else
                        numberList.Insert(int.Parse(token[2]), int.Parse(token[1]));
                        break;
                    case "Shift":
                        ShiftNumber(numberList, token[1], int.Parse(token[2]));
                        break;
                    default:
                        break;
                }

                choice = Console.ReadLine();

            }
            Console.WriteLine(string.Join(" ", numberList));

        }

        private static void ShiftNumber(List<int> numberList, string v1, int token)
        {
            if (v1 == "left")
            {
                for (int i = 0; i < token; i++)
                {
                    numberList.Add(numberList[0]);
                    numberList.RemoveAt(0);
                }
            }
            else if (v1 == "right")
            {
                for (int i = 0; i < token; i++)
                {
                    numberList.Insert(0, numberList[numberList.Count - 1]);
                    numberList.RemoveAt(numberList.Count - 1);
                }
            }

        }
    }
}
