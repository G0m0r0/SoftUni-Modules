namespace Cinema.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Cinema.Data.Models;
    using Cinema.Data.Models.Enums;
    using Cinema.DataProcessor.ImportDto;
    using Cinema.XmlHelper;
    using Data;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var moviesDtos = JsonConvert.DeserializeObject<ImportMoviesDTO[]>(jsonString);
            var moviesList = new List<Movie>();
            var sb = new StringBuilder();

            foreach (var movieDto in moviesDtos)
            {
                if (!IsValid(movieDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var flag = context.Movies.FirstOrDefault(x => x.Title == movieDto.Title);

                if (flag!=null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                TimeSpan duration;
                bool isDurationValid = TimeSpan.TryParseExact
                    (movieDto.Duration,"c",CultureInfo.InvariantCulture, TimeSpanStyles.None, out duration);

                Genre genre;
                bool IsGenreValid = Enum.TryParse(movieDto.Genre, out genre);

                if (!isDurationValid||!IsGenreValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var movie = new Movie
                {
                    Title = movieDto.Title,
                    Genre =genre,
                    Duration = duration,
                    Rating = movieDto.Rating,
                    Director = movieDto.Director,
                };

                moviesList.Add(movie);
                sb.AppendLine(string.Format(SuccessfulImportMovie, movie.Title, movie.Genre, movie.Rating.ToString("f2")));
            }

            context.Movies.AddRange(moviesList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            var hallDtos = JsonConvert.DeserializeObject<ImportHallSeatDTO[]>(jsonString);
            var hallList = new List<Hall>();
            var sb = new StringBuilder();

            foreach (var hallDto in hallDtos)
            {
                if (!IsValid(hallDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var hall = new Hall
                {
                    Name = hallDto.Name,
                    Is3D = hallDto.Is3D,
                    Is4Dx = hallDto.Is4Dx,
                };

                for (int i = 0; i < hallDto.Seats; i++)
                {
                    var seat = new Seat
                    {
                        Hall = hall,
                        HallId=hall.Id
                    };
                    hall.Seats.Add(seat);
                }

                if (hall.Seats.Count == 0)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                hallList.Add(hall);

                var typeProjection = string.Empty;

                if (hall.Is4Dx && hall.Is3D)
                {
                    typeProjection = "4Dx/3D";
                }
                else if (hall.Is3D)
                {
                    typeProjection = "3D";
                }
                else if(hall.Is4Dx)
                {
                    typeProjection = "4Dx";
                }
                else
                {
                    typeProjection = "Normal";
                }

                sb.AppendLine(string.Format(SuccessfulImportHallSeat, hall.Name, typeProjection, hall.Seats.Count()));
            }

            context.Halls.AddRange(hallList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            var projectionsDtos = XmlConverter.Deserializer<ImportProjectionsDTO>(xmlString, "Projections");
            var projectionsList = new List<Projection>();
            var sb = new StringBuilder();

            foreach (var pDto in projectionsDtos)
            {
                if (!IsValid(pDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var validHall = context.Halls.FirstOrDefault(x => x.Id == pDto.HallId);
                var validMovie = context.Movies.FirstOrDefault(x => x.Id == pDto.MovieId);

                if (validHall==null || validMovie==null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dateTime;
                var isDateTimeValid = DateTime.TryParseExact
                    (pDto.DateTime, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime);

                if(!isDateTimeValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var projection = new Projection
                {
                    MovieId = pDto.MovieId,
                    Hall=validHall,
                    Movie=validMovie,
                    DateTime=dateTime,
                };

                projectionsList.Add(projection);
                sb.AppendLine(
                    string.Format(SuccessfulImportProjection, validMovie.Title, dateTime.ToString("MM/dd/yyyy")));
            }

            context.Projections.AddRange(projectionsList);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            var customerTicketsDtos = XmlConverter.Deserializer<ImportCustomersDTO>(xmlString, "Customers");
            var customerList = new List<Customer>();
            var sb = new StringBuilder();

            foreach (var ctDto in customerTicketsDtos)
            {
                if (!IsValid(ctDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = new Customer()
                {
                    FirstName = ctDto.FirstName,
                    LastName = ctDto.LastName,
                    Age = ctDto.Age,
                    Balance = ctDto.Balance,
                };

                foreach (var ticketDto in ctDto.Tickets)
                {
                    var ticket = new Ticket
                    {
                        Price = ticketDto.Price,
                        ProjectionId = ticketDto.ProjectionId,
                    };

                    customer.Tickets.Add(ticket);
                }

                customerList.Add(customer);
                sb.AppendLine(string.Format(SuccessfulImportCustomerTicket,customer.FirstName,customer.LastName,customer.Tickets.Count()));               
            }

            context.Customers.AddRange(customerList);
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