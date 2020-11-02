using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Engine
    {
        public Engine(int speed, int power)
        {
            this.enginePower = power;
            this.engineSpeed = speed;
        }
        public Engine() { }

        public int engineSpeed { get; set; }
        public int enginePower { get; set; }
    }
}
