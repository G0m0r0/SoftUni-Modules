using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FootballSeason
{
    class Program
    {
        static void Main(string[] args)
        {
           // string players = "";
            Dictionary<string, int> goals = new Dictionary<string, int>();
            do
            {
                // players = Console.ReadLine();
                //split input
                string[] token = Console.ReadLine().Split("-");               
                if (token[0] == "End of season")
                {
                    break;
                }
                //take imput values
                string players = token[0];
                int amount =int.Parse(token[1]);
                //int amount = int.Parse(Console.ReadLine());

                if (goals.ContainsKey(players))
                {
                    goals[players] += amount;
                }
                else
                {
                    goals.Add(players, amount);
                }
            } while (true);

            //goals.OrderBy(x => x.Key)
            foreach (var pair in goals.OrderBy(x => x.Key))
            {

                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }
        }
    }
}