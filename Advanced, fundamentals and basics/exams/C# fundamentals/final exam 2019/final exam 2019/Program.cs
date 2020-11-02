using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace final_exam_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string geoLocation = string.Empty;
            while ((geoLocation = Console.ReadLine()) != "Last note")
            {
                string pattern = @"(?<name>^[!\w@#!$?\d]*)=(?<lenght>([0-9]+))<<(?<geohash>.+)";
                Regex filter = new Regex(pattern);
                var filterInput = filter.Matches(geoLocation);

                bool flag = false;
                string namePeak = string.Empty;
                string geoHash = string.Empty;
                foreach (Match item in filterInput)
                {
                    namePeak = item.Groups["name"].Value;
                    int lenghGeoHash =int.Parse( item.Groups["lenght"].Value);
                    geoHash = item.Groups["geohash"].Value;
                    if(geoHash.Length!=lenghGeoHash)
                    {
                        continue;
                    }
                    flag = true;
                    namePeak= ValidateNamePeak(namePeak);
                }
                if(flag)
                {
                    Console.WriteLine($"Coordinates found! {namePeak} -> {geoHash}");
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }

        private static string ValidateNamePeak(string name)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <name.Length ; i++)
            {
                if(name[i]!='!'&&name[i]!='@'&&name[i]!='$'&&name[i]!='?'&&name[i]!='#')
                {
                    sb.Append(name[i]);
                }
            }
            return sb.ToString();
        }
    }
}
