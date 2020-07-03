using code_first.Model;
using System;

namespace code_first
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new RecipeDbContext();

            //create if doestn exist
            db.Database.EnsureCreated();

            //add record
            db.Recipes.Add(new Recipe { Name = "Musaka" });
            db.SaveChanges();
        }
    }
}
