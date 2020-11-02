using ClassLibrary1;
using System;

namespace Encapsulation
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var PdfReader = new PdfReader();
            var person = new Person("X", 1, 100,new FileMinimalSalaryProvider());
            person.IncreaseSalary(25);

            
        }
    }
}
