using System;
using System.Collections.Generic;
using System.Linq;

namespace store_boxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] command = Console.ReadLine().Split().ToArray();
            List<Box> boxes = new List<Box>();
            Box box = new Box();
            box.Item = new Item();
            while (command[0] != "end")
            {                                
                box.SerialNumber = command[0];
                box.Item.Name = command[1];
                box.ItemQuality = int.Parse(command[2]);     
                box.ItemPrice = decimal.Parse(command[3]);
                box.Item.Price = box.ItemQuality * box.ItemPrice;
                boxes.Add(box);

                command = Console.ReadLine().Split().ToArray();
            }
            List<Box> SortedBoxes = boxes.OrderBy(x => x.Item.Price).ToList();
            foreach (var item in boxes)
            {
                Console.WriteLine(item.SerialNumber);
                Console.WriteLine($"--{item.Item.Name}-${item.Item.Price}: {item.ItemQuality}");
                Console.WriteLine($"--{item.ItemPrice}");
            }
        }
    }
    class Item
     {
     public string Name { set; get; }
     public decimal Price { set; get; }
     }
    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { set; get; }
        public Item Item { set; get; }
        public int ItemQuality { set; get; }
        public decimal ItemPrice { set; get; }
    }

}
