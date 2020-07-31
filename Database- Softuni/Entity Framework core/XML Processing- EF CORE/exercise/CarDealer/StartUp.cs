using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.XMLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new CarDealerContext();
            //ResetDatabase(db);
            
            var suppliersXML = File.ReadAllText("../../../Datasets/suppliers.xml");
            var parts = File.ReadAllText("../../../Datasets/parts.xml");
            var cars = File.ReadAllText("../../../Datasets/cars.xml");
            var customers = File.ReadAllText("../../../Datasets/customers.xml");
            var sales = File.ReadAllText("../../../Datasets/sales.xml");
            //09
            //Console.WriteLine(ImportSuppliers(db,suppliersXML));
            //10
            //Console.WriteLine(ImportParts(db,parts));
            //11
            //Console.WriteLine(ImportCars(db,cars));
            //12
            //Console.WriteLine(ImportCustomers(db,customers));
            //13
            //Console.WriteLine(ImportSales(db,sales));
            //14
            //var result = GetCarsWithDistance(db);
            //15
            //var result = GetCarsFromMakeBmw(db);
            //16
            //var result = GetLocalSuppliers(db);
            //17
            //var result = GetCarsWithTheirListOfParts(db);
            //18
            var result = GetTotalSalesByCustomer(db);
            //19
            //var result = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(result);
            File.WriteAllText("../../../results/GetSalesWithAppliedDiscount.xml", result);
        }
        private static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
        //09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var rootElement = "Suppliers";
            var suppliers = XmlConverter.Deserializer<SuppliersDTO>(inputXml, rootElement)
                .Select(x=>new Supplier 
                {
                    Name=x.Name,
                    IsImporter=x.IsImported,
                }).ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}";
        }
        //10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var rootElement = "Parts";
            var parts = XmlConverter.Deserializer<PartsDTO>(inputXml, rootElement)
                .Where(x=>context.Suppliers.Any(y=>y.Id==x.SupplierId))
                .Select(x => new Part
                {
                    Name = x.Name,
                    Price = x.Price,
                    SupplierId = x.SupplierId,
                    Quantity = x.Quantity,
                }).ToArray();


            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}";
        }
        //11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var rootElement = "Cars";
            var carsDTO = XmlConverter.Deserializer<CarsDTO>(inputXml, rootElement);


            var cars = new List<Car>();

            foreach (var carDTO in carsDTO)
            {
                var uniqueParts = carDTO.Parts.Select(s => s.Id).Distinct().ToArray();
                var realParts = uniqueParts.Where(id => context.Parts.Any(i => i.Id == id));

                var car = new Car
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TravelledDistance = carDTO.TraveledDistance,
                    PartCars = realParts.Select(id => new PartCar()
                    {
                        PartId =id,

                    }).ToArray()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
        //12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var rootElemetn = "Customers";
            var customers = XmlConverter.Deserializer<CustomersDTO>(inputXml, rootElemetn)
                .Select(x => new Customer
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate,   //datetime.parse(birthdate)
                    IsYoungDriver = x.IsYoungDriver,
                }).ToArray();


            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}";
        }
        //13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var rootElemet = "Sales";
            var sales = XmlConverter.Deserializer<SalesDTO>(inputXml, rootElemet)
                .Where(x => context.Cars.Any(y => y.Id == x.CarId))
                .Select(x => new Sale
                {
                    CarId = x.CarId,
                    CustomerId = x.CustomerId,
                    Discount = x.Discount,
                }).ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}";
        }
        //14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TravelledDistance > 2_000_000)
                .Select(x => new CarWithDistanceDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                }).OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ToArray();

            var rootElement = "cars";
            var result = XmlConverter.Serialize(cars, rootElement);

            return result;
        }
        //15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "BMW")
                .Select(x=>new CarsFromMakeBMWDTO
                {
                    Id=x.Id,
                    Model=x.Model,
                    TravelledDistance=x.TravelledDistance,
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TravelledDistance)
                .ToArray();

            var rootElement = "cars";
            var result = XmlConverter.Serialize(cars, rootElement);

            return result;
        }
        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var localSuppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new LocalSuppliers
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Parts.Count(),
                }).ToArray();

            var rootElement = "suppliers";
            var result = XmlConverter.Serialize(localSuppliers, rootElement);

            return result;
        }
        //17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithTheirListOfParts = context.Cars
                .Select(x => new CarsWithTheirListOfPartsDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TravelledDistance = x.TravelledDistance,
                    Parts = x.PartCars.Select(y => new ListOfParts
                    {
                        Name=y.Part.Name,
                        Price=y.Part.Price,
                    }).OrderByDescending(z=>z.Price)
                    .ToArray(),
                }).OrderByDescending(x=>x.TravelledDistance)
                .ThenBy(x=>x.Model)
                .Take(5)
                .ToArray();

            var rootElement = "cars";
            var result = XmlConverter.Serialize(carsWithTheirListOfParts, rootElement);

            return result;
        }
        //18 check again
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var totalSalesByCustomer = context.Cars
                            .Where(c => c.Sales.Any(s => s.Customer.Sales.Any()))
                            .Select(c => new TotalSalesByCustomerDTO
                            {
                                Name = c.Sales.Select(n => n.Customer.Name).First(),
                                Count = c.Sales.Count,
                                SpentMoney = c.PartCars.Sum(p => p.Part.Price)
                            }).OrderByDescending(x => x.SpentMoney)
                .ToArray();

            var rootElement = "customers";
            var result = XmlConverter.Serialize(totalSalesByCustomer, rootElement);

            return result;
        }
        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales 
             .Select(x => new SalesWithAppliedDiscountDTO
             {
                Car = new SalesWithAppliedDiscountCarDTO
                {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TravelledDistance = x.Car.TravelledDistance,
                },
                Discount = x.Discount,
                Name = x.Customer.Name,
                Price = x.Car.PartCars.Sum(x => x.Part.Price),
                PriceWithDiscount = x.Car.PartCars.Sum(p => p.Part.Price) -
                                              x.Car.PartCars.Sum(p => p.Part.Price) * x.Discount / 100
             }).ToArray();

            var rootElement = "sales";
            var result = XmlConverter.Serialize(sales, rootElement);

            return result;
        }
    }
}