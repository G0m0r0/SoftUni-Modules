using Inheritance_folder.Animals;
using System;

namespace Inheritance_folder
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal animal = new Dog();
            animal.Eat(); //we can access only eat
           (animal as Dog).Bark(); //we can access and bark

            Puppy animal2 = new Puppy();
            animal2.Bark();

            Cat animal3 = new Cat();
            animal3.Meow();
        }
    }
}
