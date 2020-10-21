namespace SharedTrip.Services
{
    using SharedTrip.ViewModels.Trips;
    using System.Collections.Generic;
    public interface ITripService
    {
        void Create(AddTripsViewModel trip);
        IEnumerable<HomePageTripViewModel> GetAll();
    }
}
