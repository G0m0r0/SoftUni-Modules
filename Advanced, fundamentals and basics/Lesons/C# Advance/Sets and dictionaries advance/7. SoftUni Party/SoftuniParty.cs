using System;
using System.Collections.Generic;

namespace _7._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> guestList = new SortedSet<string>();

            string guest = string.Empty;
            while (!(guest=Console.ReadLine()).Equals("PARTY"))
            {
                guestList.Add(guest);
            }

            while (!(guest=Console.ReadLine()).Equals("END"))
            {
                guestList.Remove(guest);
            }

            Console.WriteLine(guestList.Count);
            foreach (var person in guestList)
            {
                Console.WriteLine(person);
            }
        }
    }
}
