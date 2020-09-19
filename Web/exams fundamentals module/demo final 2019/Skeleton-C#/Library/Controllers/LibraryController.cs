using System;
using System.Collections.Generic;
using System.Linq;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Library.Data;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new LibraryDbContext())
            { 
                var allTasks = db.Tasks.ToList();
                return View(allTasks);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(string title,string author,double price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author))
            {
                return RedirectToAction("Index");
            }

            Book task = new Book
            {
                Title = title,
                Author=author,
                Price=price
            };

            using (var db = new LibraryDbContext())
            {
                db.Tasks.Add(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == book.Id);
                taskToEdit.Title = book.Title;
                taskToEdit.Author = book.Author;
                taskToEdit.Price = book.Price;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new LibraryDbContext())
            {
                var taskToDelete = db.Tasks.Find(id);
                return View(taskToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new LibraryDbContext())
            {
                db.Tasks.Remove(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}