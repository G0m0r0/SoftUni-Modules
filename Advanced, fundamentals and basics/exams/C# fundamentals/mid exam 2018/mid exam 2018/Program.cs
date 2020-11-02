using System;

namespace mid_exam_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            int partySize = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int money = 0;
            for (int i = 1; i <= days; i++)
            {
                money += 50;

                if (i % 10 == 0)
                    partySize -= 2;
                if (i % 15 == 0)
                    partySize += 5;
                money -= partySize * 2;  
                
                if (i % 3 == 0)
                    money -= partySize * 3;
                if (i % 5 == 0)
                {
                    money += partySize * 20;
                    if (i % 3 == 0)
                        money -= partySize * 2;
                }
            }
            Console.WriteLine($"{partySize} companions received {money/partySize} coins each.");
        }
    }
}
