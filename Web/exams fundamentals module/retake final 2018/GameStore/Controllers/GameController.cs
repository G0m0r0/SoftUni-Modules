using System;
using System.Collections.Generic;
using System.Linq;
using GameStore.Data;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.Controllers
{
    public class GameController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new GameDbContext())
            {
                var allGames = db.Games.ToList();
                return View(allGames);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string name, string dlc, string platform, decimal price)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(dlc) || string.IsNullOrEmpty(platform))
            {
                return RedirectToAction("Index");
            }

            Game game = new Game
            {
                Name = name,
                Price = price,
                Dlc = dlc,
                Platform = platform
            };

            using (var db = new GameDbContext())
            {
                db.Games.Add(game);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new GameDbContext())
            {
                var taskToEdit = db.Games.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Game game)
        {
            using (var db = new GameDbContext())
            {
                var gameToEdit = db.Games.FirstOrDefault(t => t.Id == game.Id);
                gameToEdit.Name = game.Name;
                gameToEdit.Price = game.Price;
                gameToEdit.Dlc = game.Dlc;
                gameToEdit.Platform = game.Platform;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new GameDbContext())
            {
                var gameToDelete = db.Games.Find(id);
                //or
                //var gameToDelete = db.Games.FirstOrDefault(t => t.Id == id);
                return View(gameToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Game game)
        {
            using (var db = new GameDbContext())
            {
                db.Games.Remove(game);
                db.SaveChanges();
            }
            //or
            // using (var db = new GameDbContext())
            // {
            //     var gameToDelete = db.Games.FirstOrDefault(t => t.Id == game.Id);
            //     db.Games.Remove(gameToDelete);
            //     db.SaveChanges();
            // }
            return RedirectToAction("Index");
        }
    }
}