using System;
using System.Collections;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int durationOfGreenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            string commandOrCar = string.Empty;
            int totalCars = 0;
            while ((commandOrCar=Console.ReadLine())!="END")
            {
                if(commandOrCar=="green")
                {
                    int window = durationOfGreenLight;
                    while (cars.Count>0&&window>0)
                    {
                        string car = cars.Dequeue();
                        totalCars++;
                        window -= car.Length;
                        if(window<0)
                        {
                            if(window+freeWindow<0)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{car} was hit at {car[car.Length+window+freeWindow]}.");
                                return;
                            }
                        }
                    }

                }
                else
                {
                    cars.Enqueue(commandOrCar);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCars} total cars passed the crossroads.");

        }
    }
}
