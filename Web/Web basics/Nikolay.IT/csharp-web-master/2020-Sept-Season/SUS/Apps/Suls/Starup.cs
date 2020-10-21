using Microsoft.EntityFrameworkCore;
using Suls.Data;
using Suls.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace Suls
{
    public class Starup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate(); //every time when we start it will migrate
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}
