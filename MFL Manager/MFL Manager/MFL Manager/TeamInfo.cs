using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFL_Manager
{
    public class TeamInfo : IComparable<TeamInfo>
    {
        public string Name { get; set; }

        public string Owner { get; set; }

        public int Id { get; set; }

        public int Division { get; set; }

        public List<PlayerInfo> Players { get; private set; }
   
        public double Salary { get; set; }

        public double CapHit { get; set; }
        /// <summary>
        /// Initializes an empty TeamInfo object.
        /// </summary>
        public TeamInfo()
        {
            Players = new List<PlayerInfo>();
        }
        /// <summary>
        /// Adds a player to the team.
        /// Adds player salary to the team salary.
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayer(PlayerInfo player)
        {
            if (!player.Roster)
            {
                player.Roster = true;
                player.MFLTeamID = Id;
                Players.Add(player);
                Salary += player.Salary;
            }
        }
        /// <summary>
        /// Removes a player from the team.
        /// Removes player salary from the team salary.
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayer(PlayerInfo player)
        {
            player.Roster = false;
            Players.Remove(player);
            Salary -= player.Salary;
        }
        /// <summary>
        /// Implements IComparable with comparisons between NFLTeam Id.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TeamInfo other)
        {
            return other.Id.CompareTo(Id);
        }
    }
}
