using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using first_project.Models;

namespace first_project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Debug.WriteLine("I am here");
            //ViewData["MaxNumber"] = 55;
            return View();
        }
        //mine
        public IActionResult Numbers(int id)
        {
            ViewData["MaxNumber"] = id;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
