using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sixth
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstname = "Petrov";
            string lastname = "Petrov";
            int age = 30;
            Console.WriteLine("I am " + firstname + " " + lastname + ", " + age + " years old");
            Console.WriteLine($"I am {firstname} {lastname }, {age} years old");
            Console.WriteLine("I am {0} {1}, {2} years old",firstname,lastname,age);
            Console.Read();
        }
    }
}
