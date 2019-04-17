using System;

namespace password_validation
{
    class Program
    {
        static bool PassValidation(char[] password)
        {
            bool flag = true;

            //check password lenght
            if (password.Length < 6 || password.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                flag = false;
            }

            int num = 0;
            int br = 0;
            bool flagValidSymbols = true;
            //count numbers and check password for other symbols
            for (int i = 0; i < password.Length; i++)
            {
                string ch = password[i].ToString();
                if (int.TryParse(ch, out num))
                    br++;

                if ((password[i] >= 0 && password[i] <= 47)
                    || (password[i] >= 58 && password[i] <= 64)
                    || (password[i] >= 91 && password[i] <= 96)
                    || (password[i] >= 123))
                {
                    flag = false;
                    flagValidSymbols = false;
                }
            }
            if(!flagValidSymbols)
                Console.WriteLine("Password must consist only of letters and digits");

            //check password numbers
            if (br < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
                flag = false;
            }
            return flag;
        }
        static void Main(string[] args)
        {
            string password = Console.ReadLine();
            char[] passwordToChar = password.ToCharArray();
            if(PassValidation(passwordToChar))
                Console.WriteLine("Password is valid");
        }
    }
}
