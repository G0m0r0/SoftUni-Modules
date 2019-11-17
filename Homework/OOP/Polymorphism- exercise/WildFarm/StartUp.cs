using System;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = string.Empty;

            int counter = 0;
            while ((command=Console.ReadLine())!="End")
            {
                if(counter%2==0)
                {
                    var animal = CreateAnimal(command.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                }
                else
                {

                }
                        
                counter++;
            }
        }

        private static object CreateAnimal(string[] args)
        {
            string type = args[0];
            string Name = args[1];
            double weight =double.Parse( args[2]);
            if(animal=="")
        }
    }
}
