using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    public class Mammal:Animal
    {
        public void MammalMethod()
        {

        }

        public override void PrintToConsole()
        {
            Console.WriteLine("I am mammal!");
        }
    }
}
