using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int cake = w * h;
            string command = " ";
           

            while(true)
            {
                command = Console.ReadLine();
               
                
                if (command != "STOP")
                {
                    cake -= int.Parse(command);
                }
                else
                {
                    Console.WriteLine($"{cake} pieces are left.");
                    break;
                }
                if (cake < 0)
                {
                    Console.WriteLine($"No more cake left! You need {Math.Abs(cake)} pieces more.");
                    break;
                }
            }
            
        }
    }
}
