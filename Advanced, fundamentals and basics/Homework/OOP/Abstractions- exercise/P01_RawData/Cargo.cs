using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        public int cargoWeight;
        public string cargoType;

        public Cargo(int weight,string type)
        {
            this.cargoType = type;
            this.cargoWeight = weight;
        }
        public Cargo() { }
    }
}
