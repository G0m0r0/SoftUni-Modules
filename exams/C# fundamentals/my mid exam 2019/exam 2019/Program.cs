using System;

namespace exam_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //superrsecrett
            int dayOfVacation = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            int countPeople = int.Parse(Console.ReadLine());
            double fuelPerKilomiter = double.Parse(Console.ReadLine());
            double foodExpenses = double.Parse(Console.ReadLine());
            double hotelRoomPerNight = double.Parse(Console.ReadLine());

            double expenses = 0;

            expenses += foodExpenses * countPeople * dayOfVacation;
            if (countPeople > 10)
            {
                expenses += (countPeople * dayOfVacation * hotelRoomPerNight) * 0.75;
            }
            else
            {
                expenses += countPeople * dayOfVacation * hotelRoomPerNight;
            }   
            for (int i = 1; i <= dayOfVacation; i++)
            {
                if (expenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(expenses - budget):f2}$ more.");
                    return;
                }
                double traveledKilometers = double.Parse(Console.ReadLine());
                expenses = expenses + (traveledKilometers * fuelPerKilomiter); 
                
                if(i%3==0||i%5==0)
                {
                    expenses += expenses * 0.4;
                }
                if(i%7==0)
                {
                    expenses-=expenses/ countPeople;
                }
                if (expenses > budget)
                {
                    Console.WriteLine($"Not enough money to continue the trip. You need {(expenses - budget):f2}$ more.");
                    return;
                }
            }
            Console.WriteLine($"You have reached the destination. You have {Math.Abs(budget-expenses):f2}$ budget left.");
        }
    }
}
