using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter first name- ");
            string firstname = Console.ReadLine();
            Console.WriteLine("Please enter your age- ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter how tall are you- ");
            double height = double.Parse(Console.ReadLine());

            Console.WriteLine("My first name is: "+firstname);
            Console.WriteLine("My age is: "+age);
            Console.WriteLine("My hight is: "+height);
            Console.Read();
        }
       
    }
}
