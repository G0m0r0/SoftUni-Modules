using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Car
    {
        public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
        {
            this.Model = model;
            this.Cargo = cargo;
            this.Engine = engine;
            this.Tire = tire;
        }
        public string Model {get;set;}
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tire { get; set; }
    }
}
