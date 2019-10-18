using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(age,name);

                family.AddMember(person);
            }

            Person OldestPerson = family.GetOldestMember();
            Console.WriteLine($"{OldestPerson.Name} {OldestPerson.Age}");
        }
    }
}
