using System;
using System.Collections.Generic;
using System.Text;

namespace _10.Rage_Quit
{
    class Program
    {
        static void Main(string[] args)
        {
            //doesnt work
            string input = Console.ReadLine();
            int countUniqueChar = CountOfUniqueChar(input.ToUpper().ToCharArray());

            string rageMessage = CreateRageMessage(input.ToUpper().ToCharArray());
            Console.WriteLine($"Unique symbols used: {countUniqueChar}");
            Console.WriteLine(rageMessage);
        }

        private static string CreateRageMessage(char[] input)
        {
            StringBuilder sb = new StringBuilder();

            StringBuilder RageMessage = new StringBuilder();
            string digitStr = string.Empty;
            for (int i = 0; i < input.Length; i++)
            {
                int digit = 0;
                if (char.IsDigit(input[i]))
                {
                    while (char.IsDigit(input[i]))
                    {
                        if (i == input.Length)
                            break;
                        digitStr += input[i];
                        i++;
                    }
                    digit = int.Parse(digitStr);
                    digitStr = string.Empty;
                    for (int j = 0; j < digit; j++)
                    {
                        RageMessage.Append(sb);
                    }
                    sb.Clear();
                }
                else
                {
                    sb.Append(input[i]);
                }
            }
            return RageMessage.ToString();
        }

        private static int CountOfUniqueChar(char[] input)
        {
            List<char> uniueChar = new List<char>();
            foreach (var item in input)
            {
                if (!uniueChar.Contains(item)&&!char.IsDigit(item))
                    uniueChar.Add(item);
            }
            return uniueChar.Count;
        }
    }
}
