using System;
using System.Collections.Generic;
using System.Linq;

namespace custom_enumerator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var library1 = new LibraryICom();
            library1.AddBook(new Book("1984",1980, new List<string> { "Jorgh" }));
            library1.AddBook(new Book("The god father", 1981, new List<string> { "Pesho" }));
            library1.AddBook(new Book("The lord of the rings", 1985, new List<string> { "J.K tolkin" }));
            
            //we can use IEnumerable with linq 
            //IEnumerable interate two custom classes
            foreach (var book in library1.Where(x=>x.Year>1960))
            {
                Console.WriteLine(
                    $"{string.Join(" ",book.Authors)} - {book.Title} ({book.Year})");
            }

            //IComparable compare two custom classes
            var library2 = new LibraryICom();
            library2.AddBook(new Book("string", 1992, new List<string> { "param" }));

            if(library1.CompareTo(library2)==0)
            {
                Console.WriteLine("equal");
            }
            else if(library1.CompareTo(library2)==-1)
            {
                Console.WriteLine("Library one is bigger");
            }
            else
            {
                Console.WriteLine("Library two is bigger");
            }

            
        }
    }
}
