using System;

namespace retake_mid_exam_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());
            int daysLeft = int.Parse(Console.ReadLine());

            int price = 0;
            int christmasSpirit = 0;

            int ornamentSet = 0;
            int threeSkirt = 0;
            int threeGarlands = 0;
            int threeLights = 0;
            for (int i = 1; i <= daysLeft; i++)
            {
                if (i % 11 == 0)
                {
                    quantity += 2;
                }
                if (i % 2 ==0)
                {
                    christmasSpirit += 5;
                    price += quantity * 2;
                }             
                if (i % 3 == 0)
                {
                    christmasSpirit += 13;
                    price += quantity * 5;
                    price += quantity * 3;
                }
                if (i % 5 == 0)
                {
                    price += quantity * 15;
                    christmasSpirit += 17;
                    if (i % 3 == 0)
                    {
                        christmasSpirit += 30;
                    }
                }
                if (i%10==0)
                {
                    christmasSpirit -= 20;
                    price += 5;
                    price += 3;
                    price += 15;
                }
            }
            if(daysLeft%10==0)
            {
                christmasSpirit -= 30;
            }
            Console.WriteLine($"Total cost: {price}");
            Console.WriteLine($"Total spirit: {christmasSpirit}");
        }
    }
}
