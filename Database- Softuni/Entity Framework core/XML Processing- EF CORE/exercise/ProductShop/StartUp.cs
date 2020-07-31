namespace ProductShop
{
    using ProductShop.Data;
    using ProductShop.Import.DTOs;
    using ProductShop.Models;
    using ProductShop.XMLHelper;
    using System.Collections.Generic;
    using System.IO;
    using System;
    using System.Linq;
    using ProductShop.Dtos.Import;
    using ProductShop.Dtos.Export;
    using ProductShop.Dtos;
    using System.Xml;

    public class StartUp
    {
        public static void Main()
        {
            var db = new ProductShopContext();
            //ResetDatabase(db);
            var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            //01
            //Console.WriteLine(ImportUsers(db,usersXml));
            //02
            // Console.WriteLine(ImportProducts(db,productsXml));
            //03
            //Console.WriteLine(ImportCategories(db,categoriesXml));
            //04
            // Console.WriteLine(ImportCategoryProducts(db,categoryProductsXml));
            //05
            //var result=GetProductsInRange(db);
            //var path = "../../../results/GetProductsInRange.xml";
            //06
            //var result = GetSoldProducts(db);
            //var path = "../../../results/GetSoldProducts.xml";
            //07
            //var result = GetCategoriesByProductsCount(db);
            //var path= "../../../results/GetCategoriesByProductsCount.xml";
            //08
            //var result = GetUsersWithProducts(db);
            var path= "../../../results/GetUsersWithProducts.xml";

            //Console.WriteLine(result);
            //File.WriteAllText(path, result);
        }
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
        //01
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var users = XmlConverter
                .Deserializer<ImportUserDTO>(inputXml,rootElement)
                .Select(x=>new User
                { 
                     FirstName=x.FirstName,
                     LastName=x.LastName,
                     Age = x.Age,
                }).ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        //02
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var products = XmlConverter
                .Deserializer<ImportProductDTO>(inputXml, rootElement)
                .Select(x => new Product
                {
                    Name = x.Name,
                    Price = x.Price,
                    BuyerId=x.BuyerId,
                    SellerId=x.SellerId,
                }).ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        //03
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";
            var categories = XmlConverter
                .Deserializer<ImportCategoryDTO>(inputXml, rootElement)
                .Where(x=>x.Name!=null)
                .Select(x => new Category
                {
                    Name = x.Name
                }).ToArray();


            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
        //04
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var catProFromXML = XmlConverter.Deserializer<ImportCategoryProductDTO>(inputXml, "CategoryProducts");

            var productsId = context.Products.Select(i => i.Id).ToList();
            var categoiesId = context.Categories.Select(c => c.Id).ToList();

            var categoryProducts = new List<CategoryProduct>();

            foreach (var item in catProFromXML)
            {
                if (productsId.Contains(item.ProductId) && categoiesId.Contains(item.CategoryId))
                {
                    var newCatPro = new CategoryProduct
                    {
                        CategoryId = item.CategoryId,
                        ProductId = item.ProductId
                    };

                    categoryProducts.Add(newCatPro);
                }
            }

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }
        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            const string rootElement = "Products";
            var productsXml = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .Select(x => new ExportProductInRangeDTO
                {
                    Name=x.Name,
                    Price=x.Price,
                    Buyer = x.Buyer.FirstName + ' ' + x.Buyer.LastName,
                }).OrderBy(x=>x.Price)
                .Take(10)
                .ToArray();

            var products = XmlConverter.Serialize(productsXml,rootElement);

            return products;
        }
        //06
        public static string GetSoldProducts(ProductShopContext context)
        {
            const string rootElement = "Users";
            var persons = context.Users
                .Where(x => x.ProductsSold.Count() > 0)
                .Select(x => new ExportUserSoldProductDTO
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold.Select(y => new UserProductDTO
                    {
                        Name = y.Name,
                        Price = y.Price,
                    }).ToArray()
                }).OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Take(5)
                .ToArray();

            var personsXml = XmlConverter.Serialize(persons,rootElement);

            return personsXml;
        }
        //07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var rootElement = "Categories";
            var categories = context.Categories.Select(x => new ExportCategoriesByProductsCountDTO
            {
                Name = x.Name,
                Count = x.CategoryProducts.Count(),
                AveragePrice=x.CategoryProducts.Average(y=>y.Product.Price),
                TotalRevenue=x.CategoryProducts.Sum(y=>y.Product.Price),
            }).OrderByDescending(x=>x.Count)
            .ThenBy(x=>x.TotalRevenue)
            .ToArray();


            var categoriesXml = XmlConverter.Serialize(categories, rootElement);


            return categoriesXml;
        }
        //08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            const string rootElement = "Users";
            var users = context.Users.ToArray() //in memory exeption in judge if we dont have toarray
               .Where(x => x.ProductsBought.Any())
               .Select(x => new ExportUsersWithProductsDTO
               {
                   FirstName=x.FirstName,
                   LastName=x.LastName,
                   Age=x.Age,
                   SoldProducts=new SoldProductsDTO
                   {
                       Count=x.ProductsSold.Count,
                       Products=x.ProductsSold.Select(y=>new ProductDTO
                       {
                           Name=y.Name,
                           Price=y.Price,
                       }).OrderByDescending(p=>p.Price)
                       .ToArray(),
                   }
               }).OrderByDescending(x=>x.SoldProducts.Count)
               .Take(10)
               .ToArray();

               var result = new ExportUserCountDTO
               {
                   Count = context.Users.Where(x=>x.ProductsSold.Any()).Count(),
                   Users = users,
               };

            var productsXml = XmlConverter.Serialize(result, rootElement);

            return productsXml;
        }
    }
}