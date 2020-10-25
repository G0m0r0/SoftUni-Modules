using Git.Services;
using Git.ViewModels.Commits;
using SUS.HTTP;
using SUS.MvcFramework;


namespace Git.Controllers
{
    public class CommitsController:Controller
    {
        private readonly IRepositoryService repositoryService;
        private readonly ICommitsService commitsService;

        public CommitsController(IRepositoryService repositoryService, ICommitsService commitsService)
        {
            this.repositoryService = repositoryService;
            this.commitsService = commitsService;
        }
        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var commits = this.commitsService.GetAll();

            return this.View(commits);
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateCommitViewModel
            {
                Id = id,
                Name = repositoryService.GetNameById(id),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string description, string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(description) || description.Length < 5)
            {
                return this.Error("Description should be longer than 5 character.");
            }

            var userId = this.GetUserId();
            this.commitsService.Create(description, userId, id);

            return this.Redirect("/Repositories/All");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.commitsService.Delete(id);
            return this.Redirect("/Commits/All");
        }
    }
}
