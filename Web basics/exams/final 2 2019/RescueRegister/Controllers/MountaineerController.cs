using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new RescueRegisterDbContext())
            {
                var allMountaineers = db.Mountaineers.ToList();
                return View(allMountaineers);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name,string gender,string lastSeenDate,int age)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(gender)||string.IsNullOrEmpty(lastSeenDate))
            {
                return RedirectToAction("Index");
            }


            Mountaineer mountaineer = new Mountaineer
            {
                Name = name,
                Gender=gender,
                LastSeenDate=lastSeenDate,
                Age=age
            };

            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Add(mountaineer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var mountineerToEdit = db.Mountaineers.FirstOrDefault(t => t.Id == id);
                if (mountineerToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(mountineerToEdit);
            }
        }
       
        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var mountainerToEdit = db.Mountaineers.FirstOrDefault(t => t.Id == mountaineer.Id);
                mountainerToEdit.Name = mountaineer.Name;
                mountainerToEdit.Gender = mountaineer.Gender;
                mountainerToEdit.Age = mountaineer.Age;
                mountainerToEdit.LastSeenDate = mountaineer.LastSeenDate;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var mountineerToDelete = db.Mountaineers.Find(id);
                return View(mountineerToDelete);
            }
        }
       
        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Remove(mountaineer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}