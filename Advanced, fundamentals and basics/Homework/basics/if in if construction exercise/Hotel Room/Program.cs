using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int numberNights = int.Parse(Console.ReadLine());
            double studio = 0, apartment = 0;
            if (month == "May" || month == "October")
            {
                studio = 50*numberNights;
                apartment = 65*numberNights;
                if (numberNights > 7 && numberNights < 15)
                    studio *= 0.95;
                else if (numberNights > 14)
                    studio *= 0.7;
            }
            else if(month== "June"||month=="September")
            {
                studio = 75.2*numberNights;
                apartment = 68.7*numberNights;
                if(numberNights>14)
                    studio *= 0.8;
            }
            else if(month=="July"||month=="August")
            {
                studio = 76*numberNights;
                apartment = 77*numberNights;
            }
            if (numberNights > 14) apartment *= 0.9;
            Console.WriteLine($"Apartment: {apartment:f2} lv.");
            Console.WriteLine($"Studio: {studio:f2} lv.");
        }
    }
}

