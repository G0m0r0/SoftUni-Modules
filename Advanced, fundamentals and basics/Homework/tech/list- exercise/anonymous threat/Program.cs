using System;
using System.Collections.Generic;
using System.Linq;

namesListpace anonymous_threat
{
    class Program
{ 
    static void Main(string[] args)
    {
        List<string> namesList = Console.ReadLine()
            .Split()
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

                    break;
            }

            command = Console.ReadLine()
                .Split()
                .ToArray();
        }
    }

    private static void MergeElements(List<string> namesList, int startIndex, int endIndex)
    {
        if (startIndex < 0)
            startIndex = 0;
        if (endIndex > namesList.Count - 1)
            endIndex = namesList.Count - 1;

        string joinednamesList = string.Empty;
        for (int i = startIndex; i < endIndex; i++)
        {
            joinednamesList += namesList[i];
            namesList.RemoveAt(i);
        }
        namesList.Insert(startIndex, joinednamesList);
    }
}
}

