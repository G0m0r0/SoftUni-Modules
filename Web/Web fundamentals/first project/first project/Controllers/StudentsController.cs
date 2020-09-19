using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyProject.Controllers
{
    public class StudentsController: Controller
    {
       public IActionResult List()
        {
            return View();
        }
    }
}