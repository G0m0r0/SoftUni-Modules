using System;
using System.Collections.Generic;
using System.Linq;

namespace santa_s_list
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> noisyKids = Console.ReadLine()
                .Split("&")
                .ToList();

            string command = Console.ReadLine();
            while (command!="Finished!")
            {
                List<string> token = command.Split().ToList();
                switch (token[0])
                {
                    case "Bad":
                        AddBadKids(noisyKids, token[1]);
                        break;
                    case "Good":
                        RemoveGoodKids(noisyKids, token[1]);
                        break;
                    case "Rename":
                        RenameKid(noisyKids, token[1], token[2]);
                        break;
                    case "Rearrange":
                        RearrangeKids(noisyKids, token[1]);
                        break;
                    default:
                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(", ",noisyKids));
        }

        private static void RearrangeKids(List<string> noisyKids, string kid)
        {
            if(noisyKids.Contains(kid))
            {
                noisyKids.Remove(kid);
                noisyKids.Add(kid);
            }
        }

        private static void RenameKid(List<string> noisyKids, string oldName, string newName)
        {
            if(noisyKids.Contains(oldName))
            {
                int indexKid=noisyKids.IndexOf(oldName);
                noisyKids[indexKid] = newName;
            }
        }

        private static void RemoveGoodKids(List<string> noisyKids, string goodkid)
        {
            if (noisyKids.Contains(goodkid))
                noisyKids.Remove(goodkid);
        }

        private static void AddBadKids(List<string> noisyKids, string kid)
        {
            if (!noisyKids.Contains(kid))
                noisyKids.Insert(0, kid);
        }
    }
}
