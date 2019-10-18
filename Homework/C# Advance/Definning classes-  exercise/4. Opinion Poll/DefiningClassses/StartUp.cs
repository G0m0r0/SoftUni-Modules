using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClassses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < numOfPeople; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name,age);

                people.Add(person);
            }

            foreach (var person in people  
                .Where(x=>x.Age>30)
                .OrderBy(x => x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
