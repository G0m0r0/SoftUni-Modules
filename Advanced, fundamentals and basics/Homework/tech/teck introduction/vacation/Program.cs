using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = int.Parse(Console.ReadLine());
            string discounts = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double sum = 0;
            switch (discounts)
            {
                case "Students":
                    {
                        if (dayOfWeek == "Friday") sum += (8.45 * numOfPeople);
                        else if (dayOfWeek == "Saturday") sum += (9.8 * numOfPeople);
                        else if (dayOfWeek == "Sunday") sum += (10.46 * numOfPeople);
                        if (numOfPeople >= 30) sum *= 0.85;
                    } break;
                case "Business":
                    {
                        double reduce = 0;
                        if (dayOfWeek == "Friday")
                        {
                            sum += (10.9 * numOfPeople);
                            reduce = 109;
                        }
                        else if (dayOfWeek == "Saturday")
                        {
                            sum += (15.6 * numOfPeople);
                            reduce = 156;
                        }
                        else if (dayOfWeek == "Sunday")
                        {
                            sum += (16 * numOfPeople);
                            reduce = 160;
                        }
                        if (numOfPeople >= 100) sum -= reduce;
                    }
                    break;
                case "Regular":
                    {
                        if (dayOfWeek == "Friday") sum += (15 * numOfPeople);
                        else if (dayOfWeek == "Saturday") sum += (20 * numOfPeople);
                        else if (dayOfWeek == "Sunday") sum += (22.5 * numOfPeople);
                        if (numOfPeople >= 10 && numOfPeople <= 20) sum *= 0.95;
                    }
                    break;
                default:
                    break;
            }
            Console.WriteLine("Total price: {0:F2}",sum);
        }
    }
}
