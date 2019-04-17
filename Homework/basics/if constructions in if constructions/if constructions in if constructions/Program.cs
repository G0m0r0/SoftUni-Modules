using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace if_constructions_in_if_constructions
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameProduct = Console.ReadLine();
            string city = Console.ReadLine();
            double amountProduct = double.Parse(Console.ReadLine());
            if(city=="Sofia")
            {
                if (nameProduct == "coffee") Console.WriteLine(amountProduct * 0.5);
                if (nameProduct == "water")  Console.WriteLine(amountProduct*0.8);
                if (nameProduct == "beer") Console.WriteLine(amountProduct * 1.2);
                if (nameProduct == "sweets") Console.WriteLine(amountProduct * 1.45);
                if (nameProduct == "peanuts") Console.WriteLine(amountProduct *1.6 );
            }
            else if (city == "Plovdiv")
            {
                if (nameProduct == "coffee") Console.WriteLine(amountProduct * 0.4);
                if (nameProduct == "water") Console.WriteLine(amountProduct * 0.7);
                if (nameProduct == "beer") Console.WriteLine(amountProduct * 1.15);
                if (nameProduct == "sweets") Console.WriteLine(amountProduct * 1.30);
                if (nameProduct == "peanuts") Console.WriteLine(amountProduct * 1.5);
            }
            if (city == "Varna")
            {
                if (nameProduct == "coffee") Console.WriteLine(amountProduct * 0.45);
                if (nameProduct == "water") Console.WriteLine(amountProduct * 0.7);
                if (nameProduct == "beer") Console.WriteLine(amountProduct * 1.1);
                if (nameProduct == "sweets") Console.WriteLine(amountProduct * 1.35);
                if (nameProduct == "peanuts") Console.WriteLine(amountProduct * 1.55);
            }
        }
    }
}
