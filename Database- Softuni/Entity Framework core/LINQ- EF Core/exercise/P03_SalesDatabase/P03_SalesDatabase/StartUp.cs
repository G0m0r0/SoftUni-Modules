namespace P03_SalesDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data;
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase.Data.seeding;
    using P03_SalesDatabase.Data.seeding.contracts;
    using P03_SalesDatabase.IOManager;
    using P03_SalesDatabase.IOManager.contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data.Common;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
             SalesContext dbContext = new SalesContext();
            //  Random random = new Random();
            //  IWriter consoleWriter = new ConsoleWriter();
            //
            //  ICollection<ISeeder> seeders = new List<ISeeder>();
            //  seeders.Add(new ProductSeeder(dbContext, random,consoleWriter));
            //  seeders.Add(new SotreSeeder(dbContext,consoleWriter));
            //
            //  foreach (ISeeder seeder in seeders)
            //  {
            //      seeder.Seed();
            //  }

            Sale sale = new Sale()
            {
                CustomerId = 1,
                ProductId = 1,
                StoreId = 1,
            };

            dbContext.Sales.Add(sale);

            dbContext.SaveChanges();

            Sale[] sales = dbContext.Sales.ToArray();

            foreach (Sale saleI in sales)
            {
                Console.WriteLine($"Sale ({saleI.SaleId} {saleI.Date})");
            }
        }
    }
}
