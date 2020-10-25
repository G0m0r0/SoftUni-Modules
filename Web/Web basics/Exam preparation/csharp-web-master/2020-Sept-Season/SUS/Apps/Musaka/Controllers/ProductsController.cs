namespace Musaka.Controllers
{
    using Musaka.ViewModels.Products;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Collections.Generic;

    public class ProductsController:Controller
    {
        public HttpResponse All()
        {
            return this.View(new List<AllViewModel>());
        }

        public HttpResponse Create()
        {
            return this.View(new List<ProductsController>());                
        }

        [HttpPost]
        public HttpResponse Create()
        {

        }
    }
}
