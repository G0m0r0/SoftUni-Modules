using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name_wars
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int sum= 0;
            int max = int.MinValue;
            string nameSecond = string.Empty;
            while(name!="STOP")
            {
                nameSecond = name;
                sum = 0;
                for (int i = 0; i < name.Length; i++)
                {
                    char num = name[i];
                    sum += num;
                }           
                if (max < sum) max = sum;
                name = Console.ReadLine();       
            }
            Console.WriteLine($"Winner is {nameSecond} - {max}!");
        }
    }
}
