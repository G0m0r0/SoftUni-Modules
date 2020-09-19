using BandRegister.Data;
using BandRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BandRegister.Controllers
{
    public class BandController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new BandDbContext())
            {
                var allBands = db.Bands.ToList();
                return View(allBands);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, string members, double honorarium, string genre)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(members) || string.IsNullOrEmpty(genre))
            {
                return RedirectToAction("Index");
            }

            Band band = new Band
            {
                Name = name,
                Members = members,
                Honorarium = honorarium,
                Genre = genre
            };

            using (var db = new BandDbContext())
            {
                db.Bands.Add(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new BandDbContext())
            {
                var BandToEdit = db.Bands.FirstOrDefault(x => x.Id == id);
                if(BandToEdit==null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(BandToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Band band)
        {
            using (var db = new BandDbContext())
            {
                var bandToEdit = db.Bands.FirstOrDefault(x => x.Id ==band.Id);
                bandToEdit.Name = band.Name;
                bandToEdit.Members = band.Members;
                bandToEdit.Honorarium = band.Honorarium;
                bandToEdit.Genre = band.Genre;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BandDbContext())
            {
                var bandToDelete = db.Bands.Find(id);
                return View(bandToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Band band)
        {
            using (var db = new BandDbContext())
            {
                db.Bands.Remove(band);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}