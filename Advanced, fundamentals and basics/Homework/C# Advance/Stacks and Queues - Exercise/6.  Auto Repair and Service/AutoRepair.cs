using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _6.__Auto_Repair_and_Service
{
    class AutoRepair
    {
        static void Main(string[] args)
        {
            //queue
            string[] carModels = Console.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> carQueue = new Queue<string>(carModels);
            List<string> servicedCars = new List<string>(carQueue.Count);
            Stack<string> servicedCarsStack = new Stack<string>();

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] token = command.Split("-").ToArray();
                switch (token[0])
                {
                    case "Service":
                        if (carQueue.Count > 0)
                        {
                            Console.WriteLine($"Vehicle {carQueue.Peek()} got served.");
                            servicedCarsStack.Push(carQueue.Dequeue());
                        }
                        break;
                    case "CarInfo":
                        string carToCheck = token[1];
                        if (carQueue.Contains(carToCheck))
                        {
                            Console.WriteLine("Still waiting for service.");
                        }
                        else
                        {
                            Console.WriteLine("Served.");
                        }
                        break;
                    case "History":
                        Console.WriteLine(string.Join(", ",servicedCarsStack));
                        break;
                    default:
                        break;
                }
            }
            if (carQueue.Count > 0)
                Console.WriteLine($"Vehicles for service: {string.Join(", ", carQueue)}");
            if(servicedCarsStack.Count>0)
            {
                Console.WriteLine($"Served vehicles: {string.Join(", ",servicedCarsStack)}");
            }
        }
    }
}
