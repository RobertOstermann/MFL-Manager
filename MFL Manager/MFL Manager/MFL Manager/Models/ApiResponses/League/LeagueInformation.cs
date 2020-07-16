using System.Collections.Generic;
using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.League
{
    public class LeagueInformation
    {
        [JsonProperty("franchises")]
        public FranchiseInformation FranchiseInformation { get; set; }

        [JsonProperty("rosterSize")]
        public string RosterSize { get; set; }

        [JsonProperty("salaryCapAmount")]
        public string SalaryCap { get; set; }

        [JsonProperty("divisions")]
        public List<Division> Divisions { get; set; }
    }
}
