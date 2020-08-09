using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Player
    {
        private readonly string playerName;
        public string Name {
            get
            {
                return playerName.Replace('-', ' ');
            }
        }

        public string Id
        {
            get
            {
                return playerName.Replace(' ', '-');
            }
        }

        public string MFLTeam { get; set; }

        public string NFLTeam { get; set; }

        public int Age { get; set; }

        public double Salary { get; set; }

        public int PreviousRank { get; set; }

        public double PreviousAverage { get; set; }

        public bool Signed { get; set; }

        public Player(string player)
        {
            playerName = player;
        }

        public Player(string player, string mflTeam, string nflTeam, int age, double salary, int previousRank, double previousAverage, bool signed = false)
        {
            playerName = player;
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
