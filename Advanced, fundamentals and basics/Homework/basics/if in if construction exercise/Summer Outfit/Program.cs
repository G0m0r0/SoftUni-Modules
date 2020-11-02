using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {
            int degrees = int.Parse(Console.ReadLine());
            string partOfDay = Console.ReadLine();
            string shoes = " ";
            string outfit = " ";
            if(degrees>=10&&degrees<=18)
            {
                if (partOfDay == "Morning") { outfit = "Sweatshirt"; shoes = "Sneakers";  }
                if (partOfDay == "Afternoon") { outfit = "Shirt";  shoes = "Moccasins";  }
                if (partOfDay == "Evening") { outfit = "Shirt"; shoes = "Moccasins"; }
            }
            else if (degrees>18&&degrees<=24)
            {
                if (partOfDay == "Morning") { outfit = "Shirt"; shoes = "Moccasins"; }
                if (partOfDay == "Afternoon") { outfit = "T-Shirt"; shoes = "Sandals"; }
                if (partOfDay == "Evening") { outfit = "Shirt"; shoes = "Moccasins"; }
            }
            else if (degrees>=25)
            {
                if (partOfDay == "Morning") { outfit = "T-Shirt"; shoes = "Sandals"; }
                if (partOfDay == "Afternoon") { outfit = "Swim Suit"; shoes = "Barefoot"; }
                if (partOfDay == "Evening") { outfit = "Shirt"; shoes = "Moccasins"; }
            }
            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");
        }
    }
}
