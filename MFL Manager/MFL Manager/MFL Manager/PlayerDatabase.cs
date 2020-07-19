/* PlayerDatabase.cs
 * Author: Robert Ostermann
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MFL_Manager.Models.ApiResponses.Players;
using MFL_Manager.Models.CustomResponeses;

namespace MFL_Manager
{
    public class PlayerDatabase
    {
        //Overhaul-2020

        public Dictionary<int, PlayerDto> Players { get; set; }

        public Dictionary<int, FranchiseDto> Franchises { get; set; }

        public Dictionary<int, DivisionDto> Divisions { get; set; }

        public double CapRoom { get; set; }

        /// <summary>
        /// Initialize the PlayerDatabase.
        /// </summary>
        public PlayerDatabase()
        {
            Players = new Dictionary<int, PlayerDto>();
            Franchises = new Dictionary<int, FranchiseDto>();
            CapRoom = 125.00;
        }

        //Old
        public List<PlayerInfo> PlayerList { get; set; }

        //Current roster is stored for each team.
        public Dictionary<int, TeamInfo> Teams;

        public Dictionary<int, PlayerInfo> PlayerDictionary;

        /// <summary>
        /// Initializes the PlayerDatabase.
        /// Load local list is selected.
        /// </summary>
        /// <param name="filename">File location for the local player list.</param>
        public PlayerDatabase(string filename)
        {
            PlayerDictionary = new Dictionary<int, PlayerInfo>();
            PlayerList = new List<PlayerInfo>();
            Teams = new Dictionary<int, TeamInfo>();
            CapRoom = 125.00;
            ReadFile(filename);
        }
        /// <summary>
        /// Initializes the PlayerDatabase.
        /// Load MFL list is selected.
        /// </summary>
        /// <param name="playerURL">MFL players</param>
        /// <param name="salaryURL">MFL salary</param>
        /// <param name="leagueURL">MFL league</param>
        public PlayerDatabase(string playerURL, string salaryURL, string leagueURL, string RosterURL)
        {
            //Add in more sources for more comprehensive information, such as rosters.
            PlayerDictionary = new Dictionary<int, PlayerInfo>();
            PlayerList = new List<PlayerInfo>();
            Teams = new Dictionary<int, TeamInfo>();
            CapRoom = 125.00;
            ReadWebsiteInformation(playerURL, salaryURL, leagueURL, RosterURL);
        }
        /// <summary>
        /// Clears and updates the AllPlayers list.
        /// </summary>
        public void UpdateAllPlayerList()
        {
            PlayerList.Clear();
            foreach (PlayerInfo i in PlayerDictionary.Values)
            {
                PlayerList.Add(i);
            }
        }
        /// <summary>
        /// Adds a given PlayerInfo object to the PlayerDictionary.
        /// </summary>
        public void AddPlayerInformation(PlayerInfo player)
        {
            if(PlayerDictionary.ContainsKey(player.Id))
            {
                MessageBox.Show(@"Error - Player ID Invalid"); 
            }
            else
            {
                PlayerDictionary.Add(player.Id, player);
                AddPlayerToTeam(player);
            }
        }
        /// <summary>
        /// Initializes a new PlayerInfo object.
        /// Adds the player to the PlayerDictionary if necessary.
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="id">MFL id</param>
        /// <param name="team">NFL team</param>
        /// <param name="position">Position</param>
        public void AddPlayerInformation(string name, int id, string team, char position)
        {
            if (PlayerDictionary.TryGetValue(id, out PlayerInfo player))
            {
                player.Name = name;
                player.Team = team;
                player.Position = position;
            }
            else
            {
                player = new PlayerInfo
                {
                    Name = name,
                    Id = id,
                    Team = team,
                    Position = char.ToLower(position)
                };
                AddPlayerInformation(player);
            }
        }
        /// <summary>
        /// Adds a given player to a team.
        /// </summary>
        /// <param name="player"></param>
        public void AddPlayerToTeam(PlayerInfo player)
        {
            if (Teams.TryGetValue(player.MFLTeamID, out TeamInfo team))
            {
                team.AddPlayer(player);
            }
        }
        /// <summary>
        /// Removes a given player from a team.
        /// </summary>
        /// <param name="player"></param>
        public void RemovePlayerFromTeam(PlayerInfo player)
        {
            if (Teams.TryGetValue(player.MFLTeamID, out TeamInfo team))
            {
                team.RemovePlayer(player);
            }
        }
        /// <summary>
        /// Filters the FilterPlayers list based
        /// upon user supplied criteria.
        /// </summary>
        /// <param name="position"></param>
        public void FilterPlayerList(char position)
        {
            PlayerList.Clear();
            foreach (var player in PlayerDictionary.Values.Where(player => player.Position == position))
            {
                PlayerList.Add(player);
            }
        }
        /// <summary>
        /// Filters the FilterPlayers list based
        /// upon user supplied criteria.
        /// </summary>
        /// <param name="position"></param>
        public void FilterPlayerList(char position, bool roster)
        {
            PlayerList.Clear();
            if (position == 'a')
            {
                foreach (var player in PlayerDictionary.Values.Where(player => player.Roster == roster))
                {
                    PlayerList.Add(player);
                }
            }
            else
            {
                foreach (var player in PlayerDictionary.Values.Where(player => player.Position == position && player.Roster == roster))
                {
                    PlayerList.Add(player);
                }
            }
        }
        /// <summary>
        /// Reads a file with a StreamReader.
        /// </summary>
        /// <param name="filename">File location for the local player list.</param>
        private void ReadFile(string filename)
        {
            //Allows for either tab  or forward slash seperated values.
            char[] delim = { '\t', '/' };
            string[] information;
            string line;
            try
            {
                using (var streamReader = new StreamReader(filename))
                {
                    InitializeTeams();
                    while (!streamReader.EndOfStream)
                    {
                        var player = new PlayerInfo();
                        line = streamReader.ReadLine();
                        information = line.Split(delim);
                        player.Name = information[0];
                        player.Id = Convert.ToInt32(information[1]);
                        player.Team = information[2];
                        player.MFLTeamID = Convert.ToInt32(information[3]);
                        player.ContractYear = information[4];
                        player.Salary = Convert.ToDouble(information[5]);
                        player.Position = information[6][0];
                        //Adjust the MFL NFLTeam Id later!
                        AddPlayerInformation(player);
                    }
                }
            }
            catch
            {
                MessageBox.Show($@"Error reading {filename}");
            }
        }
        /// <summary>
        /// Reads website information with the ApiAssistant.
        /// The information is in JSON format.
        /// </summary>
        /// <param name="playerURL">MFL players</param>
        /// <param name="salaryURL">MFL salary</param>
        /// <param name="leagueURL">MFL league</param>
        private async void ReadWebsiteInformation(string playerURL, string salaryURL, string leagueURL, string rosterURL)
        {
            try
            {
                //Player information necessary for retrieval
                List<Player> apiPlayers = await ApiProcessor.LoadPlayerInformation(playerURL);
                List<ApiModel.ApiPlayerSalaryObject.ApiLeagueUnit.ApiLeagueUnitPlayer> apiSalary = await ApiProcessor.LoadSalaryInformation(salaryURL);
                List<ApiModel.ApiLeagueObject.ApiAllFranchiseObject.ApiFranchiseObject> apiTeams = await ApiProcessor.LoadTeamInformation(leagueURL);
                List<XmlNode> apiRosters = ApiProcessor.LoadRosterInformation(rosterURL);

                foreach (Player mflPlayer in apiPlayers)
                {
                    if (ReadPlayerPosition(mflPlayer.Position, out char position))
                    {
                        AddPlayerInformation(mflPlayer.PlayerName, Convert.ToInt32(mflPlayer.PlayerId), mflPlayer.NFLTeam, position);
                    }
                }
                foreach (ApiModel.ApiPlayerSalaryObject.ApiLeagueUnit.ApiLeagueUnitPlayer mflPlayer in apiSalary)
                {
                    if (PlayerDictionary.TryGetValue(mflPlayer.Id, out PlayerInfo player))
                    {
                        player.Salary = mflPlayer.Salary;
                        player.ContractYear = mflPlayer.ContractYear;
                    }
                }

                foreach (ApiModel.ApiLeagueObject.ApiAllFranchiseObject.ApiFranchiseObject franchise in apiTeams)
                {
                    if (Teams.TryGetValue(franchise.Id, out TeamInfo team))
                    {
                        team.Name = franchise.Name;
                        team.Division = franchise.Division;
                    }
                    else
                    {
                        team = new TeamInfo
                        {
                            Name = franchise.Name,
                            Id = franchise.Id,
                            Division = franchise.Division
                        };
                        Teams.Add(team.Id, team);
                    }
                }
                //Xml because JSON parsing was not successful.
                
                foreach (XmlNode teams in apiRosters)
                {
                    int teamIdConverted = Convert.ToInt32(teams.Attributes[0].InnerText.TrimStart(new char[] { '0' }));
                    if (Teams.TryGetValue(Convert.ToInt32(teams.Attributes[0].InnerText.TrimStart(new char[] { '0' })), out TeamInfo team))
                    {
                        foreach (XmlNode children in teams.ChildNodes)
                        {
                            int playerIdConverted = Convert.ToInt32(children.Attributes[0].InnerText);
                            if (PlayerDictionary.TryGetValue(Convert.ToInt32(children.Attributes[0].InnerText), out PlayerInfo rosterPlayer))
                            {
                                team.AddPlayer(rosterPlayer);
                            }
                        }
                    }
                }
                MessageBox.Show("Loading Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Loading Failed");
            }
        }
        /// <summary>
        /// Reads player information and ensures the player
        /// plays a valid position in the mfl.
        /// </summary>
        /// <param name="position">Position</param>
        /// <returns>Validity of player position.</returns>
        private bool ReadPlayerPosition(string position, out char playerPosition)
        {
            if (position[0] == 'Q')
            {
                playerPosition = 'q';
                return true;
            }
            if (position[0] == 'R')
            {
                playerPosition = 'r';
                return true;
            }
            if (position[0] == 'W')
            {
                playerPosition = 'w';
                return true;
            }
            if (position.Length == 2 && position[0] == 'T' && position[1] == 'E')
            {
                playerPosition = 't';
                return true;
            }
            if (position.Length == 2 && position[0] == 'P' && position[1] == 'K')
            {
                playerPosition = 'k';
                return true;
            }
            if (position.Length == 3 && position[0] == 'D' && position[1] == 'e' && position[2] == 'f')
            {
                playerPosition = 'd';
                return true;
            }
            //TE, K, and Def need more in depth checks!
            playerPosition = 'n';
            return false;
        }
        /// <summary>
        /// Reads the player ranking information from 
        /// fantasy pros csv file.
        /// </summary>
        /// <param name="rankingsFile"></param>
        public void ReadPlayerRankings(string filename)
        {
            //Allows for either tab  or forward slash seperated values.
            char[] delim = { ',', '"' };
            string[] information;
            string line;
            try
            {
                using (StreamReader streamReader = new StreamReader(filename))
                {
                    while (!streamReader.EndOfStream)
                    {
                        line = streamReader.ReadLine();
                        line = line.Replace("\"", "");
                        information = line.Split(delim);
                        //Need to get player information object!
                     
                        //Needs to be optimized!
                        foreach (PlayerInfo player in PlayerDictionary.Values)
                        {
                            string[] fullNamearray = player.Name.Split(delim);

                            if (fullNamearray.Length == 2 && information.Length > 2)
                            {
                                string fullName = fullNamearray[1].Trim(' ') + ' ' + fullNamearray[0];
                                if (fullName.Equals(information[3].Trim('"')))
                                {
                                    int rank = Convert.ToInt32(information[0].Trim('"'));
                                    player.FantasyProsRanking = rank;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("Error reading " + filename);
            }
        }
        /// <summary>
        /// Initializes the teams for a local list.
        /// </summary>
        private void InitializeTeams()
        {
            //Add ability to choose own teams!
            for (int i = 1; i <= 10; i++)
            {
                TeamInfo team = new TeamInfo
                {
                    Id = i,
                    Name = InitializeTeamNames(i)
                };
                Teams.Add(team.Id, team);
            }
        }
        /// <summary>
        /// Initializes the team names for a local list.
        /// </summary>
        /// <param name="i">NFLTeam ID</param>
        /// <returns>NFLTeam Name</returns>
        private string InitializeTeamNames(int i)
        {
            if (i == 1) return "Tornados";
            if (i == 2) return "Penguins";
            if (i == 3) return "Bombers";
            if (i == 4) return "Dactyls";
            if (i == 5) return "ODB's";
            if (i == 6) return "Storm Dynasty";
            if (i == 7) return "Nike Storm";
            if (i == 8) return "Gorillas";
            if (i == 9) return "Power";
            if (i == 10) return "Ram";
            return "Error";
        }
        /// <summary>
        /// Saves the player dictionary in .txt format.
        /// </summary>
        /// <param name="filename">File to save</param>
        public void SaveFile(string filename)
        {
            using (StreamWriter streamWriter = new StreamWriter(filename))
            {
                foreach (PlayerInfo i in PlayerDictionary.Values)
                {
                    streamWriter.WriteLine(i.Save());
                }
                streamWriter.Close();
            }
        }
    }
}
