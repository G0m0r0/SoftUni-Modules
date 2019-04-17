using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Vapor_winter_sale
{
    class Program
    {
        static void Main(string[] args)
        {
            var gamePriceDictionary = new Dictionary<string, double>();
            var gameDLCDictionary = new Dictionary<string, List<string>>();

            string[] input = Console.ReadLine().Split(", ");

            for (int i = 0; i < input.Length; i++)
            {
                string[] gameDLC = input[i].Split(":");
                if (gameDLC.Length == 1)
                {
                    string[] gamePrice = input[i].Split("-");
                    string game = gamePrice[0];
                    double price = double.Parse(gamePrice[1]);

                    PutPriceAndGameIntoDictionary(gamePriceDictionary, game, price);
                }
                else
                {
                    PutDLCAndGameIntoDictionary(gameDLCDictionary, gameDLC, gamePriceDictionary);
                }
            }

            ManagePricesDLC(gamePriceDictionary, gameDLCDictionary);
            MangePriceNoDLC(gamePriceDictionary, gameDLCDictionary);

            foreach (var kvp in gamePriceDictionary.OrderBy(x=>x.Value))
            {
                if(gameDLCDictionary.ContainsKey(kvp.Key))
                    Console.WriteLine($"{kvp.Key} - {string.Join(" - ",gameDLCDictionary[kvp.Key])} - {(kvp.Value):f2}");
            }
            foreach (var kvp in gamePriceDictionary.OrderByDescending(x=>x.Value))
            {
                if(!gameDLCDictionary.ContainsKey(kvp.Key))
                    Console.WriteLine($"{kvp.Key} - {(kvp.Value):f2}");
            }
        }

        private static void MangePriceNoDLC(Dictionary<string, double> PriceDic, Dictionary<string, List<string>> DLCDic)
        {
            List<string> namesWithNoDLCs = new List<string>();
            foreach ( var kvp in PriceDic)
            {
                if(!DLCDic.ContainsKey(kvp.Key))
                {
                    namesWithNoDLCs.Add(kvp.Key);
                }
            }
            for (int i = 0; i < namesWithNoDLCs.Count; i++)
            {
                PriceDic[namesWithNoDLCs[i]] *= 0.8;
            }
        }

        private static void ManagePricesDLC(Dictionary<string, double> PriceDic, Dictionary<string, List<string>> DLCDic)
        {
            foreach (var item in DLCDic)
            {
                PriceDic[item.Key] *= 0.5;
            }
        }

        private static void PutDLCAndGameIntoDictionary(Dictionary<string, List<string>> gameDLCDictionary, string[] gameDLC, Dictionary<string, double> gamePriceDictionary)
        {
            if (gamePriceDictionary.ContainsKey(gameDLC[0]) && !gameDLCDictionary.ContainsKey(gameDLC[0]))
            {
                gameDLCDictionary[gameDLC[0]] = new List<string>();
            }
            if (gamePriceDictionary.ContainsKey(gameDLC[0]))
            {
                for (int i = 1; i < gameDLC.Length; i++)
                {
                    gameDLCDictionary[gameDLC[0]].Add(gameDLC[i]);
                    gamePriceDictionary[gameDLC[0]] += gamePriceDictionary[gameDLC[0]] * 0.2;
                }
            }
        }

        private static void PutPriceAndGameIntoDictionary(Dictionary<string, double> gamePriceDictionary, string game, double price)
        {
            if (!gamePriceDictionary.ContainsKey(game))
            {
                gamePriceDictionary[game] = 0;
            }
            gamePriceDictionary[game] += price;
        }
    }
}
