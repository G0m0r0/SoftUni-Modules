using System;
using System.Collections.Generic;
using System.Linq;

namespace ordered_by_age
{
    class Program
    {
        class Person
        {
            public string Name { set; get; }
            public string ID { set; get; }
            public int Age { set; get; }
            public override string ToString()
            {
               return $"{Name} with ID: {ID} is {Age} years old.";
            }
        }
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split().ToArray();
            List<Person> persons = new List<Person>();
            while (command[0]!="End")
            {
                Person person = new Person();
                person.Name = command[0];
                person.ID = command[1];
                person.Age = int.Parse(command[2]);

                persons.Add(person);

                command = Console.ReadLine().Split().ToArray();
            }
            persons = persons.OrderBy(x => x.Age).ToList();
            Console.WriteLine(string.Join("\n",persons));
        }
    }
}
