using System;

namespace HotelReservation
{
    public class StartUp
    {
        enum Season
        {
            Autumn = 1,
            Spring = 2,
            Winter = 3,
            Summer = 4
        }
        enum Disscount
        {
            VIP = 20,
            SecondVisit = 10,
            None = 0,
        }
        public static void Main(string[] args)
        {
            var tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            var pricePerDay = decimal.Parse(tokens[0]);
            var numOfDays = int.Parse(tokens[1]);
            Season season = 0;
            switch (tokens[2])
            {
                case "Autumn":
                    season = Season.Autumn;
                    break;
                case "Spring":
                    season = Season.Spring;
                    break;
                case "Winter":
                    season = Season.Winter;
                    break;
                case "Summer":
                    season = Season.Summer;
                    break;
            }
            Disscount disscount = 0;
            if (tokens.Length == 4)
            {
                switch (tokens[3])
                {
                    case "VIP":
                        disscount = Disscount.VIP;
                        break;
                    case "SecondVisit":
                        disscount = Disscount.SecondVisit;
                        break;
                    case "None ":
                        disscount = Disscount.None;
                        break;
                }
            }
            else
            {
                disscount = Disscount.None;
            }


            var totalPrice = PriceCalculator.GetTotalPrice(pricePerDay, numOfDays, (int)season, (int)disscount);

            Console.WriteLine($"{(totalPrice):f2}");
        }
    }
}
