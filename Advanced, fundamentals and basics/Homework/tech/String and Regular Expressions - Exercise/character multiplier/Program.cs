using System;

namespace character_multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();
            char[] first = strings[0].ToCharArray();
            char[] second = strings[1].ToCharArray();
            int sum = 0;

            int shortestLenght = second.Length;
            if (first.Length < second.Length)
            {
                shortestLenght = first.Length;
                for (int i = shortestLenght; i <second.Length ; i++)
                {
                    sum += second[i];
                }
            }
            else
            {
                for (int i = shortestLenght; i < first.Length; i++)
                {
                    sum += first[i];
                }
            }

            
            for (int i = 0; i < shortestLenght; i++)
            {
                sum += first[i] * second[i];
            }

            Console.WriteLine(sum);
        }
    }
}
