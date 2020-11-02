using System;
using System.Collections.Generic;

namespace _7._1_SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> VIP = new HashSet<string>();
            HashSet<string> regular = new HashSet<string>();

            string guest = string.Empty;
            while (!(guest=Console.ReadLine()).Equals("PARTY"))
            {
                if(char.IsNumber(guest[0]))
                {
                    VIP.Add(guest);
                }
                else
                {
                    regular.Add(guest);
                }
            }

            while (!(guest=Console.ReadLine()).Equals("END"))
            {
                if(char.IsNumber(guest[0]))
                {
                    VIP.Remove(guest);
                }
                else
                {
                    regular.Remove(guest);
                }
            }

            Console.WriteLine(VIP.Count+regular.Count);
            foreach (var vipGuest in VIP)
            {
                Console.WriteLine(vipGuest);
            }

            foreach (var regularGuest in regular)
            {
                Console.WriteLine(regularGuest);
            }
        }
    }
}
