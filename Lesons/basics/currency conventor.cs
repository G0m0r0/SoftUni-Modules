using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghokr
{
    class Program
    {
        static void Main(string[] args)
        {
           double currency = double.Parse(Console.ReadLine());
            string a = Console.ReadLine();
            string b = Console.ReadLine();
           

            switch (a)
            {
                case "USD":
                    {
                        switch (b)
                        {
                            case "EUR":
                                {                               
                                    Console.WriteLine(Math.Round(((currency*1.79549)/1.95583),2));
                                }
                                break;
                            case "BGN":
                                {
                                    Console.WriteLine(Math.Round(( currency * 1.79549),2));
                                }
                                break;
                            case "GBP":
                                {
                                    Console.WriteLine(Math.Round(((currency*1.79549)/2.53405),2));
                                }
                                break;
                        }
                        }                   
                    break;
                case "BGN":
                    {
                        switch (b)
                        {
                            case "EUR":
                                {
                                    Console.WriteLine(Math.Round(( currency/1.95583),2));
                                }
                                break;
                            case "USD":
                                {
                                    Console.WriteLine(Math.Round(( currency /1.79549),2));
                                }
                                break;
                            case "GBP":
                                {
                                    Console.WriteLine(Math.Round(( currency / 2.53405),2));
                                }
                                break;
                        }
                    }                    
                    break;
                case "EUR":
                    {
                        switch (b)
                        {
                            case "USD":
                                {
                                    Console.WriteLine(Math.Round(((currency * 1.95583) / 1.79549),2));
                                }
                                break;
                            case "BGN":
                                {
                                    Console.WriteLine(Math.Round(( currency * 1.95583),2));
                                }
                                break;
                            case "GBP":
                                {
                                    Console.WriteLine(Math.Round(((currency * 1.95583)/2.53405),2));
                                }
                                break;
                        }
                    }                   
                    break;
                case "GBP":
                    {
                        switch (b)
                        {
                            case "USD":
                                {
                                    Console.WriteLine(Math.Round(((currency * 2.53405) / 1.79549),2));
                                }
                                break;
                            case "BGN":
                                {
                                    Console.WriteLine(Math.Round(( currency * 2.53405),2));
                                }
                                break;
                            case "EUR":
                                {
                                    Console.WriteLine(Math.Round(((currency * 2.53405) / 1.95583),2));
                                }
                                break;
                        }
                    }
                    break;
                    /*default:
                        Console.WriteLine("There is no such value");
                        break;*/
                    
            }
            Console.Read();
        }
    }
}
