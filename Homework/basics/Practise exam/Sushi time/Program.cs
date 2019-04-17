using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sushi_time
{
    class Program
    {
        static void Main(string[] args)
        {
            //for home 20% of the price 
            string order = Console.ReadLine();
            string restaurant = Console.ReadLine();
            int portions = int.Parse(Console.ReadLine());
            char yesNo =char.Parse(Console.ReadLine());
            double price = 0;
            if (restaurant == "Sushi Zone")
            {
                if (order == "sashimi") price = 4.99 * portions;
                if (order == "maki") price = 5.29 * portions;
                if (order == "uramaki") price = 5.99 * portions;
                if (order == "temaki") price = 4.29 * portions;
            }
            else if (restaurant == "Sushi Time")
            {
                if (order == "sashimi") price = 5.49 * portions;
                if (order == "maki") price = 4.69 * portions;
                if (order == "uramaki") price = 4.49 * portions;
                if (order == "temaki") price = 5.19 * portions;
            }
            else if (restaurant == "Sushi Bar")
            {
                if (order == "sashimi") price = 5.25 * portions;
                if (order == "maki") price = 5.55 * portions;
                if (order == "uramaki") price = 6.25 * portions;
                if (order == "temaki") price = 4.75 * portions;
            }
            else if (restaurant == "Asian Pub")
            {
                if (order == "sashimi") price = 4.5 * portions;
                if (order == "maki") price = 4.80 * portions;
                if (order == "uramaki") price = 5.5 * portions;
                if (order == "temaki") price = 5.5 * portions;
            }
            else { Console.WriteLine("{0} is invalid restaurant!", restaurant); return; }
            if (yesNo == 'Y') price = price + price * 0.2;
            Console.WriteLine("Total price: {0} lv.",Math.Ceiling(price));
        }
    }
}
