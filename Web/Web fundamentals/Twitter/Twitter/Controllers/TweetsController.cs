using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Twitter.Data;

namespace Twitter.Controllers
{
    [Authorize]
    public class TweetsController:Controller
    {
        ApplicationDbContext db;
        public TweetsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Create()
        {
            return View();
        }

        //TODO: Logged user?
        public IActionResult SaveToDatabase(string text)
        {
            //create tweet with text
            var tweet = new Tweet();
            tweet.Text = text;
            tweet.CreateOn = DateTime.Now;
            tweet.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //save to db
            db.Tweets.Add(tweet);
            db.SaveChanges();

            //redirect to homepage
            return Redirect("/");
        }
    }
}
