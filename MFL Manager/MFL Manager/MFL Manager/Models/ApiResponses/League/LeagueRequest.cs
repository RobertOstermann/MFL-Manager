using Newtonsoft.Json;

namespace MFL_Manager.Models.ApiResponses.League
{
    public class LeagueRequest
    {
        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("league")]
        public LeagueInformation LeagueInformation { get; set; }
    }
}
