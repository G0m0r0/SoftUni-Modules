using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Sun:Star
    {
        public Sun(int speed):base(200)
        {
            Console.WriteLine("Sun");
        }
        public int NumOfPlanets { get; } = 8;
    }
}
