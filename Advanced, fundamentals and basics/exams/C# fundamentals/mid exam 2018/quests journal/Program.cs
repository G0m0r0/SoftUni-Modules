using System;
using System.Collections.Generic;
using System.Linq;

namespace quests_journal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> quests = Console.ReadLine()
                .Split(", ")
                .ToList();

            string command = Console.ReadLine();
            while (command != "Retire!")
            {
                string[] token = command.Split("-").ToArray();
                switch (token[0].Trim())
                {
                    case "Start":
                        AddQuest(quests, token[1].Trim());
                        break;
                    case "Complete":
                        RemoveQuest(quests, token[1].Trim());
                        break;
                    case "Side Quest":
                        SideQuest(quests, token[1].Trim());
                        break;
                    case "Renew":
                        ChangeQuest(quests, token[1].Trim());
                        break;
                    default:
                        break;
                }
                //Console.WriteLine(string.Join(" ", quests));

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",quests));
        }

        private static void ChangeQuest(List<string> quests, string item)
        {
            if(quests.Contains(item))
            {
                quests.Remove(item);
                quests.Add(item);
            }
        }

        private static void SideQuest(List<string> quests, string item)
        {
            string[] token = item.Split(":").ToArray();
            if (quests.Contains(token[0])&&!quests.Contains(token[1]))
            {
                int index = quests.IndexOf(token[0]);
                quests.Insert(++index, token[1]);
            }
        }

        private static void RemoveQuest(List<string> quests, string item)
        {
            if (quests.Contains(item))
                quests.Remove(item);
        }

        private static void AddQuest(List<string> quests, string item)
        {
            if (!quests.Contains(item))
                quests.Add(item);
        }
    }
}
