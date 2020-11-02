using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] password = Console.ReadLine().ToCharArray();

            bool flagCapital = false;
            bool flagLower = false;
            if (password.Length < 8)
            {
                Console.WriteLine("Error, not enough lenght!");
                return;
            }
            else
            {
                for (int i = 0; i < password.Length; i++)
                {
                    if (char.IsLower(password[i]))
                        flagLower = true;
                    if (char.IsUpper(password[i]))
                        flagCapital = true;
                    if (flagCapital == true&&flagLower==true)
                    {
                        break;
                    }
                }
            }
            if (flagCapital == true && flagLower == true)
            {
                Console.WriteLine("Correct password");
            }
            else
            {
                Console.WriteLine("Error, password must contain lower and capital letter.");
            }
        }
    }
}
