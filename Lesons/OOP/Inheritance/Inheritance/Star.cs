using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class Star:CosmicalObject
    {
        public Star(int speed):base(speed)
        {
            Console.WriteLine("Star");
            this.Move();
        }

    }
}
