using System;
using System.Collections.Generic;
using System.Linq;

namespace teamwork_project
{
    class Program
    {
        //not finished!!!!!!!!!!!!!!!!
        static void Main(string[] args)
        {
            int numOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();

            CreateTeams(teams, numOfTeams);

            JoinTeams(teams);

            DisbandTeams(teams);
        }

        private static void DisbandTeams(List<Team> teams)
        {
            for (int i = 0; i < teams.Count; i++)
            {

            }
        }

        private static void JoinTeams(List<Team> teams)
        {
            string[] command = Console.ReadLine().Split("->");
            while (command[0] != "end of assignment")
            {
                if (checkExistenseTeam(teams, command[1]))
                {
                    if (checkUserForAnotherTeam(teams, command[0]))
                    {
                        Team team = new Team(command[0]);
                        teams.Add(team);
                    }
                    else
                        Console.WriteLine($"Member {command[0]} cannot join team {command[1]}!");
                }
                else
                    Console.WriteLine($"Team {command[1]} does not exit!");
                command = Console.ReadLine().Split("->");
            }
        }

        private static bool checkUserForAnotherTeam(List<Team> teams, string user)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].User.Contains(user))
                    return false;
            }
            return true;
        }

        private static bool checkExistenseTeam(List<Team> teams, string teamName)
        {
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].TeamName == teamName)
                    return true;
            }
            return false;
        }

        private static void CreateTeams(List<Team> teams, int numOfTeams)
        {
            for (int i = 0; i < numOfTeams; i++)
            {
                string[] token = Console.ReadLine().Split("-");                

                bool flag = true;
                for (int j = 0; j < teams.Count; j++)
                {
                    if (teams[j].TeamName == token[1])
                    {
                        flag = false;
                        Console.WriteLine($"Team {token[1]} was already created!");
                        break;
                    }
                    if (teams[j].User.Contains(token[0]))
                    {
                        flag = false;
                        Console.WriteLine($"{token[0]} cannot create another team!");
                        break;
                        //POSIBLE TO HAVE SAME NAME AND TEAM
                    }
                }
                if (flag)
                {
                    Team team = new Team("- "+token[0], token[1]);
                    teams.Add(team);
                    Console.WriteLine($"Team {token[1]} has been created by {token[0]}!");
                }
            }
        }

        class Team
        {
            public Team(string user,string teamName)
            {
                User = user;
                TeamName = teamName;
            }
            public Team(string user)
            {
                User.Add(user);
            }
            public List<string> User = new List<string>();
            public string TeamName { set; get; }
        }
    }
}
