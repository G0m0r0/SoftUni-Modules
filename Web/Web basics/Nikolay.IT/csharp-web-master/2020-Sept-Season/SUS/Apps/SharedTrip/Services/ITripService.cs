namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;
    public interface ITripService
    {
        void Create(AddTripsViewModel trip);
        IEnumerable<HomePageTripViewModel> GetAll();
        TripDetailsViewModel GetDetails(string id);
        bool HasAvailableSeats(string tripId);
        void AddUserToTrip(string userId, string tripId);
    }
}
