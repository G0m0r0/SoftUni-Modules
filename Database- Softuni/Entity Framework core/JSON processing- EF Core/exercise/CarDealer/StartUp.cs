using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            var db = new CarDealerContext();
            //ResetDatabase(db);

            var suppliersJson = File.ReadAllText(@"../../../Datasets/suppliers.json");
            var partsJson = File.ReadAllText(@"../../../Datasets/parts.json");
            var carsJson = File.ReadAllText(@"../../../Datasets/cars.json");
            var customersJson = File.ReadAllText(@"../../../Datasets/customers.json");
            var salesJson = File.ReadAllText(@"../../../Datasets/Sales.json");
            //09
            //Console.WriteLine(ImportSuppliers(db,suppliersJson));
            //10
            //Console.WriteLine(ImportParts(db,partsJson));
            //11
            //--Console.WriteLine(ImportCars(db,carsJson));
            //12
            //Console.WriteLine(ImportCustomers(db,customersJson));
            //13
            //Console.WriteLine(ImportSales(db,salesJson));
            //14
             //Console.WriteLine(GetOrderedCustomers(db));
            //15
            //Console.WriteLine(GetCarsFromMakeToyota(db));
            //16
            Console.WriteLine(GetLocalSuppliers(db));
            //17
            // Console.WriteLine(GetCarsWithTheirListOfParts(db));
            //18
            //Console.WriteLine(GetTotalSalesByCustomer(db));
            //19
             //Console.WriteLine(GetSalesWithAppliedDiscount(db));
        }
        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
        //09
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }
        //10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => p.SupplierId <= context.Suppliers.Count());

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }
        //11
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<List<CarDTO>>(inputJson);
            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var carDto in carsDto)
            {

                var newCar = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance,

                };
                cars.Add(newCar);

                foreach (var carPartId in carDto.PartsId.Distinct())
                {
                    var newCarPart = new PartCar()
                    {
                        PartId = carPartId,
                        Car = newCar
                    };
                    carParts.Add(newCarPart);
                }

            }
            context.Cars.AddRange(cars);
            context.PartCars.AddRange(carParts);
            context.SaveChanges();

            return $"Successfully imported { cars.Count()}.";
        }
        //12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }
        //13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }
        //14
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customersOrdered = context.Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    x.IsYoungDriver,
                }).ToArray();


            var customersJson = JsonConvert.SerializeObject(customersOrdered, Formatting.Indented);

            return customersJson;
        }
        //15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var toyota = context.Cars.Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TravelledDistance
                }).ToArray();


            var toyotaJson = JsonConvert.SerializeObject(toyota, Formatting.Indented);

            return toyotaJson;
        }
        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count(),
                }).ToList();

            var localSuppliersJson = JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);

            return localSuppliersJson;
        }
        //17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                       .Select(c => new
                       {
                           car = new
                           {
                               c.Make,
                               c.Model,
                               c.TravelledDistance
                           },
                           parts = c.PartCars
                                   .Select(p => new
                                   {
                                       p.Part.Name,
                                       Price = p.Part.Price.ToString("F2")
                                   })
                       })
                       .ToList();

            var carPartsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carPartsJson;
        }
        //18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customersWithBougthcars = context.Customers
                         .Where(c => c.Sales.Count() > 0)
                         .Select(c => new
                         {
                             fullName = c.Sales.Select(t => t.Customer.Name).First(),
                             boughtCars = c.Sales.Count(),
                             spentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(x => x.Part.Price))
                         })
                          .OrderByDescending(m => m.spentMoney)
                          .ThenByDescending(t => t.boughtCars)
                          .ToList();

            var customersWithBougthCarsJson = JsonConvert.SerializeObject(customersWithBougthcars, Formatting.Indented);

            return customersWithBougthCarsJson;
        }
        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales.Select(x => new
            {
                car = new
                {
                    x.Car.Make,
                    x.Car.Model,
                    x.Car.TravelledDistance
                },
                customerName = x.Customer.Name,
                Discount = x.Discount.ToString("F2"),
                price = x.Car.PartCars.Sum(p => p.Part.Price).ToString("F2"),
                priceWithDiscount = $"{x.Car.PartCars.Sum(y => y.Part.Price) * (1 - x.Discount / 100):F2}",

            }).Take(10)
            .ToArray();

            var salesJson = JsonConvert.SerializeObject(sales,Formatting.Indented);

            return salesJson;
        }
    }
}