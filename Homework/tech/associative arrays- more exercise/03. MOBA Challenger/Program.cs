using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._MOBA_Challenger
{
    class Program
    {
        static void Main(string[] args)
        {
            var playerInfo = new Dictionary<string, Dictionary<string, int>>();

            string command = string.Empty;
            while ((command= Console.ReadLine())!="Season end")
            {
                string[] person = command.Split(" -> ");

                if (person.Length!=1)
                {
                    string player = person[0];
                    string position = person[1];
                    int skill = int.Parse(person[2]);

                    if (!playerInfo.ContainsKey(player))
                    {
                        playerInfo.Add(player, new Dictionary<string, int>());
                    }
                    if (!playerInfo[player].ContainsKey(position))
                    {
                        playerInfo[player].Add(position, skill);
                    }
                    else
                    {
                        if (playerInfo[player][position] < skill)
                        {
                            playerInfo[player][position] = skill;
                        }
                    }
                }
                else
                {
                    person = command.Split(" vs ");
                    string battle1 = person[0];
                    string battle2 = person[1];

                    if (playerInfo.ContainsKey(battle1) && playerInfo.ContainsKey(battle2))
                    {
                        bool demoted = false;
                        foreach (var firstPlayer in playerInfo[battle1])
                        {
                            foreach (var secondPlayer in playerInfo[battle2])
                            {
                                if (firstPlayer.Key == secondPlayer.Key)
                                {
                                    if (firstPlayer.Value > secondPlayer.Value)
                                    {
                                        playerInfo.Remove(battle2);
                                        demoted = true;
                                        break;
                                    }
                                    else if (secondPlayer.Value > firstPlayer.Value)
                                    {
                                        playerInfo.Remove(battle1);
                                        demoted = true;
                                        break;
                                    }
                                }
                            }
                            if (demoted)
                            {
                                break;
                            }
                        }
                    }
                }
            }

            foreach (var item in playerInfo.OrderByDescending(x => x.Value.Values.Sum()).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Values.Sum()} skill");
                foreach (var stats in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {stats.Key} <::> {stats.Value}");
                }
            }

        }
    }
}