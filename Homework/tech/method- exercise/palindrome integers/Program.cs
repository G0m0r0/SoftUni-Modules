using System;

namespace palindrome_integers
{
    class Program
    {
        static bool Palindrom(string str)
        {
            bool flag = true;
            int end = str.Length;
            for (int i = 0; i < str.Length/2; i++)
            {       
                if (str[i] != str[end-1])
                    flag = false;
                end--;
            }
            return flag;
        }
        static void Main(string[] args)
        {
            string palindrom = Console.ReadLine();
            while (palindrom != "END")
            {
                if (Palindrom(palindrom))
                    Console.WriteLine("true");
                else Console.WriteLine("false");
                palindrom = Console.ReadLine();
            }
        }
    }
}
