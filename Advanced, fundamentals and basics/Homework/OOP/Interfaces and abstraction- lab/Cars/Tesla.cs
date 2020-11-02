using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : ICar, IElectricCar
    {
        public Tesla(string model,string color,int battery)
        {
            this.Model = model;
            this.Color = color;
            this.Battery = battery;
        }
        public int Battery { get; set ; }
        public string Model { get ; set ; }
        public string Color { get ; set; }

        public void Start()
        {
            Console.WriteLine("Engine start");
        }

        public void Stop()
        {
            Console.WriteLine("Breaaak!");
        }

        public override string ToString()
        {
            return $"{this.Color} {nameof(Tesla)} {this.Model} with {this.Battery} Batteries";
        }
    }
}
