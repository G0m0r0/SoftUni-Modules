using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Old_Books
{
    class Program
    {
        static void Main(string[] args)
        {
            string myBook = Console.ReadLine();
            int br = int.Parse(Console.ReadLine());
            string otherBooks = " ";
            int i = 0;
            while(i<br)
            {
                otherBooks = Console.ReadLine();
                if (otherBooks == myBook)
                {
                    Console.WriteLine($"You checked {i} books and found it.");
                   // i++;
                    break;
                }
                i++;
            }   
            if(i==br)
            {
                Console.WriteLine("The book you search is not here!");
                Console.WriteLine($"You checked {i} books.");
            }
        }
    }
}
