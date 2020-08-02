namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var xmlSerializer = new XmlSerializer(typeof(BookDTO[]),new XmlRootAttribute("Books"));

            using (var stringreader = new StringReader(xmlString))
            {
                BookDTO[] bookDtos = (BookDTO[])xmlSerializer.Deserialize(stringreader);

                var validBooks = new List<Book>();

                foreach (var bookDto in bookDtos)
                {
                    if(!IsValid(bookDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime publishedOn;
                    bool isDateValid = DateTime.TryParseExact(bookDto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture,DateTimeStyles.None,out publishedOn);

                    if(!isDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var book = new Book()
                    {
                        Name = bookDto.Name,
                        Genre = (Genre)bookDto.Genre,
                        Price = bookDto.Price,
                        Pages = bookDto.Pages,
                        PublishedOn = publishedOn,
                    };

                    validBooks.Add(book);
                    sb.AppendLine(string.Format(SuccessfullyImportedBook, book.Name, book.Price));
                }


                context.Books.AddRange(validBooks);
                context.SaveChanges();

                return sb.ToString().TrimEnd();
            }
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var authorsDTOs = JsonConvert.DeserializeObject<AuthorDTO[]>(jsonString);

            var authors = new List<Author>();

            foreach (var authorDTO in authorsDTOs)
            {
                if(!IsValid(authorDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if(authors.Any(a=>a.Email==authorDTO.Email))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author()
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Email = authorDTO.Email,
                    Phone = authorDTO.Phone,
                };

                foreach (var bookDTO in authorDTO.Books)
                {
                   if(!bookDTO.BookId.HasValue)
                   {
                       continue;
                   }

                    var book = context.Books.FirstOrDefault(b => b.Id == bookDTO.BookId);

                    if(book==null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = book,
                    });

                    if(author.AuthorsBooks.Count==0)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    authors.Add(author);
                    sb.AppendLine(string.Format(SuccessfullyImportedAuthor,(author.FirstName+' '+author.LastName),author.AuthorsBooks.Count));
                } 
            }

            context.Authors.AddRange(authors);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}