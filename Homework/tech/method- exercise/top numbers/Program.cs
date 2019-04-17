using System;

namespace top_numbers
{
    class Program
    {
        static void TopNumbers(int num)
        {
            
            for (int i = 1; i <= num; i++)
            {
                int sumNum = 0;
                bool flagOdd = false;

                int numI = i;
                while (numI > 0)
                {
                    sumNum += numI % 10;

                    if ((numI % 10) % 2 != 0)
                        flagOdd = true;

                    numI /= 10;
                }

                if (sumNum % 8 == 0 && flagOdd == true)
                    Console.WriteLine(i);

            }
        }
        static void Main(string[] args)
        {
            int rangeOfTopNumbers = int.Parse(Console.ReadLine());
            TopNumbers(rangeOfTopNumbers);
        }
    }
}
