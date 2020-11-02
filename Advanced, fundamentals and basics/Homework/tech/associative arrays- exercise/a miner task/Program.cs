using System;
using System.Collections.Generic;

namespace a_miner_task
{
    class Program
    {
        static void Main(string[] args)
        {
            var resources = new Dictionary<string, int>();
            string metal = Console.ReadLine();

            while (metal!="stop")
            {
                int quantity = int.Parse(Console.ReadLine());

                if(resources.ContainsKey(metal))
                {
                    resources[metal] += quantity;
                }
                else
                {
                    resources.Add(metal, quantity);
                }
                metal = Console.ReadLine();
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
