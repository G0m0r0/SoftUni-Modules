using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : ICar
    {
        public string Model { get ; set ; }
        public bool Brakes { get ; set ; }
        public bool Pedal { get ; set ; }
        public string Name { get; set; }

        public Ferrari(string name)
        {
            this.Name = name;
            this.Brakes = true;
            this.Pedal = true;
            this.Model = "488-Spider";
        }

        public override string ToString()
        {
            string brakes = string.Empty;
            string pedals = string.Empty;
            if(this.Brakes)
            {
                brakes = "Brakes!";
            }
            if(this.Pedal)
            {
                pedals = "Gas!";
            }
            return $"{this.Model}/{brakes}/{pedals}/{this.Name}";
        }
    }
}
