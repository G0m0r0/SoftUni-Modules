using System;

namespace Workshop__Exceptions_and_Error_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int a = int.Parse("afd");
            }
            catch (FormatException)
            {
                Console.WriteLine("Format error");
                //throw;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Invalid size");
            }


            var validator = new EgnValidator();
            validator.IsValidEgn(null);

            try
            {
                GenerateEng generateEgn = new GenerateEng();
                generateEgn.GenerateEgn("19/10/1999", true, "Burgas");
            }
            catch (Exception ex)
                when (ex is ArgumentException || ex is ArgumentNullException)
            {
                Console.WriteLine("Invalid EGN");
                throw new Exception("Expand exception", ex);
            }
        }
    }
    public class EgnValidator
    {
        public bool IsValidEgn(string egn)
        {
            if (egn == null)
            {
                throw new ArgumentException(nameof(egn), "egn should not be null");
            }
            return true;
        }
    }

    public class GenerateEng
    {
        /// <summary>
        /// Generates valid EGN number.
        /// </summary>
        /// <param name="dateOfBirth"></param>
        /// <param name="isMale"></param>
        /// <param name="place"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">if year is less than 1900</exception>
        /// <exception cref="ArgumentNullException"></exception>
        public string GenerateEgn(DateTime dateOfBirth, bool isMale, string place)
        {
            if (dateOfBirth.Year < 1900)
            {
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth), "cannot generate egn before 1900");
            }
            if (place == null)
            {
                throw new ArgumentNullException(nameof(place));
            }
            return string.Empty;
        }
    }
}
