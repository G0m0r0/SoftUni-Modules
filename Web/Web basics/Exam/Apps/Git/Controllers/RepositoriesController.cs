using Git.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace Git.Controllers
{
    public class RepositoriesController:Controller
    {
        private readonly IRepositoryService repositoryService;

        public RepositoriesController(IRepositoryService repositoryService)
        {
            this.repositoryService = repositoryService;
        }
        public HttpResponse All()
        {
            var repos = this.repositoryService.GetAll();
            return this.View(repos);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name,string repositoryType)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            bool IsPublic = true;
            if (repositoryType == "Public")
            {
                IsPublic = true;
            }else
            {
                IsPublic = false;
            }

            if (string.IsNullOrEmpty(name) || name.Length < 3 || name.Length > 10)
            {
                return this.Error("Repo should be between 3 and 10 character long.");
            }

            var userId = this.GetUserId();
           repositoryService.Create(name, IsPublic, userId);

            return this.Redirect("/Repositories/All");
        }
    }
}
