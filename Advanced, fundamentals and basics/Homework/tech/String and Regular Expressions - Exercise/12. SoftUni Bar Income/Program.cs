using System;
using System.Text.RegularExpressions;

namespace _12.SoftUni_Bar_Income
{
    class Program
    {

        static void Main(string[] args)
        {
            string purchases = string.Empty;
            double totalIncome = 0;
            while (purchases != "end of shift")
            {
                purchases = Console.ReadLine();
                string pattern = @"%(?<customer>[A-Z][a-z]+)%[^|$%.]*<(?<product>\w+)>[^|$.]*\|(?<count>\d+)\|[^|$%.]*?(?<price>[0-9]+\.?[0-9]+)\$";
                Regex order = new Regex(pattern);
                if (order.IsMatch(purchases))
                {
                    string name = order.Match(purchases).Groups["customer"].Value;
                    string product = order.Match(purchases).Groups["product"].Value;
                    int count = int.Parse(order.Match(purchases).Groups["count"].Value);
                    double price = double.Parse(order.Match(purchases).Groups["price"].Value);

                    double totalPrice = price * count;

                    totalIncome += totalPrice;
                    Console.WriteLine($"{name}: {product} - {totalPrice:f2}");
                }
            }
            Console.WriteLine($"Total income: {totalIncome:f2}");
        }
    }
}
