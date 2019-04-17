using System;

namespace password_validation
{
    class Program
    {
        static bool CheckPassWordLengh(char[] password)
        {
            bool flag = true;
            if (password.Length < 6 || password.Length > 10)
            {
                flag = false;
            }
            return flag;
        }
        static bool PasswordCountNumbers(char[] password)
        {
            bool flag = true;
            int br = 0;
            int num = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (int.TryParse(password[i].ToString(), out num))
                    br++;
            }
            if (br < 2)
            {
                flag = false;
            }
            return flag;
        }
        static bool PassValidSymbols(char[] password)
        {
            bool flag = true;
            bool flagValidSymbols = true;
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 0 && password[i] <= 47)
                    || (password[i] >= 58 && password[i] <= 64)
                    || (password[i] >= 91 && password[i] <= 96)
                    || (password[i] >= 123))
                {
                    flagValidSymbols = false;
                }
            }
            if (!flagValidSymbols)
            {
                flag = false;
            }
            return flag;
        }
        static void Main(string[] args)
        {
            char[] password = Console.ReadLine().ToCharArray();
            if (!CheckPassWordLengh(password))
                Console.WriteLine("Password must be between 6 and 10 characters");
            if (!PassValidSymbols(password))
                Console.WriteLine("Password must consist only of letters and digits");
            if (!PasswordCountNumbers(password))
                Console.WriteLine("Password must have at least 2 digits");
            if (CheckPassWordLengh(password)
                && PasswordCountNumbers(password)
                && PassValidSymbols(password))
                Console.WriteLine("Password is valid");

        }
    }
}
