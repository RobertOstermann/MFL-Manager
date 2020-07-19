/* PlayerInfo.cs
 * Author: Robert Ostermann
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFL_Manager
{
    //Stores player information.
    public class PlayerInfo : IComparable<PlayerInfo>
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
        /// Initializes an empty PlayerInfo object.
        /// </summary>
        public PlayerInfo()
        {
            MFLTeamID = 0;
            FantasyProsRanking = 999;
        }        
        /// <summary>
        /// Provides a string for the save text file.
        /// </summary>
        /// <returns>Relevant information.</returns>
        public string Save()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append('/');
            sb.Append(Id);
            sb.Append('/');
            sb.Append(Team);
            sb.Append('/');
            sb.Append(MFLTeamID);
            sb.Append('/');
            sb.Append(ContractYear);
            sb.Append('/');
            sb.Append(Salary);
            sb.Append('/');
            sb.Append(Position);
            return sb.ToString();
        }
        /// <summary>
        /// Overrides the ToString() method for display in the listbox.
        /// </summary>
        /// <returns>String containing vital player information.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Name.Length > 20) sb.Append(Name.Remove(20).PadRight(21));
            else sb.Append(Name.PadRight(21));
            sb.Append(PositionString().PadRight(4));
            //sb.Append(Id.ToString().PadRight(7));
            //sb.Append(MFLTeamID.ToString().PadRight(7));
            if (FantasyProsRanking == 999) sb.Append("".PadRight(7));
            else sb.Append(FantasyProsRanking.ToString().PadRight(7));
            sb.Append(String.Format("{0:C}", Salary).PadRight(11));
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
        public int CompareTo(PlayerInfo other)
        {
            if (Position.CompareTo(other.Position) == 0)
            {
                return other.Salary.CompareTo(Salary);
            }
            else
            {
                if (Position == 'q') return -1;
                else if (other.Position == 'q') return 1;
                else if (Position == 'r') return -1;
                else if (other.Position == 'r') return 1;
                else if (Position == 'w') return -1;
                else if (other.Position == 'w') return 1;
                else if (Position == 't') return -1;
                else if (other.Position == 't') return 1;
                else if (Position == 'k') return -1;
                else if (other.Position == 'k') return 1;
                else if (Position == 'd') return -1;
                else if (other.Position == 'd') return 1;
            }
            return 0;
        }

    }
}
