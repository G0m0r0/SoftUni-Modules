using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forth
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = 10; //int both absolute & negative numbers
            int secondNumber = 5; //uint unsigned int only absolute numbers
            //from double we can substract integer numbers
            int sum = firstNumber + secondNumber;
            Console.WriteLine(sum);
            int mul = firstNumber * secondNumber;
            Console.WriteLine(mul);
            double sub = firstNumber / secondNumber;
            Console.WriteLine(sub); //we lose numbers if the number are int one of them have to be double as well as the result
            //if we devide to 0 we take infinity if there is NaN its mean not a number
            Console.Read();
        }
    }
}
