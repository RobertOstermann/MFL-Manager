using System;
using System.Text;

namespace MFL_Manager.Models.CustomResponeses
{
    public class PlayerDto : IComparable<PlayerDto>
    {
        //Data for every player.
        public string Name { get; set; }

        public int Id { get; set; }

        public string Team { get; set; }

        public string MFLTeam { get; set; }

        public int MFLTeamID { get; set; }

        public bool Roster { get; set; }

        public string ContractYear { get; set; }

        public double Salary { get; set; }

        public char Position { get; set; }

        //Important information not yet implemented.
        public int ByeWeek { get; set; }

        public double PreviousScores { get; set; }

        public double ProjectedScores { get; set; }

        //Access - playerProfile - specific id
        public int Age { get; set; }

        //Additional player information. (Access - players - specific id)
        public int Weight { get; set; }

        public int Height { get; set; }

        public string College { get; set; }

        public int DraftRound { get; set; }

        public int DraftPick { get; set; }

        public int DraftYear { get; set; }

        public string Twitter { get; set; }

        //Draft data
        public double ADP { get; set; }

        public int FantasyProsRanking { get; set; }

        /// <summary>
        /// Overrides the ToString() method for display in the listbox.
        /// </summary>
        /// <returns>String containing vital player information.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name.Length > 20 ? Name.Remove(20).PadRight(21) : Name.PadRight(21));
            sb.Append(PositionString().PadRight(4));
            sb.Append(FantasyProsRanking == 999 ? "".PadRight(7) : FantasyProsRanking.ToString().PadRight(7));
            sb.Append($"{Salary:C}".PadRight(11));
            sb.Append(ContractYear);
            return sb.ToString();
        }
        /// <summary>
        /// Allows for the position to be displayed.
        /// </summary>
        /// <returns></returns>
        private string PositionString()
        {
            if (Position == 'q') return "QB";
            if (Position == 'r') return "RB";
            if (Position == 'w') return "WR";
            if (Position == 't') return "TE";
            if (Position == 'k') return "K";
            if (Position == 'd') return "DEF";
            return "";
        }
        /// <summary>
        /// Implements IComparable with comparisons 
        /// between player salaries. 
        /// More comparison options will be implemented.
        /// </summary>
        /// <param name="other">Second Player</param>
        /// <returns>Integer indicating result of the comparison.</returns>
        public int CompareTo(PlayerDto other)
        {
            if (Position.CompareTo(other.Position) == 0)
            {
                return other.Salary.CompareTo(Salary);
            }

            if (Position == 'q') return -1;
            if (other.Position == 'q') return 1;
            if (Position == 'r') return -1;
            if (other.Position == 'r') return 1;
            if (Position == 'w') return -1;
            if (other.Position == 'w') return 1;
            if (Position == 't') return -1;
            if (other.Position == 't') return 1;
            if (Position == 'k') return -1;
            if (other.Position == 'k') return 1;
            if (Position == 'd') return -1;
            return other.Position == 'd' ? 1 : 0;
        }
    }
}
