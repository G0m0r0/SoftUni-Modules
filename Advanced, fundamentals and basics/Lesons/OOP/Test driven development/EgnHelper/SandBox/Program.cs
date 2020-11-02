using EgnHelper;
using System;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            ValidateFromUser(new EgnValidator());
        }

        public static void ValidateFromUser(IEgnValidator validator)
        {
            var egn = Console.ReadLine();
            //var validator = new EgnValidator();
            Console.WriteLine("Valid: "+validator.IsValid(egn));
        }
    }
}
