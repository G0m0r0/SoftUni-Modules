using System;
using System.Collections.Generic;
using System.Linq;

namespace list__exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> peopleInWagon = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToList();

            int maxCapacity = int.Parse(Console.ReadLine());

            string choice = Console.ReadLine();
            while(choice!="end")
            {
                string[] token = choice.Split(" ").ToArray();
                switch (token[0])
                {
                    case "Add":
                        peopleInWagon.Add(int.Parse(token[1]));
                        break;
                    default:
                        AddPeopleToWagon(peopleInWagon, int.Parse(token[0]),maxCapacity);
                        break;
                }
                choice = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ",peopleInWagon));
        }

        private static void AddPeopleToWagon(List<int> peopleInWagon, int numOfPeopleToFit,int maxCapacity)
        {
            for (int i = 0; i < peopleInWagon.Count; i++)
            {
                if (peopleInWagon[i] + numOfPeopleToFit <= maxCapacity)
                {
                    int peopleInOneWagon = peopleInWagon[i];
                    peopleInWagon.RemoveAt(i);
                    peopleInWagon.Insert(i,numOfPeopleToFit + peopleInOneWagon);
                    break;
                }
            }
        }
    }
}
