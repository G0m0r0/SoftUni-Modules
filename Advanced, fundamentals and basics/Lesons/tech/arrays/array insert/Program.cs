using System;
using System.Linq;

namespace array_insert
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "Sofia", "Plovdiv" };
            string[] newArr={ "Sofia",null,"Plovdiv"};
            newArr[1] = "Inserted piece";

            var list = arr.ToList();
            list.Insert(2, "Gabrovo");
            arr = list.ToArray();

        }
    }
}
