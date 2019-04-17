using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] charArray = username.ToCharArray();
            string password = string.Empty;
            for (int i = charArray.Length - 1; i >=  0; i--)
            {
                password += charArray[i];
            }
            string login = string.Empty;
            int counter = 0;
            do
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }
                 login = Console.ReadLine();
                if (login == password) Console.WriteLine($"User {username} logged in.");
                else Console.WriteLine($"Incorrect password. Try again.");
                
            } while (password!=login);
        }
    }
}
