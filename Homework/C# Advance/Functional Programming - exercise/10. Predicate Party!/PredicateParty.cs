using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> names= new List<string>(Console.ReadLine().Split());
            

            string command = string.Empty;

            Func<string, int, bool> lenghtFunc = (name, lengh) =>
              {
                  if(name.Length==lengh)
                  {
                      return true;
                  }
                  return false;
              };
            Func<string,string,bool> startWith=(name,pattern)=>
                {
                if(name.StartsWith(pattern))
                    {
                        return true;
                    }
                    return false;
            };
            Func<string, string, bool> endsWithFunc = (name, pattern) => name.EndsWith(pattern);

            while ((command=Console.ReadLine())!="Party!")
            {
                List<string> tokens = command.Split().ToList();
                string action = tokens[0];
                string condition = tokens[1];
                string param = tokens[2];

                if(action=="Double")
                {
                    if(condition=="Length")
                    {
                        int lenght = int.Parse(param);
                        var tempNames = names.Where(name => lenghtFunc(name, lenght)).ToList();
                        // names.AddRange(temp);

                        MyAddRange(names, tempNames);
                    }
                    else if (condition == "StartsWith")
                    {
                        var temp = names.Where(name => startWith(name, param)).ToList();
                        // names.AddRange(temp);
                        MyAddRange(names, temp);
                    }
                    else if (condition == "EndsWith")
                    {
                        var temp = names.Where(name => endsWithFunc(name, param)).ToList();
                        //names.AddRange(temp);
                        MyAddRange(names, temp);
                    }
                }
                else if(action=="Remove")
                {
                    if (condition == "Length")
                    {
                        int lenght = int.Parse(param);
                        names = names.Where(name => !lenghtFunc(name, lenght)).ToList();
                    }
                    else if (condition == "StartsWith")
                    {
                        names = names.Where(name => !startWith(name, param)).ToList();
                    }
                    else if (condition == "EndsWith")
                    {
                        names = names.Where(name => !endsWithFunc(name, param)).ToList();
                    }
                }
            }
            if(names.Count>0)
            {
                Console.WriteLine($"{string.Join(", ",names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
                    
        }

        private static void MyAddRange(List<string> names, List<string> tempNames)
        {
            foreach (var currentName in tempNames)
            {
                int index = names.IndexOf(currentName);
                names.Insert(index, currentName);
            }
        }
    }
}
