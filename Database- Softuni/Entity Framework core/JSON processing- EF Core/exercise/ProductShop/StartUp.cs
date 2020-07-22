namespace ProductShop
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using ProductShop.Data;
    using ProductShop.DTO.Product;
    using ProductShop.DTO.Users;
    using ProductShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices.ComTypes;
    using System.Runtime.Serialization.Json;

    public class StartUp
    {
        public static void Main()
        {
            InitializeMapper();
            var db = new ProductShopContext();
            // ResetDatabase(db);
            string userJson = File.ReadAllText(@"../../../Datasets/users.json");
            string productsJson = File.ReadAllText(@"../../../Datasets/products.json");
            string categoriesJson = File.ReadAllText(@"../../../Datasets/categories.json");
            string categoriesProducts = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //01
            //Console.WriteLine(ImportUsers(db,userJson));
            //02
            //Console.WriteLine(ImportProducts(db,productsJson));
            //03
            //Console.WriteLine(ImportCategories(db,categoriesJson));
            //04
            //Console.WriteLine(ImportCategoryProducts(db,categoriesProducts));
            //05
            //Console.WriteLine(GetProductsInRange(db));
            //06
            //Console.WriteLine(GetSoldProducts(db));
            //07
            //Console.WriteLine(GetCategoriesByProductsCount(db));
            //08
            Console.WriteLine(GetUsersWithProducts(db));

        }
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was successfully deleted!");
            db.Database.EnsureCreated();
            Console.WriteLine("Database was successfully created!");
        }
        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }
        //01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        //or
        public static string ImportUsersDTO(ProductShopContext context, string inputJson)
        {
            var usersDto = JsonConvert.DeserializeObject<UserImportDTO[]>(inputJson);

            var users = usersDto.Select(dto => Mapper.Map<User>(dto)).ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
        //02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        //03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            //or to ignore null !but ignores only the property not the object!
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };
            //or to ignore null
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson).Where(x => x.Name != null).ToArray();

            //or to emit null
            //int count=0;
            //foreach (var category in categories)
            //{
            //    if (category.Name != null)
            //    {
            //        context.Categories.Add(category);
            //        count++;
            //    }
            //}

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
        //04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoryProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Length}";
        }
        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                 .Where(x => x.Price >= 500 && x.Price <= 1000)
                 .OrderBy(x => x.Price)
                 .Select(x => new
                 {
                     name = x.Name,
                     price = x.Price,
                     seller = x.Seller.FirstName + ' ' + x.Seller.LastName,
                 }).ToList();

            var jsonProducts = JsonConvert.SerializeObject(products);

            return jsonProducts;
        }
        //or
        public static string GetProductsInRangeDTO(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductsInRangeDTO()
                {
                    Name = x.Name,
                    Price = x.Price,
                    SellerName = x.Seller.FirstName + ' ' + x.Seller.LastName,
                }).ToArray();


            var jsonSerialized = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            if (!Directory.Exists("../../../datasets/Results"))
            {
                Directory.CreateDirectory("../../../datasets/Results");
            }

            File.WriteAllText("../../../datasets/Results/products-in-range.json", jsonSerialized);

            return jsonSerialized;
        }
        //or mapper
        public static string GetProductsInRangeDTOWithMapper(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .ProjectTo<ProductsInRangeDTO>().ToArray();


            var jsonSerialized = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            if (!Directory.Exists("../../../datasets/Results"))
            {
                Directory.CreateDirectory("../../../datasets/Results");
            }

            File.WriteAllText("../../../datasets/Results/products-in-range.json", jsonSerialized);

            return jsonSerialized;
        }
        //06
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                                    .Where(p => p.Buyer != null)
                                    .Select(y => new
                                    {
                                        name = y.Name,
                                        price = y.Price,
                                        buyerFirstName = y.Buyer.FirstName,
                                        buyerLastName = y.Buyer.LastName
                                    }).ToArray()
                }).OrderBy(x => x.lastName)
                .ThenBy(x => x.firstName)
                .ToArray();

            var soldProductsJson = JsonConvert.SerializeObject(soldProducts);

            return soldProductsJson;
        }
        //or
        public static string GetSoldProductsDTO(ProductShopContext context)
        {
            var soldProducts = context.Users
                .Where(x => x.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .ProjectTo<UsersWithSoldProductsDTO>().ToArray();

            var soldProductsJson = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);

            return soldProductsJson;
        }
        //07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProducts = context.Categories
                .OrderByDescending(x => x.CategoryProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count,
                    averagePrice = x.CategoryProducts
                                .Average(y => y.Product.Price)
                                .ToString("F2"),
                    totalRevenue = x.CategoryProducts
                                .Sum(y => y.Product.Price)
                                .ToString("F2"),
                }).ToList();

            var categoriesByProductsJson = JsonConvert.SerializeObject(categoriesByProducts, Formatting.Indented);

            return categoriesByProductsJson;
        }
        //08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var curentUsers = context.Users
                             .AsEnumerable()
                             .Where(p => p.ProductsSold.Any(b => b.Buyer != null))
                             .OrderByDescending(p => p.ProductsSold.Count(c => c.Buyer != null))
                             .Select(c => new
                             {
                                 firstName = c.FirstName,
                                 lastName = c.LastName,
                                 age = c.Age,
                                 soldProducts = new
                                 {
                                     count = c.ProductsSold.Count(b => b.Buyer != null),
                                     products = c.ProductsSold
                                                 .Where(x => x.Buyer != null)
                                                 .Select(y => new
                                                 {
                                                     name = y.Name,
                                                     price = y.Price
                                                 })
                                                 .ToList()
                                 }
                             })
                             .ToList();

            var usersWithCoiunt = new
            {
                usersCount = curentUsers.Count,
                users = curentUsers
            };

            var setingJSON = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            var usersToJSON = JsonConvert.SerializeObject(usersWithCoiunt, setingJSON);

            return usersToJSON;


        }
    }
}