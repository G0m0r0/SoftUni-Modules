using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TeisterMask.Data;
using TeisterMask.Models;

namespace TeisterMask.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            using (var db = new TeisterMaskDbContext())
            {
                //var allTasks = db.(take name from data (((((public DbSet<Task> Tasks { get; set; })))).ToList();
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
        public IActionResult Create(string title, string status)
        {
            //check if they exit 
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(status))
            {
                return RedirectToAction("Index");
            }

            //-using TeisterMask.Models;
            //-remove sing System.Threading.Tasks;

            //initialise the object
            Task task = new Task
            {
                Title = title,
                Status=status
            };

            //connect to the database after new we add the name of the database from migrations
            using (var db = new TeisterMaskDbContext())
            {
                //we add the object
                //take name Tasks from data (((((public DbSet<Task> Tasks { get; set; })))).ToList();
                db.Tasks.Add(task);
                //to save changes
                db.SaveChanges();
            }
            return RedirectToAction("Index");
            //return to homepage
        }

        //EDIT----------------------------------------

        [HttpGet]
        //we take the id
        public IActionResult Edit(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == id);
                if (taskToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(taskToEdit);
            }
        }

        //same with the post
        [HttpPost]
        public IActionResult Edit(Task task)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToEdit = db.Tasks.FirstOrDefault(t => t.Id == task.Id);
                taskToEdit.Title = task.Title;
                taskToEdit.Status = task.Status;
                //insted of three lines up we can use
                //db.Tasks.Update(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Delete......................................
        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new TeisterMaskDbContext())
            {
                var taskToDelete = db.Tasks.Find(id);
                return View(taskToDelete);
            }
        }

        //same with the post
        [HttpPost]
        public IActionResult Delete(Task task)
        {
            using (var db = new TeisterMaskDbContext())
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
