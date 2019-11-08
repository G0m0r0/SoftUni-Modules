using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        public Hero(string username,int level)
        {
            this.UserName = username;
            this.Level = level;
        }
        public string UserName { get; set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {this.GetType()} Username: {this.UserName} Level: {this.Level}";
        }
    }
}
