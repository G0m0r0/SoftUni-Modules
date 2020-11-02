using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        List<Rabbit> Rabbits;
        public string Name { get; set; }
        public int Capacity { get; set; }
       

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Rabbits = new List<Rabbit>();
        }

        public void Add(Rabbit rabbit)
        {
            if (this.Rabbits.Count < Capacity)
            {
                this.Rabbits.Add(rabbit);
            }
        }

        public bool RemoveRabbit(string name)
        {
            foreach (var rabbit in this.Rabbits)
            {
                if (rabbit.Name == name)
                {
                    this.Rabbits.Remove(rabbit);
                    return true;
                }
            }
            return false;
        }

        public void RemoveSpecies(string species)
        {
            for (int i = 0; i < this.Rabbits.Count; i++)
            {
                if (this.Rabbits[i].Species == species)
                {
                    this.Rabbits.Remove(this.Rabbits[i]);
                    i--;
                }
            }
    
        }

        public Rabbit SellRabbit(string name)
        {
            // foreach (var rabbit in this.Rabbits)
            // {
            //     if(rabbit.Name==name)
            //     {
            //         rabbit.Available = false;
            //         return rabbit;
            //     }
            // }
            //return null;
            Rabbit rabbit = new Rabbit(string.Empty, string.Empty);
            for (int i = 0; i < this.Rabbits.Count; i++)
            {
                if (Rabbits[i].Name == name)
                {
                    this.Rabbits[i].Available = false;
                    rabbit = this.Rabbits[i];
                }
            }
            return rabbit;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            List<Rabbit> listRabbits = new List<Rabbit>();
            foreach (var rabbit in this.Rabbits)
            {
                if (rabbit.Species == species)
                {
                    rabbit.Available = false;
                    listRabbits.Add(rabbit);
                }
            }
            return listRabbits.ToArray();
        }

        public int Count => this.Rabbits.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var rabbit in this.Rabbits)
            {
                if (rabbit.Available == true)
                {
                    sb.AppendLine($"{rabbit.ToString()}");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
