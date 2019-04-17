using System;
using System.Text;

namespace _5.Digits__Letters_and_Other
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            StringBuilder sbDigit = new StringBuilder();
            StringBuilder sbLetter = new StringBuilder();
            StringBuilder sbSymbol = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsDigit(text[i]))
                    sbDigit.Append(text[i]);
                else if (char.IsLetter(text[i]))
                    sbLetter.Append(text[i]);
                else
                    sbSymbol.Append(text[i]);
            }

            Console.WriteLine(sbDigit);
            Console.WriteLine(sbLetter);
            Console.WriteLine(sbSymbol);
        }
    }
}
