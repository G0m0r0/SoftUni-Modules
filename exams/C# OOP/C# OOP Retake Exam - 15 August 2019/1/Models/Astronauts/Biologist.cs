using SpaceStation.Models.Astronauts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut, IAstronaut
    {
        private const double initialUnitsOfOxygen = 70;
        public Biologist(string name) 
            : base(name, initialUnitsOfOxygen)
        {
        }

        public override void Breath()
        {
            if (this.Oxygen - 5 < 0)
            {
                this.Oxygen = 0;
            }
            else
            {
                this.Oxygen -= 5;
            }
        }

    }
}
