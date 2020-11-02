using Inheritance_folder.Animals;
using System;
using System.Collections.Generic;

namespace Inheritance_folder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();
            animals.Add(new Dog());
            animals.Add(new Puppy());
            animals.Add(new Cat());

            foreach (var item in animals)
            {
                item.Eat();
            }
        }
    }
}
