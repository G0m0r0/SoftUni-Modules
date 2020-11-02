using System;
using System.Text;

namespace string_and_text_processing__lab
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine().ToString();
            do
            {      
                Console.WriteLine($"{command} = {ReverseString(command)}");
                command = Console.ReadLine().ToString();

            } while (command!="end");
        }

        private static string ReverseString(string command)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = command.Length - 1; i >= 0; i--)
            {
                sb.Append(command[i]);
            }
            return sb.ToString();
        }
    }
}
