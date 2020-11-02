using System;
using System.Collections;
using System.Collections.Generic;

namespace _8.Traffic_Jam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int numberOfCarsPassing = int.Parse(Console.ReadLine());
            Queue<string> carsQueue = new Queue<string>();

            string command = string.Empty;
            int counterPassing = 0;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green" && carsQueue.Count >= 0)
                {
                    for (int i = 0; i < numberOfCarsPassing; i++)
                    {
                        if (carsQueue.Count > 0)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");
                            counterPassing++;
                        }

                    }
                }
                else
                {
                    carsQueue.Enqueue(command);
                }
            }
            Console.WriteLine($"{counterPassing} cars passed the crossroads.");
        }
    }
}
