/* ApiProcessor.cs
 * Author: Robert Ostermann
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Xml;
using MFL_Manager.Models.ApiResponses.Players;
using Newtonsoft.Json;

namespace MFL_Manager
{

    public class ApiProcessor
    {
        /// <summary>
        /// Loads the player information from the MFL website.
        /// This static async class awaits a response from the 
        /// apiAsyncClient and reads in the response as an ApiPlayerModel type.
        /// </summary>
        /// <param name="url">Website Address</param>
        /// <returns>Player information list</returns>
        public static async Task<List<Player>> LoadPlayerInformation(string url)
        {
            using (HttpResponseMessage response = await ApiAssistant.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    PlayerInformation playerInformation = JsonConvert.DeserializeObject<PlayerInformation>(response.ToString());
                    return playerInformation.Players;
                }
                throw new Exception(response.ReasonPhrase);
            }
        }
        /// <summary>
        /// Loads the salary information from the MFL website.
        /// </summary>
        /// <param name="url">Website Address</param>
        /// <returns>Salary information list</returns>
        public static async Task<List<ApiModel.ApiPlayerSalaryObject.ApiLeagueUnit.ApiLeagueUnitPlayer>> LoadSalaryInformation(string url)
        {
            using (HttpResponseMessage response = await ApiAssistant.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApiModel salaryModel = await response.Content.ReadAsAsync<ApiModel>();
                    return salaryModel.Salaries.LeagueUnit.Player;
                }
                throw new Exception(response.ReasonPhrase);
            }
        }
        /// <summary>
        /// Loads the team information from the MFL website.
        /// </summary>
        /// <param name="url">Website Address</param>
        /// <returns>NFLTeam information list</returns>
        public static async Task<List<ApiModel.ApiLeagueObject.ApiAllFranchiseObject.ApiFranchiseObject>> LoadTeamInformation(string url)
        {
            using (HttpResponseMessage response = await ApiAssistant.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    ApiModel teamModel = await response.Content.ReadAsAsync<ApiModel>();
                    return teamModel.League.Franchises.Franchise;
                }

                throw new Exception(response.ReasonPhrase);
            }
        }

        public static List<XmlNode> LoadRosterInformation(string url)
        {
            List<XmlNode> franchiseList = new List<XmlNode>();
            XmlDocument document = new XmlDocument();
            document.Load(url);
            foreach (XmlNode node in document.DocumentElement)
            {
                franchiseList.Add(node);
            }
            return franchiseList;
        }
    }
}