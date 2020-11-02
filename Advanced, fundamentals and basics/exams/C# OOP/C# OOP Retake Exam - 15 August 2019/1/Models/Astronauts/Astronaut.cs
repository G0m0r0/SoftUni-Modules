using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.Bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        //make collection for bag
        public IBag Bag { get; private set; }

        public virtual void Breath()
        {
           if (this.Oxygen - 10 < 0)
           {
               this.Oxygen = 0;
           }
           else
           {
               this.Oxygen -= 10;
           }
       }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Oxygen: {this.Oxygen}");
            if(this.Bag.Items.Count>0)
            {
                sb.AppendLine($"Bag items: {string.Join(",",this.Bag.Items)}");
            }
            else
            {
                sb.AppendLine("none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
