using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen
    {
        public Citizen(string id)
        {
            this.Persons = new List<Person>();
            this.Robots = new List<Robot>();
            this.Id = id;
        }
        private List<Person> Persons;
        private List<Robot> Robots;
        public string Id { get; set; }

        public void AddPerson(Person person)
        {
            this.Persons.Add(person);
        }
        public void AddRobot(Robot robot)
        {
            this.Robots.Add(robot);
        }

        public void PrintDetainCitizen(string id)
        {
            foreach (var person in this.Persons)
            {
                if (person.Id.EndsWith(id))
                    Console.WriteLine(person.Id);
            }

            foreach (var robot in this.Robots)
            {
                if(robot.Id.EndsWith(id))
                    Console.WriteLine(robot.Id);
            }
        }
    }
}
