using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace custom_enumerator
{
    public class LibraryICom : IEnumerable<Book>, IComparable<LibraryICom>
    {
        public List<Book> Books { get; private set; }
        public LibraryICom()
        {
            this.Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            // return new LibraryEnumerator(this.Books);
            for (int currentIndex = 0; currentIndex < Books.Count; currentIndex++)
            {
                yield return this.Books[currentIndex];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //compare two libraries
        public int CompareTo(LibraryICom other)
        {
            if(this.Books.Count>other.Books.Count)
            {
                return 1;
            }
            else if(this.Books.Count<other.Books.Count)
            {
                return -1;
            }
            else
            {
                //if equal
                return 0;
            }
        }
        //compare them with > <
        public static bool operator >(LibraryICom lib1,LibraryICom lib2)
        {
           return lib1.CompareTo(lib2)>0;
        }
        public static bool operator <(LibraryICom lib1, LibraryICom lib2)
        {
            return lib1.CompareTo(lib2) < 0;
        }
        public static bool operator ==(LibraryICom lib1, LibraryICom lib2)
        {
            return lib1.CompareTo(lib2) == 0;
        }
        public static bool operator !=(LibraryICom lib1, LibraryICom lib2)
        {
            return lib1.CompareTo(lib2) != 0;
        }
    }
    //  public class LibraryEnumerator : IEnumerator<Book>
    // {
    //
    //     private readonly List<Book> books;
    //
    //     private int currentIndex = -1;
    //     public LibraryEnumerator(List<Book> books)
    //     {
    //         this.books = books;
    //     }
    //     public Book Current =>this.books[currentIndex] ;
    //
    //     object IEnumerator.Current => this.Current;
    //
    //    public void Dispose()
    //    {
    //    }
    //
    //     public bool MoveNext()
    //     {
    //         this.currentIndex++;
    //         if(this.currentIndex>= this.books.Count)
    //         {
    //             return false;
    //         }
    //         return true;
    //     }
    //
    //     public void Reset()
    //     {
    //         currentIndex = -1;
    //     }
    // }
}
