using System;

namespace jagged_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            string[][] arr =
            {
                new string[]{"Sofia","Plovdiv","Varna"},
                new string[]{"Sofia","Plovdiv","Varna","Burgas"},
                new string[]{"Sofia","Plovdiv"}
            };
            //arr.Lenght ouput 9
            //compared to 2D array
            string[,] TwoDarr =
            {
               {"Sofia","Plovdiv","Varna"},
               {"Sofia","Plovdiv","Varna"},
               {"Sofia","Plovdiv","Varna"}
            };
            //arr.Lenght ouput 9
        }
    }
}
