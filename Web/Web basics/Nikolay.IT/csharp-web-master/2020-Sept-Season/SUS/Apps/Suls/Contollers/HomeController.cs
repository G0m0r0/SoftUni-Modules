using Suls.Services;
using Suls.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Contollers
{
    public class HomeController : Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")] //localhost/
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var viewModel = problemsService.GetAll();
                //view model, custom name
                return this.View(viewModel, "IndexLoggedIn");
            }
            else
            {
                return this.View(); //Views/Home/Index.cshtml
            }
        }
    }
}
