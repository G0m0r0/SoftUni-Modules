using System;

namespace Custom_exception
{
    class Program
    {
        static void Main(string[] args)
        {
            var userInput = Console.ReadLine();
            try
            {

            }
            catch (Exception)
            {

                throw new InvalidUserInputException() 
                { 
                    UserInput=userInput
                };
            }
        }
    }
    class InvalidUserInputException : Exception
    {
        public string UserInput { get; set; }
        public InvalidUserInputException()
        {

        }

        public InvalidUserInputException(string message)
            :base(message)
        {

        }

        public InvalidUserInputException(Exception innerException)
            :base("Thats inner exception",innerException)
        {

        }
    }
}
