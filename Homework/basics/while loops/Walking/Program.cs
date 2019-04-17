using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string steps = "0";
            int parsedNum = 0;
            int sum = 0;
            while(sum<10000)
            {
                steps = Console.ReadLine();
                if (steps == "Going home")
                {
                    parsedNum = int.Parse(Console.ReadLine());
                    sum += parsedNum;
                    break;
                }
                parsedNum= int.Parse(steps);
                sum += parsedNum;
            }
            if (sum > 9999) Console.WriteLine("Goal reached! Good job!");
            else Console.WriteLine(10000-sum+" more steps to reach goal.");
        }
    }
}
