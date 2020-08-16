using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace Website.Models
{
    public class Team
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public double Salary
        {
            get
            {
                return Players.Sum(p => p.Salary);
            }
        }

        public double SalaryAdjustments { get; set; }

        public double TotalSalary => Salary + SalaryAdjustments;

        public List<Player> Players { get; set; }

        public Team(string team, double salaryAdjustments, List<Player> players)
        {
            Name = team.Replace('-', ' ');
            Id = team.Replace(' ', '-').Replace("'", "");
            SalaryAdjustments = salaryAdjustments;
            Players = players;
        }
    }
}
