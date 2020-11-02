using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invalid_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool isValid = (number > 10) && (number % 2 == 0);
            if(!isValid)
            {
                Console.WriteLine("Invalid");
            }
        }
    }
}
