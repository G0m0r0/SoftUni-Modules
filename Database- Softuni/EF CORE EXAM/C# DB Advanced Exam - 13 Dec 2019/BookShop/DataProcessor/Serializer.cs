namespace BookShop.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ExportDto;
    using Data;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportMostCraziestAuthors(BookShopContext context)
        {
            var authors = context.Authors
                //.ToArray() //for judge
                .Select(x => new
            {
                AuthorName = x.FirstName + ' ' + x.LastName,
                Books = x.AuthorsBooks
                    .OrderByDescending(y=>y.Book.Price)
                    .Select(y => new
                {
                    BookName = y.Book.Name,
                    BookPrice =y.Book.Price.ToString("F2")
                })
                .ToArray()
            }).ToArray()
            .OrderByDescending(x=>x.Books.Count())
            .ThenBy(x=>x.AuthorName)
            .ToArray();

            var authorsJson = JsonConvert.SerializeObject(authors,Formatting.Indented);

            return authorsJson;
        }

        public static string ExportOldestBooks(BookShopContext context, DateTime date)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(x => x.PublishedOn < date && x.Genre == Genre.Science)
                .ToArray()
                .OrderByDescending(x => x.Pages)
                .ThenByDescending(x => x.PublishedOn)
                .Take(10)
                .Select(x => new ExportBookDTO()
                {
                    Name = x.Name,
                    Date = x.PublishedOn.ToString("d",CultureInfo.InvariantCulture),
                    Pages=x.Pages,
                })
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportBookDTO[]), new XmlRootAttribute("Books"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using(var strWriter=new StringWriter(sb))
            {
                xmlSerializer.Serialize(strWriter, books, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}