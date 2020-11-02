using System;

namespace demo_mid_password
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double flour = double.Parse(Console.ReadLine());
            double eggs = double.Parse(Console.ReadLine());
            double apron = double.Parse(Console.ReadLine());

            //1 flour 10 eggs 1 apron
            int freepackage = students / 5;
            double neededItems = apron * (Math.Ceiling(students + students * 0.2)) + students * eggs * 10 + flour * (students - freepackage);
            if (neededItems <= budget)
                Console.WriteLine("Items purchased for {0:f2}$.", neededItems);
            else
                Console.WriteLine("{0:f2}$ more needed.", neededItems - budget);
        }
    }
}
