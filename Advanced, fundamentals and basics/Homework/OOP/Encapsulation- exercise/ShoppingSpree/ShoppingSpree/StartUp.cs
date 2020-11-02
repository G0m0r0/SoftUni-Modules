using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] inputPeople = Console.ReadLine()
                .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                string[] InputProducts = Console.ReadLine()
                    .Split(new char[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);


                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                for (int i = 0; i < inputPeople.Length; i += 2)
                {
                    Person person = new Person(inputPeople[i], decimal.Parse(inputPeople[i + 1]));
                    people.Add(person);
                }
                for (int i = 0; i < InputProducts.Length; i += 2)
                {
                    Product product = new Product(InputProducts[i], decimal.Parse(InputProducts[i + 1]));
                    products.Add(product);
                }

                string command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = tokens[0];
                    string productName = tokens[1];

                    Person perosn = people.FirstOrDefault(x => x.Name == name);
                    Product product = products.FirstOrDefault(x => x.Name == productName);

                    //if (perosn != null && product != null)
                        perosn.AddToBag(product);
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
