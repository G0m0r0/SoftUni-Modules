using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_folder.Animals
{
    public class Puppy: Dog
    {
        public void Weep()
        {

        }
        public override void Eat()
        {
            Console.WriteLine("Puppy is eating");
        }
    }
}
