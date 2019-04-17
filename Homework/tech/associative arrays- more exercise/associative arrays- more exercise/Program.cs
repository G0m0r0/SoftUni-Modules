using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace associative_arrays__more_exercise
{
    class Program
    {
        //not finished dictionary in dictionary
        static void Main(string[] args)
        {
            //<contest,password>
            var ContestPassword = new Dictionary<string, string>();
            //<username,list contests,points>
            var UserPointsContests = new Dictionary<string, Dictionary<List<string>,int>>();

            EnterPasswordsAndContests(ContestPassword);

            string command = string.Empty;
            while ((command=Console.ReadLine())!="end of submissions")
            {
                string[] token = command.Split("=>").ToArray();
                string contest = token[0];
                string password = token[1];
                string username = token[2];
                int points = int.Parse(token[3]);
                //check if contest exist
                if(ContestPassword.ContainsKey(contest))
                {
                    //valid password
                    if(ContestPassword[contest]==password)
                    {
                        UserPointsContests[username] = new Dictionary<List<string>, int>();
                        UserPointsContests[username][new List<string>()] = 0;
                        if()
                    }
                }

            }
        }

        private static void EnterPasswordsAndContests(Dictionary<string, string> contestPassword)
        {
            string contPass = string.Empty;
            while ((contPass = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = contPass.Split(":").ToArray();
                contestPassword[tokens[0]] = tokens[1];
            }
        }
    }
}
