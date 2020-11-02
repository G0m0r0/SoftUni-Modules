using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @switch
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "gosho";
            switch (name)
            {
                case"ican":
                case "pesho":
                    Console.WriteLine("This is pesho");
                    break;
                case "gosho": Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("There is not such a person");
                    break;
            }
        }
    }
}
