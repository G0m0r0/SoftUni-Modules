using System;

namespace vowels_count
{
    class Program
    {
        static int GetNumOfVowel(string str)
        {
            int br = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a'
                    || str[i] == 'e'
                    || str[i] == 'i'
                    || str[i] == 'o'
                    || str[i] == 'u')
                    br++;
            }
            return br;
        }
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(GetNumOfVowel(str.ToLower()));
        }
    }
}
