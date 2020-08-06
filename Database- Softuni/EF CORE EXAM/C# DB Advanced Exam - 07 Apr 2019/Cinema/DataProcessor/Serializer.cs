namespace Cinema.DataProcessor
{
    using System;
    using System.Linq;
    using Cinema.DataProcessor.ExportDto;
    using Cinema.XmlHelper;
    using Data;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportTopMovies(CinemaContext context, int rating)
        {
            var topMovies = context
                .Movies
                .Where(m => m.Rating >= rating && m.Projections.Any(p => p.Tickets.Count > 0))
                 .OrderByDescending(r => r.Rating)
                .ThenByDescending
                (p => p.Projections
                .Sum(t => t.Tickets
                .Sum(pt => pt.Price)))
                .Select(m => new
                {
                    MovieName = m.Title,
                    Rating = m.Rating.ToString("F2"),
                    TotalIncomes = m.Projections.Sum(p => p.Tickets.Sum(t => t.Price)).ToString("F2"),
                    Customers = m
                    .Projections
                    .SelectMany(t => t.Tickets).Select(c => new
                    {
                        FirstName = c.Customer.FirstName,
                        LastName = c.Customer.LastName,
                        Balance = c.Customer.Balance.ToString("F2")
                    })

                    .OrderByDescending(c => c.Balance)
                    .ThenBy(c => c.FirstName)
                    .ThenBy(c => c.LastName)
                    .ToArray()

                })
                .Take(10)
                .ToArray();


            string json = JsonConvert.SerializeObject(topMovies, Formatting.Indented);
            return json;
        }

        public static string ExportTopCustomers(CinemaContext context, int age)
        {
            var customers = context.Customers
                .Where(x=>x.Age>=age)
                .OrderByDescending(c => c.Tickets.Sum(p => p.Price))
                 .Take(10)
                .Select(x => new ExportTopCustomersDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SpentMoney=x.Tickets.Sum(y=>y.Price).ToString("f2"),
                    SpentTime = TimeSpan.FromSeconds(x.Tickets.Sum(t => t.Projection.Movie.Duration.TotalSeconds)).ToString(@"hh\:mm\:ss")
                }).ToArray();

            var result = XmlConverter.Serialize(customers, "Customers");

            return result;
        }
    }
}