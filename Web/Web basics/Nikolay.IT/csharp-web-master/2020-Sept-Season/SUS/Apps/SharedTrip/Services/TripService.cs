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

        public void AddUserToTrip(string userId, string tripId)
        {
            var userInTrip = this.db.UserTrips.Any(x => x.UserId == userId && x.TripId == tripId);

            if (userInTrip)
            {
                return;
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.db.UserTrips.Add(userTrip);
            db.SaveChanges();
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
                Id = x.Id,
                DepartureTime = x.DepartureTime,
                UsedSeats = x.UserTrips.Count(),
                Seats = x.Seats,
            }).ToList();

            return trips;
        }

        public TripDetailsViewModel GetDetails(string id)
        {
            return this.db.Trips.Where(x => x.Id == id)
                .Select(x=>new TripDetailsViewModel
                {
                    DepartureTime = x.DepartureTime,
                    Description = x.Description,
                    EndPoint = x.EndPoint,
                    Id = x.Id,
                    ImagePath = x.ImagePath,
                    Seats = x.Seats,
                    StartPoint = x.StartPoint,
                    UsedSeats = x.UserTrips.Count(),
                })
                .FirstOrDefault();
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.db.Trips.Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;

            return availableSeats > 0;
        }
    }
}
