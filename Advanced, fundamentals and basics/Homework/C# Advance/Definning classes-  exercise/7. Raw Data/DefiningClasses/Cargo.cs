using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        private int cargoWeiht;
        private string cargoType;

        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }

        public int CargoWeight
        {
            get { return cargoWeiht; }
            set { cargoWeiht = value; }
        }
        public Cargo(string cargoType,int cargoWeight)
        {
            CargoType = cargoType;
            CargoWeight = cargoWeight;
        }
    }
}
