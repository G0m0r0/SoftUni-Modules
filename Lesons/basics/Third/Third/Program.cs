using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            Console.WriteLine("Hello, " + name+ '!'); //when it is one symbol it si allowed to write ''
            //конкатенация на стрингове се ползва +
            string firstname = "maria";
            string secondname = "ivanova";
            Console.WriteLine(firstname + " " + secondname);
            Console.Read();
        }
    }
}
