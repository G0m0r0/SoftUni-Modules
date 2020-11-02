using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookie_factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfBarchs = int.Parse(Console.ReadLine());
            //string nameOFproduct = Console.ReadLine();
            string products = string.Empty;
            int br = 0;
            for(int i=1;i<=numOfBarchs;i++)
            {
                while((br!=3)||(products!="Bake!"))
                {
                    products = Console.ReadLine();
                    if (products == "flour") br++;
                    if (products == "eggs") br++;
                    if (products == "sugar") br++;
                    if (products == "Bake!" && br != 3) Console.WriteLine("The batter should contain flour, eggs and sugar!");
                }
                Console.WriteLine("Baking batch number "+i+"...");
            }
        }
    }
}
