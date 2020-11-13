﻿using System;

namespace object_and_classes__exercise
{
    class Program
    {
        /*
         * •	Events – {"Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"}
	Authors – {"Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"}
	Cities – {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"}

         */
        static void Main(string[] args)
        {
            string[] phrase = { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] events = { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };
            Random rnd = new Random();
            int numberOfTimes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTimes; i++)
            {
                Console.WriteLine(phrase[rnd.Next(0, phrase.Length)]+" "+
                    events[rnd.Next(0,events.Length)]+" "+
                    authors[rnd.Next(0,authors.Length)]+" - "+
                    cities[rnd.Next(0,cities.Length)]+".");
            }

        }
    }
}