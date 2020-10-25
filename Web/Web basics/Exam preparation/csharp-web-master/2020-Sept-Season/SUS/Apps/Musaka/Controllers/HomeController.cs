namespace Musaka.Controllers
{
    using Musaka.ViewModels.Products;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;

    public class HomeController:Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            return this.View(new List<AllViewModel>());
        }
    }
}
