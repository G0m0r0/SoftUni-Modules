using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_folder.Animals
{
    public class Dog:Animal
    {
        public int MyProperty { get; set; }

        public void Bark()
        {

        }

        public override void Eat()
        {
            Console.WriteLine("Dog is eating");
        }
    }
}
