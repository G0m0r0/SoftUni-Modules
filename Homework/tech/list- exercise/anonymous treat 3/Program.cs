using System;
using System.Collections.Generic;
using System.Linq;

namespace anonymous_treat_2
{
    class Program
    {
        //divide is giving wrong output

        static void Main(string[] args)
        {
            List<string> namesList = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();
            while (command[0] != "3:1")
            {
                switch (command[0])
                {
                    case "merge":
                        MergeElements(namesList, int.Parse(command[1]), int.Parse(command[2]));       
                        break;
                    case "divide":
                        DivideElements(namesList, int.Parse(command[1]), int.Parse(command[2]));
                        break;
                }
               // Console.WriteLine(string.Join(" ", namesList));
                command = Console.ReadLine()
                    .Split()
                    .ToArray();
            }
            Console.WriteLine(string.Join(" ", namesList));
        }

        private static void DivideElements(List<string> namesList, int index, int partition)
        {
            string element = namesList[index];
            if (element.Length == 1)
                return;
            else if (element.Length < partition)
                partition = element.Length;
            int lenghtOfSubstring = element.Length / partition;

            int parse = lenghtOfSubstring;
            for (int i = 0; i < partition-1; i++)
            {
                element = element.Insert(lenghtOfSubstring, " ");
                lenghtOfSubstring += parse+1;
            }
            namesList.RemoveAt(index);
            namesList.Insert(index, element);
            namesList = string.Join(" ", namesList).Split().ToList();
        }

        private static void MergeElements(List<string> namesList, int startIndex, int endIndex)
        {
            if (startIndex < 0)
                startIndex = 0;
            if (endIndex > namesList.Count - 1)
                endIndex = namesList.Count - 1;

            string joinednamesList = string.Empty;
            for (int i = startIndex; i <= endIndex; i++)
            {
                joinednamesList += namesList[startIndex].Trim();
                namesList.RemoveAt(startIndex);
            }

            namesList.Insert(startIndex, joinednamesList);
        }
    }
}
