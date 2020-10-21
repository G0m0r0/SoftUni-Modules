using Microsoft.EntityFrameworkCore;
using SharedTrip.Data;
using SharedTrip.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SharedTrip
{
    public class Startup:IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate(); //every time when we start it will migrate
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<ITripService, TripService>();
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<IUserTripService, UserTripService>();
        }
    }
}
