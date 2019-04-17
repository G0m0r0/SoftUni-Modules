using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Water_dispenser
{
    class Program
    {
        static void Main()
        {
            int vCup = int.Parse(Console.ReadLine());
            int sum = 0;
            int i = 0;
            while(sum<vCup)
            {
                string button = Console.ReadLine();
                if (button == "Easy") sum += 50;
                else if (button == "Medium") sum += 100;
                else if (button == "Hard") sum += 200;
                i++;
            }
            if (sum > vCup) Console.WriteLine($"{sum-vCup}ml has been spilled.");
            else Console.WriteLine("The dispenser has been tapped {0} times.",i);
        }
    }
}
