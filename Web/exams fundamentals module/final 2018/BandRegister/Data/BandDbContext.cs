using BandRegister.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BandRegister.Data
{
    public class BandDbContext:DbContext
    {
        public DbSet<Band> Bands { get; set; }

        private const string ConnectionString= @"Server=.\SQLEXPRESS;Database=BandDataSQL;Integrated Security=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
