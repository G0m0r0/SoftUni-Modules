using System;
using System.Collections.Generic;
using System.Text;

namespace Class_car_and_engine
{
    public class Engine
    {
        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
        public Engine(int horsePower,double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }
    }
}
