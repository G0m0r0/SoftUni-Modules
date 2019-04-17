using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int squarTables = int.Parse(Console.ReadLine());
            double lenghTables = double.Parse(Console.ReadLine());
            double widthTables = double.Parse(Console.ReadLine());
            //покривки и карета
            //pokrivki pravoagalni 30sm ot masata =7dolara
            //kareta kvadrat polovinata ot daljinata na masata =9dolara
            //dolar 1.85
            double resultPokrivki = 0,resultKareta;
            resultPokrivki = squarTables * (lenghTables + 2 * 0.30) * (widthTables + 2 * 0.30);
            resultKareta=squarTables*((lenghTables/2)*(lenghTables/2));
            double usdprice = resultKareta * 9 + resultPokrivki * 7;
            // Console.WriteLine(Math.Round(( usdprice),2)+" USD");
            Console.WriteLine($"{usdprice:F2} USD");
            Console.WriteLine($"{(usdprice*1.85):F2} BGN");
            Console.ReadLine();
        }
    }
}
