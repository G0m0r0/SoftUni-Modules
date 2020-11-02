using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_else
{
    class Program
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int minAndHours = (hours * 60) + minutes + 15;
            Console.WriteLine(minAndHours/60);
        }

    }
}
