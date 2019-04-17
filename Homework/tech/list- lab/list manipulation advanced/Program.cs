using System;
using System.Collections.Generic;
using System.Linq;

namespace list_manipulation_advanced
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
            
            bool flag = true;
            while (choice != "end")
            {
                string[] token = choice.Split(" ").ToArray();

                switch (token[0])
                {
                    case "Contains":
                       if(numberList.Contains(int.Parse(token[1])))
                            Console.WriteLine("Yes");
                       else
                            Console.WriteLine("No such number");
                        break;
                    case "PrintEven":
                        PrinEvenNumbers(numberList);
                        break;
                    case "PrintOdd":
                        PrintOddNumbers(numberList);
                        break;
                    case "GetSum":
                        Console.WriteLine(GetSum(numberList)); 
                        break;
                    case "Filter":
                        Filter(numberList,token[1],int.Parse(token[2]));
                        break;
                    case "Add":
                        flag = false;
                        numberList.Add(int.Parse(token[1]));
                        break;
                    case "Remove":
                        flag = false;
                        numberList.Remove(int.Parse(token[1]));
                        break;
                    case "RemoveAt":
                        flag = false;
                        numberList.RemoveAt(int.Parse(token[1]));
                        break;
                    case "Insert":
                        flag = false;
                        numberList.Insert(int.Parse(token[2]), int.Parse(token[1]));
                        break;
                    default:
                        break;

                }
                choice = Console.ReadLine();
            }

            //Print number list only if there is changes
            if(!flag)
                Console.WriteLine(string.Join(" ",numberList));
        }

        private static void Filter(List<int> numberList, string v1, int v2)
        {
            switch (v1)
            {
                case "<":
                    Console.WriteLine(string.Join(" ",numberList.Where(x=>x<v2)));
                    break;
                case ">":
                    Console.WriteLine(string.Join(" ",numberList.Where(x=>x>v2)));
                    break;
                case ">=":
                    Console.WriteLine(string.Join(" ",numberList.Where(x=>x>=v2)));
                    break;
                case "<=":
                    Console.WriteLine(string.Join(" ",numberList.Where(x=>x<=v2)));
                    break;               
                default:
                    break;
            }
        }

        static int GetSum(List<int> numberList)
        {
            return numberList.Sum();
        }

        private static void PrintOddNumbers(List<int> numberList)
        {
            Console.WriteLine(string.Join(" ", numberList.Where(n => n % 2 != 0)));
        }

        private static void PrinEvenNumbers(List<int> numberList)
        {
            Console.WriteLine(string.Join(" ", numberList.Where(x => x % 2 == 0)));
        }

    }
}
