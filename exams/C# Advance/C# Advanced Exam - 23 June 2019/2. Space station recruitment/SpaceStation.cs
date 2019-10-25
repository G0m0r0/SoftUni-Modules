using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

       //public int count
       //{
       //    get
       //    {
       //        return astronauts.Count();
       //    }
       //}
        //or
        
        List<Astronaut> astronauts;
        public int Count => this.astronauts.Count();

        public SpaceStation(string name, int capacity)
        {
            astronauts = new List<Astronaut>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public void Add(Astronaut astronaut)
        {
            if (this.astronauts.Count < this.Capacity)
                this.astronauts.Add(astronaut);
        }
        public bool Remove(string name)
        {
            foreach (var astronaut in astronauts)
            {
                if (astronaut.Name == name)
                {
                    this.astronauts.Remove(astronaut);
                    return true;
                }
            }
            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut result = new Astronaut(string.Empty, int.MinValue, string.Empty);

            foreach (var person in this.astronauts)
            {
                if (person.Age > result.Age)
                {
                    result = person;
                }
            }
            return result;

            //Astronaut result = this.astronauts.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut result = new Astronaut(string.Empty, 0, string.Empty);
            foreach (var person in this.astronauts)
            {
                if(person.Name==name)
                {
                    result = person;
                    break;
                }
            }
            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");
            foreach (var person in astronauts)
            {
                sb.AppendLine(person.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
