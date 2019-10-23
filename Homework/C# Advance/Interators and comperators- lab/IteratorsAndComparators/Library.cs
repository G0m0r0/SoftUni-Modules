using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>,IComparable<Library>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            //this.books= books.OrderBy(x => x.Year).ThenBy(x => x.Title).ToList();
            this.books = new List<Book>(books);
        }

        class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int currentIndex;
            public Book Current => this.books[currentIndex];

            public LibraryIterator(IEnumerable<Book> books)
            {
                this.Reset();
                this.books = new List<Book>(books);
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.currentIndex++;
                if(this.currentIndex>=this.books.Count)
                {
                    return false;
                }
                return true;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int CompareTo(Library other)
        {
            if (this.books.Count > other.books.Count)
            {
                return 1;
            }
            else if (this.books.Count < other.books.Count)
            {
                return -1;
            }
            else
            {
                //if equal
                return 0;
            }
        }
    }
}
