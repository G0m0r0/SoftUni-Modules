using System;

namespace Inheritance
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(new Sun(10).Speed);

            Galaxy milkyWay = new Galaxy();
            // milkyWay.CosmicalObjects.Add(new Sun());
            //milkyWay.CosmicalObjects.Add(new Earth());
            // for (int i = 0; i < 7; i++)
            // {
            //     milkyWay.CosmicalObjects.Add(new Planet());
            // }
            CosmicalObject cosmicalObject = new Sun(100);
            cosmicalObject = new Earth(200);
            Console.WriteLine(cosmicalObject.Speed);


            Galaxy andromeda = new Galaxy();
        }
    }
}
