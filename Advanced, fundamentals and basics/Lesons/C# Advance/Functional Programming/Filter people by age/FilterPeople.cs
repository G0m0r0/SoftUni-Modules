using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_people_by_age
{
    class FilterPeople
    {
        class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
            public Person()
            {

            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

                var person = new Person();
                person.Name = input[0];
                person.Age = int.Parse(input[1]);
                people.Add(person);
            }

            var conditionString = Console.ReadLine();
            var conditionParametar = int.Parse(Console.ReadLine());

            Func<Person, bool> predicate=p=>false;
            //or Func<Person, bool> predicate; but we need else 
            if (conditionString=="older")
            {
                predicate = p => p.Age > conditionParametar;
            }
            else if(conditionString=="younger")
            {
                predicate = p => p.Age < conditionParametar;
            }
            else if(conditionString=="exactly")
            {
                predicate = p => p.Age == conditionParametar;
            }

            var filteredPeople = people.Where(predicate);
            var format = Console.ReadLine();
            foreach (var person in people)
            {
                    var output = format
                    .Replace("age", person.Age.ToString())
                    .Replace("name", person.Name);

                    Console.WriteLine(output);
            }
        }
    }
}
