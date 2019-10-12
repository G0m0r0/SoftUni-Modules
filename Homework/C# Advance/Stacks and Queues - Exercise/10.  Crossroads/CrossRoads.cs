using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _10.__Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freewindow = int.Parse(Console.ReadLine());

            Queue<string> queueCars = new Queue<string>();

            int carsPassedSafly = 0;

            string command = string.Empty;
            while ((command=Console.ReadLine())!="END")
            {
                int lefoverGreenLight = greenLight;

                if(command!="green")
                {
                    queueCars.Enqueue(command);
                }
                else
                {
                    //int carsTime = 0;
                    StringBuilder carsLenght = new StringBuilder();
                    for (int i = 0; i < queueCars.Count; i++)
                    {
                        string car = queueCars.Dequeue();
                        carsLenght.Append(car);
                       // carsTime = carsLenght.Length;
                        if(greenLight+freewindow<carsLenght.Length)
                        {
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at charackter {carsLenght[greenLight+freewindow]}");
                            return;
                        }
                        else
                        {
                            carsPassedSafly++;
                        }
                    }
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassedSafly} total cars passed the crossroads.");

        }
    }
}
