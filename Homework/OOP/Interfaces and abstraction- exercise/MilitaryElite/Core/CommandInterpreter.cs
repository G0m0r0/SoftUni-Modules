using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private Dictionary<int,ISoldier> soldiers;
        public CommandInterpreter()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        public string Read(string[] args)
        {
            string soldierType = args[0];
            int id =int.Parse(args[1]);
            string firstName = args[2];
            string lastName = args[3];

            ISoldier soldier=null;

            if (soldierType == "Private")
            {
                decimal salary = decimal.Parse(args[4]);
                soldier = new Private(firstName, lastName,id, salary);
                //this.soldiers.Add(id, soldier);
            }
            else if(soldierType== "LieutenantGeneral")
            {
                decimal salary = decimal.Parse(args[4]);
                var privates=new Dictionary<int, IPrivate>();

                for (int i = 5; i < args.Length; i++)
                {
                    int soldierId =int.Parse( args[i]);
                    var currentSoldier = (IPrivate)soldiers[soldierId];
                    privates.Add(soldierId, currentSoldier);
                }

                soldier = new LieutenantGeneral(firstName, lastName,id, salary,privates);
            }
            else if(soldierType=="Engineer")
            {
                decimal salary = decimal.Parse(args[4]);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if(!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IRepair> repairs = new List<IRepair>();

                for (int i = 6; i < args.Length; i+=2)
                {
                    string currentName = args[i];
                    int hours = int.Parse(args[i + 1]);

                    IRepair repair = new Repair(currentName, hours);
                    repairs.Add(repair);
                }

                    soldier = new Engineer(firstName, lastName, id, salary,corps, repairs);
            }
            else if(soldierType=="Commando")
            {
                decimal salary = decimal.Parse(args[4]);
                bool isValidCorps = Enum.TryParse<Corps>(args[5], out Corps corps);

                if (!isValidCorps)
                {
                    throw new Exception();
                }

                ICollection<IMission> missions = new List<IMission>();

                for (int i = 6; i < args.Length; i+=2)
                {
                    string missionName = args[i];
                    string misssionState = args[i + 1];

                    bool isValidMission = Enum.TryParse<State>(misssionState, out State stateResult);
                    if(!isValidMission)
                    {
                        continue;
                    }

                    IMission mission = new Mission(missionName,stateResult);
                    missions.Add(mission);
                }

                soldier = new Commando(firstName, lastName, id, salary, corps, missions);
            }
            else if(soldierType=="Spy")
            {
                int codeName = int.Parse(args[4]);
                soldier = new Spy(firstName, lastName, id, codeName);               
            }

            soldiers.Add(id, soldier);

            return soldier.ToString();

        }
    }
}
