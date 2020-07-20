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

        /*

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
        */
    }
}
