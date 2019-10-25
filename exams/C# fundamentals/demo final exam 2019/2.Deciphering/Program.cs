using System;
using System.Text;

namespace _2.Deciphering
{
    class Program
    {

        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string decipher = Console.ReadLine();

            bool valid = ValidOrNot(message);
           
            if(valid)
            {
                message = ReduceASCIIValue(message);
                message = ReplaceSubStrings(message, decipher);
                Console.WriteLine(message);

            }
            else
            {
                Console.WriteLine("This is not the book you are looking for.");
            }

        }

        private static bool ValidOrNot(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                if(message[i]<100||message[i]>122)
                {
                    if(message[i]!='{'&&message[i]!='}'&&message[i]!='|'&&message[i]!='#')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private static string ReplaceSubStrings(string message, string decipher)
        {
            string[] token = decipher.Split();
            string oldSub = token[0];
            string newSub = token[1];
            while (message.Contains(oldSub))
            {
               message= message.Replace(oldSub, newSub);
            }
            return message;
        }

        private static string ReduceASCIIValue(string message)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                sb.Append((char)(message[i] - 3));
            }
            return sb.ToString();
        }
    }
}
