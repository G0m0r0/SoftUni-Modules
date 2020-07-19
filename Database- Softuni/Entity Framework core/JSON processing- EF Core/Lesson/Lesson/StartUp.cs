using CsvHelper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute; //using chosen library
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Lesson
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; } = DateTime.Now;
        public int TemperatureC { get; set; } = 30;
        public string Summary { get; set; } = "Very hot day";
        [JsonIgnore]  //new tuple 
        public (int Value1, string value2) TupleProp { get; set; }

    }

    public class Car
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
    public class StartUp
    {
        static void Main()
        {
            //System.Text.json-new, faster, fewer options
            var weather = new WeatherForecast();
            string json = JsonSerializer.Serialize(weather,
                new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            //new JsonSerializerOptions to make it look better

            File.WriteAllText("Weather.json", json);
            Console.WriteLine(json);

            string readJson = File.ReadAllText("Weather.json");
            var DeserializedJson = JsonSerializer.Deserialize<WeatherForecast>(readJson);

            //JSON.NET- old,slower,more options
            var weather2 = JsonConvert.DeserializeObject<WeatherForecast>(readJson);
            Console.WriteLine(JsonConvert.SerializeObject(weather2, Formatting.Indented));

            //anonymous class
            var obj = new { temparatureC = 0, Summary = string.Empty };
            var json3 = File.ReadAllText("Weather.json");
            obj = JsonConvert.DeserializeAnonymousType(json3, obj);

            //settings
            var contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy(),
            };

            var jsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy(),
                },
                Culture = CultureInfo.InvariantCulture,
                DateFormatString = "yyyy-MM-dd",
            };

            Console.WriteLine(JsonConvert.SerializeObject(weather, jsonSettings));

            //linq to json
            var json4 = File.ReadAllText("Weather.json");
            JObject jObject = JObject.Parse(json);

            Console.WriteLine(jObject["Summary"]); //very hot day
            jObject.Children(); //gives us access to all properties 

            //xml serialize

            string xml = "myXml";
            XmlDocument doc = new XmlDocument();
            //doc.LoadXml(xml);
            string jsonText = JsonConvert.SerializeXmlNode(doc);

            //CSV.Helper read
            using CsvReader reader = new CsvReader
                (new StreamReader("Cars.csv"), CultureInfo.InvariantCulture);

            var cars1 = reader.GetRecords<Car>().ToList();

            //write
            var cars2 = new List<Car>
            {
                new Car{Year=2020,Model="A7",Make="Audi",Price=200000},
                new Car{Year=2000,Model="A3",Make="Audi",Price=20000},
                new Car{Year=2010,Model="A6",Make="Audi",Price=100000},
            };

            using CsvWriter writer = new CsvWriter
                (new StreamWriter("MyCars.csv"), CultureInfo.InvariantCulture);

            writer.WriteRecords(cars2);
        }
    }
}
