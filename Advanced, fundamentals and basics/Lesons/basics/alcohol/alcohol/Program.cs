using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alcohol
{
    class Program
    {
        static void Main(string[] args)
        {
            double whiskyPrice = double.Parse(Console.ReadLine());
            double beerLiters = double.Parse(Console.ReadLine());
            double wineLiters = double.Parse(Console.ReadLine());
            double brandyLiters = double.Parse(Console.ReadLine());
            double whiskyLiters = double.Parse(Console.ReadLine());

            double brandyPrice = whiskyPrice / 2;
            double winePrice = brandyPrice-(brandyPrice * 0.4);
            double beerPrice = brandyPrice - (brandyPrice*0.8);

            double brandy = brandyPrice * brandyLiters;
            double wine = wineLiters * winePrice;
            double beer = beerLiters * beerPrice;
            double whisky = whiskyLiters * whiskyPrice;
            Console.WriteLine($"{(brandy + wine + beer + whisky):F2}");
            Console.Read();
        }
    }
}
