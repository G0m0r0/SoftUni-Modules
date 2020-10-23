namespace BattleCards2
{
    using BattleCards2.Data;
    using BattleCards2.Services;
    using Microsoft.EntityFrameworkCore;
    using SharedTrip.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;
    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardService, CardService>();
        }
    }
}
