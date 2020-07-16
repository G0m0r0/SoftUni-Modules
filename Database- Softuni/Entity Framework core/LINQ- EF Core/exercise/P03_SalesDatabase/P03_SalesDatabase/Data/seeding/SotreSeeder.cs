
namespace P03_SalesDatabase.Data.seeding
{
    using P03_SalesDatabase.Data.Models;
    using P03_SalesDatabase.Data.seeding.contracts;
    using P03_SalesDatabase.IOManager.contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SotreSeeder:ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly IWriter writer;

        public SotreSeeder(SalesContext context,IWriter writer)
        {
            dbContext = context;
            this.writer = writer;
        }

        public void Seed()
        {
            Store[] stores = new Store[]
            {
                new Store() {Name="name1"},
                new Store() {Name="name2"},
                new Store() {Name="name3"},
                new Store() {Name="name4"},
            };

            this.dbContext.Stores.AddRange(stores);
            writer.WriteLine($"{stores.Length} stores were added to the DB");
        }
    }
}
