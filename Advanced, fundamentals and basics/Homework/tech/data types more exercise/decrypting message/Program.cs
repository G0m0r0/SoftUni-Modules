using System;

namespace decrypting_message
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numOfLines = int.Parse(Console.ReadLine());
            string decryptedMessage = string.Empty;
            for (int i = 0; i < numOfLines; i++)
            {
                char letter = char.Parse(Console.ReadLine());
                decryptedMessage += (char)(letter+key);
            }
            Console.WriteLine(decryptedMessage);
        }
    }
}
