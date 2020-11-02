using System;
using System.Collections.Generic;
using System.Text;

namespace Class_car_and_engine
{
    class Car
    {
        //another class Engine
        public Engine Engine { get; set; }

        public Car()
        {
            this.Engine = new Engine(300,3000);
        }
    }
}
