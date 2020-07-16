namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            //DbInitializer.ResetDatabase(db);

            //01
            //var command = Console.ReadLine();
            //Console.WriteLine(GetBooksByAgeRestriction(db,command));

            //02
            //Console.WriteLine(GetGoldenBooks(db));

            //03
            //Console.WriteLine(GetBooksByPrice(db));

            //04
            //var year = int.Parse(Console.ReadLine());
            //Console.WriteLine(GetBooksNotReleasedIn(db,year));

            //05
            //var category = Console.ReadLine();
            //Console.WriteLine(GetBooksByCategory(db,category));

            //06
            //var inputDate = Console.ReadLine();
            //Console.WriteLine(GetBooksReleasedBefore(db, inputDate));

            //07
            //var input = Console.ReadLine();
            //Console.WriteLine(GetAuthorNamesEndingIn(db,input));

            //08
            //ar input = Console.ReadLine();
            //Console.WriteLine(GetBookTitlesContaining(db,input));

            //09
            //var input = Console.ReadLine();
            //Console.WriteLine(GetBooksByAuthor(db,input));

            //10
            //var length = int.Parse(Console.ReadLine());
            //Console.WriteLine($"There are {CountBooks(db, length)} books with longer title than {length} symbols");

            //11
            //Console.WriteLine(CountCopiesByAuthor(db));

            //12
            //Console.WriteLine(GetTotalProfitByCategory(db));

            //13
            //Console.WriteLine(GetMostRecentBooks(db));

            //14
            //IncreasePrices(db);
            //db.SaveChanges();

            //15
            Console.WriteLine(RemoveBooks(db));
       
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var books = context.Books
                .Select(x => new
                {
                    x.Title,
                    x.AgeRestriction
                }).ToList()
                .Where(x => x.AgeRestriction.ToString().ToLower() == command.ToLower())
                .OrderBy(x => x.Title);

            return string.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            List<string> books = context.Books
                .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Price > 40)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            var bookTitles = new List<string>();

            foreach (string cat in categories)
            {
                List<string> currentBooks = context.Books
                    .Where(b => b.BookCategories.Any(bc => bc.Category.Name.ToLower() == cat))
                    .Select(b => b.Title)
                    .ToList();

                bookTitles.AddRange(currentBooks);
            }

            return string.Join(Environment.NewLine, bookTitles.OrderBy(x => x));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            string format = "dd-MM-yyyy";
            DateTime dateParsed = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < dateParsed)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price,
                    x.ReleaseDate,
                }).OrderByDescending(x => x.ReleaseDate)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var books = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .Select(x => new
                {
                    fullName = x.FirstName + ' ' + x.LastName,
                })
                .ToList();

            return string.Join(Environment.NewLine, books.Select(x => x.fullName));
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Select(x => new { x.Title })
                .ToList()
                .Where(x => x.Title.Contains(input, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(x => x.Title);

            return string.Join(Environment.NewLine, titles.Select(x => x.Title));
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Select(x => new { x.Title, x.Author.FirstName, x.Author.LastName, x.BookId })
                .ToList()
                .Where(x => x.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(x => new
                {
                    x.Title,
                    fullName = x.FirstName + ' ' + x.LastName,
                    x.BookId,
                }).OrderBy(x => x.BookId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.fullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var books = context.Books.Where(x => x.Title.Length > lengthCheck).ToList();

            return books.Count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authorBooksCount = context.Authors
                .Select(x => new
                {
                    FullName = x.FirstName + ' ' + x.LastName,
                    CountBooks = x.Books.Sum(x => x.Copies),
                }).OrderByDescending(a => a.CountBooks)
                .ToList();

            var sb = new StringBuilder();

            foreach (var item in authorBooksCount)
            {
                sb.AppendLine($"{item.FullName} - {item.CountBooks}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categoriesProfits = context.Categories.Select(x => new
            {
                x.Name,
                totalprofit = x.CategoryBooks.Sum(x => (x.Book.Copies * x.Book.Price)),
            }).OrderByDescending(x => x.totalprofit)
            .ThenBy(x => x.Name)
            .ToList();

            var sb = new StringBuilder();

            foreach (var category in categoriesProfits)
            {
                sb.AppendLine($"{category.Name} ${category.totalprofit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var bookByCategory = context.Categories
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    categoryName=x.Name,
                    topThreeBooks = x.CategoryBooks
                            .Select(x => new
                            {
                                x.Book.Title,
                                x.Book.ReleaseDate
                            }).OrderByDescending(x => x.ReleaseDate).Take(3).ToList(),
                }).ToList();


            foreach (var category in bookByCategory)
            {
                sb.AppendLine($"--{category.categoryName}");
                foreach (var topBook in category.topThreeBooks)
                {
                    sb.AppendLine($"{topBook.Title} ({topBook.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(r => r.ReleaseDate.Value.Year < 2010);

            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            //var count = 0;
            //foreach (var book in context.Books)
            //{
            //    if(book.Copies<4200)
            //    {
            //        context.Remove(book);
            //        count++;
            //    }
            //}
            //context.SaveChanges();


            //or
            var ToRemove = context.Books.Where(x => x.Copies < 4200);
            var count = ToRemove.Count();
            context.Books.RemoveRange(ToRemove);
            context.SaveChanges();

            return count;
        }
    }
}
