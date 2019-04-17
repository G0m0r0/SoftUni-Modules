using System;

namespace Caesar_Cipher
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();

            char[] encryptedText = new char[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                encryptedText[i] = (char)(text[i] + 3);
            }

            Console.WriteLine(encryptedText);
        }
    }
}
