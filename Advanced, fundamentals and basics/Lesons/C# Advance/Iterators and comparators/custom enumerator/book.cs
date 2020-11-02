using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace custom_enumerator
{
    public class Book:IComparable<Book>
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }
        public decimal Price { get; set; }

        public Book(string title,int year,List<string> authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public int CompareTo(Book other)
        {
            if (this.Year > other.Year)
            {
                return 1;
            }
            else if (this.Year < other.Year)
            {
                return -1;
            }
            else
            {
                return this.Title.CompareTo(other.Title);
            }
        }
    }
}
