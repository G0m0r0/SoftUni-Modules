using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp.Models
{
    public class RecipesDBContext: DbContext
    {
        public RecipesDBContext()
        {

        }

        public RecipesDBContext(DbContextOptions<RecipesDBContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.; Database=Recipes; Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .ToTable("MyRecipes", "system")
                .Property(x => x.Name)
                .HasColumnName("Title")
                .IsUnicode(true)
                .IsRequired()
                .HasColumnType("char(30)")
                .HasColumnType("varchar") //better this way
                .HasMaxLength(30);

            modelBuilder.Entity<Recipe>()
                .Property(x => x.Description);
        }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
