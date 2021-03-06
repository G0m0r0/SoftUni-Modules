﻿using System;
using System.Linq;
using System.Reflection;

namespace Reflection_and_Atributes
{
    class Program
    {
        static void Main(string[] args)
        {
            //takes all classes in the assembly
            var types = Assembly.GetExecutingAssembly().GetTypes();

            foreach (var mytype in types)
            {
                Console.WriteLine(mytype);
            }

            //
            Console.WriteLine("______________");

            Car car = new Car();

            Type type = car.GetType();
            Console.WriteLine(type);

            Type type2 = typeof(Car);
            Console.WriteLine(type2);

            Type type3 = Type.GetType("Reflection_and_Atributes.Car");
            Console.WriteLine(type3);

            Method<int>();
            Console.WriteLine(type.FullName);


            //take all interfaces
            Console.WriteLine("_________________");


            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                Console.WriteLine(@interface.Name);
            }

            //ferrari will take the same interfaces
            Ferrari ferrari = new Ferrari();
            Type ferrariType = ferrari.GetType();
            var interfacesFerrari = ferrariType.GetInterfaces();
            foreach (var @interface in interfacesFerrari)
            {
                Console.WriteLine(@interface);
                Console.WriteLine(@interface.FullName);
            }

            //create instance of a class we can cast to CAR too

            var obj = Activator.CreateInstance(ferrariType) as Ferrari;

            Console.WriteLine(obj.Year);


            //make a specific car
            string make = Console.ReadLine(); //Ferrari

            Type type4 = Type.GetType($"Reflection_and_Atributes.{make}");
           // var obj2 = Activator.CreateInstance(type4, 5) as Car;
            //reflection ends

            //Console.WriteLine(obj2.Name); //Ferrari

            //
            Type type5 = typeof(Car);
            var fields = type5.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            //if we call GetFields() we get only the public and instance one
            foreach (var field in fields)
            {
                Console.WriteLine(field);
            }

            //set value to private methods :(

            Type type6 = typeof(Ferrari);
            var car3 = Activator.CreateInstance(type) as Car;

            var field2 = type6.GetField(
                "name", BindingFlags.NonPublic
                | BindingFlags.Instance);

            field2.SetValue(car, "Niki");

            Console.WriteLine(car.Name);


            //

            var constructors = type6.GetConstructors(BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static);

            foreach (var constructor in constructors)
            {
                Console.WriteLine(constructor);
            }

            var certainConstructor = constructors
                .FirstOrDefault(x => x.GetParameters().Count() == 0);
            //or var certainConstructor=type6.GetConstructor(new Type[] {typeof(int)};
            //takes construcor that have integers after that invoke is (new object[] {123}); 

            var newCarByConstructor = (Ferrari)certainConstructor.Invoke(null);

            Console.WriteLine(newCarByConstructor);


            //methods

            Type type7 = typeof(Ferrari);
            var method = type7.GetMethod("SubstractMehtod",
                BindingFlags.Static|BindingFlags.Public,
                null,
                new Type[] {typeof(int),typeof(int) },
                null);
            Console.WriteLine(method.ReturnType);
            var returnValue = method.Invoke(ferrari, new object[] { 123, 312 });
            Console.WriteLine(returnValue);
        }

        //Its valid!!
        static void Method<T>()
        {
            Type type = typeof(T);
        }

        public class Car : ICloneable
        {
            protected string name;
            public string Name => this.name;
            public int Year { get; set; }

            public object Clone()
            {
                throw new NotImplementedException();
            }

            public void Move()
            {

            }
        }

        public class Ferrari : Car
        {
            public Ferrari()
            {
                this.name = "Ferrari";
            }

            public Ferrari(int a)
            {
                Console.WriteLine("int aaa");
            }

            public Ferrari(string a)
            {
                Console.WriteLine("Ferrari string a");
            }
            public double SubstractMehtod(int a, int b)
            {
                return a - b;
            }
        }

        public class Audi : Car
        {
            public Audi()
            {
                this.name = "Audi";
            }
        }
    }
}
