using RecipesApp.Models;
using System;

namespace RecipesApp
{
    class Program
    {
        static void Main()
        {
            var db = new RecipesDBContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Recipes.Add(new Recipe { Name = "Musaka", Description = "Traditional bulgarian meal", CookingTime = new TimeSpan(2, 3, 4) });

            db.SaveChanges();
        }
    }
}
