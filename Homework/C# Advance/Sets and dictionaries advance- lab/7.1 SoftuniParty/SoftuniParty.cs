using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._1_SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();

            string command = string.Empty;
            while (!(command = Console.ReadLine()).Equals("PARTY"))
            {
                guests.Add(command);
            }

            while (!(command = Console.ReadLine()).Equals("END"))
            {
                guests.Remove(command);
            }

            Console.WriteLine(guests.Count);
            foreach (var guest in guests.Where(x=>char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests.Where(x=>!char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
            }
        }
    }
}
