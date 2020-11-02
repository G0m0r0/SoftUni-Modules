using System;

namespace data_types_and_variables_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            int numFour = int.Parse(Console.ReadLine());
           int result=((numOne+numTwo)/numThree)*numFour;
            Console.WriteLine(result);
        }
    }
}
