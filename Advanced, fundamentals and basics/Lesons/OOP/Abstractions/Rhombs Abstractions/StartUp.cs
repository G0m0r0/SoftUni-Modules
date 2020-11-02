using System;
using System.Text;

namespace Rhombs_Abstractions
{
    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            RhombusAsString rhombusDrawer = new RhombusAsString();
            string rhombusAsString = rhombusDrawer.Draw(n);

            Console.WriteLine(rhombusAsString);
        }     
    }
}
