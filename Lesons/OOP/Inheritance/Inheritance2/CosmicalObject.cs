using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance2
{
    public class CosmicalObject
    {
        protected int Speed { get; set; }
        public int Move()
        {
            return this.Speed * 10;
        }
        public override string ToString()
        {
            return this.Speed.ToString();
        }
    }

}
