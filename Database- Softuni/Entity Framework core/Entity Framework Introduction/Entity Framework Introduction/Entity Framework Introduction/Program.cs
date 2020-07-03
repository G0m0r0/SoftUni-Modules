using Entity_Framework_Introduction.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Entity_Framework_Introduction
{
    class Program
    {

        public static readonly ILoggerFactory factory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        static void Main(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<SoftuniContext>();
           // optionBuilder.UseSqlServer("path to database or use default");
            optionBuilder.UseLoggerFactory(factory);

            using var db = new SoftuniContext(optionBuilder.Options);
            //if table doesnt exist create it
            db.Database.EnsureCreated();

            var firstEmployee = db.Employees.FirstOrDefault();
            firstEmployee.FirstName = "Delyan";
            db.SaveChanges();
        }
    }
}
