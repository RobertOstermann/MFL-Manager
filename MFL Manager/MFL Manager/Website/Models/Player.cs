using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Player
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public string Src { get; set; }

        public string MFLTeam { get; set; }

        public string NFLTeam { get; set; }

        public int Age { get; set; }

        public double Salary { get; set; }

        public int PreviousRank { get; set; }

        public double PreviousAverage { get; set; }

        public bool Signed { get; set; }

        public Player(string player, string src, string mflTeam, string nflTeam, int age, double salary, int previousRank, double previousAverage, bool signed = false)
        {
            Name = player.Replace('-', ' ');
            Id = player.Replace(' ', '-');
            Src = src;
            MFLTeam = mflTeam;
            NFLTeam = nflTeam;
            Age = age;
            Salary = salary;
            PreviousRank = previousRank;
            PreviousAverage = previousAverage;
            Signed = signed;
        }
    }
}
