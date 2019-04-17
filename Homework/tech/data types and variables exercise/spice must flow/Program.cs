using System;

namespace spice_must_flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int spice = 0;
            int brdays = 0;
            while(yield>=100)
            {
                spice += (yield-26);
                yield -= 10;
                brdays++;
            }
            Console.WriteLine(brdays);
            if(spice>=26)
            Console.WriteLine(spice-26);
            else Console.WriteLine(0);
        }
    }
}
