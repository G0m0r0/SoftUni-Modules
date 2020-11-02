using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    public class Animal
    {
        public void AnimalMethod()
        {
            
        }
        public virtual void PrintToConsole()
        {
            Console.WriteLine("I am animal! ");
        }
    }
}
