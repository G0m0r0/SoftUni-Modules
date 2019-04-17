using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade_Comissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double salles =double.Parse( Console.ReadLine());
            if(city=="Sofia")
            {
                if (salles >= 0 && salles <= 500) Console.WriteLine("{0:f2}", (salles * 0.05));
                if (salles >500  && salles <= 1000) Console.WriteLine("{0:f2}", (salles * 0.07));
                if (salles > 1000 && salles <= 10000) Console.WriteLine("{0:f2}", (salles * 0.08));
                if (salles > 10000 ) Console.WriteLine("{0:f2}", (salles * 0.12));
                else Console.WriteLine("error");
            }
            else if (city == "Varna")
            {
                if (salles >= 0 && salles <= 500) Console.WriteLine("{0:f2}", (salles * 0.045));
                if (salles > 500 && salles <= 1000) Console.WriteLine("{0:f2}", (salles * 0.075));
                if (salles > 1000 && salles <= 10000) Console.WriteLine("{0:f2}", (salles * 0.1));
                if (salles > 10000) Console.WriteLine("{0:f2}", (salles * 0.13));
                else Console.WriteLine("error");
            }
            else if (city == "Plovdiv")
            {
                if (salles >= 0 && salles <= 500) Console.WriteLine("{0:f2}", (salles * 0.055));
                if (salles > 500 && salles <= 1000) Console.WriteLine("{0:f2}", (salles * 0.08));
                if (salles > 1000 && salles <= 10000) Console.WriteLine("{0:f2}", (salles * 0.12));
                if (salles > 10000) Console.WriteLine("{0:f2}", (salles * 0.145));
                else Console.WriteLine("error");
            }
            else Console.WriteLine("error");
        }
    }
}
