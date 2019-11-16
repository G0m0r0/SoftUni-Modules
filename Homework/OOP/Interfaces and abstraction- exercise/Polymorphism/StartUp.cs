using Polymorphism.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polymorphism
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Enumerable.Range(0, 100)
                .Where(x=>Math.Log(x%10-2) is var value&&value>=1&&value<=2);

            Animal animal = new Animal();
            Mammal mammal = new Mammal();
            Person person = new Person();

            if(person is Person)
            {
                ((Person)person).GetSalary();
            }
            //or
            if(person is Person realPerson)
            {
                realPerson.GetSalary();
            }

            List<Animal> list = new List<Animal>();
            list.Add(person);
            list.Add(mammal);
            list.Add(person);

            foreach (var item in list)
            {
                //different answear for evry class in list (polymorphism)
                item.PrintToConsole();

                if(item is Animal)
                {
                    //Console.WriteLine("I am animal! ");
                    //added as method
                }
                else if(item is Mammal)
                {
                    //Console.WriteLine("I am mammal!");
                }
                else if(item is Person)
                {
                    //Console.WriteLine("I am person!");
                }
            }


            Animal animal3 = new Dog();
            Person person3 = animal as Person;
            person?.GetSalary(); //?. check if its null

            //same as
            if(person!=null)
            {
                person.GetSalary();
            }

            //its possible
            int? a = 4;
            a = null;

            //operator ??
            Person person4 = animal as Person ?? new Person();
            //if left side doesnt match do right side
        }
    }
}
