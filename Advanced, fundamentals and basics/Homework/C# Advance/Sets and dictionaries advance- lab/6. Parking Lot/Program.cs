using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string>();
            string[] token = new string[2];

            do
            {
                token = Console.ReadLine().Split(", ").ToArray();
                string InOrOut = token[0];
                string carNumber = string.Empty;

                if (token.Length == 2)
                    carNumber = token[1];

                if (InOrOut.Equals("IN"))
                {
                    cars.Add(carNumber);
                }
                else
                {
                    cars.Remove(carNumber);
                }
            } while (token.Length == 2);

            if (cars.Count > 0)
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
