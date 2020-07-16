using System;
using System.Text;

namespace MFL_Manager.Models.CustomResponeses
{
    public class PlayerDto : IComparable<PlayerDto>
    {
        //Data for every player.
        public string Name { get; set; }

        public int Id { get; set; }

        public string NFLTeam { get; set; }

        public string MFLTeam { get; set; }

        public int MFLTeamID { get; set; }

        public bool Roster { get; set; }

        public string ContractYear { get; set; }

        public double Salary { get; set; }

        public string Position { get; set; }

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
            if (Position[0] == 'Q') return "QB";
            if (Position[0] == 'R') return "RB";
            if (Position[0] == 'W') return "WR";
            if (Position[0] == 'T') return "TE";
            if (Position[0] == 'K') return "K";
            if (Position[0] == 'D') return "DEF";
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
            if (string.Equals(Position, other.Position))
            {
                return other.Salary.CompareTo(Salary);
            }

            if (Position[0] == 'Q') return -1;
            if (other.Position[0] == 'Q') return 1;
            if (Position[0] == 'R') return -1;
            if (other.Position[0] == 'R') return 1;
            if (Position[0] == 'W') return -1;
            if (other.Position[0] == 'W') return 1;
            if (Position[0] == 'T') return -1;
            if (other.Position[0] == 'T') return 1;
            if (Position[0] == 'K') return -1;
            if (other.Position[0] == 'K') return 1;
            if (Position[0] == 'D') return -1;
            return other.Position[0] == 'D' ? 1 : 0;
        }
    }
}
