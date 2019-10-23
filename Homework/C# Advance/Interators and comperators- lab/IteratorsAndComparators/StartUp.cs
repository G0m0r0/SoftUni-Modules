using System;

namespace IteratorsAndComparators
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Animal Farm", 2003, "George Orwell");
            Book book2 = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
            Book book3 = new Book("The Documents in the Case", 1930);

            //book1.Title = "GOsho";
            Library lib1 = new Library();
            Library lib2 = new Library(book1, book2, book3);

            //foreach (var book in lib2)
            //{
            //    Console.WriteLine($"{book.Title} - {book.Year} - {string.Join(", ", book.Authors)}");
            //}
            //
            //foreach (var book in lib1)
            //{
            //    Console.WriteLine($"{book.Title} - {book.Year} - {string.Join(", ", book.Authors)}"); //empty
            //}

            foreach (var book in lib2)
            {
                Console.WriteLine(book);
            }
        }

    }
}
