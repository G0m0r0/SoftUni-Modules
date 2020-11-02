using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance2
{
    public class Star:CosmicalObject
    {
        public void Shine()
        {
            Console.WriteLine(base.ToString());
        }

        public override string ToString()
        {
            return "Star";
        }
    }
}
