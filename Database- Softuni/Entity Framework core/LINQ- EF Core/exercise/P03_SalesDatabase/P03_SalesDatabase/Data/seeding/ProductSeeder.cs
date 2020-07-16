namespace P03_SalesDatabase.Data.seeding
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase.Data.seeding.contracts;
    using P03_SalesDatabase.IOManager.contracts;
    using System;
    using System.Collections.Generic;

    public class ProductSeeder : ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly Random random;
        private readonly IWriter writer;

        public ProductSeeder(SalesContext context,Random random,IWriter writer)
        {
            this.dbContext = context;
            this.random = random;
            this.writer = writer;
        }

        public void Seed()
        {
            ICollection<Product> products = new List<Product>();
            string[] names = new string[]
            {
                "CPU",
                "Motherboard",
                "GPU",
                "SSD",
                "HardDisk",
                "Air-Cooler"
            };

            for (int i = 0; i < 50; i++)
            {
                int nameIndex = this.random.Next(0, names.Length);
                string currentPrName = names[nameIndex];
                double quantity = this.random.Next(0, 1000);
                decimal price = this.random.Next(0, 5000) * 1.133m;

                Product product = new Product()
                {
                    Name = currentPrName,
                    Price = price,
                    Quantity = quantity
                };

                products.Add(product);

                this.writer.WriteLine($"Product (Name: ${currentPrName} {quantity} {price}$) was added to the DB");
            }

            this.dbContext.Products.AddRange(products);
            this.dbContext.SaveChanges();
        }
    }
}
