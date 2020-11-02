using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vowels_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            int sum = 0;
            for (int i = 1; i < text.Length; i++)
            {
                if (text[i] == 'a') sum++;
                else if (text[i] == 'e') sum += 2;
                else if (text[i] == 'i') sum += 3;
                else if (text[i] == 'o') sum += 4;
                else if (text[i] == 'u') sum += 5;
            }
            Console.WriteLine(sum);
        }
    }
}
