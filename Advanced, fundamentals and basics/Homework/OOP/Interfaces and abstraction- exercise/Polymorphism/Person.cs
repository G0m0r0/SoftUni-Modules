using Polymorphism.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class Person: Mammal,IAnimal
    {
        public void GetSalary()
        {

        }

        public override void PrintToConsole()
        {
            Console.WriteLine("I am person!");
        }
    }
}
