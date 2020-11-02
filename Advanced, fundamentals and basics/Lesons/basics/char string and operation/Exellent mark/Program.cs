using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exellent_mark
{
    class Program
    {
        static void Main(string[] args)
        {
            string name1 = Console.ReadLine().ToLower();
            string name2 = Console.ReadLine().ToLower();
            Console.WriteLine(name1==name2);
            //we use ToLower() ToUpper() to compare string with small and big letters
        }
    }
}
