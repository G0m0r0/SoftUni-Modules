namespace SharedTrip.Services
{
    using SharedTrip.Data;
    using SharedTrip.ViewModels.Trips;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    public class TripService : ITripService
    {
        private readonly ApplicationDbContext db;

        public TripService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(AddTripsViewModel trip)
        {
            var newTrip = new Trip
            {
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = DateTime.ParseExact(trip.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                Description = trip.Description,
                Seats = trip.Seats,
                ImagePath = trip.ImagePath,
            };

            this.db.Trips.Add(newTrip);
            db.SaveChanges();
        }

        public IEnumerable<HomePageTripViewModel> GetAll()
        {
            var trips = this.db.Trips.Select(x => new HomePageTripViewModel
            {
                StartPoint = x.StartPoint,
                EndPoint = x.EndPoint,
                Departuretime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                Seats = x.Seats
            }).ToList();

            return trips;
        }
    }
}
