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

        public string MflTeam { get; set; }

        public string OriginalRights { get; set; }

        public string NflTeam { get; set; }

        public int Age { get; set; }

        public double Salary { get; set; }

        public double OriginalSalary { get; set; }

        public int ContractYears { get; set; }

        public int PreviousRank { get; set; }

        public double PreviousAverage { get; set; }

        public bool Signed { get; set; }


        /// <summary>
        /// Free Agent player.
        /// </summary>
        /// <param name="player">Player name or id</param>
        /// <param name="src">Image source</param>
        /// <param name="mflTeam">MFL Team</param>
        /// <param name="nflTeam">NFL Team</param>
        /// <param name="salary">Salary</param>
        /// <param name="previousRank">Previous year rank by total points</param>
        /// <param name="previousAverage">Previous year average points</param>
        /// <param name="age">Player age</param>
        /// <param name="years">Contract years</param>
        /// <param name="signed">Status of signed to team</param>
        public Player(string player, string src, string mflTeam, string nflTeam, double salary, int previousRank, double previousAverage, int age, int years = 0, bool signed = false)
        {
            Name = player.Replace('-', ' ');
            Id = player.Replace(' ', '-');
            Src = src;
            MflTeam = mflTeam;
            OriginalRights = mflTeam;
            NflTeam = nflTeam;
            Age = age;
            Salary = salary;
            OriginalSalary = salary;
            ContractYears = years;
            PreviousRank = previousRank;
            PreviousAverage = previousAverage;
            Signed = signed;
        }

        /// <summary>
        /// Rostered player.
        /// </summary>
        /// <param name="player">Player name of id</param>
        /// <param name="salary">Salary</param>
        /// <param name="years">Contract years</param>
        /// <param name="team">MFL Team</param>
        public Player(string player, double salary, int years)
        {
            Name = player.Replace('-', ' ');
            Id = player.Replace(' ', '-');
            Salary = salary;
            ContractYears = years;
        }
    }
}
