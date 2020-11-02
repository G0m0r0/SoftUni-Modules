using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;
            List<Person> personDate = new List<Person>();

            while ((command=Console.ReadLine())!="END")
            {
                string[] tokens = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                string town = tokens[2];

                Person person = new Person(name, age, town);
                personDate.Add(person);
            }

            int nThPerson = int.Parse(Console.ReadLine());
            Person personToCompare = personDate[nThPerson-1];

            int equal = -1;
            int notEqual = 0;

            foreach (var person in personDate)
            {
                if(personToCompare.CompareTo(person)==0)
                {
                    equal++;
                }
                else if(personToCompare.CompareTo(person)==-1)
                {
                    notEqual++;
                }
            }
            if (equal == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{++equal} {notEqual} {personDate.Count}");
            }
        }
    }
}
