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
                .Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries)
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
                        //Console.WriteLine(string.Join(" ", namesList));
                        break;
                    case "divide":
                        DivideElements(namesList, int.Parse(command[1]), int.Parse(command[2]));
                       // Console.WriteLine(string.Join(" ",namesList));
                        break;
                }

                command = Console.ReadLine()
                    .Split()
                    .ToArray();
            }
            Console.WriteLine(string.Join(" ",namesList));
        }

        private static void DivideElements(List<string> namesList, int index, int partition)
        {
            List<char> element = namesList[index].ToList();
            for (int i = 0; i < element.Count; i++)
            {
                if (i % partition == 0)
                    element.Insert(i, ' ');
            }

            string elementStr = string.Empty;
            for (int i = 0; i < element.Count; i++)
            {
                   elementStr += element[i].ToString();
            }
            namesList.RemoveAt(index);
            List<string> splitedElement = elementStr.Trim().Split(" ").ToList();
            splitedElement.Reverse();
            // Console.Write(string.Join(" ", splitedElement));
            for (int i = 0; i <splitedElement.Count; i++)
            {
                namesList.Insert(index, splitedElement[i]);
            }
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
