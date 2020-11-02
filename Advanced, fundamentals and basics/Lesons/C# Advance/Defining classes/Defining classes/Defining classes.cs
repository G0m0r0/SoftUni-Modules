using System;

namespace Defining_classes
{
    class Program
    {
        class Dog
        {
            int sleepCount = 0;
            static int barkingCount=0;

            string name;

             public string MyPropertyName { get; set; }

            //same as
          // public string Name()
          // {
          //     return name;
          // }
          // public void Name(string value)
          // {
          //     name = value;
          // }
            //
            public void Sleep()
            {
                sleepCount++;
                Console.WriteLine("I am sleeping");
            }
           public void Barking()
           {
               Console.WriteLine("I am barking");
                barkingCount++;
           }
            public int GetSleepCount() //getter
            {
                return sleepCount;
            }
            //if there is no setter no one can change it value from main method
            public void SetBarkcount(int value) //setter
            {
                if(value<0)
                {
                    throw new ArgumentException(nameof(value),"Bark count cannot be less than zero");
                    //or we can set default value
                    //like barkingCount=0
                }
                barkingCount = value;
            }
            public int GetBarkingCount()
            {
                return barkingCount;
            }
        }
        static void Main(string[] args)
        {
            //Dog.Sleep(); if its static
            Dog dog1 = new Dog();
            Dog dog2 = new Dog();


            //dog1.Barking(); //but there is no dog.Sleep()
           // dog2.Barking();

            dog1.Sleep();
            dog1.Sleep();
            dog1.Sleep();
            dog1.Sleep();
            dog1.Sleep();

            dog1.Barking();
            dog1.Barking();
            dog1.Barking();
            dog1.Barking();
            dog1.Barking();

            Console.WriteLine(dog1.GetSleepCount());
            Console.WriteLine(dog2.GetSleepCount());

            Console.WriteLine(dog1.GetBarkingCount());
            Console.WriteLine(dog2.GetBarkingCount());

            //property
            dog1.MyPropertyName = "Sharo";
        }
    }
}
