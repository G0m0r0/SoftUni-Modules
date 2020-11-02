using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    public class CosmicalObject
    {
        public CosmicalObject(int speed)
        {
            Console.WriteLine("Cosmical Object");
            this.Speed = speed;
        }
        public int Speed { get; set; }
        public int Move()
        {
            return this.Speed * 10;
        }
    }

}
