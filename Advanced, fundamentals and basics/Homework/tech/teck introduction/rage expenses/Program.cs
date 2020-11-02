using System;

namespace rage_expenses
{
    class Program
    {
        static void Main()
        {
            int lostGames = int.Parse(Console.ReadLine());
            decimal headsetPrice = decimal.Parse(Console.ReadLine());
            decimal mousePrice = decimal.Parse(Console.ReadLine());
            decimal keyboardPrice = decimal.Parse(Console.ReadLine());
            decimal displayPrice=decimal.Parse(Console.ReadLine());

            int brHeadset = 0;
            int brMouse = 0;
            int brKeyboard = 0;
            int brDisplay = 0;

            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2==0) brHeadset++;
                if (i % 3==0) brMouse++;
                if (i % 2 == 0 && i % 3 == 0)
                {
                    brKeyboard++;
                    brDisplay++;
                }
            }
            decimal totalMoney = brHeadset*headsetPrice + brMouse*mousePrice + brKeyboard*keyboardPrice+ (brDisplay / 2)*displayPrice;
            Console.WriteLine($"Rage expenses: {(totalMoney):F2} lv.");
        }
    }
}
